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
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : UserControl
    {
        MainWindow main;
        Login login;

        public SignUp(MainWindow main, Login login)
        {
            InitializeComponent();
            this.main = main;
            this.login = login;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("진행중인 회원가입을 종료하시겠습니까?", "회원가입 취소",MessageBoxButton.YesNo,MessageBoxImage.Warning);

            if(result == MessageBoxResult.Yes)
            {
                main.MainGrid.Children.Clear();
                main.MainGrid.Children.Add(login);
            }
            else
            {

            }
        }
    }
}
