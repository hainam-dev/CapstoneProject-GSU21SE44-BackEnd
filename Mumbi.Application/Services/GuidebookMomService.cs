using AutoMapper;
using Mumbi.Application.Dtos.GuidebookMom;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class GuidebookMomService : IGuidebookMomService
    {
        private readonly IUnitOfWork _unitOfWork;
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

            return new Response<string>(guidebookMom.Id.ToString(), $"Thêm guidebook mom thành công, id: {guidebookMom.Id}");
        }

        public async Task<Response<List<GuidebookMomResponse>>> GetGuidebookMomByMomId(string momId)
        {
            var response = new List<GuidebookMomResponse>();
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.MomId == momId);
            if (guidebookMom.Count == 0)
            {
                return new Response<List<GuidebookMomResponse>>(null, $"MomId \'{momId}\' chưa có dữ liệu");
            }

            foreach (var guidebook in guidebookMom)
            {
                var guidebookData = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == guidebook.GuidebookId);
                response.Add(new GuidebookMomResponse
                {
                    Id = guidebook.Id,
                    Guidebook = _mapper.Map<GuidebookResponse>(guidebookData)
                });
            }

            return new Response<List<GuidebookMomResponse>>(response);
        }

        public async Task<Response<string>> DeleteGuidebookMom(int Id)
        {
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.FirstAsync(x => x.Id == Id);
            if (guidebookMom == null)
            {
                return new Response<string>(null, $"Không tìm thấy guidebook mom có Id \'{Id}\'.");
            }

            _unitOfWork.GuidebookMomRepository.Delete(guidebookMom);
            await _unitOfWork.SaveAsync();

            return new Response<string>(Id.ToString(), $"Xóa guidebook type Id \'{Id}\' thành công!");
        }
    }
}