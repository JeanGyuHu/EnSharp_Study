using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EnSharp_day3
{
    class DrawStartMark
    {
        /// <summary>
        /// 비밀...
        /// </summary>
        public DrawStartMark()
        {

        }
        public void Draw1()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("\n\n\n■■                ■■     ■■                      ■■     ■■■     ■■                     ■■     ■■");

        }
        public void Draw2()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("\n\n\n\n■■                ■■     ■■                      ■■     ■■■     ■■                     ■■     ■■              ");

        }
        public void Draw3()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n■■                ■■     ■■                      ■■         ■     ■■                              ■■                 ");

        }
        public void Draw4()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n■■                ■■     ■■                      ■■         ■     ■■                     ■■     ■■                 ");

        }
        public void Draw5()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n■■                ■■     ■■                      ■■                ■■                     ■■     ■■                ");

        }
        public void Draw6()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n■■                ■■     ■■                      ■■                ■■                     ■■     ■■                       ■■                  ■■");

        }
        public void Draw7()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n■■■■■■■■■■■■     ■■                      ■■                ■■                     ■■     ■■                       ■■■■■■■■      ■■■■■■■■");

        }
        public void Draw8()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n■■■■■■■■■■■■      ■■                    ■■                 ■■                     ■■     ■■■■■■■■■         ■■■■              ■■■■");

        }
        public void Draw9()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n■■                ■■       ■■                  ■■                  ■■                     ■■     ■■             ■■      ■■■                ■■■   ■      ■");

        }
        public void Draw10()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n■■                ■■        ■■                ■■                   ■■                     ■■     ■■               ■■    ■■       ■■       ■■     ■      ■");

        }
        public void Draw11()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n■■                ■■         ■■              ■■                    ■■                     ■■     ■■                ■■   ■■     ■■ ■■    ■■      ■■■■");

        }
        public void Draw12()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n■■                ■■          ■■            ■■                     ■■                     ■■     ■■               ■■    ■■     ■■ ■■    ■■           ■");

        }
        public void Draw13()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n■■                ■■           ■■■■■■■■■                      ■■■■■■■■■■     ■■     ■■             ■■      ■■       ■■  ■■ ■■          ■");

        }
        public void Draw14()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n■■                ■■            ■■■■■■■■                       ■■■■■■■■■■     ■■     ■■■■■■■■■         ■■                  ■■         ■");

        }
        public void DrawAll()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■■                ■■     ■■                      ■■     ■■■     ■■                     ■■     ■■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■■                ■■     ■■                      ■■     ■■■     ■■                     ■■     ■■              ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■                ■■     ■■                      ■■         ■     ■■                              ■■                 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■■                ■■     ■■                      ■■         ■     ■■                     ■■     ■■                 ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("■■                ■■     ■■                      ■■                ■■                     ■■     ■■                ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("■■                ■■     ■■                      ■■                ■■                     ■■     ■■                       ■■                  ■■");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("■■■■■■■■■■■■     ■■                      ■■                ■■                     ■■     ■■                       ■■■■■■■■      ■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■■■■■■■■■■■■      ■■                    ■■                 ■■                     ■■     ■■■■■■■■■         ■■■■              ■■■■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■■                ■■       ■■                  ■■                  ■■                     ■■     ■■             ■■      ■■■                ■■■   ■      ■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■■                ■■        ■■                ■■                   ■■                     ■■     ■■               ■■    ■■       ■■       ■■     ■      ■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■■                ■■         ■■              ■■                    ■■                     ■■     ■■                ■■   ■■     ■■ ■■    ■■      ■■■■");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("■■                ■■          ■■            ■■                     ■■                     ■■     ■■               ■■    ■■     ■■ ■■    ■■           ■");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("■■                ■■           ■■■■■■■■■                      ■■■■■■■■■■     ■■     ■■             ■■      ■■       ■■  ■■ ■■          ■");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("■■                ■■            ■■■■■■■■                       ■■■■■■■■■■     ■■     ■■■■■■■■■         ■■                  ■■         ■");
        }
        public void StartMark()
        {
       
            Console.SetWindowSize(192, 50);

            for (int i = 0; i < 3; i++)
            {
                Draw1();
                Thread.Sleep(10);
                Draw2();
                Thread.Sleep(10);
                Draw3();
                Thread.Sleep(10);
                Draw4();
                Thread.Sleep(10);
                Draw5();
                Thread.Sleep(10);
                Draw6();
                Thread.Sleep(10);
                Draw7();
                Thread.Sleep(10);
                Draw8();
                Thread.Sleep(10);
                Draw9();
                Thread.Sleep(10);
                Draw10();
                Thread.Sleep(10);
                Draw11();
                Thread.Sleep(10);
                Draw12();
                Thread.Sleep(10);
                Draw13();
                Thread.Sleep(10);
                Draw14();
                Thread.Sleep(10);
            }
            

            for (int i = 0; i < 5; i++)
            {
                DrawAll();
                Thread.Sleep(100);
                Console.Clear();
                Thread.Sleep(100);
                DrawAll();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\n\n\n\t\t\t\t\t\t\t\t\t\tPress Any Key. . .");
            Console.ReadKey();
            Console.SetWindowSize(120, 30);
        }
    }
}
