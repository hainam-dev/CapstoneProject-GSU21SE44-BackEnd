﻿using AutoMapper;
using Mumbi.Application.Dtos.NewsType;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class NewsTypeService : INewsTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
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
                DelFlag = false,
            };

            await _unitOfWork.NewsTypeRepository.AddAsync(newsType);
            await _unitOfWork.SaveAsync();

            return new Response<string>(newsType.Id.ToString(), "Thêm news type thành công, Id: {newsType.Id}");
        }

        public async Task<Response<List<NewsTypeResponse>>> GetAllNewsType()
        {
            var newsType = await _unitOfWork.NewsTypeRepository.GetAsync(x => x.DelFlag == false);
            if (newsType.Count == 0)
            {
                return new Response<List<NewsTypeResponse>>(null, "Chưa có dữ liệu");
            }

            var response = _mapper.Map<List<NewsTypeResponse>>(newsType);

            return new Response<List<NewsTypeResponse>>(response);
        }

        public async Task<Response<NewsTypeResponse>> GetNewsTypeById(int Id)
        {
            var response = new NewsTypeResponse();
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (newsType == null)
            {
                return new Response<NewsTypeResponse>(null, $"Không tìm thấy news type có Id \'{Id}\'");
            }

            response = _mapper.Map<NewsTypeResponse>(newsType);

            return new Response<NewsTypeResponse>(response);
        }

        public async Task<Response<string>> UpdateNewsTypeRequest(UpdateNewsTypeRequest request)
        {
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (newsType == null)
            {
                return new Response<string>(null, $"Không tìm thấy news type có Id \'{request.Id}\'.");
            }

            newsType.Type = request.Type;
            _unitOfWork.NewsTypeRepository.UpdateAsync(newsType);
            await _unitOfWork.SaveAsync();

            return new Response<string>(newsType.Id.ToString(), "Cập nhật news type thành công");
        }

        public async Task<Response<string>> DeleteNewsType(int Id)
        {
            var newsType = await _unitOfWork.NewsTypeRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (newsType == null)
            {
                return new Response<string>(null, $"Không tìm thấy news type có Id \'{Id}\'.");
            }

            var news = await _unitOfWork.NewsRepository.GetAsync(x => x.TypeId == Id && x.DelFlag == false);
            if (news.Count > 0)
            {
                foreach (var deleteNews in news)
                {
                    var newsMom = await _unitOfWork.NewsMomRepository.GetAsync(x => x.NewsId == deleteNews.Id);
                    if (newsMom.Count > 0)
                    {
                        _unitOfWork.NewsMomRepository.DeleteAllAsync(newsMom);
                    }
                    deleteNews.DelFlag = true;
                    _unitOfWork.NewsRepository.UpdateAsync(deleteNews);
                }
            }

            newsType.DelFlag = true;
            _unitOfWork.NewsTypeRepository.UpdateAsync(newsType);
            await _unitOfWork.SaveAsync();

            return new Response<string>(Id.ToString(), $"Xóa news type Id \'{Id}\' thành công!");
        }
    }
}