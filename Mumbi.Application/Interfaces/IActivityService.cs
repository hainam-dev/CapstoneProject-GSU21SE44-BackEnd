using Mumbi.Application.Dtos.Activity;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IActivityService
    {
        Task<Response<string>> AddActivity(CreateActivityRequest request);
        Task<Response<List<ActivityResponse>>> GetAllActivity();
        Task<Response<ActivityResponse>> GetActivityById(int Id);
        Task<Response<List<ActivityByTypeIdResponse>>> GetActivityByTypeId(int typeId);
        Task<Response<string>> UpdateActivityRequest(UpdateActivityRequest request);
        Task<Response<string>> DeleteActivity(int Id);
    }
}
