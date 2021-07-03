using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Diaries
{
    public class CreateDiaryRequest
    {
        public string ImageURL { get; set; }
        public string DiaryContent { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public bool PublicFlag { get; set; }
        public string ChildId { get; set; }
        public bool DelFlag { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}
