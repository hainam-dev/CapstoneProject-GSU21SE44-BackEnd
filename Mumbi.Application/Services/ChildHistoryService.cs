using AutoMapper;
using Mumbi.Application.Dtos.ChildHistory;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Response<List<ChildHistoryResponse>>> GetChildHistoryByChildId(ChildHistoryRequest request)
        {
            var response = new List<ChildHistoryResponse>();

            DateTimeOffset? dataDate = null;
            if (!string.IsNullOrEmpty(request.Date))
            {
                dataDate = DateTimeOffset.Parse(request.Date).ToOffset(new TimeSpan(7, 0, 0));
            }

            var child = await _unitOfWork.ChildHistoryRepository.GetAsync(filter: x => x.ChildId == request.ChildId
                                                                                  && (dataDate == null || x.Date == dataDate.Value.ToString("dd-MM-yyyy")),
                                                                          orderBy: o => o.OrderBy(x => x.Date));
            if (child.Count == 0)
            {
                return new Response<List<ChildHistoryResponse>>(null, $"Chưa có thông tin em bé \'{request.ChildId}\'");
            }

            response = _mapper.Map<List<ChildHistoryResponse>>(child);

            return new Response<List<ChildHistoryResponse>>(response);
        }

        public async Task<Response<string>> UpdateChildHistory(ChildHistoryRequest request, UpdateChildHistoryRequest updateRequest)
        {
            DateTimeOffset dataDate = DateTimeOffset.Parse(request.Date).ToOffset(new TimeSpan(7, 0, 0));

            var childHistory = await _unitOfWork.ChildHistoryRepository.FirstAsync(x => x.ChildId == request.ChildId && x.Date == dataDate.Date.ToString("dd-MM-yyyy"));
            if (childHistory != null)
            {
                childHistory.Height = updateRequest.Height;
                childHistory.Weight = updateRequest.Weight;
                childHistory.HeadCircumference = updateRequest.HeadCircumference;
                childHistory.AvgMilk = updateRequest.AvgMilk;
                childHistory.HourSleep = updateRequest.HourSleep;
                childHistory.WeekOlds = updateRequest.WeekOlds;

                _unitOfWork.ChildHistoryRepository.UpdateAsync(childHistory);
                await _unitOfWork.SaveAsync();

                return new Response<string>(request.ChildId, $"Cập nhật thông tin em bé thành công, id: {request.ChildId}");
            }

            childHistory = new ChildHistory
            {
                ChildId = request.ChildId,
                Date = dataDate.ToString("dd-MM-yyyy"),
                Height = updateRequest.Height,
                Weight = updateRequest.Weight,
                HeadCircumference = updateRequest.HeadCircumference,
                AvgMilk = updateRequest.AvgMilk,
                HourSleep = updateRequest.HourSleep,
                WeekOlds = updateRequest.WeekOlds
            };

            await _unitOfWork.ChildHistoryRepository.AddAsync(childHistory);
            await _unitOfWork.SaveAsync();

            return new Response<string>(null, $"Thêm thông tin bé thành công, id: \'{request.ChildId}\'");
        }
    }
}