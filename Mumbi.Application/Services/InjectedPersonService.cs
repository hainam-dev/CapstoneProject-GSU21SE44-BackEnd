using AutoMapper;
using Mumbi.Application.Dtos.InjectedPerson;
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
    public class InjectedPersonService : IInjectedPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InjectedPersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddInjectedPerson(CreateInjectedPersonRequest request)
        {
            var injectedPerson = new InjectedPerson
            {
                Id = request.Id,
                FullName = request.FullName,
                Birthday = request.Birthday,
                Gender = request.Gender,
                EthnicGroup = request.EthnicGroup,
                Phonenumber = request.Phonenumber,
                HomeAddress = request.HomeAddress,
                TemporaryAddress = request.TemporaryAddress
            };
            await _unitOfWork.InjectedPersonRepository.AddAsync(injectedPerson);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm thông tin người tiêm thành công, id: " + injectedPerson.Id);
        }
    }
}
