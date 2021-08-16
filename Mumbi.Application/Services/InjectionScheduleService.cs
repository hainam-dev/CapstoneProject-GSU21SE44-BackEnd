using AutoMapper;
using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class InjectionScheduleService : IInjectionScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InjectionScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<string>>> AddInjectionSchedule(List<CreateInjectionScheduleRequest> request)
        {
            var injectionScheduleRequest = new List<CreateInjectionScheduleRequest>();

            foreach (var item in request)
            {
                var tmp = await _unitOfWork.InjectedPersonRepository.FirstAsync(x => x.Id == item.InjectedPersonId);
                if (tmp != null)
                {
                    var childs = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.MomId == item.MomId);
                    var childId = childs.FirstOrDefault(x => x.Birthday == tmp.Birthday).Id;

                    var injectData = await _unitOfWork.InjectionScheduleRepository.FirstAsync(x => x.Id == item.Id);
                    if (injectData is null)
                    {
                        item.ChildId = childId;
                        injectionScheduleRequest.Add(item);
                    }
                }
            }

            var injectionSchedules = injectionScheduleRequest.Select(x => new InjectionSchedule
            {
                Id = x.Id,
                MomId = x.MomId,
                InjectedPersonId = x.InjectedPersonId,
                VaccineName = x.VaccineName,
                Antigen = x.Antigen,
                InjectionDate = x.InjectionDate,
                OrderOfInjection = x.OrderOfInjection,
                VaccinationFacility = x.VaccinationFacility,
                VaccineBatch = x.VaccineBatch,
                Status = x.Status
            }).ToList();

            await _unitOfWork.InjectionScheduleRepository.AddRangeAsync(injectionSchedules);
            await _unitOfWork.SaveAsync();

            var response = injectionSchedules.Select(x => x.Id.ToString()).ToList();

            return new Response<List<string>>(response, "Thêm lịch tiêm thành công");
        }

        public async Task<Response<List<InjectionScheduleResponse>>> GetInjectionScheduleByChildId(string childId)
        {
            var response = new List<InjectionScheduleResponse>();
            var child = await _unitOfWork.ChildInfoRepository.GetByIdAsync(childId);
            if (child is null)
            {
                return new Response<List<InjectionScheduleResponse>>(null, $"Không tìm thấy child, id: {childId}");
            }

            var result = await _unitOfWork.InjectionScheduleRepository.GetAsync(x => x.ChildId == childId);
            if (result.Count == 0)
            {
                return new Response<List<InjectionScheduleResponse>>(null, "Chưa có dữ liệu");
            }

            response = _mapper.Map<List<InjectionScheduleResponse>>(result);

            return new Response<List<InjectionScheduleResponse>>(response);
        }
    }
}