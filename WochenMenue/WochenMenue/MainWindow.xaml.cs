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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            
        }

        //Laden
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                /*
                string fileName = openFileDialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(Woche));

                FileStream fileStream = new FileStream(fileName, FileMode.Open);

                Wochenplan.gWoche = (Woche) serializer.Deserialize(fileStream);
                fileStream.Close();
                */
            }

            this.Hide();
            new Wochenplan().Show();

            
        }


        private void btn_b_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
