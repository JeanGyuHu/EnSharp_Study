using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class UserMode
    {
        private string id;
        private string choice;
        private bool flag = true;
        private RentBook rentBook;
        private ExtendRentalTime extendRentalTime;
        private DrawControlMember drawControlMember;
        private ReturnBooks returnBooks;
        /// <summary>
        /// 유저 모드 메뉴의 생성자
        /// </summary>
        /// <param name="memList">유저정보리스트</param>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 정보 리스트</param>
        /// <param name="id">로그인한 사용자 정보</param>
        public UserMode(string id)
        {
            drawControlMember = new DrawControlMember();
            extendRentalTime = new ExtendRentalTime(id);
            rentBook = new RentBook(id);
            returnBooks = new ReturnBooks(id);
        }

        /// <summary>
        /// 유저 모드에서 메뉴창을 그리고 다음으로 이동하는 메소드
        /// </summary>
        /// <param name="memList">유저 정보리스트</param>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public void UserMenu(string id)
        {
            flag = true;
            while (flag)
            {
                drawControlMember.UserModeMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case LibraryConstants.RentBookPage:
                        rentBook.RentBookPage(id);
                        break;
                    case LibraryConstants.ExtendRentalTimePage:
                        extendRentalTime.DrawAndRun(id);
                        break;
                    case LibraryConstants.ReturnBooks:
                        returnBooks.ReturnBook(id);
                        break;
                    case LibraryConstants.GoBack:
                        flag = false;
                        break;
                    default:

                        break;
                }
            }
        }
        public string GetId()
        {
            return id;
        }
        public void SetId(string userId)
        {
            id = userId;
        }
    }
}
