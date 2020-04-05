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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class RezMo : Window
    {
        public RezMo()
        {
            InitializeComponent();

            /*Binding bind0R = new Binding("Rezept");
            bind0R.Source = Wochenplan.gWoche.Montag;
            txt_1.SetBinding(TextBox.TextProperty, bind0R);*/

            lsV_Mo.ItemsSource = Wochenplan.gWoche.Montag.Rezept;
        }

      


        private void txt_1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            new Wochenplan().Show();
            
        }
    }
}
