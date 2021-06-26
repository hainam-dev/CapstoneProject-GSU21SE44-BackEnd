using AutoMapper;
using Mumbi.Application.Dtos.Staffs;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<StaffResponse>> GetStaffByAccountId(string accountId)
        {
            var response = new StaffResponse();
            var staff = await _unitOfWork.StaffRepository.FirstAsync(x => x.AccountId == accountId);
            if (staff == null)
            {
                return new Response<StaffResponse>($"Tài khoản staff \'{accountId}\' không tồn tại");
            }
            response = _mapper.Map<StaffResponse>(staff);
            return new Response<StaffResponse>(response);
        }

        public async Task<Response<string>> UpdateStaffRequest(UpdateStaffRequest request)
        {
            var staff = await _unitOfWork.StaffRepository.FirstAsync(x => x.AccountId == request.AccountId);

            if (staff == null)
            {
                return new Response<string>($"Không tìm thấy thông tin staff \'{request.AccountId}\'.");

            }
            staff.FullName = request.FullName;
            staff.Image = request.Image;
            staff.Birthday = request.BirthDay;
            staff.Phonenumber = request.Phonenumber;
          

            _unitOfWork.StaffRepository.UpdateAsync(staff);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin staff thành công", staff.AccountId);
        }
    }
}
