using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class StartMenu
    {
        //매직 넘버
        private const string LoginSuperviserMode = "1";
        private const string LoginUserMode = "2";
        private const string GoToSignUpPage = "3";
        private const string Exit = "4";

        private string strMode;         //어떤 메뉴로 들어갈지 여부
        private Boolean flag = true;    //종료 flag
        private DrawControlMember drawControlMember;    //UI 그리기 위한 객체
        private List<Member> listUserMember;            //유저 정보
        private List<Member> listSuperviser;            //관리자 정보
        private List<Book> listBook;                    //책정보
        private List<RentalData> listRental;            //대여자 정보
        private Login login;                            //메뉴 선택시 로그인 창으로 넘어가기 위함

        /// <summary>
        /// 시작했을때 첫 화면 선택에 따라서
        /// 관리자모드, 회원모드, 회원가입 모드로 이동한다.
        /// </summary>
        public StartMenu()
        {
            drawControlMember = new DrawControlMember();
            listUserMember = new List<Member>();
            listSuperviser = new List<Member>();
            listBook = new List<Book>();
            listRental = new List<RentalData>();

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
