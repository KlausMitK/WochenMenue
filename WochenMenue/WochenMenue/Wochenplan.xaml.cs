using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
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
            txt_GerMo.SetBinding(TextBox.TextProperty, bind0);

            lsV_Mo.ItemsSource = MainWindow.gWoche.Montag.Rezept;

            //Dienstag
            Binding bind1 = new Binding("Gericht");
            bind1.Source = MainWindow.gWoche.Dienstag;
            txt_GerDi.SetBinding(TextBox.TextProperty, bind1);

            lsV_Di.ItemsSource = MainWindow.gWoche.Dienstag.Rezept;

            //Mittwoch
            Binding bind2 = new Binding("Gericht");
            bind2.Source = MainWindow.gWoche.Mittwoch;
            txt_GerMi.SetBinding(TextBox.TextProperty, bind2);

            lsV_Mi.ItemsSource = MainWindow.gWoche.Mittwoch.Rezept;

            //Donnerstag
            Binding bind3 = new Binding("Gericht");
            bind3.Source = MainWindow.gWoche.Donnerstag;
            txt_GerDo.SetBinding(TextBox.TextProperty, bind3);

            lsV_Do.ItemsSource = MainWindow.gWoche.Donnerstag.Rezept;

            //Freitag
            Binding bind4 = new Binding("Gericht");
            bind4.Source = MainWindow.gWoche.Freitag;
            txt_GerFr.SetBinding(TextBox.TextProperty, bind4);

            lsV_Fr.ItemsSource = MainWindow.gWoche.Freitag.Rezept;


            //Samstag
            Binding bind5 = new Binding("Gericht");
            bind5.Source = MainWindow.gWoche.Samstag;
            txt_GerSa.SetBinding(TextBox.TextProperty, bind5);

            lsV_Sa.ItemsSource = MainWindow.gWoche.Samstag.Rezept;


            //Sonntag
            Binding bind6 = new Binding("Gericht");
            bind6.Source = MainWindow.gWoche.Sonntag;
            txt_GerSo.SetBinding(TextBox.TextProperty, bind6);

            lsV_So.ItemsSource = MainWindow.gWoche.Sonntag.Rezept;
        }

        // Drucken
        public void Drucken(FrameworkElement wpf_Element)
        {
            XpsDocument doc = new XpsDocument("print_previw.xps", FileAccess.ReadWrite);

            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            SerializerWriterCollator preview_Document = writer.CreateVisualsCollator();

            FixedDocumentSequence preview = doc.GetFixedDocumentSequence();

            /*preview_Document.BeginBatchWrite();

            preview_Document.Write(wpf_Element);  

            preview_Document.EndBatchWrite();*/

            var window = new Window();

            window.Content = new DocumentViewer { Document = preview };

            window.ShowDialog();

            doc.Close();
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

        private void Menue_File_Open_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Open();
            Bind();
        }

        private void Menue_File_Save_Click(object sender, RoutedEventArgs e)
        {
            // Wichtig ist hier, dass der Fokus aus den Data Grids auf eine anderes Element gesetzt wird, sonst wird gWoche nicht aktualisiert.
            txt_Suche.Focus();
            Save();
        }

        private void Menue_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Menue_File_Drucken_Click(object sender, RoutedEventArgs e)
        {
            Drucken(Grid_1);
        }

        //Extras -> Einkaufsliste Menue Button
        private void Menue_File_Einkaufsliste_Click(object sender, RoutedEventArgs e)
        {
            new Einkaufsliste().Show();
        }
    }
}
