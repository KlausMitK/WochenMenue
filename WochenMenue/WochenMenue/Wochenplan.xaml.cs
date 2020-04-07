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






namespace WochenMenue
{

    
    public partial class Wochenplan : Window
    {

        public Wochenplan()
        {
            InitializeComponent();
            Bind();
        }

        public void Bind()
        {
            //Montag
            Binding bind0 = new Binding("Gericht");
            bind0.Source = MainWindow.gWoche.Montag;
            txt_0.SetBinding(TextBox.TextProperty, bind0);

            lsV_Mo.ItemsSource = MainWindow.gWoche.Montag.Rezept;

            //Dienstag
            Binding bind1 = new Binding("Gericht");
            bind1.Source = MainWindow.gWoche.Dienstag;
            txt_1.SetBinding(TextBox.TextProperty, bind1);

            lsV_Di.ItemsSource = MainWindow.gWoche.Dienstag.Rezept;

            //Mittwoch
            Binding bind2 = new Binding("Gericht");
            bind2.Source = MainWindow.gWoche.Mittwoch;
            txt_2.SetBinding(TextBox.TextProperty, bind2);

            lsV_Mi.ItemsSource = MainWindow.gWoche.Mittwoch.Rezept;

            //Donnerstag
            Binding bind3 = new Binding("Gericht");
            bind3.Source = MainWindow.gWoche.Donnerstag;
            txt_3.SetBinding(TextBox.TextProperty, bind3);

            lsV_Do.ItemsSource = MainWindow.gWoche.Donnerstag.Rezept;

            //Freitag
            Binding bind4 = new Binding("Gericht");
            bind4.Source = MainWindow.gWoche.Freitag;
            txt_4.SetBinding(TextBox.TextProperty, bind4);

            lsV_Fr.ItemsSource = MainWindow.gWoche.Freitag.Rezept;


            //Samstag
            Binding bind5 = new Binding("Gericht");
            bind5.Source = MainWindow.gWoche.Samstag;
            txt_5.SetBinding(TextBox.TextProperty, bind5);

            lsV_Sa.ItemsSource = MainWindow.gWoche.Samstag.Rezept;


            //Sonntag
            Binding bind6 = new Binding("Gericht");
            bind6.Source = MainWindow.gWoche.Sonntag;
            txt_6.SetBinding(TextBox.TextProperty, bind6);

            lsV_So.ItemsSource = MainWindow.gWoche.Sonntag.Rezept;
        }

        //Buttons Rezepte Bearbeiten \\
        private void BtnMoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Montag, this).Show();
        }

        private void BtnDiRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Dienstag, this).Show();
        }

        private void BtnMiRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Mittwoch, this).Show();
        }

        private void BtnDoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Donnerstag, this).Show();
        }

        private void BtnFrRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Freitag, this).Show();
        }

        private void BtnSaRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Samstag, this).Show();
        }

        private void BtnSoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Sonntag, this).Show();
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

 
        private void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(Woche));

                FileStream filestream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(filestream, MainWindow.gWoche);
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

        private void Menue_File_Open_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Open();
            Bind();
        }

        private void Menue_File_Save_Click(object sender, RoutedEventArgs e)
        {
            // Wichtig ist hier, dass der Fokus aus den Data Grids auf eine anderes Element gesetzt wird, sonst wirg gWoche nicht aktualisiert.
            txt_S.Focus();
            Save();
        }

        private void Menue_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Extras -> Einkaufsliste Menue Button
        private void Menue_File_Einkaufsliste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_0_TextChanged()
        {

        }
    }
}
