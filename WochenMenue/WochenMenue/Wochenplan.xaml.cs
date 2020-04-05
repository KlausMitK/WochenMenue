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

using System.Linq;




namespace WochenMenue
{

    
    public partial class Wochenplan : Window
    {
        public static Woche gWoche = new Woche();

        

        public Wochenplan()
        {
            InitializeComponent();
            //Montag
            Binding bind0 = new Binding("Gericht");
            bind0.Source = gWoche.Montag;
            txt_0.SetBinding(TextBox.TextProperty, bind0);



            //Dienstag
            Binding bind1 = new Binding("Gericht");
            bind1.Source = gWoche.Dienstag;
            txt_1.SetBinding(TextBox.TextProperty, bind1);

            Binding bind1R = new Binding("Rezept");
            bind1R.Source = gWoche.Dienstag;
            txt_1R.SetBinding(TextBox.TextProperty, bind1R);
            


            //Mittwoch
            Binding bind2 = new Binding("Gericht");
            bind2.Source = gWoche.Mittwoch;
            txt_2.SetBinding(TextBox.TextProperty, bind2);


            Binding bind2R = new Binding("Rezept");
            bind2R.Source = gWoche.Mittwoch;
            txt_2R.SetBinding(TextBox.TextProperty, bind2R);


            //Donnerstag
            Binding bind3 = new Binding("Gericht");
            bind3.Source = gWoche.Donnerstag;
            txt_3.SetBinding(TextBox.TextProperty, bind3);

            Binding bind3R = new Binding("Rezept");
            bind3R.Source = gWoche.Donnerstag;
            txt_3R.SetBinding(TextBox.TextProperty, bind3R);


            //Freitag
            Binding bind4 = new Binding("Gericht");
            bind4.Source = gWoche.Freitag;
            txt_4.SetBinding(TextBox.TextProperty, bind4);

            Binding bind4R = new Binding("Rezept");
            bind4R.Source = gWoche.Freitag;
            txt_4R.SetBinding(TextBox.TextProperty, bind4R);


            //Samstag
            Binding bind5 = new Binding("Gericht");
            bind5.Source = gWoche.Samstag;
            txt_5.SetBinding(TextBox.TextProperty, bind5);

            Binding bind5R = new Binding("Rezept");
            bind5R.Source = gWoche.Samstag;
            txt_5R.SetBinding(TextBox.TextProperty, bind5R);


            //Sonntag
            Binding bind6 = new Binding("Gericht");
            bind6.Source = gWoche.Sonntag;
            txt_6.SetBinding(TextBox.TextProperty, bind6);

            Binding bind6R = new Binding("Rezept");
            bind6R.Source = gWoche.Sonntag;
            txt_6R.SetBinding(TextBox.TextProperty, bind6R);

            

        }

        //Buttons rezepte Hinzufügen\\
        private void BtnMoRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezMo().Show();
        }

        private void BtnDiRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezDi().Show();
        }

        private void BtnMiRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezMi().Show();
        }

        private void BtnDoRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezDo().Show();
        }

        private void BtnFrRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezFr().Show();
        }

        private void BtnSaRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezSa().Show();
        }

        private void BtnSoRez_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new RezSo().Show();
        }

        // TextBox\\

        //Gericht Montag
        private void txt_0_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Dienstag
        private void txt_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Mittwoch
        private void txt_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Donnerstag
        private void txt_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Freitag
        private void txt_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Samstag
        private void txt_5_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        //Gericht Sonntag
        private void txt_6_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        // Button zurück zum Menue
        private void btn_m_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();
        }

        //Speichern
        private void btn_s_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(Woche));

                FileStream filestream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(filestream, Wochenplan.gWoche);
                filestream.Close();
            }
        }

        //Rezept Montag
        private void txt_0R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Rezepte Dienstag
        private void txt_1R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Rezepte Mittwoch
        private void txt_2R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Rezepte Donnerstag
        private void txt_3R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Rezepte Freitag
        private void txt_4R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Rezepte Samstag
        private void txt_5R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
           
        //Rezepte Sonntag
        private void txt_6R_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        //Linq Einngabe
        private void txt_S_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_EiL_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            //new Einkaufsliste().Show();

            
        }
    }
}
