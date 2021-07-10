using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Tooths
{
    public class ToothResponse
    {
        public string ToothId { get; set; }
        public string ChildId { get; set; }
        public DateTime GrownDate { get; set; }
        public string Note { get; set; }
        public string ImageURL { get; set; }
        public bool GrownFlag { get; set; }
    }
}
