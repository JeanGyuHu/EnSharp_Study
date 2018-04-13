using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class UserMode
    {
        //매직 넘버
        private const string RentBookPage = "1";
        private const string ExtendRentalTimePage = "2";
        private const string Exit = "3";

        private string strChoice;
        private bool flag = true;
        private RentBook rentBook;
        private ExtendRentalTime extendRentalTime;
        private DrawControlMember drawControlMember;

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
            while (flag)
            {
                drawControlMember.DrawUserModeMenu();
                strChoice = Console.ReadLine();
                switch (strChoice)
                {
                    case RentBookPage:
                        rentBook = new RentBook(bookList,rentalList,id);
                        break;

                    case ExtendRentalTimePage:
                        extendRentalTime = new ExtendRentalTime(memList,rentalList,id);
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
