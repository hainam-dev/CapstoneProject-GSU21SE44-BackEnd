using AutoMapper;
using Mumbi.Application.Dtos.ToothInfo;
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
    public class ToothInfoService : IToothInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToothInfoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddToothInfo(CreateToothInfoRequest request)
        {
            var toothInfo = new ToothInfo
            {
                Id = Guid.NewGuid().ToString(),
                Position = request.Position,
                Number = request.Number,
                Name = request.Name,
                GrowTime = request.GrowTime
            };
            await _unitOfWork.ToothInfoRepository.AddAsync(toothInfo);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm thông tin răng thành công, id: " + toothInfo.Id);
        }

        public async Task<Response<ToothInfoResponse>> GetToothInfoByPosition(byte position)
        {
            var response = new ToothInfoResponse();
            var toothInfo = await _unitOfWork.ToothInfoRepository.FirstAsync(x => x.Position == position);
            if (toothInfo == null)
            {
                return new Response<ToothInfoResponse>($"Không tìm thấy thông tin răng tại vị trí \'{position}\'");
            }
            response = _mapper.Map<ToothInfoResponse>(toothInfo);
            return new Response<ToothInfoResponse>(response);
        }
    }
}
