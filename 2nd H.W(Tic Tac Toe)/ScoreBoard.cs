using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    class ScoreBoard
    {
        
        public ScoreBoard(List<UserData> list,ArrayList array)
        {
            Console.WriteLine("\n\n\t\t**************************************************************");
            Console.WriteLine("\t\t**************\t\tGAME SCORE BOARD\t**************");
            Console.WriteLine("\t\t**************************************************************");

            Console.WriteLine("\n\n\t\t\tWinner List");
            foreach (var item in list)
            {
                Console.WriteLine("\n\n\t\t{0} 의 승수 {1}",item.StrPlayer,item.Num);
            }

            Console.WriteLine("\n\n\t\t☆★☆★Computer를 이긴 명예의 전당☆★☆★");

            foreach (object obj in array)
            {
                Console.WriteLine("\n\n\t\t{0}", obj);
            }
            System.Threading.Thread.Sleep(2000);

        }
    }
}
