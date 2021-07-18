using AutoMapper;
using Microsoft.Extensions.Options;
using Mumbi.Application.Dtos.News;
using Mumbi.Application.Dtos.NewsMom;
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
    public class NewsMomService : INewsMomService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsMomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddNewsMom(CreateNewsMomRequest request)
        {
            var newsMom = new NewsMom
            {
                MomId = request.MomId,
                NewsId = request.NewsId,
            };
            await _unitOfWork.NewsMomRepository.AddAsync(newsMom);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm news mom thành công, id: " + newsMom.Id);
        }

        public async Task<Response<List<NewsMomResponse>>> GetNewsMomByMomId(string momId)
        {
            var response = new List<NewsMomResponse>();
            var newsMom = await _unitOfWork.NewsMomRepository.GetAsync(x => x.MomId == momId);
            if (newsMom.Count == 0)
            {
                return new Response<List<NewsMomResponse>>($"MomId \'{momId}\' chưa có dữ liệu");
            }

            foreach (var news in newsMom)
            {
                var newsSaved = await _unitOfWork.NewsRepository.FirstAsync(x => x.Id == news.NewsId);
                response.Add(new NewsMomResponse
                {
                    Id = news.Id,
                    NewsData = _mapper.Map<NewsResponse>(newsSaved)
                });
            }

            return new Response<List<NewsMomResponse>>(response);
        }

        public async Task<Response<string>> DeleteNewsMom(int Id)
        {
            var newsMom = await _unitOfWork.NewsMomRepository.FirstAsync(x => x.Id == Id);
            if (newsMom == null)
            {
                return new Response<string>($"Không tìm thấy news mom có Id \'{Id}\'.");
            }
            _unitOfWork.NewsMomRepository.DeleteAsync(newsMom);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa news type id \'{Id}\' thành công!");
        }
    }
}
