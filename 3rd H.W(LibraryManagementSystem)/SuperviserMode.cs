using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class SuperviserMode
    {
        private bool flag = true;
        private string strChoice;
        private ControlMember controlMember;
        private LibraryManagement libraryManagement;

        public SuperviserMode(List<Member> slist, List<Member> ulist, List<Book> bookList)
        {
            while (flag)
            {
                draw();

                switch (strChoice)
                {
                    case "1":
                        controlMember = new ControlMember(ulist);
                        break;
                    case "2":
                        libraryManagement = new LibraryManagement(bookList);
                        break;
                    case "3":
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
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           S U P E R V I S E R   M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. User Management");
            Console.WriteLine("\n\n\t\t\t\t2. Book Management");
            Console.WriteLine("\n\n\t\t\t\t3. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");
            strChoice = Console.ReadLine();
            
        }
    }
}
