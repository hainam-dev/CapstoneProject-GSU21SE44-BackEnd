using AutoMapper;
using Mumbi.Application.Dtos.GuidebookMom;
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
            return new Response<string>("Thêm guidebook type thành công, id: " + guidebookMom.Id);
        }

        public async Task<Response<List<GuidebookMomResponse>>> GetGuidebookMomByMomId(string momId)
        {
            var response = new List<GuidebookMomResponse>();
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.MomId == momId);
            if (guidebookMom == null)
            {
                return new Response<List<GuidebookMomResponse>>($"MomId \'{momId}\' chưa có dữ liệu");
            }
            response = _mapper.Map<List<GuidebookMomResponse>>(guidebookMom);
            return new Response<List<GuidebookMomResponse>>(response);
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
            return new Response<string>($"Xóa guidebook type id \'{Id}\' thành công!");
        }
    }
}
