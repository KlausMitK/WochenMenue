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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Collection_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Point : INotifyPropertyChanged
        {
            private int mPropChangedCount = 0;

            double mX, mY, mZ;

            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
                mPropChangedCount++;
            }


            public double X 
            {
                get { return mX; }
                set { mX = value; NotifyPropertyChanged("X"); }
            }
            public double Y
            {
                get { return mY; }
                set { mY = value; NotifyPropertyChanged("Y"); }
            }
            public double Z
            {
                get { return mZ; }
                set { mZ = value; NotifyPropertyChanged("Z"); }
            }
        }

        private List<Point> mListe;

        public List<Point> Liste
        {
            get { return mListe; }
            set { mListe = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            mListe = new List<Point>();

            for (int i = 0; i<10; i++)
            {
                Point p = new Point();
                p.X = i;
                p.Y = -i;
                p.Z = -2 * i;
                mListe.Add(p);
            }

            DtG_Liste.ItemsSource = Liste;
        }

        private void UpdButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i<10; i++)
            {
                Liste[i].X = Liste[i].X + 1;
                Liste[i].Y = Liste[i].Y - 1;
                Liste[i].Z = Liste[i].Z + 2;
            }

        }
    }
}
