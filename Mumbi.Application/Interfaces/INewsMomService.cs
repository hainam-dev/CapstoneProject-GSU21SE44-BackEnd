﻿using Mumbi.Application.Dtos.NewsMom;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface INewsMomService
    {
        Task<Response<string>> AddNewsMom(CreateNewsMomRequest request);

        Task<Response<List<NewsMomResponse>>> GetNewsMomByMomId(string momId);

        Task<Response<string>> DeleteNewsMom(int Id);
    }
}