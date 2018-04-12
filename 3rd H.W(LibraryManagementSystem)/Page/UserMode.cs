using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class UserMode
    {
        private const string RentBookPage = "1";
        private const string ExtendRentalTimePage = "2";
        private const string Exit = "3";
        private string strChoice;
        private bool flag = true;
        private RentBook rentBook;
        private ExtendRentalTime extendRentalTime;
        private DrawControlMember drawControlMember = new DrawControlMember();

        public UserMode(List<Member> memList, List<Book> bookList,List<RentalData> rentalList,string id)
        {
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
