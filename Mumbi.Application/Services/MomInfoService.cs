using AutoMapper;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<PagedResponse<List<MomInfoResponse>>> GetListMomInfo(MomInfoRequest request)
        {
            var response = new List<MomInfoResponse>();
            Expression<Func<Domain.Entities.User, bool>> query = x => x.DelFlag == false
                                                                   && x.RoleId == Constants.RoleConstant.USER_ROLE
                                                                   && (request.FullName == null || x.UserInfo.FullName.Contains(request.FullName))
                                                                   && (request.Email == null || x.UserInfo.IdNavigation.Email.Contains(request.Email));
            var user = await _unitOfWork.UserRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize,
                                                                             filter: query,
                                                                             includeProperties: "UserInfo,MomInfo");
            response = _mapper.Map<List<MomInfoResponse>>(user);
            var totalCount = await _unitOfWork.UserRepository.CountAsync(query);

            return new PagedResponse<List<MomInfoResponse>>(response, request.PageNumber, request.PageSize, totalCount);
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