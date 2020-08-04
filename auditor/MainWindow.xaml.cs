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
using auditor.Classes;

namespace auditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void PrintDoc(object sender, RoutedEventArgs e)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();

            object missing = System.Reflection.Missing.Value;
            //var document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            //object start = 0;
            //object end = 0;
            //var tableLocation = document.Range(ref start, ref end);
            //document.Tables.Add(tableLocation, 3, 4);
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



            var newTable = document.Tables[1];
            newTable.Cell(1, 2).Range.Text = "sadfdsf";

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
            Tech.Items.Add().InsertRow();

        }
    }
}
