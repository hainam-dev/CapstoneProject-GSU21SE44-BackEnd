using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.Tokens
{
    public class CreateTokenRequest
    {
        public string Token { get; set; }
        public string AccountId { get; set; }
    }
}
