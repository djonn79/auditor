using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace auditor.Model
{
    class Device
    {
        public int Id { get; set; }
        public Boolean IsRemoved { get; set; }
        public int DepartmentId { get; set; }
        public int DivisionId { get; set; }
        public int BuildingId { get; set; }
        [DisplayName("Тип техники")]
        public int TechTypeId { get; set; }
        [DisplayName("Зав. №")]
        public string SerialNumber { get; set; }
        [DisplayName("Инв. №")]
        public string InventoryNumber { get; set; }
        public string Cabinet { get; set; }
        
        public Device(int techType, string inventoryNumber)
        {
            this.TechTypeId = techType;
            this.InventoryNumber = inventoryNumber;
        }

        public Device()
        {
        }
    }
}
