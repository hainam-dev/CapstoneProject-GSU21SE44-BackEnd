using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Diaries
{
    public class UpdateDiaryRequest
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string DiaryContent { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string ChildId { get; set; }
        public bool IsPublic { get; set; }
    }
}
