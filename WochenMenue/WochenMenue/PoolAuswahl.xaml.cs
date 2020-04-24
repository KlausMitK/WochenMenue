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
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;


namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für PoolAuswahl.xaml
    /// </summary>
    public partial class PoolAuswahl : Window
    {

        //TODO: Hier brauchen wir eine Propoerty "Tag"

        public PoolAuswahl()
        {
            InitializeComponent();

            //Lade Pool (Deserialisieren)
            MainWindow.gLog.Info("RezeptPool: " + MainWindow.gPoolPath + " wird geladen...");

            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(MainWindow.gPoolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            fileStream.Close();

            MainWindow.gLog.Info("RezeptPool: " + MainWindow.gPoolPath + " ist geladen");

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
                MainWindow.gWoche.Montag.Gericht = gericht.Name;

                foreach (Zutat zutat in gericht.Zutaten)
                {
                    MainWindow.gWoche.Montag.Zutaten.Add(zutat);
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

        }
    }
}
