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

            loginSuper = new Login(mode);
            loginUser = new Login(mode);
            signUp = new SignUp();

            drawControlMember = new DrawControlMember();
            
            drawStartMark = new DrawStartMark();

        }
        public void StartMainMenu()
        {
            drawStartMark.StartMark();

            flag = true;
            while (flag)
            {
                drawControlMember.BasicMenu();
               
                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.LoginSuperviserMode:
                        loginSuper.CheckAndChangeScene(mode);
                        break;

                    case LibraryConstants.LoginUserMode:
                        loginUser.CheckAndChangeScene(mode);
                        break;

                    case LibraryConstants.GoToSignUpPage:
                        signUp.HelpSignUp();
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
