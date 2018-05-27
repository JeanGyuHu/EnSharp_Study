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
using System.Windows.Shapes;

namespace Hu_s_SignUp
{
    /// <summary>
    /// FindAddress.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindAddress : Window
    {
        UsingAPI usingAPI;
        List<AddressVO> list;
        SignUp signUp = null;
        EditInformation editInformation = null;

        public FindAddress(EditInformation edit)
        {
            InitializeComponent();
            editInformation = edit;
            usingAPI = new UsingAPI();
            list = new List<AddressVO>();
        }

        public FindAddress(SignUp signUp)
        {
            InitializeComponent();
            usingAPI = new UsingAPI();
            list = new List<AddressVO>();
            this.signUp = signUp;
        }
        
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            listBox.Items.Clear();
            listBox.Items.Refresh();
            list = usingAPI.Find(addressInputTextBox.Text);

            if (list.Count.Equals(0))
            {
                listBox.Items.Clear();
                listBox.Items.Refresh();
                return;
            }
            else
            {
                foreach(AddressVO item in list)
                {
                    listBox.Items.Add(item.No + "   " + item.RoadAddress + "\r\n\r\n" + item.BeforeAddress);
                }
            }      
        }

        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                int index = listBox.SelectedValue.ToString().IndexOf("\r\n\r\n",0);

                if (editInformation == null)
                {
                    signUp.addressNumberText.Text = listBox.SelectedValue.ToString().Substring(0, 5);
                    signUp.addressText.Text = listBox.SelectedValue.ToString().Substring(8, index - 8);
                }
                else if(signUp == null)
                {
                    editInformation.addressNumber.Text = listBox.SelectedValue.ToString().Substring(0, 5);
                    editInformation.frontAddress.Text = listBox.SelectedValue.ToString().Substring(8, index - 8);
                }
                this.Close();
            }
        }

        private void AddressInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                SearchButton_Click(sender, e);
        }
    }
}
