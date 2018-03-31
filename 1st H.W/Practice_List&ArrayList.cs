using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayListPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 52, 273, 32, 64 };   //연결리스트이고 <> 사이에 있는 자료형의 자료들을 저장할 수 있는 저장 공간이다.
            ArrayList array = new ArrayList();                      //연결리스트이고 최상위 클래스인 Object형으로 자료들을 받으므로 어떤 것이든지 다 받아서 저장한다.


            list.Add(52);           //List 의 메소드이고, list에 값을 추가해주는 메소드이다.
            list.Add(273);
            list.Add(32);
            list.Add(64);

            list.Remove(52);    //52라는 숫자를 순서대로 찾다가 가장 먼저 찾은 걸 1개 삭제한다.

            foreach (var item in list)      //var은 정해져있지 않은 자료형으로 처음으로 받은 자료형으로 설정된다. (한번 설정된 자료형은 다시 재지정 불가능)
                Console.WriteLine("count : {0} \titem : {1}", list.Count, item);    //Count는 여태까지 몇개의 자료가 들어가있는지 세는 메소드

            for (int i = 0; i < 5; i++)
                array.Add(i);           //ArrayList에 자료를 추가하는 모습 (int형의 정수를 추가하고 있다.)

            foreach(object obj in array)
                Console.Write("{0} ", obj);     //arrayList 안의 오브젝트를 하나하나 꺼내서 보여줌

            Console.WriteLine();

            array.RemoveAt(2);          //index 가 2인 곳에 있는 자료 제거

            foreach (object obj in array)
                Console.Write("{0} ", obj); //제거 확인

            Console.WriteLine();


            array.Insert(2, 10);        //추가하는 메소드인데, 앞부분이 위치 뒷부분이 무엇을 추가할지를 의미한다 index가 2인 곳에 10을 추가한다.   

            foreach (object obj in array)       //foreach 는 array 안에 있는 것을 처음부터 끝까지 도는 반복문이다.
                Console.Write("{0} ", obj);

            Console.WriteLine();

            array.Add("abc");       //정수와 다른 문자열을 추가해도 추가가 되는지 체크
            array.Add("def");       

            for (int i = 0; i < array.Count; i++)       //foreach를 사용해도 되지만 Count 메소드를 통해서 for문을 돌려줘도 가능하다.
                Console.Write("{0} ", array[i]);    
            Console.WriteLine();
        }
    }
}
