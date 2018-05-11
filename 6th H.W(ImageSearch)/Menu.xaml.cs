using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ImageSearch
{
    /// <summary>
    /// Menu.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Menu : Page
    {
        private Uri SearchImageUri;     //검색창으로 넘어가기 위한 uri
        private Uri SearchLogUri;       //로그 확인창으로 넘어가기 위한 uri
        private CommonEvent commonEvent;    //자주 추가 해야되는 이벤트들에 대해서 모아놓은 

        private Canvas MyEllipseCanvas; //애니메이션을 추가 하기 위한 
        private Image MyImage;          //애니메이션을 담당하는 이미지

        private DoubleAnimation MyDoubleAnimation1; //애니메이션 왼쪽으로 카메라 이동효과
        private DoubleAnimation MyDoubleAnimation2; //애니메이션 오른쪽으로 카메라 이동효과

        /// <summary>
        /// 기본 생성자로써 모든 객체들을 초기화, Event 추가 등이 이루어진다.
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            SearchImageUri = new Uri("/SearchImage.xaml", UriKind.Relative);
            SearchLogUri = new Uri("/SearchLog.xaml", UriKind.Relative);
            MyEllipseCanvas = new Canvas();
            commonEvent = new CommonEvent();

            MyDoubleAnimation1 = new DoubleAnimation();
            MyDoubleAnimation2 = new DoubleAnimation();

            SearchPictureButton.Foreground = Constants.ENTER[1];
            SearchPictureButton.Background = Constants.ENTER[0];
            SearchMyLogButton.Foreground = Constants.ENTER[1];
            SearchMyLogButton.Background = Constants.ENTER[0];

            SearchPictureButton.MouseEnter += commonEvent.Button_MouseEnter;
            SearchPictureButton.MouseLeave += commonEvent.Button_MouseLeave;
            SearchMyLogButton.MouseEnter += commonEvent.Button_MouseEnter;
            SearchMyLogButton.MouseLeave += commonEvent.Button_MouseLeave;

            MyImage = new Image();
            MyImage.Source = new BitmapImage(new Uri(@"\Image\skyscape.jpg", UriKind.Relative));
            MyImage.MouseLeftButtonDown += Image_Click;
            InitUI();
        }

        //이미지 검색 버튼을 눌렀을때 창 이동
        private void SearchPictureButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                SearchImageUri
                );
        }
        //검색 목록 버튼을 눌렀을때 창 이동
        private void SearchMyLogButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                SearchLogUri
                );
        }

        //애니메이션 사진이 클릭됬을때 창 없애기
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("그만 볼꾸양?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                //do no stuff
            }
            else
            {
                MyImage.Visibility = Visibility.Hidden;
                //do yes stuff
            }
            
        }

        //애니메이션 기본값을 초기화 한 후에 애니메이션 시작
        public void InitUI()
        {

            MyEllipseCanvas.Width = 1500;
            MyEllipseCanvas.Height = 350;

            MyImage.Width = 1500;
            MyImage.Height = 350;


            //Top, Left 프로퍼티로 애니메이션을 주기 위해 일부러 캔버스에 담았다. 
            MyEllipseCanvas.Children.Add(MyImage);

            MainCanvas.Children.Add(MyEllipseCanvas);
            Content = MainCanvas;

            DoubleAnimation_Start();
        }


        public void DoubleAnimation_Start()
        {

            MyDoubleAnimation1.From = -550.0;           //좌표값 시작 지점
            MyDoubleAnimation1.To = this.Width - 970;   //좌표값 종료 지점
            
            MyDoubleAnimation1.AccelerationRatio = 0;   //애니메이션 이동시에 가속도

            MyDoubleAnimation1.Duration = new Duration(TimeSpan.FromSeconds(3));    //등속도 운동할 때의 기본 속도
            //애니메이션 효과를 적용한 후에는 속성 값을 변경하기 
            MyDoubleAnimation1.Completed += new EventHandler(MyDoubleAnimation1_Completed); //끝까지 갔을때에 다음에 할 행동
            //yDoubleAnimation1.RepeatBehavior = RepeatBehavior.Forever;
            MyEllipseCanvas.BeginAnimation(Canvas.LeftProperty, MyDoubleAnimation1);        //애니메이션 시작


        }

        //애니메이션이 시작했고 그 애니메이션 효과가 끝났을때 그후에 어떻게 할 것인지에 대한 이벤트 처리
        void MyDoubleAnimation1_Completed(object sender, EventArgs e)      
        {
            MyDoubleAnimation2.From = this.Width - 970;
            MyDoubleAnimation2.To = -550.0;
            //가속도값 설정하기 
            MyDoubleAnimation2.AccelerationRatio = 0;
            MyDoubleAnimation2.Completed += new EventHandler(MyDoubleAnimation2_Completed);
            MyDoubleAnimation2.Duration = new Duration(TimeSpan.FromSeconds(3));
            //애니메이션 효과를 적용한 후에는 속성 값을 변경하기 

            MyEllipseCanvas.BeginAnimation(Canvas.LeftProperty, MyDoubleAnimation2);
        }

        //위의 이벤트와 서로를 이벤트로 추가함으로써 무한 반복을 하게 했다.
        void MyDoubleAnimation2_Completed(object sender, EventArgs e)
        {

            MyDoubleAnimation1.From = -550.0;
            MyDoubleAnimation1.To = this.Width - 970;
            //가속도값 설정하기
            MyDoubleAnimation1.AccelerationRatio = 0;
            MyDoubleAnimation1.Completed += new EventHandler(MyDoubleAnimation1_Completed);
            MyDoubleAnimation1.Duration = new Duration(TimeSpan.FromSeconds(3));
            //애니메이션 효과를 적용한 후에는 속성 값을 변경하기 

            MyEllipseCanvas.BeginAnimation(Canvas.LeftProperty, MyDoubleAnimation1);
        }
    }
}
