using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class SuperviserMode
    {
        //매직넘버
        private const string MemberControl = "1";
        private const string BookManagement = "2";
        private const string Exit = "3";

        private bool flag = true;       //종료 flag
        private string strChoice;       //어떤 작업을 할지 입력받음
        private ControlMember controlMember;    //회원관리 메뉴
        private LibraryManagement libraryManagement;    //책관리 메뉴
        private DrawControlMember drawControlMember;    //Ui 그리는 객체

        /// <summary>
        /// 기본 생성자로써 객체를 초기화하고
        /// 선택에 따라 해당 창으로 이동한다.
        /// </summary>
        /// <param name="slist">관리자 목록</param>
        /// <param name="ulist">유저 목록</param>
        /// <param name="bookList">책 목록</param>
        public SuperviserMode(List<Member> slist, List<Member> ulist, List<Book> bookList)
        {
            drawControlMember = new DrawControlMember();

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
