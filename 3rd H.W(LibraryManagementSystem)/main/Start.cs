using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Start
    {
        /****************************************************
         * 도서관리프로그램 (MySQL을 통해 데이터베이스 연동)*
         * 관리자 아이디는 Admin 비밀번호는 123             *
         * 사용자 아이디는 qwe 비밀번호는 123입니다.        *
         * 원하는 메뉴에 들어가면서 작업하시면 됩니다.      *
         * *************************************************/
        static void Main(string[] args)
        {
            StartMenu startMenu = new StartMenu();
            startMenu.StartMainMenu();
        }
    }
}
