using Mumbi.Application.Dtos.Vaccine;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IVaccineService
    {
        Task<Response<List<VaccineResponse>>> GetAllVaccine();

        Task<Response<List<VaccineResponse>>> GetVaccineByAntigen(string antigen);
    }
}