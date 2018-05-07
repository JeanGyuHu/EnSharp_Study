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
    /// Menu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu : Page
    {
        private Uri SearchImageUri;
        private Uri SearchLogUri;

        public Menu()
        {
            InitializeComponent();
            SearchImageUri = new Uri("/SearchImage.xaml", UriKind.Relative);
            SearchLogUri = new Uri("/SearchLog.xaml", UriKind.Relative);
        }

        private void SearchPictureButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                SearchImageUri
                );
        }

        private void SearchMyLogButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                SearchLogUri
                );
        }
    }
}
