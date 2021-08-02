using AutoMapper;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class MomInfoService : IMomInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MomInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<List<MomInfoResponse>>> GetAllMomInfo()
        {
            var response = new List<MomInfoResponse>();
            var user = await _unitOfWork.UserRepository.GetAsync(x => x.DelFlag == false && x.RoleId == "role01", includeProperties: "UserInfo,MomInfo");
            response = _mapper.Map<List<MomInfoResponse>>(user);

            return new Response<List<MomInfoResponse>>(response);
        }

        public async Task<Response<MomInfoResponse>> GetMomInfoById(string Id)
        {
            var response = new MomInfoResponse();
            var user = await _unitOfWork.UserRepository.FirstAsync(x => x.DelFlag == false && x.Id == Id, includeProperties: "UserInfo,MomInfo");
            if (user is null)
            {
                return new Response<MomInfoResponse>(null, $"Không tìm thấy tài khoản \'{Id}\'.");
            }

            response = _mapper.Map<MomInfoResponse>(user);

            return new Response<MomInfoResponse>(response);
        }

        public async Task<Response<string>> UpdateMomInfoRequest(UpdateMomInfoRequest request)
        {
            var user = await _unitOfWork.UserRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false, includeProperties: "MomInfo,UserInfo");
            if (user == null)
            {
                return new Response<string>(null, $"Không tìm thấy thông tin tài khoản \'{request.Id}\'.");
            }

            user.UserInfo.FullName = request.FullName;
            user.UserInfo.ImageUrl = request.ImageUrl;
            user.UserInfo.Birthday = request.BirthDay;
            user.UserInfo.Phonenumber = request.Phonenumber;
            user.MomInfo.BloodGroup = request.BloodGroup;
            user.MomInfo.RhBloodGroup = request.RhBloodGroup;

            _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return new Response<string>(user.Id, $"Cập nhật thông tin thành công, {user.Id}");
        }

        public async Task<Response<string>> DeleteMomInfo(string Id)
        {
            var user = await _unitOfWork.UserRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (user == null)
            {
                return new Response<string>(null, $"Không tìm thấy thông tin tài khoản \'{user}\'.");
            }

            user.DelFlag = true;
            _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            return new Response<string>(user.Id, $"Xóa mom thành công, {user.Id}");

        }
    }
}
