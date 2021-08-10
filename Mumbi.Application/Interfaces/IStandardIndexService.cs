using Mumbi.Application.Dtos.StandardIndex;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IStandardIndexService
    {
        Task<Response<List<StandardIndexResponse>>> GetStandardIndexByGender(byte gender);
    }
}