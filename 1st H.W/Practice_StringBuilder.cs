using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace String_builder____3월_30일__
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder strBldr = new StringBuilder("super");     //StringBuilder 클래스에 있는 많은 메소드들을 활용하여 문자열을 추가, 제거하기
            strBldr.Append(" star");
            Console.WriteLine(strBldr);

            StringBuilder strBldr1 = new StringBuilder("Super Star");
            strBldr1.Insert(6, "Real ");    //인덱스 6에 대입 (6칸에 대입이 아니라 6칸 다음 7번째 칸에 대입)
            Console.WriteLine(strBldr1);

            StringBuilder strBldr2 = new StringBuilder("Super Star");
            strBldr2.Remove(3, 5);          //index 3번째부터 5개 지움
            Console.WriteLine(strBldr2.ToString());

            StringBuilder strBldr3 = new StringBuilder("Super Star");
            strBldr3.Replace('S', 'a');     //대소문자 구분 있음 (모든 S를 다 바꾼다)
            Console.WriteLine(strBldr3.ToString());

            StringBuilder strBldr4 = new StringBuilder("One little, two little Indians");
            strBldr4.Replace("little", "big");      //모든 litte 
            Console.WriteLine(strBldr4.ToString());

            StringBuilder strBldr5 = new StringBuilder("One little, two little Indians");
            strBldr5.Replace('l', 'L', 0, 8);   // index 0~8까지 l을 L로 바꾼다. (왼쪽은 포함, 오른쪽 미포함)
            Console.WriteLine(strBldr5.ToString());

            StringBuilder strBldr6 = new StringBuilder("One little, two little Indians");
            strBldr6.Replace("little", "big", 15, 10);      //index 15~25까지 little을 big으로 바꾼다 (왼쪽 포함, 오른쪽 미포함)
            Console.WriteLine(strBldr6.ToString());

            StringBuilder strBldr7 = new StringBuilder("Hello.");
            Console.WriteLine(strBldr7.ToString());     //strBldr7을 출력

            string name1 = "Park", name2 = "Son";
            StringBuilder strBldr8 = new StringBuilder("One little,two little Indians");
            strBldr8.AppendFormat("\nTheir names : {0},{1}", name1, name2); //합성형식 문자열을 붙힐때 사용
            Console.WriteLine(strBldr8);
        }
    }
}
