using Mumbi.Application.Dtos.StandardIndex;
using Mumbi.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IStandardIndexService
    {
        Task<Response<List<StandardIndexResponse>>> GetStandardIndexByGender(byte gender);
    }
}
