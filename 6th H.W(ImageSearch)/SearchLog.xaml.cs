using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ImageSearch
{
    /// <summary>
    /// SearchLog.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchLog : Page
    {
        private SearchListDAO searchListDAO;        //로그를 데이터베이스로부터 삭제하고 불러오기 위함
        private List<LogData> list;                 //데이터베이스에서 받아온 정보를 받기 위함
        private CommonEvent commonEvent;            //버튼에 이벤트를 추가하기 위함

        //기본 생성자로써 초기화한다.
        public SearchLog()
        {
            InitializeComponent();
            searchListDAO = new SearchListDAO();
            UpdateList();
            commonEvent = new CommonEvent();
            list = new List<LogData>();

            deleteButton.Foreground = Constants.ENTER[1];
            deleteButton.Background = Constants.ENTER[0];

            deleteButton.MouseEnter += commonEvent.Button_MouseEnter;
            deleteButton.MouseLeave += commonEvent.Button_MouseLeave;
        }

        //전부 삭제 버튼이 눌렸을때 모든 정보를 데이터베이스에 있는걸 지우고, listView도 초기화 해준다.
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            searchListDAO.DeleteInformation("delete from information;");    //DB 내용 초기화

            list.Clear();

            searchLog.ItemsSource = null; //listView 초기화
            searchLog.Items.Refresh();
        }

        //추가되었을때 리스트를 업데이트해준다.
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
