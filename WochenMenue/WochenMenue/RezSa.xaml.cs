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
    /// Interaktionslogik für Window7.xaml
    /// </summary>
    public partial class RezSa : Window
    {
        public RezSa()
        {
            InitializeComponent();
            lsV_SaR.ItemsSource = MainWindow.gWoche.Samstag.Rezept;
        }
                
        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Wochenplan().Show();
        }
    }
}
