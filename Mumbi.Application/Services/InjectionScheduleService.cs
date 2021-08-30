using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;

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
            var response = new List<string>();

            foreach (var item in request)
            {
                var tmp = await _unitOfWork.InjectedPersonRepository.FirstAsync(x => x.Id == item.InjectedPersonId);
                if (tmp != null)
                {
                    var childs = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.MomId == item.MomId);
                    var childId = childs.FirstOrDefault(x => x.Birthday == tmp.Birthday).Id;
                    var injectData = await _unitOfWork.InjectionScheduleRepository.FirstAsync(x => x.InjectionScheduleId == item.InjectionScheduleId && x.ChildId == childId);
                    if (injectData is null)
                    {
                        item.ChildId = childId;
                        injectionScheduleRequest.Add(item);
                    }
                }
            }

            foreach (var item in injectionScheduleRequest)
            {
                var injectionData = await _unitOfWork.InjectionScheduleRepository.FirstAsync(x => x.InjectionScheduleId == item.InjectionScheduleId && x.ChildId == item.ChildId);
                if (injectionData is null)
                {
                    var injectionSchedule = new InjectionSchedule
                    {
                        InjectionScheduleId = item.InjectionScheduleId,
                        MomId = item.MomId,
                        ChildId = item.ChildId,
                        InjectedPersonId = item.InjectedPersonId,
                        VaccineName = item.VaccineName,
                        Antigen = item.Antigen,
                        InjectionDate = item.InjectionDate,
                        OrderOfInjection = item.OrderOfInjection,
                        VaccinationFacility = item.VaccinationFacility,
                        VaccineBatch = item.VaccineBatch,
                        Status = item.Status
                    };

                    await _unitOfWork.InjectionScheduleRepository.AddAsync(injectionSchedule);
                    response.Add(injectionSchedule.InjectionScheduleId.ToString());
                }
            }

            await _unitOfWork.SaveAsync();

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