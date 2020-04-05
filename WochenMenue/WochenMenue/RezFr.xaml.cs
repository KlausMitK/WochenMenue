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
    /// Interaktionslogik für Window6.xaml
    /// </summary>
    public partial class RezFr : Window
    {
        public RezFr()
        {
            InitializeComponent();

            Binding bind4R = new Binding("Rezept");
            bind4R.Source = Wochenplan.gWoche.Freitag;
            txt_0.SetBinding(TextBox.TextProperty, bind4R);
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
