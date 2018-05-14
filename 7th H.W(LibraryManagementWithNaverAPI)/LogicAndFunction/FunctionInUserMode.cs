using System;

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
       
        public FunctionInUserMode()
        {
            logDAO = new LogDAO();
            bookDAO = new BookDAO();
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

            if (dBExceptionHandler.IsInAlreadyRentDB(id, no))
            {
                printAboutBooks.ExtendResult("F A I L E D !");
            }
            else
            {
                if (rentalDataDAO.GetRentalData(id, no).ExtendCount < 2)
                {
                    logDAO.AddLog(DateTime.Now, rentalDataDAO.GetRentalData(id,no).BookName, "도서 연장");
                    rentalDataDAO.ChangeInformationAfterExtendTime(id, no, rentalDataDAO.GetRentalData(id, no).BookReturnTime.AddDays(10), rentalDataDAO.GetRentalData(id, no).ExtendCount + 1);

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

            if (!dBExceptionHandler.IsInAlreadyRentDB(id, no))
            {
                printAboutBooks.RentalResult("F A I L E D");
            }
            else if (bookDAO.GetBook(no).Count > 0)
            {
                Book book = bookDAO.GetBook(no);
                bookDAO.EditBookCount(no, --book.Count);
                logDAO.AddLog(DateTime.Now, book.Name, "도서 대여");
                rentalDataDAO.AddAfterRent(new RentalData(no, book.Name, book.Pbls, book.Author, id, new DateTime(now.Year, now.Month + 1, now.Day + 10), 0));
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
                bookDAO.SearchAll();
            }
            else if (mode.Equals(LibraryConstants.EXTENDTIME))
            {
                printAboutBooks.ExtendTimeTitle();
                rentalDataDAO.SearchAll();
            }
            else if (mode.Equals(LibraryConstants.RETURNBOOK))
            {
                printAboutBooks.ReturnBooksTitle();
                rentalDataDAO.SearchAll();
            }
            
            printAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;
            if (!exceptionHandler.CheckBookNo(no))
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

            if (dBExceptionHandler.IsInAlreadyRentDB(id, no))
            {
                printAboutBooks.ReturnResult("F A I L E D !");
            }
            else
            {
                logDAO.AddLog(DateTime.Now, bookDAO.GetBook(no).Name, "도서 반납");
                rentalDataDAO.ChangeAfterReturnBook(id, no);
                bookDAO.EditBookCount(no, ++bookDAO.GetBook(no).Count);
                printAboutBooks.ReturnResult("S U C C E S S !");
            }
            printAboutBooks.PressAnyKey();

        }
    }
}
