using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Model
{
    class Szi : Dir
    {
        public int DeviceId { get; set; }
        public int SziTypeId { get; set; }
        public string SerialNumber { get; set; }
        public string ConfirmityNumber { get; set; }
        public int CertificateId { get; set; }
    }
}
