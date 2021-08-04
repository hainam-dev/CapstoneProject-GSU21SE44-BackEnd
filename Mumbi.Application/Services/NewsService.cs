using AutoMapper;
using Mumbi.Application.Dtos.News;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddNews(CreateNewsRequest request)
        {
            var news = new News
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                NewsContent = request.NewsContent,
                ImageUrl = request.ImageURL,
                EstimatedFinishTime = request.EstimatedFinishTime,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                LastModifiedBy = request.LastModifiedBy,
                LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                TypeId = request.TypeId,
                DelFlag = false,
            };

            await _unitOfWork.NewsRepository.AddAsync(news);
            await _unitOfWork.SaveAsync();

            return new Response<string>(news.Id, $"Thêm news thành công, id: {news.Id}");
        }

        public async Task<Response<List<NewsResponse>>> GetAllNews()
        {
            var news = await _unitOfWork.NewsRepository.GetAsync(x => x.DelFlag == false, includeProperties: "Type");
            if (news.Count == 0)
            {
                return new Response<List<NewsResponse>>(null, "Chưa có dữ liệu");
            }

            var response = _mapper.Map<List<NewsResponse>>(news);

            return new Response<List<NewsResponse>>(response);
        }

        public async Task<Response<NewsResponse>> GetNewsById(string Id)
        {
            var response = new NewsResponse();
            var news = await _unitOfWork.NewsRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false, includeProperties: "Type");
            if (news == null)
            {
                return new Response<NewsResponse>(null, $"Không tìm thấy news id \'{Id}\'");
            }

            response = _mapper.Map<NewsResponse>(news);

            return new Response<NewsResponse>(response);
        }

        public async Task<PagedResponse<List<NewsByTypeIdResponse>>> GetNews(NewsRequest request)
        {
            var response = new List<NewsByTypeIdResponse>();
            var news = await _unitOfWork.NewsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize,
                                                                             x => (request.TypeId == null || x.TypeId == request.TypeId.Value)
                                                                               && (request.SearchValue == null || x.Title.Contains(request.SearchValue))
                                                                               && x.DelFlag == false);

            response = _mapper.Map<List<NewsByTypeIdResponse>>(news);

            return new PagedResponse<List<NewsByTypeIdResponse>>(response, request.PageNumber, request.PageSize);
        }

        public async Task<Response<string>> UpdateNewsRequest(UpdateNewsRequest request)
        {
            var news = await _unitOfWork.NewsRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (news == null)
            {
                return new Response<string>(null, $"Không tìm thấy news id \'{request.Id}\'");
            }

            news.Title = request.Title;
            news.NewsContent = request.NewsContent;
            news.ImageUrl = request.ImageURL;
            news.EstimatedFinishTime = request.EstimatedFinishTime;
            news.LastModifiedBy = request.LastModifiedBy;
            news.LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime;
            news.TypeId = request.TypeId;

            _unitOfWork.NewsRepository.UpdateAsync(news);
            await _unitOfWork.SaveAsync();

            return new Response<string>(news.Id, "Cập nhật news thành công");
        }

        public async Task<Response<string>> DeleteNews(string Id)
        {
            var news = await _unitOfWork.NewsRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (news == null)
            {
                return new Response<string>(null, $"Không tìm thấy news id \'{Id}\'.");
            }

            var newsMom = await _unitOfWork.NewsMomRepository.GetAsync(x => x.NewsId == Id);
            if (newsMom.Count > 0)
            {
                news.DelFlag = true;
                _unitOfWork.NewsRepository.UpdateAsync(news);
                _unitOfWork.NewsMomRepository.DeleteAllAsync(newsMom);
                await _unitOfWork.SaveAsync();
                return new Response<string>(Id, $"Xóa news id \'{Id}\' thành công!");
            }

            news.DelFlag = true;
            _unitOfWork.NewsRepository.UpdateAsync(news);
            await _unitOfWork.SaveAsync();

            return new Response<string>(Id, $"Xóa news id \'{Id}\' thành công!");
        }
    }
}