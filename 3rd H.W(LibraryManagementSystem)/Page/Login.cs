﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    
    
    class Login
    {
        //매직넘버
        private const string StartSuperViserMode = "1";
        private const string StartUserMode = "2";

        private DrawControlMember drawControlMember;
        private string id;
        private SecureString securePassword;
        private int idCheck = -1;
        private bool loginFlag = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode">메인 메뉴에서 사용자가 선택한 메뉴
        /// superviser mode인지 User mode인지</param>
        /// <param name="slist">superviser id가 저장되어있는 리스트</param>
        /// <param name="ulist">User id가 저장되어있는 리스트</param>
        /// <param name="bookList">책정보가 저장되어있는 리스트</param>
        /// <param name="rentalList">대여자 목록이 있는 리스트</param>
        public Login(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList,List<RentalData> rentalList)
        {
            drawControlMember = new DrawControlMember();
            securePassword = new SecureString();
            CheckAndChangeScene(mode,slist, ulist, bookList, rentalList);
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
                case StartSuperViserMode:

                    loginFlag = DrawLoginPage(slist);

                    if (loginFlag)
                    {
                        SuperviserMode super = new SuperviserMode(slist, ulist, bookList);
                    }
                    else
                    {
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    }
                    break;

                case StartUserMode:
                    loginFlag = DrawLoginPage(ulist);

                    if (loginFlag)
                    {
                        UserMode user = new UserMode(ulist, bookList, rentalList, id);
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
            drawControlMember.DrawLoginPage();
            drawControlMember.DrawWriteId();
            id = Console.ReadLine();
            idCheck = CheckID(list, id);

            if (idCheck != -1)
            {
                drawControlMember.DrawWritePassword();
                securePassword = drawControlMember.GetConsoleSecurePassword();
                string stringPassword = new NetworkCredential("", securePassword).Password;
                if(CheckPW(list, idCheck, stringPassword))
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
        public int CheckID(List<Member> list,string id)
        {
            for(int check = 0;check <list.Count;check++)
            {
                if (list[check].Id.Equals(id))
                    return check;
            }
            return -1;
        }
        /// <summary>
        /// 아이디를 체크했을때, 그 아이디에 해당하는 비밀번호가 사용자가 입력한 비밀번호와 일치하는지 체크
        /// </summary>
        /// <param name="list">유저 리스트</param>
        /// <param name="index">아이디가 있는 인덱스정보</param>
        /// <param name="pw">사용자가 입력한 비밀번호</param>
        /// <returns></returns>
        public bool CheckPW(List<Member> list,int index, string pw)
        {
            if (list[index].Password.Equals(pw))
                return true;

            return false;
        }
    }
}
