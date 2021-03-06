﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hu_s_SignUp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        Login login;

        public MainWindow()
        {
            InitializeComponent();

            login = new Login(this);
            MainGrid.Children.Add(login);
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
                e.Cancel = false;
            
        }
    }
}
