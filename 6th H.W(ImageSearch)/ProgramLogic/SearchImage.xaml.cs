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

namespace ImageSearch
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchImage : Page
    {
        private string response;
        private ParsingData parsingData;
        private List<ImageData> list;
        private SearchListDAO searchListDAO;

        public SearchImage()
        {
            InitializeComponent();
            searchListDAO = new SearchListDAO();
            parsingData = new ParsingData();
            list = new List<ImageData>();

            searchTextBox.Text = "검색어 입력!";
            searchTextBox.Foreground = Brushes.Gray;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text.Equals(""))
                return;
            searchListDAO.InsertSearchInformation(searchTextBox.Text, DateTime.Now);
            response = parsingData.RequestJson(searchTextBox.Text);
            list = parsingData.ParseJson(response);
            listView.Items.Clear();
            if(howMany.SelectedIndex.Equals(1))
            {
                
                for(int count = 0; count < 10; count++)
                {
                    AddImageInPanel(count);
                }
                searchTextBox.Clear();
            }
            else if (howMany.SelectedIndex.Equals(2))
            {
                for (int count = 0; count < 20; count++)
                {
                    AddImageInPanel(count);
                }
                searchTextBox.Clear();
            }
            else if (howMany.SelectedIndex.Equals(3))
            {
                for (int count = 0; count < 30; count++)
                {
                    AddImageInPanel(count);
                }
                searchTextBox.Clear();
            }
        }

        private void AddImageInPanel(int count)
        {
            Image image = new Image();
            image.MouseLeftButtonDown += Image_DoubleClick;
            image.Source = parsingData.LoadImage(list[count].ImageURL);
            image.Height = 100;
            image.Width = 100;
            listView.Items.Add(image);
        }
        private void Image_DoubleClick(object sender, RoutedEventArgs e)
        {
            PictureDialog pictureDialog = new PictureDialog(); 
                pictureDialog.SetImage((Image)sender);
                pictureDialog.Show();
        }

        private void SearchTextBox_Focus(object sender, EventArgs e)
        {
            if (searchTextBox.IsFocused)
            {
                searchTextBox.Text = "";
                searchTextBox.Foreground = Brushes.Black;
            }
        }
    }
}
