﻿using AutoMapper;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Enums;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class ChildInfoService : IChildInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChildInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddChildInfo(CreateChildInfoRequest request)
        {
            if (request.ChildrenStatus == (int)ChildrenStatusEnum.Children)
            {
                var child = new ChildInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    MomId = request.MomID,
                    FullName = request.FullName,
                    Nickname = request.Nickname,
                    ImageUrl = request.ImageURL,
                    Gender = request.Gender,
                    Birthday = request.Birthday,
                    BloodGroup = request.BloodGroup,
                    RhBloodGroup = request.RhBloodGroup,
                    HeadVortex = request.HeadVortex,
                    Fingertips = request.Fingertips,
                    BornFlag = true,
                };

                await _unitOfWork.ChildInfoRepository.AddAsync(child);
                await _unitOfWork.SaveAsync();

                return new Response<string>(child.Id, $"Thêm em bé thành công, id: {child.Id}");
            }
            else
            {
                var pregnancy = new ChildInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    MomId = request.MomID,
                    FullName = request.FullName,
                    Nickname = request.Nickname,
                    ImageUrl = request.ImageURL,
                    EstimatedBornDate = request.EstimatedBornDate,
                    Gender = request.Gender,
                    Birthday = request.Birthday,
                    BornFlag = false,
                };

                await _unitOfWork.ChildInfoRepository.AddAsync(pregnancy);
                await _unitOfWork.SaveAsync();

                return new Response<string>(pregnancy.Id, $"Thêm thai kì thành công, id: {pregnancy.Id}");
            }
        }

        public async Task<Response<string>> UpdateChildInfo(UpdateChildInfoRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.Id);
            if (child != null)
            {
                if (child.BornFlag)
                {
                    child.FullName = request.FullName;
                    child.Nickname = request.Nickname;
                    child.ImageUrl = request.ImageURL;
                    child.Gender = request.Gender;
                    if (request.ChildrenStatus == (int)ChildrenStatusEnum.Pregnancy)
                    {
                        child.BornFlag = false;
                        child.Birthday = null;
                        child.EstimatedBornDate = request.EstimatedBornDate;
                    }
                    else
                    {
                        child.Birthday = request.Birthday;
                        child.BloodGroup = request.BloodGroup;
                        child.RhBloodGroup = request.RhBloodGroup;
                        child.HeadVortex = request.HeadVortex;
                        child.Fingertips = request.Fingertips;
                    }
                }
                else
                {
                    child.FullName = request.FullName;
                    child.Nickname = request.Nickname;
                    child.ImageUrl = request.ImageURL;
                    child.Gender = request.Gender;
                    if (request.ChildrenStatus == (int)ChildrenStatusEnum.Children)
                    {
                        child.BornFlag = true;
                        child.EstimatedBornDate = null;
                        child.Birthday = request.Birthday;
                        child.BloodGroup = request.BloodGroup;
                        child.RhBloodGroup = request.RhBloodGroup;
                        child.HeadVortex = request.HeadVortex;
                        child.Fingertips = request.Fingertips;
                    }
                    else
                    {
                        child.EstimatedBornDate = request.EstimatedBornDate;
                    }
                }

                _unitOfWork.ChildInfoRepository.UpdateAsync(child);
                await _unitOfWork.SaveAsync();

                return new Response<string>(child.Id, $"Cập nhật thông tin em bé thành công, id: {child.Id}");
            }

            return new Response<string>(null, $"Không tìm thấy em bé \'{request.Id}\'");
        }

        public async Task<Response<string>> DeleteChildInfo(string id)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == id);
            if (child != null)
            {
                child.DelFlag = true;
                _unitOfWork.ChildInfoRepository.UpdateAsync(child);
                await _unitOfWork.SaveAsync();

                return new Response<string>(child.Id, $"Xóa em bé thành công, id: {child.Id}");
            }

            return new Response<string>(null, $"Không tìm thấy em bé \'{id}\'");
        }

        public async Task<Response<ChildInfoResponse>> GetChildInfoById(string Id)
        {
            var response = new ChildInfoResponse();

            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == Id);
            if (child == null)
            {
                return new Response<ChildInfoResponse>(null, $"Không tìm thấy em bé \'{Id}\'");
            }

            response = _mapper.Map<ChildInfoResponse>(child);

            return new Response<ChildInfoResponse>(response);
        }

        public async Task<Response<List<ChildInfoResponse>>> GetAllChildInfo()
        {
            var response = new List<ChildInfoResponse>();
            var child = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.DelFlag == false);
            if (child.Count > 0)
            {
                response = _mapper.Map<List<ChildInfoResponse>>(child);
            }

            return new Response<List<ChildInfoResponse>>(response);
        }

        public async Task<Response<List<ChildInfoResponse>>> GetChildInfoByMomId(string momId)
        {
            var response = new List<ChildInfoResponse>();
            var mom_info = await _unitOfWork.MomInfoRepository.FirstAsync(x => x.Id == momId && x.IdNavigation.DelFlag == false);
            if (mom_info == null)
            {
                return new Response<List<ChildInfoResponse>>(null, $"Không tìm thấy mẹ \'{momId}\'");
            }

            var child = await _unitOfWork.ChildInfoRepository.GetAsync(x => x.MomId == momId && x.DelFlag == false);
            if (child.Count == 0)
            {
                return new Response<List<ChildInfoResponse>>(null, $"Id \'{momId}\' chưa có con");
            }

            response = _mapper.Map<List<ChildInfoResponse>>(child);

            return new Response<List<ChildInfoResponse>>(response, $"Có {child.Count} người con");
        }
    }
}