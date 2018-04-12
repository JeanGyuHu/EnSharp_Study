using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class StartMenu
    {
        private DrawControlMember drawControlMember = new DrawControlMember();
        private const string LoginSuperviserMode = "1";
        private const string LoginUserMode = "2";
        private const string GoToSignUpPage = "3";
        private const string Exit = "4";
        private string strMode;
        private Boolean flag = true;
        private List<Member> listUserMember = new List<Member>();
        private List<Member> listSuperviser = new List<Member>();
        private List<Book> listBook = new List<Book>();
        private List<RentalData> listRental = new List<RentalData>();
        private Login login;

        public StartMenu()
        {
            listBook.Add(new Book("12-12341234", "C#프로그래밍", 3, "허진규출판사", "허진규"));
            listSuperviser.Add(new Member("1", "1", "1", "1", 1, "1", "1"));
            listUserMember.Add(new Member("1", "1", "1", "1", 1, "1", "1"));
            listUserMember.Add(new Member("2", "2", "2", "2", 2, "2", "2"));
            listUserMember.Add(new Member("3", "3", "3", "3", 3, "3", "3"));
            listUserMember.Add(new Member("4", "4", "4", "4", 4, "4", "4"));

            while (flag)
            {
                drawControlMember.DrawBasicMenu();
                strMode = Console.ReadLine();
                switch (strMode)
                {
                    case LoginSuperviserMode:
                        login = new Login(strMode, listSuperviser, listUserMember, listBook,listRental);
                        break;

                    case LoginUserMode:
                        login = new Login(strMode, listUserMember, listUserMember, listBook,listRental);
                        break;

                    case GoToSignUpPage:
                        SignUp signup = new SignUp(listUserMember); 
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
