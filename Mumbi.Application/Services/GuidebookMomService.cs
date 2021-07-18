using AutoMapper;
using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Dtos.Guidebooks;
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
    public class GuidebookMomService : IGuidebookMomService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GuidebookMomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddGuidebookMom(CreateGuidebookMomRequest request)
        {
            var guidebookMom = new GuidebookMom
            {
                MomId = request.MomId,
                GuidebookId = request.GuidebookId,
            };
            await _unitOfWork.GuidebookMomRepository.AddAsync(guidebookMom);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm guidebook mom thành công, id: " + guidebookMom.Id);
        }

        public async Task<Response<List<GuidebookResponse>>> GetGuidebookMomByMomId(string momId)
        {
            var response = new List<GuidebookResponse>();
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.MomId == momId);
            if (guidebookMom.Count == 0)
            {
                return new Response<List<GuidebookResponse>>($"MomId \'{momId}\' chưa có dữ liệu");
            }
            foreach(var guidebook in guidebookMom)
            {
                var guidebooks = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == guidebook.GuidebookId);
                response = _mapper.Map<List<GuidebookResponse>>(guidebooks);
            }
            return new Response<List<GuidebookResponse>>(response);
        }

        public async Task<Response<string>> DeleteGuidebookMom(int Id)
        {
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.FirstAsync(x => x.Id == Id);
            if (guidebookMom == null)
            {
                return new Response<string>($"Không tìm thấy guidebook mom có Id \'{Id}\'.");
            }
            _unitOfWork.GuidebookMomRepository.DeleteAsync(guidebookMom);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa guidebook type Id \'{Id}\' thành công!");
        }
    }
}
