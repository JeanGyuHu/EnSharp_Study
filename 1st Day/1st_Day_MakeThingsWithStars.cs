using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENjoy_day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;

            Console.WriteLine("피라미드");
            size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for(int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("역피라미드");
            size = Convert.ToInt32(Console.ReadLine());

            for(int i = size-1; i >= 0; i--){

                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for(int j = 2 * i+1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }

            Console.WriteLine("모래시계");

            size = Convert.ToInt32(Console.ReadLine());

            for (int i = size - 1; i > 0; i--)
            {

                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for (int j = 2 * i + 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.WriteLine("다이아");

            size = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < size-1; i++)
            {
                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }

            for (int i = size - 1; i >= 0; i--)
            {

                for (int j = 0; j < size - i; j++)
                    Console.Write(" ");
                for (int j = 2 * i + 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }
    }
}
