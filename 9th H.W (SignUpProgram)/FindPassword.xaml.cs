using System;
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
    /// FindPassword.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindPassword : Window
    {
        bool isFill;
        DispatcherTimer timer;
        TimeSpan time;

        public FindPassword()
        {
            InitializeComponent();
            isFill = false;
        }

        private void FindId_Closing(object sender, CancelEventArgs e)
        {
            if (this.isFill)
            {
                string msg = "아이디 찾기가 진행되고 있습니다. 진짜 종료하시겠습니까?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
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
                if (time == TimeSpan.Zero) timer.Stop();
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            timer.Start();
        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            confirmPanel.Visibility = Visibility.Visible;
            SetTimer();
        }
    }
}
