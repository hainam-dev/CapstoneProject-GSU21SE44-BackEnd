using AutoMapper;
using Mumbi.Application.Dtos.GuidebookTypes;
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
    public class GuidebookTypeService : IGuidebookTypeService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GuidebookTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddGuidebookType(CreateGuidebookTypeRequest request)
        {
            var guidebookType = new GuidebookType
            {
                Type = request.Type,
                IsDeleted = false,
            };
            await _unitOfWork.GuidebookTypeRepository.AddAsync(guidebookType);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm guidebook type thành công, id: " + guidebookType.Id);
        }

        public async Task<Response<List<GuidebookTypeResponse>>> GetAllGuidebookType()
        {
            var guidebookType = await _unitOfWork.GuidebookTypeRepository.GetAllAsync();
            if (guidebookType == null)
            {
                return new Response<List<GuidebookTypeResponse>>("Chưa có dữ liệu");
            }
            var response = _mapper.Map<List<GuidebookTypeResponse>>(guidebookType);
            return new Response<List<GuidebookTypeResponse>>(response);
        }

        public async Task<Response<GuidebookTypeResponse>> GetGuidebookTypeById(int Id)
        {
            var response = new GuidebookTypeResponse();
            var guidebookType = await _unitOfWork.GuidebookTypeRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (guidebookType == null)
            {
                return new Response<GuidebookTypeResponse>($"Không có guidebook type id \'{Id}\'");
            }
            response = _mapper.Map<GuidebookTypeResponse>(guidebookType);
            return new Response<GuidebookTypeResponse>(response);
        }

        public async Task<Response<string>> UpdateGuidebookTypeRequest(UpdateGuidebookTypeRequest request)
        {
            var guidebookType = await _unitOfWork.GuidebookTypeRepository.FirstAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (guidebookType == null)
            {
                return new Response<string>($"Không tìm thấy guidebook type có id \'{request.Id}\'.");
            }
            guidebookType.Type = request.Type;
            _unitOfWork.GuidebookTypeRepository.UpdateAsync(guidebookType);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật guidebook type thành công");
        }

        public async Task<Response<string>> DeleteGuidebookType(int Id)
        {
            var guidebookType = await _unitOfWork.GuidebookTypeRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (guidebookType == null)
            {
                return new Response<string>($"Không tìm thấy guidebook type có id \'{Id}\'.");
            }
            var guidebook = await _unitOfWork.GuidebookRepository.GetAsync(x => x.TypeId == Id && x.IsDeleted == false);
            if (guidebook == null)
            {
                return new Response<string>($"Type id \'{Id}\' chưa có dữ liệu");
            }
            foreach (var deleteGuidebook in guidebook)
            {
                deleteGuidebook.IsDeleted = true;
                var guidebookMom = await _unitOfWork.GuidebookMomRepository.GetAsync(x => x.GuidebookId == deleteGuidebook.Id);
                if(guidebookMom != null)
                {
                    _unitOfWork.GuidebookMomRepository.DeleteAllAsync(guidebookMom);
                    await _unitOfWork.SaveAsync();
                }
                _unitOfWork.GuidebookRepository.UpdateAsync(deleteGuidebook);
                await _unitOfWork.SaveAsync();
            }
            guidebookType.IsDeleted = true;
            _unitOfWork.GuidebookTypeRepository.UpdateAsync(guidebookType);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa guidebook type id \'{Id}\' thành công!");
        }
    }
}
