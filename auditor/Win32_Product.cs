using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace auditor
{
    class Win32_Product : Win32_Base
    {
        public Win32_Product(ManagementObject mo) : base(mo) { }

        public object AssignmentType => mo["AssignmentType"];
        public string Caption => mo["Caption"].ToString();
        public string Description => mo["Description"].ToString();
        public string IdentifyingNumber => mo["IdentifyingNumber"].ToString();
        public string InstallDate => mo["InstallDate"].ToString();
        public DateTime InstallDate2 => (DateTime)mo["InstallDate2"];
        public string InstallLocation => mo["InstallLocation"].ToString();  // путь к папке в ProgramFiles, может быть null
        public short InstallState => (short)mo["InstallState"];
        public string HelpLink => mo["HelpLink"].ToString();
        public string HelpTelephone => mo["HelpTelephone"].ToString();
        public string InstallSource => mo["InstallSource"].ToString();
        public string Language => mo["Language"].ToString();
        public string LocalPackage => mo["LocalPackage"].ToString();
        public string Name => mo["Name"].ToString();
        public string PackageCache => mo["PackageCache"].ToString();
        public string PackageCode => mo["PackageCode"].ToString();
        public string PackageName => mo["PackageName"].ToString();
        public string ProductID => mo["ProductID"].ToString();  // возможно данные лицензии
        public string RegOwner => mo["RegOwner"].ToString();
        public string RegCompany => mo["RegCompany"].ToString();
        public string SKUNumber => mo["SKUNumber"].ToString();
        public string Transforms => mo["Transforms"].ToString();
        public string URLInfoAbout => mo["URLInfoAbout"].ToString();
        public string URLUpdateInfo => mo["URLUpdateInfo"].ToString();
        public string Vendor => mo["Vendor"].ToString(); // разработчик
        public int WordCount => (int)mo["WordCount"];
        public string Version => mo["Version"].ToString();  // версия
    }
}
