using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using auditor.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;

namespace auditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private List<Device> devicesList;

        public MainWindow()
        {
            InitializeComponent();
            if (devicesList == null)
                devicesList = new List<Device>();
            Devices.ItemsSource = devicesList;
            using (var context = new AuditorContext())
            {
                var techType = new TechType
                {
                    Name = "ПЭВМ (системный блок, монитор, клавиатура, мышь)"
                };
                context.TechTypes.Add(techType);
                context.SaveChanges();
            }

        }

        private void PrintDoc(object sender, RoutedEventArgs e)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();

            object missing = System.Reflection.Missing.Value;
            object template = Environment.CurrentDirectory + "/templates/ТП.docx";
            var document = winword.Documents.Open(template);
            var findObject = winword.Selection.Find;
            object findText = "#location";

            if (findObject.Execute(ref findText,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing))
            {
                findObject.ClearFormatting();
                findObject.Replacement.ClearFormatting();
                findObject.Replacement.Text = "административное здание, расположенное по адресу: " + ((ComboBoxItem)Buildings.SelectedItem).Content.ToString() + ", кабинет № " + cabinet.Text + ".";
                object replaceAll = WdReplace.wdReplaceAll;
                findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            }





            var fileName = Environment.CurrentDirectory + "/generateddocs/ТП.docx";
            document.SaveAs(fileName);
            winword.Documents.Open(fileName);

            /*
            var mo = new SystemParametres<Win32_DiskDrive>().GetInfo();
            foreach (var m in mo)
            {
                MessageBox.Show(((Win32_DiskDrive)m).SerialNumber);
            } 
            var mo1 = new SystemParametres<Win32_Product>().GetInfo();
            foreach (var m in mo1)
            {
                var obj = (Win32_Product)m;
                if (obj.Name != null)
                {
                    MessageBox.Show(obj.Name + " => " + obj.Version);
                }
            }
            var mo1 = new SystemParametres<Win32_Product>().GetInfo();
            foreach (var m in mo1)
            {
                var obj = (Win32_Product)m;
                if (obj.Name != null)
                {
                    MessageBox.Show(obj.Name + " => " + obj.Caption);
                }
            }*/
        }

        private void InsertRow(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Метод, скрывающий ненужные колонки  DataGrid'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            List<String> hiddenColumns = new List<string>
            {
                "IsRemoved",
                "DepartmentId",
                "DivisionId",
                "BuildingId",
                "Cabinet"
            };
            if (hiddenColumns.Contains(propertyDescriptor.DisplayName))
            {
                e.Cancel = true;
            }
        }
    }
}
