using AutoMapper;
using Mumbi.Application.Dtos.ActionChild;
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
            var getActionChild = await _unitOfWork.ActionChildRepository.FirstAsync(x=> x.ChildId == request.ChildId && x.ActionId == request.ActionId);
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
                return new Response<string>("Thêm action child thành công, id: " + actionChild.Id);
            }
                getActionChild.CheckedFlag = request.CheckedFlag;
                _unitOfWork.ActionChildRepository.UpdateAsync(getActionChild);
                await _unitOfWork.SaveAsync();
                return new Response<string>("Update action child thành công, id: " + getActionChild.Id);
        }

        public async Task<Response<ActionChildResponse>> GetActionChildByActionIdAndChildId(int actionId, string childId)
        {
            var response = new ActionChildResponse();
            var actionChild = await _unitOfWork.ActionChildRepository.FirstAsync(x => x.ChildId == childId && x.ActionId == actionId);
            if (actionChild == null)
            {
                return new Response<ActionChildResponse>($"Không có dữ liệu");
            }
            response = _mapper.Map<ActionChildResponse>(actionChild);
            return new Response<ActionChildResponse>(response);
        }

        
    }
}
