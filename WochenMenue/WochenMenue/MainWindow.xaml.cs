using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;


namespace WochenMenue
{

    public partial class MainWindow : Window
    {

        public static Woche gWoche = new Woche();
        public static string gPoolPath = "";
        public static Logging gLog;
        public static string gIniFilePath;

        public MainWindow()
        {
            InitializeComponent();
            Bind();

            // iniFile muss im gleichen Verzeichnis wie exe-Datei leigen
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string iniDirectory = System.IO.Path.GetDirectoryName(exePath);
            gIniFilePath = iniDirectory + "\\WochenMenue.ini";

            IniFile iniFile = new IniFile(gIniFilePath);

            //TODO: Auslesen des letzten PoolPath und in gPoolPAth speichern.
            //Wenn ini-File nicht gefunden wird, wird PoolPAth auf "" gesetzt
            gPoolPath = iniFile.IniReadValue("Path", "PoolPath");

            // Logging initialisieren
            gLog = new Logging(this.TxbLog);
        }

        public void Bind()
        {

            //Montag
            /*Binding bind0 = new Binding("Gericht");
            bind0.Source = MainWindow.gWoche.Montag;
            txt_GerMo.SetBinding(TextBox.TextProperty, bind0);*/
            txt_GerMo.DataContext = MainWindow.gWoche.Montag;
            lsV_Mo.ItemsSource = MainWindow.gWoche.Montag.Zutaten;

            //Dienstag
            Binding bind1 = new Binding("Gericht");
            bind1.Source = MainWindow.gWoche.Dienstag;
            txt_GerDi.SetBinding(TextBox.TextProperty, bind1);

            lsV_Di.ItemsSource = MainWindow.gWoche.Dienstag.Zutaten;

            //Mittwoch
            Binding bind2 = new Binding("Gericht");
            bind2.Source = MainWindow.gWoche.Mittwoch;
            txt_GerMi.SetBinding(TextBox.TextProperty, bind2);

            lsV_Mi.ItemsSource = MainWindow.gWoche.Mittwoch.Zutaten;

            //Donnerstag
            Binding bind3 = new Binding("Gericht");
            bind3.Source = MainWindow.gWoche.Donnerstag;
            txt_GerDo.SetBinding(TextBox.TextProperty, bind3);

            lsV_Do.ItemsSource = MainWindow.gWoche.Donnerstag.Zutaten;

            //Freitag
            Binding bind4 = new Binding("Gericht");
            bind4.Source = MainWindow.gWoche.Freitag;
            txt_GerFr.SetBinding(TextBox.TextProperty, bind4);

            lsV_Fr.ItemsSource = MainWindow.gWoche.Freitag.Zutaten;


            //Samstag
            Binding bind5 = new Binding("Gericht");
            bind5.Source = MainWindow.gWoche.Samstag;
            txt_GerSa.SetBinding(TextBox.TextProperty, bind5);

            lsV_Sa.ItemsSource = MainWindow.gWoche.Samstag.Zutaten;


            //Sonntag
            Binding bind6 = new Binding("Gericht");
            bind6.Source = MainWindow.gWoche.Sonntag;
            txt_GerSo.SetBinding(TextBox.TextProperty, bind6);

            lsV_So.ItemsSource = MainWindow.gWoche.Sonntag.Zutaten;
        }


