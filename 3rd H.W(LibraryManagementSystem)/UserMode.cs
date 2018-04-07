using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class UserMode
    {
        private string strChoice;
        private bool flag = true;

        public UserMode()
        {
            while (flag)
            {
                draw();
                switch (strChoice)
                {
                    case "1":
                        
                        break;

                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":
                        flag = false;
                        break;
                    default:

                        break;
                }
            }
            


        }
        public void draw()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------┐");
            Console.WriteLine("\t\t\t│           U S E R   M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. Book Rental");
            Console.WriteLine("\n\n\t\t\t\t2. Extend return time");
            Console.WriteLine("\n\n\t\t\t\t3. Change my information");
            Console.WriteLine("\n\n\t\t\t\t4. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");

            strChoice = Console.ReadLine();

        }
    }
}
