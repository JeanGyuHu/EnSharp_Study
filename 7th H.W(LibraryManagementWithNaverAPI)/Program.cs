using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class Program
    {
        /*********************************************************************
         * 도서관리프로그램을 데이터베이스와 네이버API를 사용하여 만듬       *
         * 관리자 아이디는 admin 비밀번호는 123입니다.                       *
         * 회원 아이디는 gjwlsrb1700 비밀번호는 123123123 입니다.(허진규1700)*
         * 데이터베이스 아이디와 API Key는 LibraryConstants에 가서 변경하시  *
         * 면 됩니다!                                                        *
         * *******************************************************************/

        static void Main(string[] args)
        {
            MenuLogic menuLogic = new MenuLogic();
            menuLogic.StartMainMenu();
        }
    }
}
