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
    /// AfterLogin.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AfterLogin : UserControl
    {
        Login login;
        MainWindow main;
        EditInformation editInformation;
        MemberDAO memberDAO;
        string id; 

        public AfterLogin(MainWindow main, Login login)
        {
            InitializeComponent();
            this.login = login;
            this.main = main;
            memberDAO = new MemberDAO();
            editInformation = new EditInformation();
            editInformation.backButton.Click += EditBackButton_Click;
            editInformation.signButton.Click += EditEndButton_Click;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(login);
        }
        private void EditBackButton_Click(object sender, RoutedEventArgs e)
        {
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(this);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(editInformation);
            editInformation.InitTextBoxes(memberDAO.FindMember(id,Constants.SEARCH_WITH_ID));
        }

        private void EditEndButton_Click(object sender, RoutedEventArgs e)
        {
            editInformation.Edit();
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(this);
        }

        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("정말 탈퇴하시겠습니까?", "경고", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result.Equals(MessageBoxResult.Yes))
            {
                memberDAO.DeleteMember(id);
                main.MainGrid.Children.Clear();
                main.MainGrid.Children.Add(login);
            }
            else
            {

            }

        }

        public void SetId(string id)
        {
            this.id = id;
        }
    }
}
