using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumbi.Application.Dtos.InjectedPerson
{
    public class CreateInjectedPersonRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public byte Gender { get; set; }
        public string EthnicGroup { get; set; }
        public string Phonenumber { get; set; }
        public string HomeAddress { get; set; }
        public string TemporaryAddress { get; set; }
    }
}
