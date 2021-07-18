using AutoMapper;
using Mumbi.Application.Dtos.InjectionSchedule;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Response<string>> AddInjectionSchedule(CreateInjectionScheduleRequest request)
        {
            var injectionSchedule = new InjectionSchedule
            {
                Id = request.Id,
                MomId = request.MomId,
                InjectedPersonId = request.InjectedPersonId,
                VaccineName = request.VaccineName,
                Antigen = request.Antigen,
                InjectionDate = request.InjectionDate,
                OrderOfInjection = request.OrderOfInjection,
                VaccinationFacility = request.VaccinationFacility,
                VaccineBatch = request.VaccineBatch,
                Status = request.Status
            };
            await _unitOfWork.InjectionScheduleRepository.AddAsync(injectionSchedule);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm lịch tiêm thành công, id: " + injectionSchedule.Id);
        }
    }
}
