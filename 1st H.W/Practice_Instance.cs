using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Instance
{
    class Program
    {
        private int width;      //Program이라는 클래스 안에 존재하는 instance 변수이다. private로 선언되어 있어 Program 클래스 외 다른 클래스에서는 접근 불가능
                                
                                //속성의 자료형은 다루고자 하는 변수의 자료형을 따라간다.
        public int Width        //instance 변수 width를 다른 클래스에서 사용하기 위해서 get/set 만드는 속성이다.
        {                       //속성의 이름은 다른 것으로 정해도 상관 없지만 시작을 대문자로 해야하고, 주로 다룰 변수의 맨 앞자만 대문자로 바꿔줘서 사용한다.
            get { return width; }           //get은 내가 width에 들어있는 값을 알고 싶을때 쓰는 속성접근자이다.

            set                             //set은 내가 width에 들어있는 값을 변경하고자 할때 사용한다.
            {
                if (value > 0) { width = value; }       //Width = 000; 이런식으로 대입이 일어났을때 set속성접근자가 사용되고, 000이 value가 된다.
                else { Console.WriteLine("너비는 자연수를 입력해주세요"); }      //값 변경 외에도 다른 추가적인 조건 추가가 가능하다.

            }
        }

        private int height;         //height란 instance 변수에도 위와 동일한 작업을 해준다.
        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0) { height = value; }
                else { Console.WriteLine("높이는 자연수를 입력해주세요"); }
            }
        }

        public Program(int width,int height)        //생성자로써 입력한 값으로 width,height를 초기화해준다.
        {
            Width = width;
            Height = height;
        }

        public int Area() { return this.width * this.height; }  //넓이를 구하는 메소드

        static void Main(string[] args)
        {
            Program box = new Program(-10, -20);    //Program 클래스의 box 객체 생성 (-10,-20)으로 초기화한다.

            box.Width = -200;   //위에서 만든 Width 속성을 사용하여 초기화
            box.Height = -100;  //Height 속성을 사용하여 초기화
        }
    }
}
