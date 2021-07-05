using AutoMapper;
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class UserInfoService : IUserInfoService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<StaffInfoResponse>> GetStaffInfoById(String Id)
        {
            var response = new StaffInfoResponse();
            var user = await _unitOfWork.UserRepository.FirstAsync(x => x.DelFlag == false && x.Id == Id, includeProperties: "UserInfo");
            if (user == null)
            {
                return new Response<StaffInfoResponse>($"Không tìm thấy tài khoản \'{Id}\'.");
            }
            response = _mapper.Map<StaffInfoResponse>(user);
            return new Response<StaffInfoResponse>(response);
        }

        public async Task<Response<string>> UpdateStaffInfoRequest(UpdateStaffInfoRequest request)
        {
            var user = await _unitOfWork.UserRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false, includeProperties: "UserInfo");
            if (user == null)
            {
                return new Response<string>($"Không tìm thấy thông tin tài khoản \'{request.Id}\'.");
            }

            user.UserInfo.FullName = request.FullName;
            user.UserInfo.ImageUrl = request.ImageURL;
            user.UserInfo.Birthday = request.BirthDay;
            user.UserInfo.Phonenumber = request.Phonenumber;
            _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Cập nhật thông tin thành công", user.Id);
        }
    }
}
