using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ReturnBooks
    {
        private DatabaseException databaseException;
        private RentalDataDAO rentalDataDAO; 
        private DrawAboutBooks drawAboutBooks;          //UI를 그리기 위한 객체
        private ExceptionHandling exceptionHandling;    //예외처리를 위한 객체
        private BookDAO bookDAO;
        private string no;  //번호를 받기 위한 string 변수

        /// <summary>
        /// 생성자 객체들을 초기화하고 생성한다.
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public ReturnBooks(string id)
        {
            databaseException = new DatabaseException();
            rentalDataDAO = new RentalDataDAO();
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
            bookDAO = new BookDAO();
        }
        /// <summary>
        /// 책 빌리는 작업을 하는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public void ReturnBook(string id)
        {
            int findIndex = -1;

            DrawNo(id);
            if (no.Equals("0"))
                return;

            if (databaseException.IsInAlreadyRentDB(id,no))
            {
                drawAboutBooks.ReturnResult("F A I L E D !");
            }
            else
            {
                rentalDataDAO.ChangeAfterReturnBook(id, no);
                bookDAO.EditBookInformation(no,++bookDAO.GetBook(no).Count,bookDAO.GetBook(no).Price);
                drawAboutBooks.ReturnResult("S U C C E S S !");
            }
            drawAboutBooks.PressAnyKey();
            
        }

        /// <summary>
        /// 번호를 입력 받는 메소드
        /// </summary>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자 명</param>
        public void DrawNo(string id)
        {
            drawAboutBooks.ReturnBooksTitle();
            rentalDataDAO.SearchAll();
            drawAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(no))
            {
                DrawNo(id);
                if (no.Equals("0"))
                    return;
            }
        }
    }
}
