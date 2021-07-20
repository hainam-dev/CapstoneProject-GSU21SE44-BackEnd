using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.ActionChild
{
    public class ActionChildResponse
    {
        public int Id { get; set; }
        public string ChildId { get; set; }
        public int ActionId { get; set; }
        public bool CheckedFlag { get; set; }
    }
}
