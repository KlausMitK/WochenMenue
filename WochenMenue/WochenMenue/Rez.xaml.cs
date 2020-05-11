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
using BusinessLogic;

namespace WochenMenue
{
    /// <summary>
    /// Interaktionslogik für Window2.xaml
    /// </summary>
    public partial class Rez : Window
    {
        //Wochenplan mParentWochenplan;
        Tag mTag;

        public Rez(Tag tag /*, Wochenplan wochenplan*/)
        {
            mTag = tag;
            //mParentWochenplan = wochenplan;
            InitializeComponent();
            lsV.ItemsSource = mTag.Zutaten;
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void lsV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
