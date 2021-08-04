using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.PregnancyHistory
{
    public class PregnancyHistoryRequest
    {
        public string ChildId { get; set; }
        public string Date { get; set; }
    }
}
