using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Serialization;
using Utils;
using BusinessLogic;
using System.Windows.Navigation;

namespace WochenMenue
{

    public partial class MainWindow : Window
    {

        public static Woche gWoche = new Woche();

        public static Logging gLog;
        //public static string gIniFilePath="";
        public static ILogOutput outputRTB; 

        public MainWindow()
        {
            InitializeComponent();
            Bind();

            PropValues prop = PropValues.Instance();
            
            // iniFile muss im gleichen Verzeichnis wie exe-Datei leigen
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string iniDirectory = System.IO.Path.GetDirectoryName(exePath);
            IniFile.gIniFileName = iniDirectory + "\\WochenMenue.ini";

            outputRTB = new LogOutputRTB(TxbLog);
            gLog = Logging.Instance();
            gLog.SetOutputcontainer(outputRTB);
            
        }

        public void Bind()
        {
            // Damit der Window Title auf den SavePAth gesetzt wird.
            this.DataContext = PropValues.Instance();

            //Montag
            txt_GerMo.DataContext = gWoche.Montag;
            lsV_Mo.ItemsSource = gWoche.Montag.Zutaten;

            //Dienstag
            txt_GerDi.DataContext = gWoche.Dienstag;
            lsV_Di.ItemsSource = gWoche.Dienstag.Zutaten;

            //Mittwoch
            txt_GerMi.DataContext = gWoche.Mittwoch;
            lsV_Mi.ItemsSource = gWoche.Mittwoch.Zutaten;


            //Donnerstag
            txt_GerDo.DataContext = gWoche.Donnerstag;
            lsV_Do.ItemsSource = gWoche.Donnerstag.Zutaten;


            //Freitag
            txt_GerFr.DataContext = gWoche.Freitag;
            lsV_Fr.ItemsSource = gWoche.Freitag.Zutaten;

            //Samstag
            txt_GerSa.DataContext = gWoche.Samstag;
            lsV_Sa.ItemsSource = gWoche.Samstag.Zutaten;

            //Sonntag
            txt_GerSo.DataContext = gWoche.Sonntag;
            lsV_So.ItemsSource = gWoche.Sonntag.Zutaten;
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

        // Datein Laden
        public void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                LoadSaveFile loadSaveFile = new Utils.LoadSaveFile();
                MainWindow.gWoche = loadSaveFile.Load(fileName);
                
            }
            Bind();
        }


        private void Menue_File_Open_Click(object sender, RoutedEventArgs e)
        {
            if (PropValues.Instance().SavePath != "")
            {
                // Fragen, ob gespeichert werden soll, dann ggfl. Speichern.

                MessageBoxResult result = MessageBox.Show("Soll die geöffnete Datei gespeichert werden?", "WochenMenue", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        LoadSaveFile loadSvaeFile = new LoadSaveFile();
                        loadSvaeFile.Save(MainWindow.gWoche, PropValues.Instance().SavePath);
                        gWoche = new Woche();
                        PropValues.Instance().SavePath = "";
                        Bind();
                        Open();
                        break;
                    case MessageBoxResult.No:
                        gWoche = new Woche();
                        PropValues.Instance().SavePath = "";
                        Bind();
                        Open();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            else
            {
                Open(); 
            }
        }


        private void Menue_File_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //Extras -> Einkaufsliste Menue Button
        private void Menue_File_Einkaufsliste_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gWoche.GenerateEKL();
            new Einkaufsliste(MainWindow.gWoche.mEKL).ShowDialog();
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
            RezeptPoolHelper rezPoolHelper = new Utils.RezeptPoolHelper();
            rezPoolHelper.GerichtInPool(tag);
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
            MainWindow.gLog.Info("Start Hinzufügen Gericht Dienstag ...");
            GerichtInPool(gWoche.Dienstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Dienstag.");
        }

        private void BtnZoMi_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gLog.Info("Start Hinzufügen Gericht Mittwoch ...");
            GerichtInPool(gWoche.Mittwoch);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Mittwoch.");
        }

        private void BtnZoDo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gLog.Info("Start Hinzufügen Gericht Donnerstag ...");
            GerichtInPool(gWoche.Donnerstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Donnerstag.");
        }

        private void BtnZoFr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gLog.Info("Start Hinzufügen Gericht Freitag ...");
            GerichtInPool(gWoche.Freitag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Freitag.");
        }

        private void BtnZoSa_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gLog.Info("Start Hinzufügen Gericht Samstag ...");
            GerichtInPool(gWoche.Samstag);
            MainWindow.gLog.Info("Ende Hinzufügen Gericht Samstag.");
        }

        private void BtnZoSo_Click(object sender, RoutedEventArgs e)
        {
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        //Speichern unter
        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;

                XmlSerializer serializer = new XmlSerializer(typeof(Woche));

                LoadSaveFile loadSaveFile = new LoadSaveFile();
                loadSaveFile.Save(MainWindow.gWoche, fileName);
                PropValues.Instance().SavePath = fileName;
            }
        }
                        

        //Speichern 
        private void Menue_File_Save_Click(object sender, RoutedEventArgs e)
        {
            txt_Suche.Focus();
            if(PropValues.Instance().SavePath == "")
            {
                // Beim ersten mal, muus der Speicher-Dialog geöffnet werden.
                SaveAs();
            }
            else  // ... später kann einfach in den bekannte nSpeicherpfad gespeichert werden.
            {
                LoadSaveFile loadSaveFile = new LoadSaveFile();
                loadSaveFile.Save(MainWindow.gWoche, PropValues.Instance().SavePath);
            }
            
        }

        // Speichern unter
        private void Menue_File_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            // Wichtig ist hier, dass der Fokus aus den Data Grids auf eine anderes Element gesetzt wird, sonst wird gWoche nicht aktualisiert.
            txt_Suche.Focus();
            SaveAs();
        }
    }
}
