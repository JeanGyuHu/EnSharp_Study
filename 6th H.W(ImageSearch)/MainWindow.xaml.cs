using System.Windows;

namespace ImageSearch
{
    /******************************************************************
     * 이미지 검색하는 프로그램입니다. 프로그램을 실행시키기 위해서는 *
     * 우선 constants 파일에 들어가서 database 정보와 api 키값을 확인 *
     * 해야하고, 그후에 같이 첨부한 글꼴들을 다운받으셔야합니다.      *
     * create table information(                                      *
     *      info char(30),                                            *
     *	    time datetime                                             *
     * );                                                             *
     * 데이터베이스가 추가가 되지 않을시 만들어 사용하세요!           *
     * ***************************************************************/
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
