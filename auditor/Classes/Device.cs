using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Classes
{
    class Device
    {
        public int Id { get; set; }
        public Boolean IsRemoved { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int BuildingId { get; set; }
        public int TechTypeId { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string Cabinet { get; set; }
        
        public Device(int techType, string inventoryNumber)
        {
            this.TechTypeId = techType;
            this.InventoryNumber = inventoryNumber;
        }
    }
}
