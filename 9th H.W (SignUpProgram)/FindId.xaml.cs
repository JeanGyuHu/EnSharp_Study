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

namespace Hu_s_SignUp
{
    /// <summary>
    /// FindId.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindId : Window
    {
        bool isFill;
        
        public FindId()
        {
            InitializeComponent();
            isFill = false;
        }

        private void FindId_Closing(object sender, CancelEventArgs e)
        {
            
            MessageBox.Show("아이디 검색을 종료합니다.");
            e.Cancel = true;

            if (this.isFill)
            {
                string msg = "Data is dirty. Close without saving?";
                MessageBoxResult result =
                  MessageBox.Show(
                    msg,
                    "Data App",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    // If user doesn't want to close, cancel closure
                    e.Cancel = true;
                }
            }
        }
    }
}
