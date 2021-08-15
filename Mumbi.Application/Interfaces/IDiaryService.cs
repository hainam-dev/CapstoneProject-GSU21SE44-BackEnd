using Mumbi.Application.Dtos.Diaries;
using Mumbi.Application.Parameters;
using Mumbi.Application.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mumbi.Application.Interfaces
{
    public interface IDiaryService
    {
        Task<Response<string>> AddDiary(CreateDiaryRequest request);

        Task<Response<List<DiaryPublicResponse>>> GetDiaryToApprove();

        Task<PagedResponse<List<DiaryPublicResponse>>> GetDiaryPublic(RequestParameter request);

        Task<PagedResponse<List<DiaryResponse>>> GetDiaryOfChildren(DiaryRequest request);

        Task<Response<string>> UpdateDiaryRequest(UpdateDiaryRequest request);

        Task<Response<string>> UpdateDiaryPublicRequest(UpdateDiaryPublicRequest request);

        Task<Response<string>> DeleteDiary(int Id);
    }
}