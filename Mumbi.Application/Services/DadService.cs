using AutoMapper;
using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class DadService : IDadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<string>> AddDad(CreateDadRequest request)
        {
            var dad = new Dad
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.FullName,
                Image = request.Image,
                Birthday = request.Birthday,
                Phonenumber = request.Phonenumber,
                BloodGroup = request.BloodGroup,
                RhBloodGroup =request.RhBloodGroup,
                MomId = request.MomId,
                IsDeleted = false,
            };
            await _unitOfWork.DadRepository.AddAsync(dad);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Thêm thông tin ba thành công" + dad.Id);
        }

        public async Task<Response<string>> UpdateDadRequest(UpdateDadRequest request)
        {
            var dad = await _unitOfWork.DadRepository.FirstAsync(x => x.Id == request.Id);

            if (dad == null)
            {
                return new Response<string>($"Không tìm thấy thông tin ba \'{dad.Id}\'.");
                
            }
            dad.Id = request.Id;
            dad.FullName = request.FullName;
            dad.Image = request.Image;
            dad.Birthday = request.BirthDay;
            dad.Phonenumber = request.Phonenumber;
            dad.BloodGroup = request.BloodGroup;
            dad.RhBloodGroup = request.RhBloodGroup;

            _unitOfWork.DadRepository.UpdateAsync(dad);
            await _unitOfWork.SaveAsync();

            return new Response<string>("Cập nhật thông tin ba thành công", dad.Id);
        }

        public async Task<Response<string>> DeleteDad(string id)
        {
            var dad = await _unitOfWork.DadRepository.FirstAsync(x => x.Id == id);
            if (dad == null)
            {
                return new Response<string>($"Không tìm thấy thông tin ba \'{dad.Id}\'.");
            }
            dad.IsDeleted = true;
            _unitOfWork.DadRepository.UpdateAsync(dad);
            await _unitOfWork.SaveAsync();
            return new Response<string>("Xóa thông tin ba thành công", dad.FullName);
        }
    }
}
