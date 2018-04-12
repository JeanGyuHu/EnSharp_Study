using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class SuperviserMode
    {
        private const string MemberControl = "1";
        private const string BookManagement = "2";
        private const string Exit = "3";
        private bool flag = true;
        private string strChoice;
        private ControlMember controlMember;
        private LibraryManagement libraryManagement;
        private DrawControlMember drawControlMember = new DrawControlMember();

        public SuperviserMode(List<Member> slist, List<Member> ulist, List<Book> bookList)
        {
            while (flag)
            {
                drawControlMember.DrawSuperViserModeMenu();
                strChoice = Console.ReadLine();
                switch (strChoice)
                {
                    case MemberControl:
                        controlMember = new ControlMember(ulist);
                        break;
                    case BookManagement:
                        libraryManagement = new LibraryManagement(bookList);
                        break;
                    case Exit:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
