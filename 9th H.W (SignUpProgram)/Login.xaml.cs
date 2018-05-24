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
        MainWindow main;
        AfterLogin afterLogin;
        MemberDAO memberDAO;

        public Login(MainWindow main)
        {
            InitializeComponent();

            this.main = main;
            signUp = new SignUp(main, this);
            afterLogin = new AfterLogin(main, this);
            memberDAO = new MemberDAO();
        }
        public void InIt()
        {
            idTextBox.Clear();
            passwordBox.Clear();
        }
        private void FindId_Click(object sender, RoutedEventArgs e)
        {
            findId = new FindId();
            findId.Show();
        }

        private void FindPw_Click(object sender, RoutedEventArgs e)
        {
            findPassword = new FindPassword();
            findPassword.Show();
        }
        
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            InIt();
            signUp.InIt();
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(signUp);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (memberDAO.CheckLogin(idTextBox.Text, passwordBox.Password))
            {
                
                main.MainGrid.Children.Clear();
                afterLogin.SetId(idTextBox.Text);
                InIt();
                main.MainGrid.Children.Add(afterLogin);
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호가 틀렸습니다.", "로그인 실패");
                InIt();
            }
            
        }
    }
}
