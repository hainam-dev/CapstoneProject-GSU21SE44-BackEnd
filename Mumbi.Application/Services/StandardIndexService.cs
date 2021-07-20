using AutoMapper;
using Mumbi.Application.Dtos.StandardIndex;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class StandardIndexService : IStandardIndexService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StandardIndexService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<StandardIndexResponse>>> GetStandardIndexByGender(byte gender)
        {
            var response = new List<StandardIndexResponse>();
            var standardIndex = await _unitOfWork.StandardIndexRepository.GetAsync(x => x.Gender == gender);
            if (standardIndex.Count == 0)
            {
                return new Response<List<StandardIndexResponse>>($"Không tìm thấy gender \'{gender}\'");
            }
            response = _mapper.Map<List<StandardIndexResponse>>(standardIndex);
            return new Response<List<StandardIndexResponse>>(response);
        }
    }
}
