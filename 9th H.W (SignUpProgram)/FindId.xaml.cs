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
        int creditNumber;
        DispatcherTimer timer;
        TimeSpan time;
        UsingAPI usingAPI;
        MemberDAO memberDAO;

        public FindId()
        {
            InitializeComponent();
            isFill = false;
            usingAPI = new UsingAPI();
            memberDAO = new MemberDAO();
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
                    emailTextBox.Focusable = true;
                    emailButton.IsEnabled = true;
                    confirmPanel.Visibility = Visibility.Hidden;
                }
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter)&&sender.Equals(emailTextBox))
                EmailButton_Click(sender, e);
            else if(e.Key.Equals(Key.Enter) && sender.Equals(ConfirmTextBox))
                CheckNumberButton_Click(sender, e);
        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (memberDAO.CheckEmail(emailTextBox.Text) && emailTextBox.Text.Length>8)
            {
                emailTextBox.Focusable = false;
                emailButton.IsEnabled = false;
                creditNumber = usingAPI.SendEMail(emailTextBox.Text);
                confirmPanel.Visibility = Visibility.Visible;
                SetTimer();
            }
            else
            {
                MessageBox.Show("가입되지 않은 이메일입니다!", "찾기 실패");
            }
        }

        private void CheckNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConfirmTextBox.Text.Equals(creditNumber.ToString()))
            {
                answer.Content = memberDAO.FindMember(emailTextBox.Text,Constants.SEARCH_WITH_EMAIL).Id;
                timer.Stop();
                confirmPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("인증번호가 틀렸습니다!", "실패");
                emailTextBox.Focusable = true;
                emailButton.IsEnabled = true;
            }
        }
    }
}
