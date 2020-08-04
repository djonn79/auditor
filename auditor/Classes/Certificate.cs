using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Classes
{
    class Certificate : Dir
    {
        public int InstituteId { get; set; }
        public DateTime DateCertify { get; set; }
        public DateTime DateExpire { get; set; }
    }
}
