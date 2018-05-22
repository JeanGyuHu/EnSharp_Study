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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Hu_s_SignUp
{
    /// <summary>
    /// FindId.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindId : Window
    {
        bool isFill;
        DispatcherTimer timer;
        TimeSpan time;
        UsingAPI usingAPI;

        public FindId()
        {
            InitializeComponent();
            isFill = false;
            usingAPI = new UsingAPI();
        }

        private void FindId_Closing(object sender, CancelEventArgs e)
        {
            if (this.isFill)
            {
                string msg = "아이디 찾기가 진행되고 있습니다. 진짜 종료하시겠습니까?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "아이디 찾기",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                }
                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void SetTimer()
        {
            time = TimeSpan.FromSeconds(180);

            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timerLabel.Content = time.ToString(@"m\:ss");
                if (time == TimeSpan.Zero)
                {
                    timer.Stop();

                    MessageBox.Show("시간이 초과되었습니다.", "인증 실패");
                    confirmPanel.Visibility = Visibility.Hidden;
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            usingAPI.SendEMail();
            confirmPanel.Visibility = Visibility.Visible;
            SetTimer();
        }
    }
}
