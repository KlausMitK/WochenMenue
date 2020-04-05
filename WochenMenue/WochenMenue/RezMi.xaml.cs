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
    /// Interaktionslogik für Window4.xaml
    /// </summary>
    public partial class RezMi : Window
    {
        public RezMi()
        {
            InitializeComponent();

            Binding bind2R = new Binding("Rezept");
            bind2R.Source = Wochenplan.gWoche.Mittwoch;
            txt_0.SetBinding(TextBox.TextProperty, bind2R);
        }

        private void txt_0_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Wochenplan().Show(); 
        }
    }
}
