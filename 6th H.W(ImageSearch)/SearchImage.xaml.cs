using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace ImageSearch
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchImage : Page
    {
        private string response;            //api 에서 넘어온 결과 값
        private ParsingData parsingData;    //데이터를 파싱해주기 위한 객체
        private List<ImageData> list;       //파싱해서 넘겨준 데이터를 받기 위한 리스트
        private SearchListDAO searchListDAO;//검색 결과를 데이터베이스에 저장하기 위한 객체
        private CommonEvent commonEvent;    //버튼 액션에 대한 처리를 위한 객체

        
        //기본 생성자로써 객체들 초기화와 각각의 이벤트들을 추가한다.
        public SearchImage()
        {
            InitializeComponent();
            searchListDAO = new SearchListDAO();
            parsingData = new ParsingData();
            list = new List<ImageData>();
            commonEvent = new CommonEvent();

            searchTextBox.Text = "검색어 입력!";
            searchTextBox.Foreground = Brushes.Gray;

            Search.Foreground = Constants.ENTER[1];
            Search.Background = Constants.ENTER[0];

            Search.MouseEnter += commonEvent.Button_MouseEnter;
            Search.MouseLeave += commonEvent.Button_MouseLeave;

            searchTextBox.KeyDown += TextBox_KeyDown;
        }

        //TextBox안에서 엔터를 눌렀을시에도 검색이 되게하기 위함
        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                Search_Click(sender, e);
        }

        //textBox에서 enter를 누르거나 검색버튼을 눌렀을 시에 검색하기
        private void Search_Click(object sender, EventArgs e)
        {
            int size = 0;

            if (searchTextBox.Text.Equals("검색어 입력!"))   //처음 기본 상태에서 검색을 누를시에는 안되게 처리
            {
                searchTextBox.Clear();
                return;
            }
            if (!SearchExceptionHandler(searchTextBox.Text))    //검색이 안되게 막아놓은 기본적인 특수문자나 공백에 대한 예외처리
            {
                searchTextBox.Clear();
                return;
            }
            searchListDAO.InsertSearchInformation(searchTextBox.Text, DateTime.Now);    //예외처리를 지났다면 검색어를 저장
            response = parsingData.RequestJson(searchTextBox.Text);                     //정보를 API를 통해 받아오고
            list = parsingData.ParseJson(response);                                     //정보를 파싱한다.

            if (list.Count.Equals(0))       //검색 결과가 없다면 끝낸다.
            {
                searchTextBox.Clear();
                return;
            }
            listView.Items.Clear();                 //그림을 그리기 전에 이전에 그려놓을 것들을 전부 삭제
            if (howMany.SelectedIndex.Equals(1))    //콤보박스에서 10개를 선택했을 때
            {
                if (list.Count < 10)    //검색 결과가 10개보다 적다면
                    size = list.Count;
                else
                    size = 10;

                for (int count = 0; count < size; count++)
                    AddImageInPanel(count);
            }
            else if (howMany.SelectedIndex.Equals(2))   //콤보박스에서 20개를 선택했을 때
            {
                if (list.Count < 20)    //20개보다 적다면
                    size = list.Count;
                else
                    size = 20;

                for (int count = 0; count < size; count++)
                    AddImageInPanel(count);

            }
            else if (howMany.SelectedIndex.Equals(3))   //콤보박스에서 30개를 선택했을 때
            {
                if (list.Count < 30)    //30개보다 적다면
                    size = list.Count;
                else
                    size = 30;

                for (int count = 0; count < size; count++)
                    AddImageInPanel(count);
            }
            searchTextBox.Clear();

        }

        //이미지를 패널에 추가해주는 역할을 하는 메서드
        private void AddImageInPanel(int count)
        {
            Image image = new Image();
            image.MouseLeftButtonDown += Image_DoubleClick;
            image.Source = parsingData.LoadImage(list[count].ImageURL);
            image.Height = 100;
            image.Width = 100;
            listView.Items.Add(image);
        }
        //사진을 2번 클릭했을시에 Dialog에 사진을 확대해서 띄워준다.
        private void Image_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                PictureDialog pictureDialog = new PictureDialog();
                pictureDialog.SetImage((Image)sender);
                pictureDialog.Show();
            }
        }

        //처음 시작할때 검색어를 않았을 때 
        private void SearchTextBox_Focus(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Equals("검색어 입력!"))
            {
                searchTextBox.Text = "";
                searchTextBox.Foreground = Brushes.Black;
            }
        }

        //검색할때 공백과 특수무자에 대한 처리
        private bool SearchExceptionHandler(string text)
        {
            if (Regex.IsMatch(text, @"^ *$"))
                return false;
            if (Regex.IsMatch(text, @"^[~`!@#$%%\-+={}[\]|\\;:""<>,.?/]*$"))
                return false;
            return true;
        }
    }
}
