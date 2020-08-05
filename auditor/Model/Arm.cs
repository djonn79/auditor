using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Model
{
    class Arm
    {
        public int Id { get; set; }
        public bool IsRemoved { get; set; }
        public int DeviceId { get; set; }
    }
}
