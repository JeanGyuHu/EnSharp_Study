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
    /// EditInformation.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditInformation : UserControl
    {
        ExceptionHandler exceptionHandler;
        MemberDAO memberDAO;
        bool pwFlag = false, phoneFlag = false, addressFlag = false;

        public EditInformation()
        {
            InitializeComponent();
            exceptionHandler = new ExceptionHandler();
            memberDAO = new MemberDAO();
        }

        public void CheckFlag()
        {
            if (pwFlag && phoneFlag && addressFlag)
            {
                signButton.IsEnabled = true;
            }
            else
            {
                signButton.IsEnabled = false;
            }
        }
        public void InitTextBoxes(MemberVO member)
        {
            id.Text = member.Id;
            pw.Text = member.Password;
            pw.BorderBrush = Brushes.Black;
            pw2.Text = member.Password;
            pw2.BorderBrush = Brushes.Black;
            name.Text = member.Name;
            frontResiNum.Text = member.ResidentNumber.Substring(0, 6);
            behindResiNum.Text = member.ResidentNumber.Substring(6, 7);
            addressNumber.Text = member.AddressNumber;
            addressNumber.BorderBrush = Brushes.Black;
            frontAddress.Text = member.Address;
            behindAddress.Text = member.AddressDetail;

            phone1.BorderBrush = Brushes.Black;
            phone2.BorderBrush = Brushes.Black;
            phone3.BorderBrush = Brushes.Black;

            if (member.PhoneNumber.Length.Equals(11))
            {
                phone1.Text = member.PhoneNumber.Substring(0, 3);
                phone2.Text = member.PhoneNumber.Substring(3, 4);
                phone3.Text = member.PhoneNumber.Substring(7, 4);
            }
            else if (member.PhoneNumber.Length.Equals(10)){

                phone1.Text = member.PhoneNumber.Substring(0, 3);
                phone2.Text = member.PhoneNumber.Substring(3, 3);
                phone3.Text = member.PhoneNumber.Substring(6, 4);
            }

            int index = member.Email.IndexOf('@');

            emailFront.Text = member.Email.Substring(0, index);
            emailBehind.Text = member.Email.Substring(index + 1, member.Email.Length - index - 1);
        }
        
        public void Edit()
        {
            memberDAO.EditMemberInfo(new MemberVO(id.Text, pw.Text, name.Text, frontResiNum.Text + behindResiNum.Text, addressNumber.Text, frontAddress.Text, behindAddress.Text, phone1.Text + phone2.Text + phone3.Text, emailFront.Text + "@" + emailBehind.Text));
        }
        
        private void FindAddress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PwText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!pw.Text.Equals(pw2.Text))
            {
                alarm.Content = "비밀번호가 다릅니다";
                alarm.Foreground = Brushes.Red;
                pw.BorderBrush = Brushes.Red;
                pw2.BorderBrush = Brushes.Red;
                pwFlag = false;
                return;
            }

            switch (exceptionHandler.CheckPw(pw.Text))
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
                    pw.BorderBrush = Brushes.Green;
                    pw2.BorderBrush = Brushes.Green;
                    pwFlag = true;
                    break;
            }

            CheckFlag();
        }

        private void AddressDetailText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (behindAddress.Text.Length < 5 && (frontAddress.Text.Length == 0 || addressNumber.Text.Length == 0))
            {
                alarm.Content = "너무 짧습니다.";
                alarm.Foreground = Brushes.Red;
                behindAddress.BorderBrush = Brushes.Red;
                addressFlag = false;
            }
            else
            {
                alarm.Content = "성공";
                alarm.Foreground = Brushes.Green;
                behindAddress.BorderBrush = Brushes.Green;
                addressFlag = true;
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
    }
}
