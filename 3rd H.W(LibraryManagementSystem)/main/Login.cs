using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{


    class Login
    {
        private DatabaseException databaseException;
        private SuperviserMode superviserMode;
        private UserMode userMode;
        private DrawControlMember drawControlMember;
        private string id;
        private SecureString securePassword;
        private int idCheck = -1;
        private bool loginFlag = false;
        private string stringPassword;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">메인 메뉴에서 사용자가 선택한 메뉴
        /// superviser mode인지 User mode인지</param>
        /// <param name="slist">superviser id가 저장되어있는 리스트</param>
        /// <param name="ulist">User id가 저장되어있는 리스트</param>
        /// <param name="bookList">책정보가 저장되어있는 리스트</param>
        /// <param name="rentalList">대여자 목록이 있는 리스트</param>
        public Login(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList, List<RentalData> rentalList)
        {
            databaseException = new DatabaseException();
            superviserMode = new SuperviserMode(slist, ulist, bookList);
            userMode = new UserMode(ulist, bookList, rentalList, id);
            drawControlMember = new DrawControlMember();
            securePassword = new SecureString();
        }
        /// <summary>
        /// 사용자가 선택한 모드에 따라서 관리자모드, 유저모드를 호출해준다.
        /// </summary>
        /// <param name="mode">선택한 모드</param>
        /// <param name="slist">superviser id 목록</param>
        /// <param name="ulist">user id 목록</param>
        /// <param name="bookList">책 목록</param>
        /// <param name="rentalList">대여자 목록</param>
        public void CheckAndChangeScene(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList, List<RentalData> rentalList)
        {

            switch (mode)
            {
                case LibraryConstants.StartSuperViserMode:

                    loginFlag = DrawLoginPage(slist);
                    if (id.Equals("0") || stringPassword.Equals("0"))
                        return;
                    if (loginFlag)
                    {
                        superviserMode.SuperViserMenu(slist, ulist, bookList);
                    }
                    else
                    {
                        userMode.SetId(id);
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    }
                    break;

                case LibraryConstants.StartUserMode:
                    loginFlag = DrawLoginPage(ulist);
                    if (id.Equals("0") || stringPassword.Equals("0"))
                        return;
                    if (stringPassword.Equals("-1"))
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    if (loginFlag)
                    {
                        userMode.UserMenu(ulist, bookList, rentalList, id);
                    }
                    else
                    {
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    }
                    break;
            }
        }

        /// <summary>
        /// 로그인 페이지를 그리고 로그인이 됬는지 안됬는지 체크해주는 메소드
        /// </summary>
        /// <param name="list">멤버 목록이 들어있는 리스트</param>
        /// <returns>로그인 여부</returns>
        public bool DrawLoginPage(List<Member> list)
        {
            drawControlMember.LoginPage();
            drawControlMember.WriteId();
            id = Console.ReadLine();
            if (id.Equals("0"))
                return false;

            if (CheckID(id))
            {
                drawControlMember.WritePassword();
                securePassword = drawControlMember.GetConsoleSecurePassword();
                stringPassword = new NetworkCredential("", securePassword).Password;
                if (CheckPW(stringPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DrawLoginPage(list);
            }
            return false;
        }
        /// <summary>
        /// 아이디가 있는지 없는지 체크해주는 메소드
        /// </summary>
        /// <param name="list">유저 리스트</param>
        /// <param name="id">입력한 아이디</param>
        /// <returns></returns>
        public bool CheckID(string id)
        {
            if (!databaseException.IsIdInMemberDB(id))
                return true;

            return false;
        }
        /// <summary>
        /// 아이디를 체크했을때, 그 아이디에 해당하는 비밀번호가 사용자가 입력한 비밀번호와 일치하는지 체크
        /// </summary>
        /// <param name="list">유저 리스트</param>
        /// <param name="index">아이디가 있는 인덱스정보</param>
        /// <param name="pw">사용자가 입력한 비밀번호</param>
        /// <returns></returns>
        public bool CheckPW(string pw)
        {
            if (!databaseException.IsPasswordInMemberDB(id, pw))
                return true;

            return false;
        }
        public void SetId(string loginId)
        {
            id = loginId;
        }
    }
}
