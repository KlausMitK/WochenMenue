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
using Utils;

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
            oldFileName = PropValues.Instance().PoolPath;
            Txt_PoolPath.DataContext = PropValues.Instance();
            TxtSpecherOrtWchPl.DataContext = PropValues.Instance();

            string logLevel = IniFile.Instance().IniReadValue("LoggingLevel", "LogLevel");

            if (logLevel == "E")
            {
                RBE.IsChecked=true;
            }
            else if (logLevel == "W")
            {
                RBW.IsChecked=true;
            }
            else if (logLevel == "I")
            {
                RBI.IsChecked=true;
            }
            else
            {
                throw new Exception("Unerlaubter Wert für LoggingLevel!");
            }
        }

        private void BtnÄndern_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                Txt_PoolPath.Text = fileName;
                PropValues.Instance().PoolPath = fileName;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            PropValues.Instance().PoolPath = oldFileName;
            this.Close();
        }

        // Radiobutton
        private void CheckedError(object sender, RoutedEventArgs e)
        {
            PropValues.Instance().LogLevel = "E";
        }

        private void CheckedWarning(object sender, RoutedEventArgs e)
        {
            PropValues.Instance().LogLevel = "W";
        }

        private void CheckedInfo(object sender, RoutedEventArgs e)
        {
            PropValues.Instance().LogLevel = "I";
        }
    }
}
