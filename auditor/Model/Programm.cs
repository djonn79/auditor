using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Model
{
    class Programm : Dir
    {
        public int DeviceId { get; set; }
        public int ProgramTypeId { get; set; }
        public string LicenceNumber { get; set; }
    }
}
