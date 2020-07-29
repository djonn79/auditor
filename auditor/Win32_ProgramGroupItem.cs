using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace auditor
{
    public class Win32_ProgramGroupItem : Win32_Base
    {
        public Win32_ProgramGroupItem(ManagementObject mo) : base(mo) { }
        public string Caption => mo["Caption"].ToString();
        public string Description => mo["Description"].ToString();
        public DateTime InstallDate => (DateTime)mo["InstallDate"];
        public string Name => mo["Name"].ToString();
        public string Status => mo["Status"].ToString();
    }
}
