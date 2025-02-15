﻿using AutoMapper;
using Mumbi.Application.Dtos.ActionChild;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class ActionChildService : IActionChildService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActionChildService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> UpsertActionChild(UpsertActionChildRequest request)
        {
            var getActionChild = await _unitOfWork.ActionChildRepository.FirstAsync(x => x.ChildId == request.ChildId && x.ActionId == request.ActionId);
            if (getActionChild == null)
            {
                var actionChild = new ActionChild
                {
                    ChildId = request.ChildId,
                    ActionId = request.ActionId,
                    CheckedFlag = true,
                };

                await _unitOfWork.ActionChildRepository.AddAsync(actionChild);
                await _unitOfWork.SaveAsync();

                return new Response<string>(actionChild.ChildId, $"Thêm action child thành công, id: {actionChild.Id}");
            }

            getActionChild.CheckedFlag = request.CheckedFlag;
            _unitOfWork.ActionChildRepository.UpdateAsync(getActionChild);
            await _unitOfWork.SaveAsync();

            return new Response<string>(getActionChild.Id.ToString(), $"Update action child thành công, id: {getActionChild.Id}");
        }

        public async Task<Response<List<ActionChildResponse>>> GetActionChildByChildId(string childId)
        {
            var response = new List<ActionChildResponse>();
            var actionChild = await _unitOfWork.ActionChildRepository.GetAsync(x => x.ChildId == childId);
            if (actionChild == null)
            {
                return new Response<List<ActionChildResponse>>(null, $"Không có dữ liệu");
            }

            response = _mapper.Map<List<ActionChildResponse>>(actionChild);

            return new Response<List<ActionChildResponse>>(response);
        }
    }
}