using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class RentBook
    {
        private string choice;           //빌리려고하는 책정보
        private int count = 0;                  //책을 다 검사했나 체크하기 위한 변수
        private int findIndex = -1;             //대여할때 찾은 책의 인덱스 값
        private DrawAboutBooks drawAboutBooks;   //UI를 그리기 위한  객체
        private ExceptionHandling exceptionHandling;
        private DateTime now;
        private BookDAO bookDAO;
        private RentalDataDAO rentalDataDAO;
        private DatabaseException databaseException;
        /// <summary>
        /// 책 정보, 이미 빌린 사람의 정보, 현재 사용중인 사람의 id를 이용하여 책을 대여해주는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용중인 유저 아이디</param>
        public RentBook(string id)
        {
            databaseException = new DatabaseException();
            rentalDataDAO = new RentalDataDAO();
            bookDAO = new BookDAO();
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
            now = DateTime.Now;
        }
        /// <summary>
        /// 책을 빌리는 창을 띄워주고
        /// 책을 고르고 빌리는 역할을 한다.
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자 명</param>
        public void RentBookPage(string id)
        {
            drawAboutBooks.Category();
            bookDAO.SearchAll();

            DrawNo();
            if (choice.Equals("0"))
                return;

            if (!databaseException.IsInAlreadyRentDB(id,choice))
            {
                drawAboutBooks.RentalResult("F A I L E D");
            }
            else if (bookDAO.GetBook(choice).Count>0)
            {
                Book book = bookDAO.GetBook(choice);
                bookDAO.EditBookInformation(choice, --book.Count,book.Price);
                rentalDataDAO.AddAfterRent(new RentalData(choice, book.Name, book.Pbls, book.Author, id, new DateTime(now.Year, now.Month + 1, now.Day + 10), 0));
                drawAboutBooks.RentalResult("S U C C E S S");
            }
            else
            {
                drawAboutBooks.RentalResult("F A I L E D (연장 횟수 초과)");    
            }

            drawAboutBooks.PressAnyKey();
        }
        /// <summary>
        /// 책의 번호를 입력받는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        public void DrawNo()
        {
            drawAboutBooks.Category();
            bookDAO.SearchAll();
            drawAboutBooks.WriteBookNo();
            choice = Console.ReadLine();
            if (choice.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(choice))
                DrawNo();
        }
    }
}
