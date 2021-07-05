using AutoMapper;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class DadInfoService : IDadInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DadInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> AddDadInfo(CreateDadInfoRequest request)
        {
            var dadInfo = new DadInfo
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.FullName,
                ImageUrl = request.ImageURL,
                Birthday = request.Birthday,
                Phonenumber = request.Phonenumber,
                BloodGroup = request.BloodGroup,
                RhBloodGroup = request.RhBloodGroup,
                MomId = request.MomId,
            };
            var momInfo = await _unitOfWork.MomInfoRepository.FirstAsync(x => x.Id == request.MomId && x.IdNavigation.DelFlag == false);
            if(momInfo == null)
            {
                return new Response<string>("Không tìm thấy MomId: " + request.MomId);
            }
            if(momInfo.DadId != null)
            {
                return new Response<string>("MomId: " + request.MomId +" đã thêm cha");
            }
            momInfo.DadId = dadInfo.Id;
            await _unitOfWork.DadInfoRepository.AddAsync(dadInfo);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm thông tin ba thành công: " + dadInfo.Id);
        }
        public async Task<Response<DadInfoResponse>> GetDadInfoByMomId(String momId)
        {
            var response = new DadInfoResponse();
            var momInfo = await _unitOfWork.MomInfoRepository.FirstAsync(x => x.Id == momId && x.IdNavigation.DelFlag == false);
            if (momInfo != null)
            {
                var dadInfo = await _unitOfWork.DadInfoRepository.FirstAsync(x => x.MomId == momId);
                if (dadInfo == null)
                {
                    return new Response<DadInfoResponse>($"Tài khoản mẹ \'{momId}\' chưa thêm thông tin ba!");
                }
                response = _mapper.Map<DadInfoResponse>(dadInfo);
                return new Response<DadInfoResponse>(response);
            }
            return new Response<DadInfoResponse>("Không tìm thấy MomId: " + momId);


        }
        public async Task<Response<string>> UpdateDadInfoRequest(UpdateDadInfoRequest request)
        {
            var dadInfo = await _unitOfWork.DadInfoRepository.FirstAsync(x => x.Id == request.Id);

            if (dadInfo == null)
            {
                return new Response<string>($"Không tìm thấy thông tin ba \'{request.Id}\'.");

            }
            dadInfo.FullName = request.FullName;
            dadInfo.ImageUrl = request.ImageURL;
            dadInfo.Birthday = request.Birthday;
            dadInfo.Phonenumber = request.Phonenumber;
            dadInfo.BloodGroup = request.BloodGroup;
            dadInfo.RhBloodGroup = request.RhBloodGroup;

            _unitOfWork.DadInfoRepository.UpdateAsync(dadInfo);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin ba thành công", dadInfo.Id);
        }

        public async Task<Response<string>> DeleteDadInfo(string Id)
        {
            var dadInfo = await _unitOfWork.DadInfoRepository.FirstAsync(x => x.Id == Id, includeProperties:"Mom");
            if (dadInfo == null)
            {
                return new Response<string>($"Không tìm thấy thông tin ba \'{Id}\'.");
            }
            dadInfo.Mom.DadId = null;
            _unitOfWork.DadInfoRepository.DeleteAsync(dadInfo);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Xóa thông tin ba thành công", dadInfo.Id);
        }
    }
}
