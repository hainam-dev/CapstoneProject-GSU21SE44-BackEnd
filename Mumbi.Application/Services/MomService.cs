using AutoMapper;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class MomService : IMomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

       

        public async Task<Response<List<MomResponse>>> GetAllMom()
        {
            var response = new List<MomResponse>();
            var account = await _unitOfWork.AccountRepository.GetAsync(x => x.IsDeleted == false, includeProperties: "Mom");
            if (account != null)
            {
                response = _mapper.Map<List<MomResponse>>(account);
            }
            return new Response<List<MomResponse>>(response);
        }

        public async Task<Response<MomResponse>> GetMomById(String accountId)
        {
            var response = new MomResponse();
            var account = await _unitOfWork.AccountRepository.FirstAsync(x => x.AccountId == accountId && x.IsDeleted == false);
            if(account == null)
            {
                return new Response<MomResponse>($"Không tìm thấy tài khoản \'{accountId}\'.");
            }
            var mom = await _unitOfWork.MomRepository.FirstAsync(x => x.AccountId == accountId);
            if (mom != null)
            {
                response = _mapper.Map<MomResponse>(mom);
            }
            return new Response<MomResponse>(response);
        }

        public async Task<Response<string>> UpdateMomRequest(UpdateMomRequest request)
        {
            var mom = await _unitOfWork.MomRepository.FirstAsync(x => x.AccountId == request.AccountId);

            if (mom == null)
            {
                return new Response<string>($"Không tìm thấy thông tin tài khoản \'{request.AccountId}\'.");
            }
            mom.FullName = request.FullName;
            mom.Image = request.Image;
            mom.Birthday = request.BirthDay;
            mom.Phonenumber = request.Phonenumber;
            mom.BloodGroup = request.BloodGroup;
            mom.RhBloodGroup = request.RhBloodGroup;
            mom.Weight = request.Weight;
            mom.Height = request.Height;

            _unitOfWork.MomRepository.UpdateAsync(mom);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin thành công", mom.AccountId);
        }

        public async Task<Response<string>> DeleteMom(string accountId)
        {
            var account = await _unitOfWork.AccountRepository.FirstAsync(x => x.AccountId == accountId && x.IsDeleted == false);
            if (account == null)
            {
                return new Response<string>($"Không tìm thấy thông tin tài khoản \'{accountId}\'.");
            }
            account.IsDeleted = true;
            _unitOfWork.AccountRepository.UpdateAsync(account);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Delete mom succesfully", account.AccountId);
        }
    }
}
