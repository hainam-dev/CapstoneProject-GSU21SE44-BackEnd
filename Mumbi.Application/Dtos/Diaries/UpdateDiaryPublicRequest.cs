using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Diaries
{
    public class UpdateDiaryPublicRequest
    {
        public int Id { get; set; }
        public string ChildId { get; set; }
        public DateTime PublicDate { get; set; }
        public bool PublicFlag { get; set; }
        public bool ApprovedFlag { get; set; }
    }
}
