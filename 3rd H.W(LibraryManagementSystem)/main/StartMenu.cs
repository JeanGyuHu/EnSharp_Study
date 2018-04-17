using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class StartMenu
    {
        private string mode;         //어떤 메뉴로 들어갈지 여부
        private Boolean flag = true;    //종료 flag
        private DrawControlMember drawControlMember;    //UI 그리기 위한 객체
        private List<Member> listUserMember;            //유저 정보
        private List<Member> listSuperviser;            //관리자 정보
        private List<Book> listBook;                    //책정보
        private List<RentalData> listRental;            //대여자 정보
        private Login loginUser;                            //메뉴 선택시 로그인 창으로 넘어가기 위함
        private Login loginSuper;                       //관리자모드를 위해 선언
        private SignUp signUp;                          //유저모드를 위해 선언  
        private DrawStartMark drawStartMark;            //★
        /// <summary>
        /// 시작했을때 첫 화면 선택에 따라서
        /// 관리자모드, 회원모드, 회원가입 모드로 이동한다.
        /// </summary>
        public StartMenu()
        {

            loginSuper = new Login(mode, listSuperviser, listUserMember, listBook, listRental);
            loginUser = new Login(mode, listUserMember, listUserMember, listBook, listRental);
            signUp = new SignUp(listUserMember);

            drawControlMember = new DrawControlMember();
            listUserMember = new List<Member>();
            listSuperviser = new List<Member>();
            listBook = new List<Book>();
            listRental = new List<RentalData>();
            drawStartMark = new DrawStartMark();

            listBook.Add(new Book("12-12341234", "C++프로그래밍", 1, "허진교출판사", "허진교"));
            listBook.Add(new Book("12-12341235", "C프로그래밍", 2, "허진규출판사", "허진규"));
            listBook.Add(new Book("12-12341236", "C#프로그래밍", 3, "허진구출판사", "허진구"));
            listSuperviser.Add(new Member("1", "1", "1", "1", 1, "1", "1"));
            listUserMember.Add(new Member("1", "1", "1", "1", 1, "1", "1"));
            listUserMember.Add(new Member("김예진", "970102-2222222", "1", "rladPwls12", 1, "서울시 군자구 화양로", "010-1234-1234"));
            listUserMember.Add(new Member("주영준", "960202-1111111", "1", "wndudwns23", 2, "서울시 군자구 세종로", "010-2345-2345"));
            listUserMember.Add(new Member("서코찡", "920302-1223232", "1", "tjzhWld123", 3, "서울시 율곡구 육공오로", "010-3456-3456"));
            listUserMember.Add(new Member("허진규", "920402-1133223", "1", "gjwlsrb1231", 4, "서울시 율곡구 에이로", "010-4701-8554"));
            listRental.Add(new RentalData("12-12341234","C++프로그래밍","호호출판사","호호","서코찡",new DateTime(2018,05,10)));
            listRental.Add(new RentalData("12-12341235", "C프로그래밍", "하하출판사", "하하", "김예진", new DateTime(2018,05,10)));
            listRental.Add(new RentalData("12-12341236", "C#프로그래밍", "후후출판사", "후후", "주영준", new DateTime(2018,05,10)));
        }
        public void StartMainMenu()
        {
            //drawStartMark.StartMark();

            flag = true;
            while (flag)
            {
                drawControlMember.BasicMenu();
               
                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.LoginSuperviserMode:
                        loginSuper.CheckAndChangeScene(mode,listSuperviser,listUserMember,listBook,listRental);
                        break;

                    case LibraryConstants.LoginUserMode:
                        loginUser.CheckAndChangeScene(mode, listSuperviser, listUserMember, listBook, listRental);
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
