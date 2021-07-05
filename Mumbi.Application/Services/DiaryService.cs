using AutoMapper;
using Mumbi.Application.Constants;
using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class DiaryService : IDiaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiaryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<string>> AddDiary(CreateDiaryRequest request)
        {
            var diary = new Diary
            {
                ChildId = request.ChildId,
                ImageUrl = request.ImageURL,
                DiaryContent = request.DiaryContent,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTime.Now,
                LastModifiedTime = DateTime.Now,
                PublicFlag = request.PublicFlag,
            };
            await _unitOfWork.DiaryRepository.AddAsync(diary);
            if (request.PublicFlag)
            {
                var staffs = await _unitOfWork.UserRepository.GetAsync(x => x.RoleId == RoleConstant.STAFF_ROLE && x.DelFlag == false);
                foreach (var staff in staffs)
                {
                    await sendNotification(staff.Id, "Request public diary", "Mom id request public diary id");
                }
            }
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm nhật ký thành công, id: " + diary.Id);
        }

        public async Task<Response<List<DiaryPublicResponse>>> GetDiaryPublic()
        {
            var diaryPublic = await _unitOfWork.DiaryRepository.GetAsync(x => x.PublicFlag == true && x.DelFlag == false);
            if (diaryPublic == null)
            {
                return new Response<List<DiaryPublicResponse>>("Chưa có dữ liệu");
            }
            var response = _mapper.Map<List<DiaryPublicResponse>>(diaryPublic);
            return new Response<List<DiaryPublicResponse>>(response);
        }

        public async Task<Response<List<DiaryResponse>>> GetDiaryOfChildren(string childId)
        {
            var response = new List<DiaryResponse>();
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == childId && x.DelFlag == false);
            if (child == null)
            {
                return new Response<List<DiaryResponse>>($"Không tìm thấy bé \'{childId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.GetAsync(x => x.ChildId == childId && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<List<DiaryResponse>>($"Bé {child.FullName} chưa có nhật ký nào!");
            }
            response = _mapper.Map<List<DiaryResponse>>(diary);
            return new Response<List<DiaryResponse>>(response);
        }

        public async Task<Response<string>> UpdateDiaryRequest(UpdateDiaryRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId && x.DelFlag == false);
            if (child == null)
            {
                return new Response<String>($"Không tìm thấy bé \'{request.ChildId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<string>($"Không tìm thấy thông tin nhật ký có id \'{request.Id}\'.");
            }
            diary.ImageUrl = request.ImageURL;
            diary.DiaryContent = request.DiaryContent;
            diary.LastModifiedBy = request.LastModifiedBy;
            diary.LastModifiedTime = DateTime.Now;
            diary.PublicFlag = request.PublicFlag;
            diary.ApprovedFlag = request.ApprovedFlag;

            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin nhật ký thành công");
        }

        public async Task<Response<string>> DeleteDiary(string childId, int Id)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == childId && x.DelFlag == false);
            if (child == null)
            {
                return new Response<String>($"Không tìm thấy bé \'{childId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<string>($"Không tìm thấy thông tin nhật ký có id \'{Id}\'.");
            }
            diary.DelFlag = true;
            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa nhật ký id \'{Id}\' thành công!");
        }

        private async Task<bool> sendNotification(string receiverId, string title, string body)
        {
            try
            {
                var fcmTokens = await _unitOfWork.TokenRepository.GetAsync(x => x.UserId == receiverId);
                var deviceTokens = fcmTokens.Select(x => x.FcmToken).ToArray();
                return await SendNotificationService.SendNotificationAsync(deviceTokens, title, body);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }


}
