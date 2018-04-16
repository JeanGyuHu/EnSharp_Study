﻿using System;
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
        public UserMode(List<Member> memList, List<Book> bookList,List<RentalData> rentalList,string id)
        {
            drawControlMember = new DrawControlMember();
            extendRentalTime = new ExtendRentalTime(memList, rentalList, id);
            rentBook = new RentBook(bookList, rentalList, id);
            returnBooks = new ReturnBooks(bookList,rentalList,id);
        }

        public void UserMenu(List<Member> memList, List<Book> bookList, List<RentalData> rentalList, string id)
        {
            while (flag)
            {
                drawControlMember.UserModeMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case LibraryConstants.RentBookPage:
                        rentBook.RentBookPage(bookList,rentalList,id);
                        break;
                    case LibraryConstants.ExtendRentalTimePage:
                        extendRentalTime.DrawAndRun(memList, rentalList, id);
                        break;
                    case LibraryConstants.ReturnBooks:
                        returnBooks.ReturnBook(bookList,rentalList,id);
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
        public void setId(string userId)
        {
            id = userId;
        }
    }
}