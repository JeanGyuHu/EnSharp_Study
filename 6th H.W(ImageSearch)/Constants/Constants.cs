using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ImageSearch
{
    class Constants
    {
        public const string KEY = "fe5ea773dd821f940e6e707c83fb4b8c";              //카카오톡 API를 사용하기 위한 키 값
        public static readonly SolidColorBrush[] ENTER = { Brushes.White, Brushes.LightBlue };      //버튼에 마우스를 올려놨을때의 색 변화
        public static readonly SolidColorBrush[] EXIT = { Brushes.LightBlue, Brushes.White };       //버튼에서 마우스가 나왔을때의 색 변화
        public const string CONNECTIONINFORMATION = "Server = localhost; Database = imagesearch;Uid=root;Pwd=123123;";     //DB에 연결할때 사용하는 DB 연결정보
    }
}
