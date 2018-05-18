using System;
using System.Collections.Generic;

namespace LibraryManagementWithNaverAPI
{
    class FunctionInUserMode
    {
        private LogDAO logDAO;
        private BookDAO bookDAO;
        private RentalDataDAO rentalDataDAO;
        private PrintAboutBooks printAboutBooks;
        private ExceptionHandler exceptionHandler;
        private DBExceptionHandler dBExceptionHandler;
        private DateTime now;
        private string no;
        private string choice;
        private List<Book> bookList;
        private List<RentalData> rentalList;

        public FunctionInUserMode()
        {
            logDAO = new LogDAO();
            bookDAO = new BookDAO();
            bookList = new List<Book>();
            rentalList = new List<RentalData>();
            rentalDataDAO = new RentalDataDAO();
            printAboutBooks = new PrintAboutBooks();
            exceptionHandler = new ExceptionHandler();
            dBExceptionHandler = new DBExceptionHandler();
            now = DateTime.Now;
        }

        /// <summary>
        /// 실질적으로 모든 작업을 하는 메소드
        /// </summary>
        /// <param name="memList">회원정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용중인 사용자 아이디</param>
        public void ExtendRentalTime(string id)
        {
            PrintNo(LibraryConstants.EXTENDTIME);
            if (no.Equals("0"))
                return;

            if (dBExceptionHandler.IsInAlreadyRentDB(id, rentalList[Convert.ToInt32(no) - 1].BookNo))
            {
                printAboutBooks.ExtendResult("F A I L E D !");
            }
            else
            {
                if (rentalDataDAO.GetRentalData(id, rentalList[Convert.ToInt32(no) - 1].BookNo).ExtendCount < 2)
                {
                    logDAO.AddLog(DateTime.Now, rentalDataDAO.GetRentalData(id, rentalList[Convert.ToInt32(no) - 1].BookNo).BookName, "도서 연장");
                    rentalDataDAO.ChangeInformationAfterExtendTime(id, rentalList[Convert.ToInt32(no) - 1].BookNo, rentalDataDAO.GetRentalData(id, rentalList[Convert.ToInt32(no) - 1].BookNo).BookReturnTime.AddDays(10), rentalDataDAO.GetRentalData(id, rentalList[Convert.ToInt32(no) - 1].BookNo).ExtendCount + 1);

                    printAboutBooks.ExtendResult("S U C C E S S !");
                }
                else
                    printAboutBooks.ExtendResult("F A I L E D !");
            }

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
            printAboutBooks.Category();
            bookDAO.SearchAll();

            PrintNo(LibraryConstants.RENTBOOK);
            if (no.Equals("0"))
                return;

            if (!dBExceptionHandler.IsInAlreadyRentDB(id, bookList[Convert.ToInt32(no) - 1].Isbn))
            {
                printAboutBooks.RentalResult("F A I L E D");
            }
            else if (bookDAO.GetBook(bookList[Convert.ToInt32(no) - 1].Isbn).Count > 0)
            {
                Book book = bookDAO.GetBook(bookList[Convert.ToInt32(no) - 1].Isbn);
                bookDAO.EditBookCount(bookList[Convert.ToInt32(no) - 1].Isbn, --book.Count);
                logDAO.AddLog(DateTime.Now, book.Name, "도서 대여");
                rentalDataDAO.AddAfterRent(new RentalData(bookList[Convert.ToInt32(no) - 1].Isbn, book.Name, book.Pbls, book.Author, id, new DateTime(now.Year, now.Month + 1, now.Day + 10),0,0));
                printAboutBooks.RentalResult("S U C C E S S");
            }
            else
            {
                printAboutBooks.RentalResult("F A I L E D (연장 횟수 초과)");
            }

            printAboutBooks.PressAnyKey();
        }

        /// <summary>
        /// 연장을 할때 No 정보를 입력 받기 위한 메소드
        /// </summary>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자 명</param>
        public void PrintNo(string mode)
        {
            if(mode.Equals(LibraryConstants.RENTBOOK))
            {
                printAboutBooks.Category();
                bookList = bookDAO.SearchAll();
            }
            else if (mode.Equals(LibraryConstants.EXTENDTIME))
            {
                printAboutBooks.ExtendTimeTitle();
                rentalList = rentalDataDAO.SearchAll();
            }
            else if (mode.Equals(LibraryConstants.RETURNBOOK))
            {
                printAboutBooks.ReturnBooksTitle();
                rentalList = rentalDataDAO.SearchAll();
            }
            
            printAboutBooks.WriteNumber();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;
            if (!exceptionHandler.CheckBookCount(no))
                PrintNo(mode);
        }

        /// <summary>
        /// 책 빌리는 작업을 하는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public void ReturnBook(string id)
        {
            PrintNo(LibraryConstants.RETURNBOOK);
            if (no.Equals("0"))
                return;

            if (dBExceptionHandler.IsInAlreadyRentDB(id, rentalList[Convert.ToInt32(no)-1].BookNo))
            {
                printAboutBooks.ReturnResult("F A I L E D !");
            }
            else
            {
                logDAO.AddLog(DateTime.Now, bookDAO.GetBook(rentalList[Convert.ToInt32(no) - 1].BookNo).Name, "도서 반납");
                rentalDataDAO.ChangeAfterReturnBook(id, rentalList[Convert.ToInt32(no) - 1].BookNo);
                bookDAO.EditBookCount(no, ++bookDAO.GetBook(rentalList[Convert.ToInt32(no) - 1].BookNo).Count);
                printAboutBooks.ReturnResult("S U C C E S S !");
            }
            printAboutBooks.PressAnyKey();

        }
    }
}
