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

namespace ImageSearch
{
    /// <summary>
    /// SearchLog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchLog : Page
    {
        private SearchListDAO searchListDAO;
        private List<LogData> list;

        public SearchLog()
        {
            InitializeComponent();
            searchListDAO = new SearchListDAO();
            UpdateList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            searchListDAO.DeleteInformation();

            list.Clear();

            searchLog.Items.Refresh();
        }

        private void UpdateList()
        {
            searchLog.Items.Clear();
            list = searchListDAO.SearchAll();

            if (list == null)
                searchLog.Items.Refresh();
            else
                searchLog.ItemsSource = list;
        }
    }
}
