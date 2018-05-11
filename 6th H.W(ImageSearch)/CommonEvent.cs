using System.Windows.Controls;
using System.Windows.Input;

namespace ImageSearch
{
    //자주 일어나는 이벤트들에 대해서 모아둔 클래스
    class CommonEvent
    {
        public CommonEvent() { }
        //버튼에 마우스가 들어갔을때
        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Constants.ENTER[0];
            ((Button)sender).Background = Constants.ENTER[1];
        }
        //버튼에서 마우스가 나왔을때
        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Constants.ENTER[1];
            ((Button)sender).Background = Constants.ENTER[0];
        }
    }
}
