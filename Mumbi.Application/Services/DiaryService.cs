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
                Image = request.Image,
                DiaryContent = request.DiaryContent,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTime.Now,
                LastModifiedTime = DateTime.Now,
                IsPublic = request.IsPublic,
                ChildId = request.ChildId,
                IsDeleted = false,
                IsApproved = false,
            };
            await _unitOfWork.DiaryRepository.AddAsync(diary);
            if (request.IsPublic)
            {
                var staffs = await _unitOfWork.AccountRepository.GetAsync(x => x.RoleId == RoleConstant.STAFF_ROLE && x.IsDeleted == false);
                foreach(var staff in staffs)
                {
                    await sendNotification(staff.AccountId, "Request public diary", "Mom id request public diary id");
                }
            }
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm nhật ký thành công, id: " + diary.Id);
        }
        public async Task<Response<List<DiaryPublicResponse>>> GetDiaryPublic()
        {
            var diaryPublic = await _unitOfWork.DiaryRepository.GetAsync(x => x.IsPublic == true && x.IsDeleted == false);
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
            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == childId && x.IsDeleted == false);
            if (child == null)
            {
                return new Response<List<DiaryResponse>>($"Không tìm thấy bé \'{childId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.GetAsync(x => x.ChildId == childId && x.IsDeleted == false);
            if (diary == null)
            {
                return new Response<List<DiaryResponse>>($"Bé {child.FullName} chưa có nhật ký nào!");
            }
            response = _mapper.Map<List<DiaryResponse>>(diary);
            return new Response<List<DiaryResponse>>(response);
        }

        public async Task<Response<string>> UpdateDiaryRequest(UpdateDiaryRequest request)
        {

            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == request.ChildId && x.IsDeleted == false);
            if (child == null)
            {
                return new Response<String>($"Không tìm thấy bé \'{request.ChildId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (diary == null)
            {
                return new Response<string>($"Không tìm thấy thông tin nhật ký có id \'{request.Id}\'.");
            }
            diary.Image = request.Image;
            diary.DiaryContent = request.DiaryContent;
            diary.LastModifiedTime = DateTime.Now;
            diary.IsPublic = request.IsPublic;
            diary.IsApproved = request.IsApproved;

            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin nhật ký thành công");
        }

        public async Task<Response<string>> DeleteDiary(string childId, int Id)
        {
            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == childId && x.IsDeleted == false);
            if (child == null)
            {
                return new Response<String>($"Không tìm thấy bé \'{childId}\'.");
            }
            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == Id && x.IsDeleted == false);
            if (diary == null)
            {
                return new Response<string>($"Không tìm thấy thông tin nhật ký có id \'{Id}\'.");
            }
            diary.IsDeleted = true;
            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();
            return new Response<string>($"Xóa nhật ký id \'{Id}\' thành công!");
        }

        private async Task<bool> sendNotification(string receiverId, string title, string body)
        {
            try
            {
                var fcmTokens = await _unitOfWork.TokenRepository.GetAsync(x => x.AccountId == receiverId);
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
