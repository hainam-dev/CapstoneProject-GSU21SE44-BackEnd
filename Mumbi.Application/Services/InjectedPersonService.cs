using Mumbi.Application.Dtos.InjectedPerson;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class InjectedPersonService : IInjectedPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InjectedPersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<string>>> AddInjectedPerson(List<CreateInjectedPersonRequest> request)
        {
            var injectPersonRequest = new List<CreateInjectedPersonRequest>();
            foreach (var item in request)
            {
                var childs = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.MomId == item.MomId);
                if (childs.Any(x => x.Birthday == item.Birthday))
                {
                    injectPersonRequest.Add(item);
                }
            }

            var injectedPerson = injectPersonRequest.Select(x => new InjectedPerson
            {
                Id = x.Id,
                FullName = x.FullName,
                Birthday = x.Birthday,
                Gender = x.Gender,
                EthnicGroup = x.EthnicGroup,
                IdentityCardNumber = x.IdentityCardNumber,
                Phonenumber = x.Phonenumber,
                HomeAddress = x.HomeAddress,
                TemporaryAddress = x.TemporaryAddress
            }).ToList();

            await _unitOfWork.InjectedPersonRepository.AddRangeAsync(injectedPerson);
            await _unitOfWork.SaveAsync();

            var response = injectedPerson.Select(x => x.Id.ToString()).ToList();

            return new Response<List<string>>(response, "Thêm thông tin người tiêm thành công");
        }
    }
}