        //Buttons Rezepte Bearbeiten \\
        private void BtnMoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Montag).Show();
        }

        private void BtnDiRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Dienstag).Show();
        }

        private void BtnMiRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Mittwoch).Show();
        }

        private void BtnDoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Donnerstag).Show();
        }

        private void BtnFrRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Freitag).Show();
        }

        private void BtnSaRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Samstag).Show();
        }

        private void BtnSoRez_Click(object sender, RoutedEventArgs e)
        {
            new Rez(MainWindow.gWoche.Sonntag).Show();
        }

        private void Save()
        {
            //TODO: Muss geändert werden. Entscheiden, ob EKL gespeichert wird, oder nicht.
            MainWindow.gWoche.mEKL.Clear();

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

        // Datein Laden
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(Woche));
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                MainWindow.gWoche = (Woche)serializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }


        private void Menue_File_Open_Click(object sender, RoutedEventArgs e)
        {
            Open();
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


        //Extras -> Einkaufsliste Menue Button
        private void Menue_File_Einkaufsliste_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gWoche.GenerateEKL();
            new Einkaufsliste().Show();
        }

        private void txt_Suche_TextChanged(object sender, TextChangedEventArgs e)
        {
            string suchString = txt_Suche.Text;

            //Selektion der Such-Ergebnisse in der Montagsliste
            SelectFoundCells(lsV_Mo, suchString);
            SelectFoundCells(lsV_Di, suchString);
            SelectFoundCells(lsV_Mi, suchString);
            SelectFoundCells(lsV_Do, suchString);
            SelectFoundCells(lsV_Fr, suchString);
            SelectFoundCells(lsV_Sa, suchString);
            SelectFoundCells(lsV_So, suchString);
        }

        private void SelectFoundCells(DataGrid datagrid, string suchString)
        {

            //Liste der selektieren Zellen vor der Suche Löschen (falls vorher schon gesucht wurde, muss die Selektion rückgängig gemacht werden).
            datagrid.SelectedCells.Clear();

            // Nur wenn der Suchstring vom Leerstring verschieden ist, soll gesucht werden
            if (suchString == "")
            {
                return;
            }

            // Suche des Suchstrings in den Namen der Zutaten und Selektion der entsprechenden Zeile wenn es passt.
            foreach (var item in datagrid.Items)
            {
                if (!(item is Zutat))
                {
                    return;
                }

                Zutat zutat = (Zutat)item;

                if (zutat.Name.Contains(suchString))
                {
                    datagrid.CurrentCell = new DataGridCellInfo(item, datagrid.Columns[0]);
                    datagrid.SelectedCells.Add(datagrid.CurrentCell);
                }
            }
        }

        private void GerichtInPool(Tag tag)
        {
            string GerichtName = tag.Gericht;

            Gericht gericht = new Gericht(GerichtName);
            foreach (Zutat zutat in tag.Zutaten)
            {
                gericht.Zutaten.Add(zutat);
            }

            MainWindow.gLog.Info("RezeptPool: " + gPoolPath + " wird geladen...");

            RezeptPool rezPool = new RezeptPool();
            XmlSerializer serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream fileStream = new FileStream(MainWindow.gPoolPath, FileMode.Open);
            rezPool = (RezeptPool)serializer.Deserialize(fileStream);
            fileStream.Close();

            MainWindow.gLog.Info("RezeptPool: " + gPoolPath + " ist geladen");

            if (rezPool.FindeGericht(GerichtName) == null)
            {
                rezPool.AddGericht(gericht);
            }
            else
            {
                MainWindow.gLog.Warning("Das Gericht " + GerichtName + " ist bereits im RezeptPool vorhanden");
                return; // Das folgende muss in dem Fall nicht mehr gemacht werden.
            }


            MainWindow.gLog.Info("RezeptPool: " + gPoolPath + " wird aktualisiert ...");

            serializer = new XmlSerializer(typeof(RezeptPool));
            FileStream filestream = new FileStream(MainWindow.gPoolPath, FileMode.Create);
            serializer.Serialize(filestream, rezPool);
            filestream.Close();

            MainWindow.gLog.Info("RezeptPool: " + gPoolPath + " ist aktualisiert");
        }

        // Stackpanel --> Hizufügen
        private void Menue_File_Eigenschaften_Click(object sender, RoutedEventArgs e)
        {
            new Eigenschaften().Show();
        }

        //Gericht aus Pool Buttons
        private void BtnAPoMo_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Montag).ShowDialog();
            
        }

        private void BtnAPoDI_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Dienstag).ShowDialog();
        }

        private void BtnAPoMI_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Mittwoch).ShowDialog();
        }

        private void BtnAPoDo_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Donnerstag).ShowDialog();
        }

        private void BtnAPoFr_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Freitag).ShowDialog();
        }

        private void BtnAPoSa_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Samstag).ShowDialog();
        }

        private void BtnAPoSo_Click(object sender, RoutedEventArgs e)
        {
            new PoolAuswahl(MainWindow.gWoche.Sonntag).ShowDialog();
        }

        // Gericht Pool Hizufügen Buttons
        private void BtnZoMo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gLog.Info("Start Hinzufügen Gericht Montag ...");
            GerichtInPool(gWoche.Montag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Montag.");
        }

        private void BtnZoDi_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben.
            MainWindow.gLog.Info("Start Hinzufügen Gericht Dienstag ...");
            GerichtInPool(gWoche.Dienstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Dienstag.");
        }

        private void BtnZoMi_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben.
            MainWindow.gLog.Info("Start Hinzufügen Gericht Mittwoch ...");
            GerichtInPool(gWoche.Mittwoch);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Mittwoch.");
        }

        private void BtnZoDo_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben.
            MainWindow.gLog.Info("Start Hinzufügen Gericht Donnerstag ...");
            GerichtInPool(gWoche.Donnerstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Donnerstag.");
        }

        private void BtnZoFr_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben
            MainWindow.gLog.Info("Start Hinzufügen Gericht Freitag ...");
            GerichtInPool(gWoche.Freitag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Freitag.");
        }

        private void BtnZoSa_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben.
            MainWindow.gLog.Info("Start Hinzufügen Gericht Samstag ...");
            GerichtInPool(gWoche.Samstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Samstag.");
        }

        private void BtnZoSo_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Dominik: Info ins Logging schreiben.
            MainWindow.gLog.Info("Start Hinzufügen Gericht Sonntag ...");
            GerichtInPool(gWoche.Sonntag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Sonntag.");
        }

        private void TxbLog_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void TxbLog_TouchEnter(object sender, TouchEventArgs e)
        {

        }
    }
}
