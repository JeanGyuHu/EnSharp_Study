using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class StartMenu
    {
        private string strMode;         //어떤 메뉴로 들어갈지 여부
        private Boolean flag = true;    //종료 flag
        private DrawControlMember drawControlMember;    //UI 그리기 위한 객체
        private List<Member> listUserMember;            //유저 정보
        private List<Member> listSuperviser;            //관리자 정보
        private List<Book> listBook;                    //책정보
        private List<RentalData> listRental;            //대여자 정보
        private Login loginUser;                            //메뉴 선택시 로그인 창으로 넘어가기 위함
        private Login loginSuper;
        private SignUp signUp;
        /// <summary>
        /// 시작했을때 첫 화면 선택에 따라서
        /// 관리자모드, 회원모드, 회원가입 모드로 이동한다.
        /// </summary>
        public StartMenu()
        {
            loginSuper = new Login(strMode, listSuperviser, listUserMember, listBook, listRental);
            loginUser = new Login(strMode, listUserMember, listUserMember, listBook, listRental);
            signUp = new SignUp(listUserMember);

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
        }
        public void StartMainMenu()
        {
            while (flag)
            {
                drawControlMember.BasicMenu();
                strMode = Console.ReadLine();
                switch (strMode)
                {
                    case LibraryConstants.LoginSuperviserMode:
                        loginSuper.CheckAndChangeScene(strMode,listSuperviser,listUserMember,listBook,listRental);
                        break;

                    case LibraryConstants.LoginUserMode:
                        loginUser.CheckAndChangeScene(strMode, listSuperviser, listUserMember, listBook, listRental);
                        break;

                    case LibraryConstants.GoToSignUpPage:
                        signUp.HelpSignUp(listUserMember);
                        break;

                    case LibraryConstants.Exit:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
