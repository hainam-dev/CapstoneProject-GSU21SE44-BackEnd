using AutoMapper;
using Mumbi.Application.Dtos.PregnancyHistory;
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
    public class PregnancyHistoryService : IPregnancyHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PregnancyHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<PregnancyHistoryResponse>> GetPregnancyHistoryByChildId(PregnancyHistoryRequest request)
        {
            var response = new PregnancyHistoryResponse();

            var child = await _unitOfWork.PregnancyHistoryRepository.FirstAsync(x => x.ChildId == request.ChildId && x.Date == request.Date);
            if (child == null)
            {
                return new Response<PregnancyHistoryResponse>(null, $"Không tìm thấy em bé \'{request.ChildId}\'");
            }
            response = _mapper.Map<PregnancyHistoryResponse>(child);
            return new Response<PregnancyHistoryResponse>(response);
        }
        public async Task<Response<string>> UpdatePregnancyHistory(UpdatePregnancyHistoryRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId);
            if (child != null)
            {
                var pregnancyHistory = new PregnancyHistory
                {
                    ChildId = request.ChildId,
                    Date = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime.ToShortDateString(),
                    PregnancyWeek = request.PregnancyWeek,
                    Weight = request.Weight,
                    BiparietalDiameter = request.BiparietalDiameter,
                    HeadCircumference = request.HeadCircumference,
                    FemurLength = request.FemurLength,
                    FetalHeartRate = request.FetalHeartRate,
                    MotherWeight = request.MotherWeight
                };
                await _unitOfWork.PregnancyHistoryRepository.AddAsync(pregnancyHistory);
                await _unitOfWork.SaveAsync();

                return new Response<string>(pregnancyHistory.ChildId, $"Cập nhật thông tin em bé thành công, id: {pregnancyHistory.Id}");
            }
            return new Response<string>(null, $"Không tìm thấy em bé \'{request.ChildId}\'");
        }
    }
}
