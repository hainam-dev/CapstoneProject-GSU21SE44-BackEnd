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
            var getMom = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId);
            var diary = new Diary
            {
                ChildId = request.ChildId,
                ImageUrl = request.ImageURL,
                DiaryContent = request.DiaryContent,
                CreatedBy = request.CreatedBy,
                CreatedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime,
                PublicFlag = request.PublicFlag,
            };
            await _unitOfWork.DiaryRepository.AddAsync(diary);

            if (request.PublicFlag)
            {
                var staffs = await _unitOfWork.UserRepository.GetAsync(x => x.RoleId == RoleConstant.STAFF_ROLE && x.DelFlag == false);
                foreach (var staff in staffs)
                {
                    await sendNotification(staff.Id, "Yêu cầu đăng nhật ký mới!", $"Id mẹ \'{getMom.MomId}\' gửi yêu cầu public nhật ký \'{diary.Id}\', vui lòng kiểm tra và phê duyệt!");
                }
            }

            await _unitOfWork.SaveAsync();

            return new Response<string>(diary.Id.ToString(), $"Thêm nhật ký thành công, id: {diary.Id}");
        }

        public async Task<Response<List<DiaryPublicResponse>>> GetDiaryToApprove()
        {
            var diaryPublic = await _unitOfWork.DiaryRepository.GetAsync(x => x.PublicFlag == true && x.DelFlag == false && x.ApprovedFlag == false);
            if (diaryPublic.Count == 0)
            {
                return new Response<List<DiaryPublicResponse>>(null, "Chưa có dữ liệu");
            }

            var response = _mapper.Map<List<DiaryPublicResponse>>(diaryPublic);

            return new Response<List<DiaryPublicResponse>>(response);
        }
        public async Task<Response<List<DiaryPublicResponse>>> GetDiaryPublic()
        {
            var diaryPublic = await _unitOfWork.DiaryRepository.GetAsync(x => x.DelFlag == false && x.ApprovedFlag == true,
                                                                         includeProperties: "Child.Mom.IdNavigation.UserInfo");
            if (diaryPublic.Count == 0)
            {
                return new Response<List<DiaryPublicResponse>>(null, "Chưa có dữ liệu");
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
            if (diary.Count == 0)
            {
                return new Response<List<DiaryResponse>>(null, $"Bé {child.FullName} chưa có nhật ký nào!");
            }

            response = _mapper.Map<List<DiaryResponse>>(diary);

            return new Response<List<DiaryResponse>>(response);
        }

        public async Task<Response<string>> UpdateDiaryRequest(UpdateDiaryRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId && x.DelFlag == false);
            if (child == null)
            {
                return new Response<String>(null, $"Không tìm thấy bé \'{request.ChildId}\'.");
            }

            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<string>(null, $"Không tìm thấy thông tin nhật ký có id \'{request.Id}\'.");
            }

            diary.ImageUrl = request.ImageURL;
            diary.DiaryContent = request.DiaryContent;
            diary.LastModifiedBy = request.LastModifiedBy;
            diary.LastModifiedTime = DateTimeOffset.Now.ToOffset(new TimeSpan(7, 0, 0)).DateTime;
            diary.PublicDate = request.PublicDate;
            diary.PublicFlag = request.PublicFlag;
            diary.ApprovedFlag = request.ApprovedFlag;

            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();

            return new Response<string>(diary.Id.ToString(), $"Cập nhật thông tin nhật ký thành công, id: {diary.Id}");
        }
        public async Task<Response<string>> UpdateDiaryPublicRequest(UpdateDiaryPublicRequest request)
        {
            var child = await _unitOfWork.ChildInfoRepository.FirstAsync(x => x.Id == request.ChildId && x.DelFlag == false);
            if (child == null)
            {
                return new Response<String>(null, $"Không tìm thấy bé \'{request.ChildId}\'.");
            }

            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == request.Id && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<string>(null, $"Không tìm thấy thông tin nhật ký có id \'{request.Id}\'.");
            }

            diary.PublicDate = request.PublicDate;
            diary.PublicFlag = request.PublicFlag;
            diary.ApprovedFlag = request.ApprovedFlag;
            if (request.ApprovedFlag)
            {
                await sendNotification(child.MomId, "Đăng nhật ký lên cộng đồng đã được duyệt!", $"Nhật ký của bạn đã được duyệt để đăng lên cộng đồng!");
            }
            else
            {
                await sendNotification(child.MomId, "Đăng nhật ký lên cộng đồng không được chấp nhận!", $"Nhật ký của bạn đã vi phạm quy định tiêu chuẩn cộng đồng, vui lòng thử lại!");
            }

            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();

            return new Response<string>(diary.Id.ToString(), "Duyệt nhật ký thành công!");
        }

        public async Task<Response<string>> DeleteDiary(int Id)
        {
            var diary = await _unitOfWork.DiaryRepository.FirstAsync(x => x.Id == Id && x.DelFlag == false);
            if (diary == null)
            {
                return new Response<string>(null, $"Không tìm thấy thông tin nhật ký có id \'{Id}\'.");
            }

            diary.DelFlag = true;
            _unitOfWork.DiaryRepository.UpdateAsync(diary);
            await _unitOfWork.SaveAsync();

            return new Response<string>(Id.ToString(), $"Xóa nhật ký id \'{Id}\' thành công!");
        }

        private async Task<int> sendNotification(string receiverId, string title, string body)
        {
            try
            {
                var fcmTokens = await _unitOfWork.TokenRepository.GetAsync(x => x.UserId == receiverId);
                var deviceTokens = fcmTokens.Select(x => x.FcmToken).ToList();
                return await SendNotificationService.SendNotificationAsync(deviceTokens, title, body);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }


}
