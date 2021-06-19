using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Guidebooks
{
    public class GuidebookByTypeIdResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string GuidebookContent { get; set; }
        public string Image { get; set; }
        public string EstimateFinishTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int TypeId { get; set; }
    }
}
