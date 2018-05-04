using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ExtendRentalTime
    {
        private BookDAO bookDAO;
        private RentalDataDAO rentalDataDAO;
        private DrawAboutBooks drawAboutBooks;
        private ExceptionHandling exceptionHandling;
        private DatabaseException databaseException;
        private string bookName;

        /// <summary>
        /// 기본 생성자로 그리고 나머지 모든 동작을 하는 메소드를 호출한다.
        /// </summary>
        /// <param name="memList">회원정보 리스트</param>
        /// <param name="rentalList">대여한 사람들의 리스트</param>
        /// <param name="id">현재 사용중인 사용자의 아이디</param>
        public ExtendRentalTime(string id)
        {
            bookDAO = new BookDAO();
            rentalDataDAO = new RentalDataDAO();
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
            databaseException = new DatabaseException();
        }
        
        /// <summary>
        /// 실질적으로 모든 작업을 하는 메소드
        /// </summary>
        /// <param name="memList">회원정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용중인 사용자 아이디</param>
        public void DrawAndRun(string id)
        {
            DrawNo(id);
            if (bookName.Equals("0"))
                return;

            if (databaseException.IsInAlreadyRentDB(id,bookName))
            {
                drawAboutBooks.ExtendResult("F A I L E D !");
            }
            else
            {
                if (rentalDataDAO.GetRentalData(id, bookName).ExtendCount < 2)
                {
                    rentalDataDAO.ChangeInformationAfterExtendTime(id, bookName, rentalDataDAO.GetRentalData(id, bookName).BookReturnTime.AddDays(10), rentalDataDAO.GetRentalData(id, bookName).ExtendCount + 1);
                    drawAboutBooks.ExtendResult("S U C C E S S !");
                }
                else
                    drawAboutBooks.ExtendResult("F A I L E D !");
            }

        }
        /// <summary>
        /// 연장을 할때 No 정보를 입력 받기 위한 메소드
        /// </summary>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자 명</param>
        public void DrawNo(string id)
        {
            drawAboutBooks.ExtendTimeTitle();
            rentalDataDAO.SearchAll();
            drawAboutBooks.WriteBookNo();
            bookName = Console.ReadLine();
            if (bookName.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(bookName))
                DrawNo(id);
        }
    }
}