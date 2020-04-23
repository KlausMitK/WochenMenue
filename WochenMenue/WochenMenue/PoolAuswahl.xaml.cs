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

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für PoolAuswahl.xaml
    /// </summary>
    public partial class PoolAuswahl : Window
    {
        public PoolAuswahl()
        {
            InitializeComponent();
        }

        private void Btn_Abb_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Aus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_Suchen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
