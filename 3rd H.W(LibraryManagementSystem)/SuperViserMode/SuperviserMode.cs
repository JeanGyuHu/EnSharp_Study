﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class SuperviserMode
    {
        private bool flag = true;       //종료 flag
        private string choice;       //어떤 작업을 할지 입력받음
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
        public SuperviserMode()
        {
            drawControlMember = new DrawControlMember();
            controlMember = new ControlMember();
            libraryManagement = new LibraryManagement();  
        }

        /// <summary>
        /// 관리자모드 메뉴 창을 띄워주는 메소드
        /// </summary>
        /// <param name="slist">관리자 정보 리스트</param>
        /// <param name="ulist">유저 정보 리스트</param>
        /// <param name="bookList">책 정보 리스트</param>
        public void SuperViserMenu()
        {
            flag = true;
            while (flag)
            {
                drawControlMember.SuperViserModeMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case LibraryConstants.MemberControl:
                        controlMember.MemberManagement();
                        break;
                    case LibraryConstants.BookManagement:
                        libraryManagement.DrawAndSelectMenu();
                        break;
                    case LibraryConstants.GoReturn:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
