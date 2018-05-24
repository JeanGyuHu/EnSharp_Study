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
        MemberDAO memberDAO;

        public EditInformation()
        {
            InitializeComponent();
            memberDAO = new MemberDAO();
        }

        public void InitTextBoxes(MemberVO member)
        {
            id.Text = member.Id;
            pw.Text = member.Password;
            pw2.Text = member.Password;
            name.Text = member.Name;
            frontResiNum.Text = member.ResidentNumber.Substring(0, 6);
            behindResiNum.Text = member.ResidentNumber.Substring(6, 7);
            addressNumber.Text = member.AddressNumber;
            frontAddress.Text = member.Address;
            behindAddress.Text = member.AddressDetail;

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

        

        private void FindAdress_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
