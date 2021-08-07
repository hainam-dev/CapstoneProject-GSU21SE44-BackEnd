using AutoMapper;
using Mumbi.Application.Dtos.PregnancyHistory;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class PregnancyHistoryService : IPregnancyHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PregnancyHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<PregnancyHistoryResponse>>> GetPregnancyHistoryByChildId(PregnancyHistoryRequest request)
        {
            var response = new List<PregnancyHistoryResponse>();

            DateTimeOffset? dataDate = null;
            if (!string.IsNullOrEmpty(request.Date))
            {
                dataDate = DateTimeOffset.Parse(request.Date).ToOffset(new TimeSpan(7, 0, 0));
            }

            var child = await _unitOfWork.PregnancyHistoryRepository.GetAsync(filter: x => x.ChildId == request.ChildId
                                                                                  && (dataDate == null || x.Date == dataDate.Value.ToString("dd-MM-yyyy")),
                                                                              orderBy: o => o.OrderBy(x => x.Date));
            if (child.Count == 0)
            {
                return new Response<List<PregnancyHistoryResponse>>(null, $"Chưa có thông tin em bé \'{request.ChildId}\'");
            }

            response = _mapper.Map<List<PregnancyHistoryResponse>>(child);

            return new Response<List<PregnancyHistoryResponse>>(response);
        }

        public async Task<Response<string>> UpdatePregnancyHistory(PregnancyHistoryRequest request, UpdatePregnancyHistoryRequest updateRequest)
        {
            DateTimeOffset dataDate = DateTimeOffset.Parse(request.Date).ToOffset(new TimeSpan(7, 0, 0));

            var pregnancyHistory = await _unitOfWork.PregnancyHistoryRepository.FirstAsync(x => x.ChildId == request.ChildId && x.Date == dataDate.Date.ToString("dd-MM-yyyy"));
            if (pregnancyHistory != null)
            {
                pregnancyHistory.PregnancyWeek = updateRequest.PregnancyWeek;
                pregnancyHistory.Weight = updateRequest.Weight;
                pregnancyHistory.BiparietalDiameter = updateRequest.BiparietalDiameter;
                pregnancyHistory.HeadCircumference = updateRequest.HeadCircumference;
                pregnancyHistory.FemurLength = updateRequest.FemurLength;
                pregnancyHistory.FetalHeartRate = updateRequest.FetalHeartRate;
                pregnancyHistory.MotherWeight = updateRequest.MotherWeight;

                _unitOfWork.PregnancyHistoryRepository.UpdateAsync(pregnancyHistory);
                await _unitOfWork.SaveAsync();

                return new Response<string>(pregnancyHistory.ChildId, $"Cập nhật thông tin em bé thành công, id: {pregnancyHistory.Id}");
            }

            pregnancyHistory = new PregnancyHistory
            {
                ChildId = request.ChildId,
                Date = dataDate.ToString("dd-MM-yyyy"),
                PregnancyWeek = updateRequest.PregnancyWeek,
                Weight = updateRequest.Weight,
                BiparietalDiameter = updateRequest.BiparietalDiameter,
                HeadCircumference = updateRequest.HeadCircumference,
                FemurLength = updateRequest.FemurLength,
                FetalHeartRate = updateRequest.FetalHeartRate,
                MotherWeight = updateRequest.MotherWeight
            };

            await _unitOfWork.PregnancyHistoryRepository.AddAsync(pregnancyHistory);
            await _unitOfWork.SaveAsync();

            return new Response<string>(null, $"Thêm thông tin thành công, id: \'{request.ChildId}\'");
        }
    }
}