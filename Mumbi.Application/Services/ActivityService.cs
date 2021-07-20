using AutoMapper;
using Mumbi.Application.Dtos.Activity;
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
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddActivity(CreateActivityRequest request)
        {
            var activity = new Activity
            {
                ActivityName = request.ActivityName,
                MediaFileUrl = request.MediaFileURL,
                TypeId = request.TypeId,
                SuitableAge = request.SuitableAge,
                DelFlag = false,
            };
            //await _unitOfWork.ActivityRepository.AddAsync(activity);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm activity thành công, id: " + activity.Id);
        }

        public Task<Response<List<ActivityByTypeIdResponse>>> GetActivityByTypeId(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ActivityResponse>>> GetAllActivity()
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateActivityRequest(UpdateActivityRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> DeleteActivity(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
