using AutoMapper;
using Mumbi.Application.Dtos.Guidebooks;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class GuidebookService : IGuidebookService
    {
        private readonly IUnitOfWork _unitOfWork;
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
                ImageUrl = request.ImageURL,
                EstimatedFinishTime = request.EstimatedFinishTime,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                LastModifiedBy = request.LastModifiedBy,
                LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                SuitableAge = request.SuitableAge,
                TypeId = request.TypeId,
                DelFlag = false,
            };

            await _unitOfWork.GuidebookRepository.AddAsync(guidebook);
            await _unitOfWork.SaveAsync();

            return new Response<string>(guidebook.Id, $"Thêm guidebook thành công, id: {guidebook.Id}");
        }

        public async Task<PagedResponse<List<GuidebookByTypeIdResponse>>> GetGuidebook(GuidebookRequest request)
        {
            var response = new List<GuidebookByTypeIdResponse>();
            var guidebook = await _unitOfWork.GuidebookRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize,
                                                                                       filter: x => (request.TypeId == null || x.TypeId == request.TypeId.Value)
                                                                                                 && (request.SuitableAge == null || x.SuitableAge == request.SuitableAge.Value)
                                                                                                 && (request.SearchValue == null || x.Title.Contains(request.SearchValue))
                                                                                                 && x.DelFlag == false,
                                                                                       orderBy: x => x.OrderByDescending(o => o.CreatedTime),includeProperties:"Type");

            response = _mapper.Map<List<GuidebookByTypeIdResponse>>(guidebook);
            var totalCount = await _unitOfWork.GuidebookRepository.CountAsync(x => (request.TypeId == null || x.TypeId == request.TypeId.Value)
                                                                                          && (request.SuitableAge == null || x.SuitableAge == request.SuitableAge.Value)
                                                                                          && (request.SearchValue == null || x.Title.Contains(request.SearchValue))
                                                                                          && x.DelFlag == false);

            return new PagedResponse<List<GuidebookByTypeIdResponse>>(response, request.PageNumber, request.PageSize, totalCount);
        }

        public async Task<Response<List<GuidebookResponse>>> GetAllGuidebook()
        {
            var guidebook = await _unitOfWork.GuidebookRepository.GetAsync(x => x.DelFlag == false, includeProperties: "Type");
            if (guidebook.Count == 0)
            {
                return new Response<List<GuidebookResponse>>(null, "Chưa có dữ liệu");
            }

            var response = _mapper.Map<List<GuidebookResponse>>(guidebook);

            return new Response<List<GuidebookResponse>>(response);
        }

        public async Task<Response<GuidebookResponse>> GetGuidebookById(string Id)
        {
            var response = new GuidebookResponse();
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (guidebook == null)
            {
                return new Response<GuidebookResponse>(null, $"Không tìm thấy guidebook id \'{Id}\'");
            }

            response = _mapper.Map<GuidebookResponse>(guidebook);

            return new Response<GuidebookResponse>(response);
        }

        public async Task<Response<List<GuidebookByTypeIdResponse>>> GetGuidebookByTypeId(int typeId)
        {
            var response = new List<GuidebookByTypeIdResponse>();
            var guidebook = await _unitOfWork.GuidebookRepository.GetAsync(x => x.TypeId == typeId && x.DelFlag == false);
            if (guidebook.Count == 0)
            {
                return new Response<List<GuidebookByTypeIdResponse>>(null, $"TypeId \'{typeId}\' chưa có dữ liệu");
            }

            response = _mapper.Map<List<GuidebookByTypeIdResponse>>(guidebook);

            return new Response<List<GuidebookByTypeIdResponse>>(response);
        }

        public async Task<Response<string>> UpdateGuidebookRequest(UpdateGuidebookRequest request)
        {
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (guidebook == null)
            {
                return new Response<string>(null, $"Không tìm thấy guidebook id \'{request.Id}\'");
            }

            guidebook.Title = request.Title;
            guidebook.GuidebookContent = request.GuidebookContent;
            guidebook.ImageUrl = request.ImageURL;
            guidebook.EstimatedFinishTime = request.EstimatedFinishTime;
            guidebook.LastModifiedBy = request.LastModifiedBy;
            guidebook.LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime;
            guidebook.SuitableAge = request.SuitableAge;
            guidebook.TypeId = request.TypeId;

            _unitOfWork.GuidebookRepository.UpdateAsync(guidebook);
            await _unitOfWork.SaveAsync();

            return new Response<string>(guidebook.Id, "Cập nhật guidebook thành công");
        }

        public async Task<Response<string>> DeleteGuidebook(string Id)
        {
            var guidebook = await _unitOfWork.GuidebookRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (guidebook == null)
            {
                return new Response<string>(null, $"Không tìm thấy guidebook có id \'{Id}\'.");
            }

            var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.GuidebookId == Id);
            if (guidebookMom.Count > 0)
            {
                guidebook.DelFlag = true;
                _unitOfWork.GuidebookMomRepository.DeleteAllAsync(guidebookMom);
                _unitOfWork.GuidebookRepository.UpdateAsync(guidebook);
                await _unitOfWork.SaveAsync();

                return new Response<string>(Id, $"Xóa guidebook id \'{Id}\' thành công!");
            }

            guidebook.DelFlag = true;
            _unitOfWork.GuidebookRepository.UpdateAsync(guidebook);
            await _unitOfWork.SaveAsync();

            return new Response<string>(Id, $"Xóa guidebook id \'{Id}\' thành công!");
        }
    }
}