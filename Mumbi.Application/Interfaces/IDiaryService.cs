using Mumbi.Application.Dtos.Dads;
using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Dtos.Moms;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IDiaryService
    {
        Task<Response<string>> AddDiary(CreateDiaryRequest request);
        Task<Response<List<DiaryPublicResponse>>> GetDiaryToApprove();
        Task<Response<List<DiaryPublicResponse>>> GetDiaryPublic();
        Task<Response<List<DiaryResponse>>> GetDiaryOfChildren(string childId);
        Task<Response<string>> UpdateDiaryRequest(UpdateDiaryRequest request);
        Task<Response<string>> DeleteDiary(string childId, int Id);
    }
}
