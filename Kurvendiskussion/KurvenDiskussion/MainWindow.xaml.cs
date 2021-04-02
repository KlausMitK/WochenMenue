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
        public MainWindow()
        {
            InitializeComponent();

            PolynomTerm term1 = new PolynomTerm();
            term1.coefValue = 2d;
            term1.expoValue = 2;

            PolynomTerm term2 = new PolynomTerm();
            term2.coefValue = -3d;
            term2.expoValue = 1;
            
            PolynomTerm term3 = new PolynomTerm();
            term3.coefValue = 4d;
            term3.expoValue = 0;

            Function fX = new Function();
            fX.Terms.Add(term1);
                
                
            fX.Terms.Add(term2);
            fX.Terms.Add(term3);

            //double y = fX.Calculate(9d);

            ChartValues<double> Pvalues = new ChartValues<double>();
            Labels = new List<string>();

            for (int i = -10; i<=10; i++)
            {
                Pvalues.Add(fX.Calculate(i));
                Labels.Add(Convert.ToString(i));
            }

            LineSeries lineSeries = new LineSeries();
            lineSeries.Values = Pvalues;
            lineSeries.Title = "f(x)";
            lineSeries.PointGeometry = null;

            SeriesCollection serCol = new SeriesCollection();
            serCol.Add(lineSeries);

            SeriesCollection = serCol;

            //Labels = new[] { "1", "2", "3", "4", "5" };
            YFormatter = value => value.ToString("C");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        
    }
}
