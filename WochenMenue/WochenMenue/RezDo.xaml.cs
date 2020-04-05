﻿using System;
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
    /// Interaktionslogik für Window5.xaml
    /// </summary>
    public partial class RezDo : Window
    {
        public RezDo()
        {
            InitializeComponent();
            lsV_DoR.ItemsSource = Wochenplan.gWoche.Donnerstag.Rezept;
        }
             

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Wochenplan().Show();
        }
    }
}
