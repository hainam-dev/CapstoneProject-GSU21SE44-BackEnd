using AutoMapper;
using Mumbi.Application.Dtos.Action;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class ActionService : IActionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<ActionResponse>>> GetActionByType(string type)
        {
            var response = new List<ActionResponse>();
            var action = await _unitOfWork.ActionRepository.GetAsync(x => x.Type == type);
            if (action.Count == 0)
            {
                return new Response<List<ActionResponse>>($"Không có action type \'{type}\'");
            }
            response = _mapper.Map<List<ActionResponse>>(action);
            return new Response<List<ActionResponse>>(response);
        }
    }
}
