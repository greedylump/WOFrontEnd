﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WOFrontEnd.Views
{
    /// <summary>
    /// Interaction logic for EntryView.xaml
    /// </summary>
    public partial class EntryView : UserControl
    {
        public EntryView()
        {
            InitializeComponent();
        }

        private void RepBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                RepBox.Text=string.Empty;
        }

     
    }
}
