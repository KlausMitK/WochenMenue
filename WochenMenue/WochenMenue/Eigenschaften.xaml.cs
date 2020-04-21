using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Xml.Serialization;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für Eigenschaften.xaml
    /// </summary>
    public partial class Eigenschaften : Window
    {

        private string oldFileName = @"";

        public Eigenschaften()
        {
            InitializeComponent();
            oldFileName = MainWindow.gPoolPath;
            Txt_PoolPath.Text = oldFileName;
        }

        private void BtnÄndern_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                Txt_PoolPath.Text = fileName;
                MainWindow.gPoolPath = fileName;
            }


        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string iniFilePath = MainWindow.gIniFilePath;
            IniFile iniFile = new IniFile(MainWindow.gIniFilePath);

            iniFile.IniWriteValue("Path", "PoolPath", MainWindow.gPoolPath);
            this.Close();
        }

        private void BtnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            Txt_PoolPath.Text = oldFileName;
            MainWindow.gPoolPath = oldFileName;
            this.Close();
        }

        private void Txt_PoolPath_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
