using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class MenuLogic
    {
        private string mode;
        private string id;
        private string stringPassword;
        private SecureString securePassword;
        private AddNewMember addNewMember;
        private PrintAboutBooks printAboutBooks;
        private PrintAboutControlMembers printAboutControlMembers;
        private FunctionInUserMode functionInUserMode;
        private LibraryManagement libraryManagement;
        private BookDAO bookDAO;

        public MenuLogic()
        {
            printAboutControlMembers = new PrintAboutControlMembers();
            functionInUserMode = new FunctionInUserMode();
            libraryManagement = new LibraryManagement();
            printAboutBooks = new PrintAboutBooks();
            addNewMember = new AddNewMember();
            bookDAO = new BookDAO();
        }

        public void StartMainMenu()
        {
            //drawStartMark.StartMark();

            bool flag = true;
            while (flag)
            {
                printAboutControlMembers.BasicMenu();

                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.LOGIN_SUPERVISER_MODE:
                        Login();
                        break;

                    case LibraryConstants.LOGIN_USER_MODE:
                        Login();
                        break;

                    case LibraryConstants.GOTO_SIGNUP_PAGE:
                        addNewMember.DrawAndAdd();
                        break;

                    case LibraryConstants.EXIT:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 사용자가 선택한 모드에 따라서 관리자모드, 유저모드를 호출해준다.
        /// </summary>
        /// <param name="mode">선택한 모드</param>
        /// <param name="slist">superviser id 목록</param>
        /// <param name="ulist">user id 목록</param>
        /// <param name="bookList">책 목록</param>
        /// <param name="rentalList">대여자 목록</param>
        public void Login()
        {
            bool loginFlag = false;

            loginFlag = addNewMember.DrawLoginPage(mode);

            if (id.Equals("0") || stringPassword.Equals("0"))
                return;
            if (stringPassword.Equals("-1"))
                Login();
            if (loginFlag)
            {
                if (mode.Equals(LibraryConstants.START_SUPERVISER_MODE))
                    SuperViserMenu();
                else
                    UserMenu();
            }
            else
            {
                Login();
            }
        }

        
        public void SuperViserMenu()
        {
            bool flag = true;
            while (flag)
            {
                printAboutControlMembers.SuperViserModeMenu();
                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.MEMBER_CONTROL:
                        MemberManagement();
                        break;
                    case LibraryConstants.BOOK_MANAGEMENT:
                        BookManagement();
                        break;
                    case LibraryConstants.GO_RETURN:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 유저 모드에서 메뉴창을 그리고 다음으로 이동하는 메소드
        /// </summary>
        /// <param name="memList">유저 정보리스트</param>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public void UserMenu()
        {
            bool flag = true;
            while (flag)
            {
                printAboutControlMembers.UserModeMenu();
                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.RENT_BOOK_PAGE:
                        functionInUserMode.RentBookPage(id);
                        break;
                    case LibraryConstants.EXTEND_RENTALTIME_PAGE:
                        functionInUserMode.ExtendRentalTime(id);
                        break;
                    case LibraryConstants.RETURN_BOOKS:
                        functionInUserMode.ReturnBook(id);
                        break;
                    case LibraryConstants.GO_BACK:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 멤버 관리하는 메소드 (메인 역할)
        /// </summary>
        /// <param name="list">회원 정보 목록</param>
        public void MemberManagement()
        {
            bool flag = true;
            while (flag)
            {
                printAboutControlMembers.Menu();
                mode = Console.ReadLine();

                switch (mode)
                {
                    case LibraryConstants.ADD_NEW_MEMBER:
                        addNewMember.DrawAndAdd();
                        break;
                    case LibraryConstants.EDIT_MEMBER_INFO:
                        libraryManagement.DrawEdit();
                        break;
                    case LibraryConstants.DELETE_MEMBER:
                        libraryManagement.DrawDelete();
                        break;
                    case LibraryConstants.SEARCH_MEMBER:
                        libraryManagement.DrawSearch();
                        break;
                    case LibraryConstants.PRINT_MEMBER_INFO:
                        libraryManagement.DrawPrint();
                        break;
                    case LibraryConstants.GO_BEFORE_PAGE:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 기본 메뉴창을 띄우는 메소드
        /// </summary>
        /// <param name="list">책의 리스트</param>
        public void BookManagement()
        {
            bool flag = true;
            while (flag)
            {
                printAboutBooks.ManagementMenu();
                mode = Console.ReadLine();
                switch (mode)
                {
                    case LibraryConstants.ADD_MODE:
                        libraryManagement.DrawAdd();
                        break;
                    case LibraryConstants.EDIT_MODE:
                        libraryManagement.DrawEdit();
                        break;
                    case LibraryConstants.DELETE_MODE:
                        libraryManagement.DrawDelete();
                        break;
                    case LibraryConstants.SEARCH_MODE:
                        libraryManagement.DrawSearch();
                        break;
                    case LibraryConstants.PRINT_MODE:
                        printAboutBooks.Category();
                        bookDAO.SearchAll();
                        printAboutBooks.PressAnyKey();
                        break;
                    case LibraryConstants.GO_BEFORE:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
