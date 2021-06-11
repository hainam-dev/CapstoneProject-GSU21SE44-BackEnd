using AutoMapper;
using Mumbi.Application.Dtos.Childrens;
using Mumbi.Application.Enums;
using Mumbi.Application.Interfaces;
using Mumbi.Application.Wrappers;
using Mumbi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Services
{
    public class ChildrenService : IChildrenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChildrenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddChildren(CreateChildrenRequest request)
        {
            var child = new Child
            {
                Id = Guid.NewGuid().ToString(),
                FullName = request.FullName,
                Nickname = request.NickName,
                Gender = request.Gender,
                BirthDay = request.BirthDay,
                Image = request.Image,
            };

            await _unitOfWork.ChildrenRepository.AddAsync(child);

            if (request.ChildrenStatus == (int)ChildrenStatusEnum.Pregnancy)
            {
                var pregnancyInfo = new PregnancyInformation
                {
                    Id = child.Id,
                    CalculatedBornDate = request.CalculatedBornDate
                };

                await _unitOfWork.PregnancyInformationRepository.AddAsync(pregnancyInfo);
            }

            await _unitOfWork.SaveAsync();

            return new Response<string>("Add children succesfully", child.Id);
        }

        public async Task<Response<string>> UpdateChildrenInformation(UpdateChildrenInfoResquest request)
        {
            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == request.Id);

            if (child != null)
            {
                child.Weight = request.Weight;
                child.Height = request.Height;
                child.BirthDay = request.BirthDay;
                child.HeadCircumference = request.HeadCircumference;
                child.HourSleep = request.HourSleep;
                child.AvgMilk = request.AvgMilk;

                _unitOfWork.ChildrenRepository.UpdateAsync(child);
                await _unitOfWork.SaveAsync();

                return new Response<string>("Update children information succesfully", child.Id);
            }

            return new Response<string>("Update children information failed");
        }
        public async Task<Response<string>> UpdatePregnancyInformation(UpdatePregnancyInfoRequest request)
        {
            var pregnancy = await _unitOfWork.PregnancyInformationRepository.FirstAsync(x => x.Id == request.Id);
            if(pregnancy != null)
            {
                pregnancy.PregnancyWeek = request.PregnancyWeek;
                pregnancy.MotherWeight = request.MotherWeight;
                pregnancy.Weight = request.Weight;
                pregnancy.HeadCircumference = request.HeadCircumference;
                pregnancy.FetalHeartRate = request.FetalHeartRate;
                pregnancy.FemurLength = request.FemurLength;

                _unitOfWork.PregnancyInformationRepository.UpdateAsync(pregnancy);
                await _unitOfWork.SaveAsync();

                return new Response<string>("Update pregnancy information succesfully", pregnancy.Id);
            }
            return new Response<string>("Update pregnancy information failed");
        }

        public async Task<Response<string>> DeleteChildren(string id)
        {
            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == id);
            if (child != null)
            {
                //child.IsDeleted = true;
                _unitOfWork.ChildrenRepository.UpdateAsync(child);
                await _unitOfWork.SaveAsync();

                return new Response<string>("Delete children succesfully", child.Id);
            }

            return new Response<string>("Delete children failed");
        }

        public async Task<Response<ChildrenResponse>> GetChildrenById(string id)
        {
            var response = new ChildrenResponse();

            var child = await _unitOfWork.ChildrenRepository.FirstAsync(x => x.Id == id);
            if (child != null)
            {
                response = _mapper.Map<ChildrenResponse>(child);
                var pregnancyInfo = await _unitOfWork.PregnancyInformationRepository.FirstAsync(x => x.Id == id);

                if(pregnancyInfo != null)
                {
                    response = _mapper.Map<ChildrenResponse>(pregnancyInfo);
                }
            }

            return new Response<ChildrenResponse>(response);
        }

        public async Task<Response<List<ChildrenResponse>>> GetAllChildren()
        {
            var response = new List<ChildrenResponse>();
            var child = await _unitOfWork.ChildrenRepository.GetAllAsync();
            if(child != null)
            {
                response = _mapper.Map<List<ChildrenResponse>>(child);
                var pregnancyInfo = await _unitOfWork.PregnancyInformationRepository.GetAllAsync();
                if(pregnancyInfo != null)
                {
                    response = _mapper.Map<List<ChildrenResponse>>(pregnancyInfo);
                }
            }
            return new Response<List<ChildrenResponse>>(response);
        }

        
    }
}
