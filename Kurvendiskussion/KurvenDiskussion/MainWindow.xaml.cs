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
using LiveCharts;
using LiveCharts.Wpf;
using MathBib;
using System.Collections.ObjectModel;

namespace KurvenDiskussion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    // TODO: Im MainWindow brauchen wir auch noch ein Ausgabe für die zweite Ableitung
    public partial class MainWindow : Window
    {
        private IMathFunc mFunction = new Function();
        private IMathFunc mDerivative;
        private ChartValues<double> mPvalues;

        private ObservableCollection<DPoint> mPoints;

        public ObservableCollection<DPoint> Points
        {
            get { return mPoints; }
            set { mPoints = value; }
        }

        
        public IMathFunc TheFunction
        {
            get { return mFunction; }
            set { mFunction = value; }
        }

        public IMathFunc TheDerivative
        {
            get { return mDerivative; }
            set { mDerivative = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
                                    
            for (int i = 0; i<6; i++)
            {
                PolynomTerm term = new PolynomTerm();
                term.coefValue = 0;
                term.expoValue = 0;
                mFunction.Terms.Add(term);
                TheDerivative = TheFunction.Derivative();
            }

            mPoints = new ObservableCollection<DPoint>(); 
            /*DPoint p1 = new DPoint();
            p1.xValue = 1;
            p1.yValue = 1;
            p1.PType = DPoint.PointType.NullPoint;
            Points.Add(p1);

            DPoint p2 = new DPoint();
            p2.xValue = 2;
            p2.yValue = 2;
            p2.PType = DPoint.PointType.Minimum;
            Points.Add(p2);

            DPoint p3 = new DPoint();
            p3.xValue = 3;
            p3.yValue = 3;
            p3.PType = DPoint.PointType.Maximum;
            Points.Add(p3);

            DPoint p4 = new DPoint();
            p4.xValue = 4;
            p4.yValue = 4;
            p4.PType = DPoint.PointType.Inflection;
            Points.Add(p4);*/

            mPvalues = new ChartValues<double>();
            Labels = new List<string>();

            for (int i = -10; i<=10; i++)
            {
                mPvalues.Add(mFunction.Calculate(i));
                Labels.Add(Convert.ToString(i));
            }

            LineSeries lineSeries = new LineSeries();
            lineSeries.Values = mPvalues;
            lineSeries.Title = "f(x)";
            lineSeries.PointGeometry = null;

            SeriesCollection serCol = new SeriesCollection();
            serCol.Add(lineSeries);

            SeriesCollection = serCol;

            //Labels = new[] { "1", "2", "3", "4", "5" };
            YFormatter = value => value.ToString("C");

            DataContext = this;
            Dtg_Points.ItemsSource = Points;
        }

        public void UpdateAll()
        {
            if (mFunction.Terms.Count() == 0)
            {
                return;
            }

            try
            {
                TheFunction.Terms[0].coefValue = Convert.ToDouble(tbCoef_0.Text);
                TheFunction.Terms[0].expoValue = Convert.ToDouble(tbExpo_0.Text);
                TheFunction.Terms[1].coefValue = Convert.ToDouble(tbCoef_1.Text);
                TheFunction.Terms[1].expoValue = Convert.ToDouble(tbExpo_1.Text);
                TheFunction.Terms[2].coefValue = Convert.ToDouble(tbCoef_2.Text);
                TheFunction.Terms[2].expoValue = Convert.ToDouble(tbExpo_2.Text);
                TheFunction.Terms[3].coefValue = Convert.ToDouble(tbCoef_3.Text);
                TheFunction.Terms[3].expoValue = Convert.ToDouble(tbExpo_3.Text);
                TheFunction.Terms[4].coefValue = Convert.ToDouble(tbCoef_4.Text);
                TheFunction.Terms[4].expoValue = Convert.ToDouble(tbExpo_4.Text);
                TheFunction.Terms[5].coefValue = Convert.ToDouble(tbCoef_5.Text);
                TheFunction.Terms[5].expoValue = Convert.ToDouble(tbExpo_5.Text);

                TheDerivative = TheFunction.Derivative();
               
                for (int i = 0; i <= 20; i++)
                {
                    SeriesCollection[0].Values.RemoveAt(i);
                    SeriesCollection[0].Values.Insert(i, mFunction.Calculate(i - 10));
                }

                // Test
                if (Points.Count > 0)
                Points.Clear();

                ObservableCollection<DPoint> list = TheFunction.NullPoints();
                foreach (DPoint p in list)
                {
                    Points.Add(p);
                }

                foreach (DPoint p in TheFunction.Extrema())
                {
                    Points.Add(p);
                }

                

            }
            catch(FormatException)
            {

            }
        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private void tbCoef_0_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();
        }

        private void tbCoef_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbCoef_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbCoef_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbCoef_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbCoef_5_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_0_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        private void tbExpo_5_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAll();

        }

        //Abgeleitete Koeffizienten
        private void tbCoefDer_0_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCoefDer_1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCoefDer_2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCoefDer_3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCoefDer_4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCoefDer_5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Abgeleitet Exponenten
        private void tbExpoDer_0_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbExpoDer_1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbExpoDer_2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbExpoDer_3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbExpoDer_4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbExpoDer_5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
