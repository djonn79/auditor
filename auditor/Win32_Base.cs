using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace auditor
{
    public abstract class Win32_Base
    {
        protected ManagementObject mo { get; set; }
        public Win32_Base(ManagementObject mo)
        {
            this.mo = mo;
        }
    }
}
