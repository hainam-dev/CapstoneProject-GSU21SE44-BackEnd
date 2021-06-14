using AutoMapper;
using Mumbi.Application.Dtos.Dads;
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
    public class DadService : IDadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //public Task<Response<string>> AddDad(CreateDadRequest request)
        //{
            //var dad = new Dad
            //{
            //    Id = Guid.NewGuid().,
            //    FullName = request.FullName,
            //    Birthday = request.BirthDay,
            //    Image = request.Image,
            //    MomId = request.MomID,
            //    IsDeleted = false,
            //};
            //await _unitOfWork.DadRepository.AddAsync(dad);
        //}

        //public async Task<Response<string>> DeleteDad(int id)
        //{
        //    var dad = await _unitOfWork.DadRepository.FirstAsync(x => x.Id == id);
        //    if (dad != null) { 
        //        dad.IsDeleted = true;
        //        _unitOfWork.DadRepository.UpdateAsync(dad);
        //        await _unitOfWork.SaveAsync();
        //        return new Response<string>("Delete dad succesfully", dad.FullName);
        //    }
        //return new Response<string>("Delete dad failed");
        //}
    }
}
