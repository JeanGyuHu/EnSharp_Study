using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class StartMenu
    {
        private string strMode;
        private Boolean flag = true;
        private List<Member> listUserMember = new List<Member>();
        private List<Member> listSuperviser = new List<Member>();
        private List<Book> listBook = new List<Book>();
        private Login login;
        public StartMenu()
        {
            while (flag)
            {
                drawAndRead();

                switch (strMode)
                {
                    case "1":
                        Console.Clear();
                        login = new Login(strMode, listSuperviser, listUserMember, listBook);
                        break;

                    case "2":
                        Console.Clear();
                        login = new Login(strMode, listUserMember, listUserMember, listBook);
                        break;

                    case "3":
                        Console.Clear();
                        SignUp signup = new SignUp(listUserMember); 
                        break;

                    case "4":
                        flag = false;
                        break;

                    default:
                        Console.Clear();
                        drawAndRead();
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }

        }

        public void drawAndRead()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t****************");
            Console.WriteLine("\t\t\t\t* Hu's Library *");
            Console.WriteLine("\t\t\t\t****************\n\n");
            Console.WriteLine("\n\n\t\t\t\t1. Superviser Mode");
            Console.WriteLine("\n\n\t\t\t\t2. User Mode");
            Console.WriteLine("\n\n\t\t\t\t3. Sign up");
            Console.WriteLine("\n\n\t\t\t\t4. EXIT");
            Console.Write("\n\n\t\t\t >>> ");
            strMode = Console.ReadLine();
        }
    }
}
