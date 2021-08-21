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
            var response = new List<string>();

            foreach (var item in request)
            {
                var childs = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.MomId == item.MomId);
                if (childs.Any(x => x.Birthday == item.Birthday))
                {
                    injectPersonRequest.Add(item);
                }
            }

            foreach (var item in injectPersonRequest)
            {
                var injectionData = await _unitOfWork.InjectedPersonRepository.FirstAsync(x => x.Id == item.Id);
                if (injectionData is null)
                {
                    var injectionPerson = new InjectedPerson
                    {
                        Id = item.Id,
                        FullName = item.FullName,
                        Birthday = item.Birthday,
                        Gender = item.Gender,
                        EthnicGroup = item.EthnicGroup,
                        IdentityCardNumber = item.IdentityCardNumber,
                        Phonenumber = item.Phonenumber,
                        HomeAddress = item.HomeAddress,
                        TemporaryAddress = item.TemporaryAddress
                    };

                    await _unitOfWork.InjectedPersonRepository.AddAsync(injectionPerson);
                    response.Add(injectionPerson.Id.ToString());
                }
            }

            await _unitOfWork.SaveAsync();

            return new Response<List<string>>(response, "Thêm thông tin người tiêm thành công");
        }
    }
}