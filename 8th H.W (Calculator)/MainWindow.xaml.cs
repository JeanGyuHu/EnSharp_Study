using System.Windows;
using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Drawing;

namespace Hu_s_Calculator1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 21자
    public partial class MainWindow : Window
    {
        private AllLogPage allLogPage;
        private MainControl mainControl;

        public MainWindow()
        {
            InitializeComponent();

            allLogPage = new AllLogPage();
            mainControl = new MainControl(allLogPage);

            allLogPage.allLog.Click += Back_ButtonClicked;
            mainControl.allLog.Click += AllLog_ButtonClicked;

            MainGrid.Children.Add(mainControl);
        }

        private void AllLog_ButtonClicked(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            allLogPage.SetTextBox(mainControl.GetBefore(),mainControl.GetNow());

            MainGrid.Children.Add(allLogPage);
        }

        private void Back_ButtonClicked(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(mainControl);
        }
       
    }
}
