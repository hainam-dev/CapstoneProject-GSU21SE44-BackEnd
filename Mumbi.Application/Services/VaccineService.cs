using AutoMapper;
using Mumbi.Application.Dtos.Vaccine;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VaccineService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<VaccineResponse>>> GetAllVaccine()
        {
            var response = new List<VaccineResponse>();
            var vaccine = await _unitOfWork.VaccineRepository.GetAllAsync();
            if (vaccine.Count == 0)
            {
                return new Response<List<VaccineResponse>>($"Chưa có dữ liệu");
            }
            response = _mapper.Map<List<VaccineResponse>>(vaccine);
            return new Response<List<VaccineResponse>>(response);
        }

        public async Task<Response<List<VaccineResponse>>> GetVaccineByAntigen(string antigen)
        {
            var response = new List<VaccineResponse>();
            var vaccine = await _unitOfWork.VaccineRepository.GetAsync(x => x.Antigen == antigen);
            if (vaccine.Count == 0)
            {
                return new Response<List<VaccineResponse>>($"Không tìm thấy antigen \'{antigen}\'");
            }
            response = _mapper.Map<List<VaccineResponse>>(vaccine);
            return new Response<List<VaccineResponse>>(response);
        }
    }
}
