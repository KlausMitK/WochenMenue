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

namespace KurvenDiskussion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Function mFunction = new Function();
        private ChartValues<double> mPvalues;
        public MainWindow()
        {
            InitializeComponent();

            
            for (int i = 0; i<6; i++)
            {
                PolynomTerm term = new PolynomTerm();
                term.coefValue = 1;
                term.expoValue = 1;
                mFunction.Terms.Add(term);
            }

            
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
        }

        public void UpdateAll()
        {
            if (mFunction.Terms.Count() == 0)
            {
                return;
            }

            try
            {
                mFunction.Terms[0].coefValue = Convert.ToDouble(tbCoef_0.Text);
                mFunction.Terms[0].expoValue = Convert.ToDouble(tbExpo_0.Text);
                mFunction.Terms[1].coefValue = Convert.ToDouble(tbCoef_1.Text);
                mFunction.Terms[1].expoValue = Convert.ToDouble(tbExpo_1.Text);
                mFunction.Terms[2].coefValue = Convert.ToDouble(tbCoef_2.Text);
                mFunction.Terms[2].expoValue = Convert.ToDouble(tbExpo_2.Text);
                mFunction.Terms[3].coefValue = Convert.ToDouble(tbCoef_3.Text);
                mFunction.Terms[3].expoValue = Convert.ToDouble(tbExpo_3.Text);
                mFunction.Terms[4].coefValue = Convert.ToDouble(tbCoef_4.Text);
                mFunction.Terms[4].expoValue = Convert.ToDouble(tbExpo_4.Text);
                mFunction.Terms[5].coefValue = Convert.ToDouble(tbCoef_5.Text);
                mFunction.Terms[5].expoValue = Convert.ToDouble(tbExpo_5.Text);
               
                for (int i = 0; i <= 20; i++)
                {
                    SeriesCollection[0].Values.RemoveAt(i);
                    SeriesCollection[0].Values.Insert(i, mFunction.Calculate(i - 10));
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
