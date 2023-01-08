using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections.ObjectModel;
using BusinessLogic;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für Einkaufsliste.xaml
    /// </summary>
    public partial class Einkaufsliste : Window
    {
        public ObservableCollection<Zutat> mEKL { get; set; }

        public Einkaufsliste(ObservableCollection<Zutat> ekl)
        {
            InitializeComponent();
            mEKL = ekl;

            BrushConverter bc = new BrushConverter();
            TextRange textRange = new TextRange(Dtg_Ekl.Document.ContentEnd, Dtg_Ekl.Document.ContentEnd);
            textRange.Text = "Einkaufsliste"+"\n";
            textRange.ApplyPropertyValue(TextElement.FontSizeProperty, "20");
            textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);


            foreach (Zutat zutat in mEKL)
            {
                bc = new BrushConverter();
                textRange = new TextRange(Dtg_Ekl.Document.ContentEnd, Dtg_Ekl.Document.ContentEnd);
                textRange.Text = zutat.ToString()+"\r";
                textRange.ApplyPropertyValue(TextElement.FontSizeProperty, "15");
                textRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            }

        }

        public void Bind()
        {
            //Bind Woche.mEKL mit entsprechendem DataGrid
            //Dtg_Ekl.  ItemsSource = MainWindow.gWoche.mEKL;
            
        }
               

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Button Drucken
        private void btn_Drucken_Click(object sender, RoutedEventArgs e)
        {
            
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                MainWindow.gLog.Info("Drucken gestartet ...");
                //use either one of the below
                //pd.PrintVisual(Dtg_Ekl as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)Dtg_Ekl.Document).DocumentPaginator), "printing as paginator");
                MainWindow.gLog.Info("Drucken beendet.");
            }
            this.Close();
        }
    }
}
