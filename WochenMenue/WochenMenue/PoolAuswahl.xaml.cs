using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using Utils;
using BusinessLogic;


namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für PoolAuswahl.xaml
    /// </summary>
    public partial class PoolAuswahl : Window
    {

        //TODO: Hier brauchen wir eine Propoerty "Tag"
        public Tag Wochentag { get; set; }

        public PoolAuswahl(Tag tag)
        {
            Wochentag = tag;

            InitializeComponent();

            txt_Suchen.Focus();

            //Lade Pool (Deserialisieren)
            MainWindow.gLog.Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird geladen...");

            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(PropValues.Instance().PoolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            fileStream.Close();

            MainWindow.gLog.Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist geladen");

            //Binding
            DtG_PoA.ItemsSource = rezPool.Gerichte;
        }

        private void Btn_Abb_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Aus_Click(object sender, RoutedEventArgs e)
        {
            Gericht gericht =  (Gericht) DtG_PoA.SelectedItem;

            if (gericht != null)
            {
                MainWindow.gLog.Info("Gericht " + gericht.Name + " ausgewählt.");
                Wochentag.Gericht = gericht.Name;

                Wochentag.Zutaten.Clear();
                foreach (Zutat zutat in gericht.Zutaten)
                {
                    Wochentag.Zutaten.Add(zutat);
                }

                this.Close();
                
            }
            else
            {
                MainWindow.gLog.Error("Es wurd kein Gericht ausgewählt.");
            }
            
        }

        private void txt_Suchen_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(DtG_PoA.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Gericht p = o as Gericht;
                    return (p.Name.ToUpper().StartsWith(filter.ToUpper()));
                };
            }
        }
    }
}
