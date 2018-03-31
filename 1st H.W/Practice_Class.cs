using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENjoy_HW1
{

    class Cat
    {
        public string Name;     //public 형으로 선언하여 다른 클래스에서 바로 instance에 접근 가능 Ex)kitty.Color = 000;
        public string Color;    //public 형 문자열 Name과 Color

        public Cat()    //기본 생성자 (인자로 아무것도 넘어오지 않았을때 둘다 공백으로 초기화한다.
        {
            Name = "";
            Color = "";
        }
        public Cat (String _Name , String _Color)   //기본 생성자 (인자로 넘어 왔을시에 원하는 곳에 원하는 방식대로 초기화해주면 된다.
                                                    //이때 위에 만든 생성자와 메소드가 같지만 매개변수가 있으므로 다른 생성자이다.
                                                    //이런 걸 method overloading 이라고 한다.
        {
            Name = _Name;   //매개변수로 넘어온 값으로 각각 초기화
            Color = _Color;
        }
        public void Meow()  //클래스 안에 method
        {
            Console.WriteLine("{0} : 야옹", Name);
        }
    }
    class Program       //메인 method가 있는 클래스
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat();  //Cat 이라는 Class의 kitty라는 객체를 선언하고 생성한다.
            kitty.Color = "하얀색";    //public형으로 선언된 instance 변수에 접근하여 값을 변경한다.
            kitty.Name = "키티";
            kitty.Meow();               //객체 kitty의 method를 사용한다. 

            Console.WriteLine("{0} : {1}", kitty.Name, kitty.Color);    //public 형으로 선언된 instance에 바로 접근하여 출력한다.

            Cat nero = new Cat();   //Cat 클래스의 객체를 또 선언하고 생성한다.
            nero.Color = "검은색";  //위와 같이 초기화한다.
            nero.Name = "네로";
            nero.Meow();            //사용한다.

            Console.WriteLine("{0} : {1}", nero.Name, nero.Color);  //확인

            Cat nabi = new Cat("나비", "갈색");     //오버로딩하여 만든 method를 이용하여 객체를 초기화해본다.

            nabi.Meow();        //사용
            Console.WriteLine("{0} : {1}", nabi.Name, nabi.Color);  //제대로 초기화되었는지 확인한다.
            
        }
    }
}
