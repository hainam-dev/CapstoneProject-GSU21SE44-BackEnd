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

        public InjectionScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<string>>> AddInjectionSchedule(List<CreateInjectionScheduleRequest> request)
        {
            var injectionScheduleRequest = new List<CreateInjectionScheduleRequest>();
            foreach (var item in request)
            {
                var injectData = await _unitOfWork.InjectionScheduleRepository.FirstAsync(x => x.Id == item.Id);
                if (injectData is null)
                {
                    injectionScheduleRequest.Add(item);
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
    }
}