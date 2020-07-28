using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace auditor
{
    class SystemParametres<T> where T : Win32_Base
    {
        public IEnumerable<Win32_Base> GetInfo()
        {
            foreach (ManagementObject mo in new ManagementObjectSearcher($"SELECT * FROM {typeof(T).Name}").Get())
            {
                // При добавлении нового класса (производного от Win32_Base) нужный объект будет создан автоматически.  
                var construct = typeof(T).GetConstructor(new[] { mo.GetType() });
                var instance = construct.Invoke(new[] { mo });
                yield return (Win32_Base)instance;
            }
        }
        
    }
    
}
