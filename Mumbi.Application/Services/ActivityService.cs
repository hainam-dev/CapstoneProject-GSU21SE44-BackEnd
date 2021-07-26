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
            await _unitOfWork.ActivityRepository.AddAsync(activity);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Thêm activity thành công, id: {activity.Id}");
        }
        public async Task<Response<ActivityResponse>> GetActivityById(int Id)
        {
            var response = new ActivityResponse();
            var activity = await _unitOfWork.ActivityRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false, includeProperties: "Type");
            if (activity == null)
            {
                return new Response<ActivityResponse>($"Không tìm thấy activity id \'{Id}\'");
            }
            response = _mapper.Map<ActivityResponse>(activity);
            return new Response<ActivityResponse>(response);
        }
        public async Task<Response<List<ActivityByTypeIdResponse>>> GetActivityByTypeId(int typeId)
        {
            var response = new List<ActivityByTypeIdResponse>();
            var activity = await _unitOfWork.ActivityRepository.GetAsync(x => x.TypeId == typeId && x.DelFlag == false);
            if (activity.Count == 0)
            {
                return new Response<List<ActivityByTypeIdResponse>>($"TypeId \'{typeId}\' chưa có dữ liệu");
            }
            response = _mapper.Map<List<ActivityByTypeIdResponse>>(activity);
            return new Response<List<ActivityByTypeIdResponse>>(response);
        }

        public async Task<Response<List<ActivityResponse>>> GetAllActivity()
        {
            var activity = await _unitOfWork.ActivityRepository.GetAsync(x => x.DelFlag == false, includeProperties: "Type");
            if (activity.Count == 0)
            {
                return new Response<List<ActivityResponse>>("Chưa có dữ liệu");
            }
            var response = _mapper.Map<List<ActivityResponse>>(activity);
            return new Response<List<ActivityResponse>>(response);
        }

        public async Task<Response<string>> UpdateActivityRequest(UpdateActivityRequest request)
        {
            var activity = await _unitOfWork.ActivityRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (activity == null)
            {
                return new Response<string>($"Không tìm thấy activity id \'{request.Id}\'");
            }
            activity.ActivityName = request.ActivityName;
            activity.MediaFileUrl = request.MediaFileURL;
            activity.TypeId = request.TypeId;
            activity.SuitableAge = request.SuitableAge;
            _unitOfWork.ActivityRepository.UpdateAsync(activity);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Cập nhật activity thành công");
        }

        public async Task<Response<string>> DeleteActivity(int Id)
        {
            var activity = await _unitOfWork.ActivityRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (activity == null)
            {
                return new Response<string>($"Không tìm thấy activity id \'{Id}\'.");
            }
            activity.DelFlag = true;
            _unitOfWork.ActivityRepository.UpdateAsync(activity);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa activity id \'{Id}\' thành công!");
        }

        
    }
}
