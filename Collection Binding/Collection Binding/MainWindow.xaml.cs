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

namespace Collection_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
        }

        private ObservableCollection<Point> mListe;

        public ObservableCollection<Point> Liste
        {
            get { return mListe; }
            set { mListe = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            mListe = new ObservableCollection<Point>();

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
                Point p = new Point();

                p.X = Liste[i].X + 1;
                p.Y = Liste[i].Y - 1;
                p.Z = Liste[i].Z + 2;

                Liste.RemoveAt(i);
                Liste.Insert(i, p);
            }

        }
    }
}
