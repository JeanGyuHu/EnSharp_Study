using System;
using System.Collections.Generic;
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
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : UserControl
    {
        FindId findId;
        FindPassword findPassword;
        SignUp signUp;

        public Login()
        {
            InitializeComponent();
            findId = new FindId();
            findPassword = new FindPassword();
            signUp = new SignUp();
        }

        private void FindId_Click(object sender, RoutedEventArgs e)
        {
            findId.Show();
        }

        private void FindPw_Click(object sender, RoutedEventArgs e)
        {
            findPassword.Show();
        }
        
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            signUp.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
