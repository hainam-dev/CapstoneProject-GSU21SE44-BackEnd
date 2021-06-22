using AutoMapper;
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
    public class GuidebookService : IGuidebookService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GuidebookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddGuidebook(CreateGuidebookRequest request)
        {
            var guidebook = new Guidebook
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                GuidebookContent = request.GuidebookContent,
                Image = request.Image,
                EstimateFinishTime = request.EstimateFinishTime,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTime.Now,
                LastModifiedTime = DateTime.Now,
                TypeId = request.TypeId,
                IsDeleted = false,
            };
            await _unitOfWork.GuidebookRepository.AddAsync(guidebook);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm guidebook thành công, id: " + guidebook.Id);
        }

        public async Task<Response<List<GuidebookResponse>>> GetAllGuidebook()
        {
            var guidebook = await _unitOfWork.GuidebookRepository.GetAsync(x => x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<List<GuidebookResponse>>("Chưa có dữ liệu");
            }
            var response = _mapper.Map<List<GuidebookResponse>>(guidebook);
            return new Response<List<GuidebookResponse>>(response);
        }

        public async Task<Response<GuidebookResponse>> GetGuidebookById(string Id)
        {
            var response = new GuidebookResponse();
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<GuidebookResponse>($"Không tìm thấy guidebook id \'{Id}\'");
            }
            response = _mapper.Map<GuidebookResponse>(guidebook);
            return new Response<GuidebookResponse>(response);
        }

        public async Task<Response<List<GuidebookByTypeIdResponse>>> GetGuidebookByTypeId(int typeId)
        {
            var response = new List<GuidebookByTypeIdResponse>();
            var guidebook = await _unitOfWork.GuidebookRepository.GetAsync(x => x.TypeId == typeId && x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<List<GuidebookByTypeIdResponse>>($"TypeId \'{typeId}\' chưa có dữ liệu");
            }
            response = _mapper.Map<List<GuidebookByTypeIdResponse>>(guidebook);
            return new Response<List<GuidebookByTypeIdResponse>>(response);
        }

        public async Task<Response<string>> UpdateGuidebookRequest(UpdateGuidebookRequest request)
        {
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<string>($"Không tìm thấy guidebook id \'{request.Id}\'");
            }
            guidebook.Title = request.Title;
            guidebook.GuidebookContent = request.GuidebookContent;
            guidebook.Image = request.Image;
            guidebook.EstimateFinishTime = request.EstimateFinishTime;
            guidebook.TypeId = request.TypeId;
            _unitOfWork.GuidebookRepository.UpdateAsync(guidebook);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Cập nhật guidebook thành công");
        }

        public async Task<Response<string>> DeleteGuidebook(string Id)
        {
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<string>($"Không tìm thấy guidebook type có id \'{Id}\'.");
            }
            var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.GuidebookId == Id);
            if (guidebookMom == null)
            {
                return new Response<string>($"Guidebook id \'{Id}\' chưa có dữ liệu");
            }
            guidebook.IsDeleted = true;
            _unitOfWork.GuidebookMomRepository.DeleteAllAsync(guidebookMom);
            _unitOfWork.GuidebookRepository.UpdateAsync(guidebook);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa guidebook id \'{Id}\' thành công!");
        }
    }
}
