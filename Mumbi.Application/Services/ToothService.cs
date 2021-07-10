using AutoMapper;
using Mumbi.Application.Dtos.Tooths;
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
    public class ToothService : IToothService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToothService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ToothResponse>> GetToothByChildId(string childId, string toothId)
        {
            var response = new ToothResponse();
            var child = await _unitOfWork.ToothRepository.GetAsync(x => x.ChildId == childId && x.GrownFlag == true);
            if (child.Count == 0)
            {
                return new Response<ToothResponse>($"Không có dữ liệu mọc răng của bé \'{childId}\'.");
            }
            foreach(var tooth in child)
            {
                if(toothId == tooth.ToothId)
                {
                    response = _mapper.Map<ToothResponse>(tooth);
                    return new Response<ToothResponse>(response);
                }
            }
            return new Response<ToothResponse>($"Không có dữ liệu mọc răng của răng \'{toothId}\'.");
        }

        public async Task<Response<string>> UpsertToothRequest(UpsertToothRequest request)
        {
            var tooth = await _unitOfWork.ToothRepository.FirstAsync(x => x.ChildId == request.ChildId && x.ToothId == request.ToothId);
            if (tooth == null)
            {
                var toothChild = new Tooth
                {
                    ToothId =  request.ToothId,
                    ChildId = request.ChildId,
                    GrownDate = request.GrownDate,
                    Note = request.Note,
                    ImageUrl = request.ImageURL,
                    GrownFlag = request.GrownFlag,
                };
                await _unitOfWork.ToothRepository.AddAsync(toothChild);
                await _unitOfWork.SaveAsync();
                return new Response<string>("Thêm răng thành công, id: " + toothChild.Id);
            }
            tooth.ToothId = request.ToothId;
            tooth.ChildId = request.ChildId;
            tooth.GrownDate = request.GrownDate;
            tooth.Note = request.Note;
            tooth.ImageUrl = request.ImageURL;
            tooth.GrownFlag = request.GrownFlag; ;
            _unitOfWork.ToothRepository.UpdateAsync(tooth);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Cập nhật răng thành công");
        }
    }
}
