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
        FindAddress findAddress;
        ExceptionHandler exceptionHandler;
        MemberDAO memberDAO;

        bool nameFlag = false, pwFlag = false, idFlag = false, resinumFlag = false, AddressFlag = false, phoneFlag =false,emailFlag = false;

        public SignUp(MainWindow main, Login login)
        {
            InitializeComponent();
            this.main = main;
            this.login = login;
            exceptionHandler = new ExceptionHandler();
            memberDAO = new MemberDAO();
        }

        public void InIt()
        {
            alarm.Content = "";
            idText.Clear();
            idText.BorderBrush = Brushes.Red;
            pwText.Clear();
            pwText.BorderBrush = Brushes.Red;
            pw2Text.Clear();
            pw2Text.BorderBrush = Brushes.Red;
            nameText.Clear();
            nameText.BorderBrush = Brushes.Red;
            frontResinum.Clear();
            frontResinum.BorderBrush = Brushes.Red;
            behindResinum.Clear();
            behindResinum.BorderBrush = Brushes.Red;
            addressNumberText.Clear();
            addressText.Clear();
            addressDetailText.Clear();
            addressDetailText.BorderBrush = Brushes.Red;
            phone1.Clear();
            phone1.BorderBrush = Brushes.Red;
            phone2.Clear();
            phone2.BorderBrush = Brushes.Red;
            phone3.Clear();
            phone3.BorderBrush = Brushes.Red;
            frontEmail.Clear();
            frontEmail.BorderBrush = Brushes.Red;
            behindEmail.Clear();
            emailComboBox.Text ="";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("진행중인 회원가입을 종료하시겠습니까?", "회원가입 취소", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                main.MainGrid.Children.Clear();
                main.MainGrid.Children.Add(login);
            }
            else
            {

            }
        }

        private void FindAddress_Click(object sender, RoutedEventArgs e)
        {
            findAddress = new FindAddress(this);
            findAddress.Show();
        }

        private void IdText_LostFocus(object sender, RoutedEventArgs e)
        {
            switch (exceptionHandler.CheckId(idText.Text))
            {
                case Constants.ERROR_ID_LENGTH:
                    alarm.Content = "길이 제한 (5 ~ 15)";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    idFlag = false;
                    break;
                case Constants.ERROR_ID_SPECIAL:
                    alarm.Content = "특수 문자 불가능";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    idFlag = false;
                    break;
                case Constants.ERROR_ID_ALREADY:
                    alarm.Content = "이미 가입되어있는 아이디";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    idFlag = false;
                    break;
                case Constants.ERROR_ID_SPACE:
                    alarm.Content = "공백 불가능";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    idFlag = false;
                    break;
                case Constants.ERRO_ID_KOREAN:
                    alarm.Content = "한글 불가능";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    idFlag = false;
                    break;
                case Constants.SUCCESS_ID:
                    alarm.Content = "성공";
                    alarm.Foreground = Brushes.Green;
                    idText.BorderBrush = Brushes.Green;
                    idFlag = true;
                    break;
            }
            CheckFlag();
        }

        private void PwText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!pwText.Text.Equals(pw2Text.Text))
            {
                alarm.Content = "비밀번호가 다릅니다";
                alarm.Foreground = Brushes.Red;
                pwText.BorderBrush = Brushes.Red;
                pw2Text.BorderBrush = Brushes.Red;
                pwFlag = false;
                return;
            }
            
            switch (exceptionHandler.CheckPw(pwText.Text))
            {
                case Constants.ERROR_PW_LENGTH:
                    alarm.Content = "길이 제한 (5 ~ 15)";
                    alarm.Foreground = Brushes.Red;
                    ((TextBox)sender).BorderBrush = Brushes.Red;
                    pwFlag = false;
                    break;
                case Constants.ERROR_PW_KOREAN:
                    alarm.Content = "한글 불가능";
                    alarm.Foreground = Brushes.Red;
                    ((TextBox)sender).BorderBrush = Brushes.Red;
                    pwFlag = false;
                    break;

                case Constants.ERROR_PW_SPACE:
                    alarm.Content = "공백 불가능";
                    alarm.Foreground = Brushes.Red;
                    ((TextBox)sender).BorderBrush = Brushes.Red;
                    pwFlag = false;
                    break;
                case Constants.SUCCESS_PW:
                    alarm.Content = "성공";
                    alarm.Foreground = Brushes.Green;
                    pwText.BorderBrush = Brushes.Green;
                    pw2Text.BorderBrush = Brushes.Green;
                    pwFlag = true;
                    break;
            }

            CheckFlag();
        }

        private void NameText_LostFocus(object sender, RoutedEventArgs e)
        {
            switch (exceptionHandler.CheckName(nameText.Text))
            {
                case Constants.ERROR_NAME_LENGTH:
                    alarm.Content = "길이 제한 (2 ~ 5)";
                    alarm.Foreground = Brushes.Red;
                    nameText.BorderBrush = Brushes.Red;
                    nameFlag = false;
                    break;
                case Constants.ERROR_NAME_NOTKOREAN:
                    alarm.Content = "한글만 가능";
                    alarm.Foreground = Brushes.Red;
                    nameText.BorderBrush = Brushes.Red;
                    nameFlag = false;
                    break;

                case Constants.ERROR_NAME_SPACE:
                    alarm.Content = "공백 불가능";
                    alarm.Foreground = Brushes.Red;
                    nameText.BorderBrush = Brushes.Red;
                    nameFlag = false;
                    break;
                case Constants.SUCCESS_NAME:
                    alarm.Content = "성공";
                    alarm.Foreground = Brushes.Green;
                    nameText.BorderBrush = Brushes.Green;
                    nameFlag = true;
                    break;
            }
            CheckFlag();
        }

        private void SignButton_Click(object sender, RoutedEventArgs e)
        {
            memberDAO.AddMember(new MemberVO(idText.Text, pw2Text.Text, nameText.Text, frontResinum.Text + behindResinum.Text, addressNumberText.Text, addressText.Text, addressDetailText.Text, phone1.Text + phone2.Text + phone3.Text, frontEmail.Text + "@" + behindEmail.Text));
            MessageBox.Show("회원가입에 성공하였습니다!", "회원가입 성공!");
            main.MainGrid.Children.Clear();
            main.MainGrid.Children.Add(login);
        }

        private void Resinum_LostFocus(object sender, RoutedEventArgs e)
        {

            string residentNumber = frontResinum.Text + behindResinum.Text;

            switch (exceptionHandler.CheckResidentNumber(residentNumber))
            {
                case Constants.ERROR_RESINUM_ALREADY:
                    alarm.Content = "이미 가입된 회원입니다.";
                    alarm.Foreground = Brushes.Red;
                    frontResinum.BorderBrush = Brushes.Red;
                    behindResinum.BorderBrush = Brushes.Red;
                    resinumFlag = false;
                    break;
                case Constants.ERROR_RESINUM_FORMAT:
                    alarm.Content = "형식을 확인하세요.";
                    alarm.Foreground = Brushes.Red;
                    frontResinum.BorderBrush = Brushes.Red;
                    behindResinum.BorderBrush = Brushes.Red;
                    resinumFlag = false;
                    break;
                case Constants.SUCCESS_RESINUM:
                    alarm.Content = "성공";
                    alarm.Foreground = Brushes.Green;
                    frontResinum.BorderBrush = Brushes.Green;
                    behindResinum.BorderBrush = Brushes.Green;
                    resinumFlag = true;
                    break;
            }
            CheckFlag();
        }

        private void AddressDetailText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (addressDetailText.Text.Length < 5&&(addressText.Text.Length==0||addressNumberText.Text.Length==0))
            {
                alarm.Content = "너무 짧습니다.";
                alarm.Foreground = Brushes.Red;
                addressDetailText.BorderBrush = Brushes.Red;
                AddressFlag = false;
            }
            else
            {
                alarm.Content = "성공";
                alarm.Foreground = Brushes.Green;
                addressDetailText.BorderBrush = Brushes.Green;
                AddressFlag = true;
            }
            CheckFlag();
        }

        private void Phone_LostFocus(object sender, RoutedEventArgs e)
        {
            string phone = phone1.Text + phone2.Text + phone3.Text;

            if (exceptionHandler.CheckPhoneNumber(phone))
            {
                alarm.Content = "성공";
                alarm.Foreground = Brushes.Green;

                phone1.BorderBrush = Brushes.Green;
                phone2.BorderBrush = Brushes.Green;
                phone3.BorderBrush = Brushes.Green;
                phoneFlag = true;
            }

            else
            {
                alarm.Content = "형식을 확인하세요.";
                alarm.Foreground = Brushes.Red;
                phone1.BorderBrush = Brushes.Red;
                phone2.BorderBrush = Brushes.Red;
                phone3.BorderBrush = Brushes.Red;
                phoneFlag = false;
            }
            CheckFlag();
        }

        private void Email_LostFocus(object sender, RoutedEventArgs e)
        {
            string email = frontEmail.Text + "@" + behindEmail.Text;

            switch (exceptionHandler.CheckEmail(email))
            {
                case Constants.ERROR_EMAIL_LENGTH:
                    alarm.Content = "길이 제한 (5 ~ 15)";
                    alarm.Foreground = Brushes.Red;
                    frontEmail.BorderBrush = Brushes.Red;
                    emailFlag = false;
                    break;
                case Constants.ERROR_EMAIL_SPECIAL:
                    alarm.Content = "특수 문자 불가능";
                    alarm.Foreground = Brushes.Red;
                    frontEmail.BorderBrush = Brushes.Red;
                    emailFlag = false;
                    break;
                case Constants.ERROR_EMAIL_ALREADY:
                    alarm.Content = "이미 가입되어있는 아이디";
                    alarm.Foreground = Brushes.Red;
                    frontEmail.BorderBrush = Brushes.Red;
                    emailFlag = false;
                    break;
                case Constants.ERROR_EMAIL_SPACE:
                    alarm.Content = "공백 불가능";
                    alarm.Foreground = Brushes.Red;
                    frontEmail.BorderBrush = Brushes.Red;
                    emailFlag = false;
                    break;
                case Constants.ERROR_EMAIL_KOREAN:
                    alarm.Content = "한글 불가능";
                    alarm.Foreground = Brushes.Red;
                    idText.BorderBrush = Brushes.Red;
                    emailFlag = false;
                    break;
                case Constants.SUCCESS_EMAIL:
                    alarm.Content = "성공";
                    alarm.Foreground = Brushes.Green;
                    frontEmail.BorderBrush = Brushes.Green;
                    emailFlag = true;
                    break;
            }
            CheckFlag();
        }

        private void EmailComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(emailComboBox.SelectedIndex.Equals(0))
            behindEmail.Text = "naver.com";
            if (emailComboBox.SelectedIndex.Equals(1))
                behindEmail.Text = "google.com";
            if (emailComboBox.SelectedIndex.Equals(2))
                behindEmail.Text = "daum.com";

            Email_LostFocus(sender,new RoutedEventArgs());
        }

        public void CheckFlag()
        {
            if (idFlag && pwFlag && nameFlag && resinumFlag && AddressFlag && phoneFlag && emailFlag)
                signButton.IsEnabled = true;
            else
                signButton.IsEnabled = false;
        }
    }
}
