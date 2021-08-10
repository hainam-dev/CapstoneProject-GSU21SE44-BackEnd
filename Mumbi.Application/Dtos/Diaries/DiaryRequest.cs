using Mumbi.Application.Parameters;

namespace Mumbi.Application.Dtos.Diaries
{
    public class DiaryRequest : RequestParameter
    {
        public string ChildId { get; set; }
    }
}