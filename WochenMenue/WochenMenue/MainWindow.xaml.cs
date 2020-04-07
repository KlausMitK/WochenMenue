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

        public static Woche gWoche = new Woche();

        private Wochenplan mWochenPlan = new Wochenplan();

        public MainWindow()
        {
            InitializeComponent();
            mWochenPlan.Bind();
        }

        //Laden
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            mWochenPlan.Show();
        }

        public static void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(Woche));
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                MainWindow.gWoche = (Woche)serializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }

        private void btn_b_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
