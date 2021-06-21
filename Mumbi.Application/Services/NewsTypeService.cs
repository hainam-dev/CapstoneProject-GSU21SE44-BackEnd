using AutoMapper;
using Microsoft.Extensions.Options;
using Mumbi.Application.Dtos.NewsType;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using Mumbi.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class NewsTypeService : INewsTypeService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddNewsType(CreateNewsTypeRequest request)
        {
            var newsType = new NewsType
            {
                Type = request.Type,
                IsDeleted = false,
            };
            await _unitOfWork.NewsTypeRepository.AddAsync(newsType);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm news type thành công, id: " + newsType.Id);
        }

        public async Task<Response<List<NewsTypeResponse>>> GetAllNewsType()
        {
            var newsType = await _unitOfWork.NewsTypeRepository.GetAllAsync();
            if (newsType == null)
            {
                return new Response<List<NewsTypeResponse>>("Chưa có dữ liệu");
            }
            var response = _mapper.Map<List<NewsTypeResponse>>(newsType);
            return new Response<List<NewsTypeResponse>>(response);
        }

        public async Task<Response<NewsTypeResponse>> GetNewsTypeById(int Id)
        {
            var response = new NewsTypeResponse();
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (newsType == null)
            {
                return new Response<NewsTypeResponse>($"Không có news type id \'{Id}\'");
            }
             response = _mapper.Map<NewsTypeResponse>(newsType);
            return new Response<NewsTypeResponse>(response);
        }

        public async Task<Response<string>> UpdateNewsTypeRequest(UpdateNewsTypeRequest request)
        {
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (newsType == null)
            {
                return new Response<string>($"Không tìm thấy news type có id \'{request.Id}\'.");
            }
            newsType.Type = request.Type;
            _unitOfWork.NewsTypeRepository.UpdateAsync(newsType);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật news type thành công");
        }

        public async Task<Response<string>> DeleteNewsType(int Id)
        {
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (newsType == null)
            {
                return new Response<string>($"Không tìm thấy news type có id \'{Id}\'.");
            }
            var news = await _unitOfWork.NewsRepository.GetAsync(x => x.TypeId == Id && x.IsDeleted == false);
            if (news == null)
            {
                return new Response<string>($"Type id \'{Id}\' chưa có dữ liệu");
            }
            foreach(var deleteNews in news)
            {
                var newsMom = await _unitOfWork.NewsMomRepository.GetAsync(x => x.NewsId == deleteNews.Id);
                if (newsMom != null)
                {
                    _unitOfWork.NewsMomRepository.DeleteAllAsync(newsMom);
                }
                deleteNews.IsDeleted = true;
                _unitOfWork.NewsRepository.UpdateAsync(deleteNews);
            }
            newsType.IsDeleted = true;
            _unitOfWork.NewsTypeRepository.UpdateAsync(newsType);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa news type id \'{Id}\' thành công!");
        }
    }
}
