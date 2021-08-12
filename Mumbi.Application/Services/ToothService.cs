using AutoMapper;
using Mumbi.Application.Dtos.Tooths;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class ToothService : IToothService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ToothService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ToothResponse>>> GetToothByChildId(string childId)
        {
            var response = new List<ToothResponse>();
            var tooth = await _unitOfWork.ToothChildRepository.GetAsync(x => x.ChildId == childId && x.GrownFlag == true, includeProperties: "ToothNavigation");
            if (tooth == null)
            {
                return new Response<List<ToothResponse>>(null, $"Không có dữ liệu mọc răng của bé \'{childId}\'.");
            }

            response = _mapper.Map<List<ToothResponse>>(tooth);

            return new Response<List<ToothResponse>>(response);
        }

        public async Task<Response<ToothResponse>> GetToothByToothId(string childId, string toothId)
        {
            var response = new ToothResponse();
            var tooth = await _unitOfWork.ToothChildRepository.FirstAsync(x => x.ChildId == childId && x.ToothId == toothId && x.GrownFlag == true);
            if (tooth == null)
            {
                return new Response<ToothResponse>(null, $"Không có dữ liệu mọc răng của răng \'{toothId}\'.");
            }

            response = _mapper.Map<ToothResponse>(tooth);

            return new Response<ToothResponse>(response);
        }

        public async Task<Response<string>> UpsertToothRequest(UpsertToothRequest request)
        {
            var tooth = await _unitOfWork.ToothChildRepository.FirstAsync(x => x.ChildId == request.ChildId && x.ToothId == request.ToothId);
            if (tooth == null)
            {
                var toothChild = new ToothChild
                {
                    ToothId = request.ToothId,
                    ChildId = request.ChildId,
                    GrownDate = request.GrownDate,
                    Note = request.Note,
                    ImageUrl = request.ImageURL,
                    GrownFlag = request.GrownFlag,
                };
                await _unitOfWork.ToothChildRepository.AddAsync(toothChild);
                await _unitOfWork.SaveAsync();
                return new Response<string>(null, "Thêm răng thành công, id: " + toothChild.Id);
            }

            tooth.ToothId = request.ToothId;
            tooth.ChildId = request.ChildId;
            tooth.GrownDate = request.GrownDate;
            tooth.Note = request.Note;
            tooth.ImageUrl = request.ImageURL;
            tooth.GrownFlag = request.GrownFlag; ;

            _unitOfWork.ToothChildRepository.UpdateAsync(tooth);
            await _unitOfWork.SaveAsync();

            return new Response<string>(tooth.Id.ToString(), "Cập nhật răng thành công");
        }
    }
}