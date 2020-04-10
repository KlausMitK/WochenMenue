using Microsoft.Win32;
using System.IO;
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
using System.Windows.Shapes;

using System.Windows.Documents.Serialization;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für Einkaufsliste.xaml
    /// </summary>
    public partial class Einkaufsliste : Window
    {
        public Einkaufsliste()
        {
            InitializeComponent();
            Bind();
        }

        public void Bind()
        {
            //Bind Woche.mEKL mit entsprechendem DataGrid
            Dtg_Ekl.ItemsSource = MainWindow.gWoche.mEKL;
        }
               

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
