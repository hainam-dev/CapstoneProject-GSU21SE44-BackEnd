using Mumbi.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Guidebooks
{
    public class GuidebookRequest : RequestParameter
    {
        public int? TypeId { get; set; }
        public string SearchValue { get; set; }
    }
}
