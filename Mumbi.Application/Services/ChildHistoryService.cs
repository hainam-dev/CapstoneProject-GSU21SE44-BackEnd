using AutoMapper;
using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
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
    public class ChildHistoryService : IChildHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChildHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<ChildHistoryResponse>> GetChildHistoryByChildId(ChildHistoryRequest request)
        {
            var response = new ChildHistoryResponse();

            var child = await _unitOfWork.ChildHistoryRepository.FirstAsync(x => x.ChildId == request.ChildId && x.Date == request.Date);
            if (child == null)
            {
                return new Response<ChildHistoryResponse>(null, $"Không tìm thấy em bé \'{request.ChildId}\'");
            }

            response = _mapper.Map<ChildHistoryResponse>(child);

            return new Response<ChildHistoryResponse>(response);
        }
        public async Task<Response<string>> UpdateChildHistory(UpdateChildHistoryRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId);
            if (child != null)
            {
                var childHistory = new ChildHistory
                {
                    ChildId = request.ChildId,
                    Date = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).Date.ToShortDateString(),
                    Height = request.Height,
                    Weight = request.Weight,
                    HeadCircumference = request.HeadCircumference,
                    AvgMilk = request.AvgMilk,
                    HourSleep = request.HourSleep,
                    WeekOlds = request.WeekOlds
                };
                await _unitOfWork.ChildHistoryRepository.AddAsync(childHistory);
                await _unitOfWork.SaveAsync();
                return new Response<string>(child.Id, $"Cập nhật thông tin em bé thành công, id: {child.Id}");
            }

            return new Response<string>(null, $"Không tìm thấy em bé \'{request.ChildId}\'");
        }
    }
}
