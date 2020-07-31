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


namespace auditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();

            //object missing = System.Reflection.Missing.Value;
            //var document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            //object start = 0;
            //object end = 0;
            //var tableLocation = document.Range(ref start, ref end);
            //document.Tables.Add(tableLocation, 3, 4);
            object filename = @"d:temp2.docx";
            var document = winword.Documents.Open(filename);
            
            
            var newTable = document.Tables[1];
            newTable.Cell(1, 2).Range.Text = "sadfdsf";
            document.SaveAs(ref filename);
            winword.Documents.Open(@"d:temp2.docx");

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

        

        
    }
}
