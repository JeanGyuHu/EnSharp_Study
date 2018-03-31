using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Method
{
    class Calculator    //Calculator 클래스 정의
    {
        public static int Plus(int a, int b)    //static 형으로 method를 만든다
                                                //static으로 만들었을 시에는 객체를 통해서 method에 접근이 불가능하고
                                                //클래스 명을 통해서 바로 접근이 가능하다.
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            int result = Calculator.Plus(3, 4);     //Calculator의 객체가 아닌 클래스명으로 method를 사용
            Console.WriteLine(result);

            result = Calculator.Minus(5, 2);        //Calculator의 객체가 아닌 클래스명으로 method를 사용
            Console.WriteLine(result);
        }
    }
}
