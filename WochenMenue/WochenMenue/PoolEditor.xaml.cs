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
using BusinessLogic;
using Utils;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für PoolEditor.xaml
    /// </summary>
    public partial class PoolEditor : Window
    {
        RezeptPool rezPool { get; set; }
        public PoolEditor()
        {
            InitializeComponent();

            //Lade Pool (Deserialisieren)
            MainWindow.gLog.Info("RezeptPool: " + PropValues.Instance().PoolPath + " wird geladen...");
            rezPool = RezeptPool.Load(PropValues.Instance().PoolPath);
            MainWindow.gLog.Info("RezeptPool: " + PropValues.Instance().PoolPath + " ist geladen");

            //Binding
            GerichtList.ItemsSource = rezPool.Gerichte;
        }

        private void GerichtList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           try
            { 
                Gericht gericht = (Gericht)GerichtList.SelectedItem;
                if (gericht != null)
                {
                    if (gericht.Zutaten.Count() > 0)
                    {
                        ZutatenList.ItemsSource = gericht.Zutaten;
                    }
                
                }
            }
            catch (System.InvalidCastException)
            {
                Gericht ger = new Gericht("XXX");
                Zutat zutat = new Zutat("xxx", 0, "yyy");
                ger.Zutaten.Add(zutat);
                rezPool.AddGericht(ger);

                ZutatenList.ItemsSource = ger.Zutaten;
            }
        }

        private void NeuGer_btn_Click(object sender, RoutedEventArgs e)
        {
            Gericht ger = new Gericht("XXX");
            Zutat zutat = new Zutat("xxx", 0, "yyy");
            ger.Zutaten.Add(zutat);
            rezPool.AddGericht(ger);
            
            ZutatenList.ItemsSource = ger.Zutaten;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            RezeptPool.Save(PropValues.Instance().PoolPath, rezPool);
        }

        private void Quit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
