﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LibraryManagementWithNaverAPI
{
    class LibraryManagement
    {
        private ExceptionHandler exceptionHandler;    //예외처리를 위한 객체 선언
        private PrintAboutBooks printAboutBooks;          //UI를 그리기 위한 객체 선언
        private DBExceptionHandler dBExceptionHandler;
        private BookDAO bookDAO;
        private string status;                       //어떤 작업을 할지 선택받는 변수
        private bool flag = true;                       //이전 메뉴로 돌아가기 위한 flag
        private string no;                       //책 번호 입력받기 위함
        private string name;                     //책 이름 입력받기 위함
        private string count;                    //책 개수 입력받기 위함
        private string price;                       //책의 가격을 받기 위함
        private string author;                   //책 저자 입력받기 위함
        private string publisher;                //책 출판사 입력받기 위함
        private string deleteName;                         //삭제할 이름 입력받기 위함
        private string search;                       //어떤걸로 검색할지 입력받기 위함
        private string mode;
        private string publishDate;
        private string information;
        private string answer;
        private List<Book> bookList;
        private LogDAO logDAO;

        /// <summary>
        /// 생성자로써 사용되는 객체를 생성, 초기화한다.
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public LibraryManagement()
        {
            dBExceptionHandler = new DBExceptionHandler();
            exceptionHandler = new ExceptionHandler();
            printAboutBooks = new PrintAboutBooks();
            bookDAO = new BookDAO();
            bookList = new List<Book>();
            logDAO = new LogDAO();
        }

        /// <summary>
        /// 원하는 책을 지울때 사용하는 메소드
        /// </summary>
        /// <param name="list">책 목록</param>
        public void DrawDelete()
        {
            DeleteSub();

            if (bookDAO.DeleteBook(deleteName))
            {
                logDAO.AddLog(DateTime.Now, deleteName, "도서 삭제");
                printAboutBooks.DeleteResult("S U C C E S S !");
            }
            else
                printAboutBooks.DeleteResult("F A I L E D !");
        }
        /// <summary>
        /// 책을 삭제할때 기본 키 값인 No값을 체크해주는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DeleteSub()
        {
            printAboutBooks.Category();
            bookDAO.SearchAll();

            printAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (!exceptionHandler.CheckBookNo(deleteName))
                DeleteSub();
        }
        /// <summary>
        /// 원하는 정보로 검색하는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DrawSearch()
        {
            bool exitFlag = true;
            while (exitFlag)
            {
                printAboutBooks.SearchMenu();
                deleteName = Console.ReadLine();
                Console.Clear();
                switch (deleteName)
                {
                    case LibraryConstants.SEARCH_BOOK_NO:
                        SearchSub(LibraryConstants.SEARCH_BOOK_NO);
                        if (search.Equals("0")) return;
                        printAboutBooks.Category();
                        logDAO.AddLog(DateTime.Now, search, "로컬 도서 검색");
                        bookDAO.SearchWithQuary("Select * from book where no = \"" + search + "\"");
                        break;
                    case LibraryConstants.SEARCH_BOOK_NAME:
                        SearchSub(LibraryConstants.SEARCH_BOOK_NAME);
                        if (search.Equals("0")) return;
                        printAboutBooks.Category();
                        logDAO.AddLog(DateTime.Now, search, "로컬 도서 검색");
                        bookDAO.SearchWithQuary("Select * from book where name = \"" + search + "\"");
                        break;
                    case LibraryConstants.SEARCH_BOOK_COUNT:
                        SearchSub(LibraryConstants.SEARCH_BOOK_COUNT);
                        if (search.Equals("0")) return;
                        printAboutBooks.Category();
                        logDAO.AddLog(DateTime.Now, search, "로컬 도서 검색");
                        bookDAO.SearchWithQuary("Select * from book where count = \"" + search + "\"");
                        break;
                    case LibraryConstants.SEARCH_BOOK_AUTHOR:
                        SearchSub(LibraryConstants.SEARCH_BOOK_AUTHOR);
                        if (search.Equals("0")) return;
                        printAboutBooks.Category();
                        logDAO.AddLog(DateTime.Now, search, "로컬 도서 검색");
                        bookDAO.SearchWithQuary("Select * from book where author = \"" + search + "\"");
                        break;
                    case LibraryConstants.SEARCH_BOOK_PUBLISHER:
                        SearchSub(LibraryConstants.SEARCH_BOOK_PUBLISHER);
                        if (search.Equals("0")) return;
                        printAboutBooks.Category();
                        logDAO.AddLog(DateTime.Now, search, "로컬 도서 검색");
                        bookDAO.SearchWithQuary("Select * from book where publisher = \"" + search + "\"");
                        break;
                    case LibraryConstants.SEARCH_BOOK_IN_NAVER:
                        SearchSub(deleteName);
                        break;
                    case LibraryConstants.SEARCH_GO_BACK:
                        exitFlag = false;
                        return;
                    default:
                        break;

                }
            }
            printAboutBooks.PressAnyKey();
        }
        /// <summary>
        /// 검색할때 들어오는 입력값에 대해서 예외처리를 해주는 메소드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mode"></param>
        public void SearchSub(string mode)
        {

            switch (mode)
            {
                case LibraryConstants.SEARCH_BOOK_NO:
                    printAboutBooks.WriteBookNo();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandler.CheckBookNo(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_NO);
                    }
                    break;
                case LibraryConstants.SEARCH_BOOK_NAME:
                    printAboutBooks.WriteBookName();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (search.Length < 1 || search.Length > 15)
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_NAME);
                    }
                    if (Regex.IsMatch(search, @"^\s"))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_NAME);
                    }
                    break;
                case LibraryConstants.SEARCH_BOOK_COUNT:
                    printAboutBooks.WriteBookCount();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (exceptionHandler.CheckBookCount(search).Equals(-1))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_COUNT);
                    }
                    break;
                case LibraryConstants.SEARCH_BOOK_AUTHOR:
                    printAboutBooks.WriteBookAuthor();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandler.CheckAuthor(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_AUTHOR);
                    }
                    break;
                case LibraryConstants.SEARCH_BOOK_PUBLISHER:
                    printAboutBooks.WriteBookPublisher();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandler.CheckPublisher(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SEARCH_BOOK_PUBLISHER);
                    }
                    break;
                case LibraryConstants.SEARCH_BOOK_IN_NAVER:
                    SearchInNaver();
                    break;
                case LibraryConstants.SEARCH_GO_BACK:
                    break;
                default:
                    break;
            }
        }
        public void SearchInNaver()
        {
            bool exitFlag = true;
            while (exitFlag)
            {
                printAboutBooks.SearchCategoryInNaver();
                mode = Console.ReadLine();
                
                switch (mode)
                {
                    case LibraryConstants.SEARCH_NAVER_NAME:
                        
                        if (!SearchSubInNaver(mode))
                            return;
                        status = "도 서 명";
                        bookList = printAboutBooks.ResultFromNaver(status, search, Convert.ToInt32(count));
                        logDAO.AddLog(DateTime.Now, search, "네이버 도서 검색");
                        printAboutBooks.PressAnyKey();
                        if (bookList != null)
                            AddAfterSearch(bookList);
                        return;
                    case LibraryConstants.SEARCH_NAVER_PUBLISHER:
                        
                        if (!SearchSubInNaver(mode))
                            return;
                        status = "출 판 사";
                        bookList = printAboutBooks.ResultFromNaver(status, search, Convert.ToInt32(count));
                        logDAO.AddLog(DateTime.Now, search, "네이버 도서 검색");
                        printAboutBooks.PressAnyKey();
                        if (bookList != null)
                            AddAfterSearch(bookList);
                        return;
                    case LibraryConstants.SEARCH_NAVER_AUTHOR:
                        if (!SearchSubInNaver(mode))
                            return;
                        status = "저    자";
                        bookList = printAboutBooks.ResultFromNaver(status, search, Convert.ToInt32(count));
                        logDAO.AddLog(DateTime.Now, search, "네이버 도서 검색");
                        printAboutBooks.PressAnyKey();
                        if (bookList != null) 
                            AddAfterSearch(bookList);
                        return;
                    case LibraryConstants.GO_BACK:
                        exitFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddAfterSearch(List<Book> list)
        {
            bool successFlag = false, yesOrNoExitFlag= true;
            while (yesOrNoExitFlag)
            {
                Console.Clear();
                printAboutBooks.AddOrNot();
                mode = Console.ReadLine();

                switch (mode)
                {
                    case LibraryConstants.YES:
                        Console.Clear();
                        printAboutBooks.ResultFromNaver(status,search, Convert.ToInt32(count));
                        printAboutBooks.WriteBookNo();
                        answer = Console.ReadLine();

                        foreach (Book book in list)
                        {
                            if (book.Isbn.Equals(answer))
                            {
                                if (dBExceptionHandler.IsInBookDB(answer))
                                {
                                    bookDAO.AddBook(new Book(book.Isbn, book.Name, book.Count, book.Pbls, book.Author, book.Price, book.PblsDate, book.Information));
                                    logDAO.AddLog(DateTime.Now, book.Isbn, "네이버 도서 추가");
                                    successFlag = true;
                                    break;
                                }
                            }
                        }
                        if (successFlag)
                            printAboutBooks.AddResult("S U C C E S S !");
                        else
                            printAboutBooks.AddResult("F A I L E D ! (잘못된 ISBN이거나, 이미 추가된 항목입니다.)");
                        return;
                    case LibraryConstants.NO:
                        printAboutBooks.PressAnyKey();
                        yesOrNoExitFlag = false;
                        return;
                    default:
                        break;
                }
            }
        }
        public bool SearchSubInNaver(string mode)
        {
            Console.Clear();
            if(mode.Equals(LibraryConstants.SEARCH_NAVER_NAME))
                printAboutBooks.WriteBookName();
            else if(mode.Equals(LibraryConstants.SEARCH_NAVER_PUBLISHER))
                printAboutBooks.WriteBookPublisher();
            else if(mode.Equals(LibraryConstants.SEARCH_NAVER_AUTHOR))
                printAboutBooks.WriteBookAuthor();

            search = Console.ReadLine();
            if (search.Equals("0"))
                return false;
            else if (Regex.IsMatch(search, @"^ *$") || search.Length < 1)
            {
                SearchSubInNaver(mode);
                return false;
            }
            printAboutBooks.WriteBookCount();
            count = Console.ReadLine();
            if (count.Equals("0"))
                return false;
            else if (!exceptionHandler.CheckBookCount(count))
            {
                SearchSubInNaver(mode);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 책의 이름을 받는 메소드
        /// </summary>
        public void DrawName()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookName();
            name = Console.ReadLine();
            if (name.Equals("0"))
                return;
            if (name.Equals("1"))
                DrawNo();
            if (name.Length < 1 || name.Length > 15)
                DrawName();
            if (Regex.IsMatch(name, @"^\s"))
                DrawName();
        }

        /// <summary>
        /// 책의 정보를 입력받고 수정하는 메소드를 호출
        /// </summary>
        /// <param name="list">모든 책 리스트</param>
        public void DrawEdit()
        {
            printAboutBooks.Category();
            bookDAO.SearchAll();

            printAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (deleteName.Equals("1"))
                return;
            if (!exceptionHandler.CheckBookNo(deleteName))
                DrawEdit();
            else
            {
                EditWhichOne();
            }
        }

        public void EditWhichOne()
        {
            bool exitFlag = true;

            while (exitFlag)
            {
                printAboutBooks.WriteEditWhich();
                mode = Console.ReadLine();

                switch (mode)
                {
                    case LibraryConstants.EDIT_COUNT:
                        DrawCountRead();
                        if (count.Equals("-1"))
                            return;
                        else if (count.Equals("-2"))
                            return;
                        else
                        {
                            if (!dBExceptionHandler.IsInBookDB(deleteName))
                            {
                                bookDAO.EditBookCount(deleteName, Convert.ToInt32(count));
                                logDAO.AddLog(DateTime.Now, deleteName, "도서 수량 수정");
                                //drawAboutBooks.EditResult("S U C C E S S");
                            }
                            else
                            {
                                //drawAboutBooks.EditResult("F A I L E D");
                            }
                        }
                        return;
                    case LibraryConstants.EDIT_PRICE:
                        DrawEditPrice();
                        if (price.Equals("0"))
                            return;
                        else if (price.Equals("1"))
                            return;
                        else
                        {
                            if (!dBExceptionHandler.IsInBookDB(deleteName))
                            {
                                bookDAO.EditBookPrice(deleteName, Convert.ToInt32(price));
                                logDAO.AddLog(DateTime.Now, deleteName, "도서 가격 수정");
                                //drawAboutBooks.EditResult("S U C C E S S");
                            }
                            else
                            {
                                //drawAboutBooks.EditResult("F A I L E D");
                            }
                        }
                        return;
                    case LibraryConstants.EDIT_EXIT:
                        exitFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void DrawCountRead()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookCount();
            count = Console.ReadLine();
            if (count.Equals("-1"))
                return;
            if (count.Equals("-2"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandler.CheckBookCount(count))
            {
                DrawCountRead();
            }
        }
        /// <summary>
        /// 책 번호를 입력받는 메소드
        /// </summary>
        public void DrawNo()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;

            if (!exceptionHandler.CheckBookNo(no))
            {
                DrawNo();
            }
            if (!dBExceptionHandler.IsInBookDB(no))
            {
                DrawNo();
            }
        }

        /// <summary>
        /// 저자를 입력받는 메소드
        /// </summary>
        public void DrawAuthor()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookAuthor();
            author = Console.ReadLine();
            if (author.Equals("0"))
                return;
            if (author.Equals("1"))
                DrawCountRead();
            if (!exceptionHandler.CheckAuthor(author))
                DrawAuthor();
        }

        public void DrawPblsDate()
        {
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookPublishDate();
            publishDate = Console.ReadLine();
            if (publishDate.Equals("0"))
                return;
            if (publishDate.Equals("1"))
                return;


        }
        /// <summary>
        /// 출판사를 입력받는 메소드
        /// </summary>
        public void DrawPublisher()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.WriteBookPublisher();
            publisher = Console.ReadLine();
            if (publisher.Equals("0"))
                return;
            if (publisher.Equals("1"))
                DrawAuthor();
            if (!exceptionHandler.CheckPublisher(publisher))
                DrawPublisher();
        }
        public void DrawEditPrice()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.DrawWritePrice();
            price = Console.ReadLine();
            if (price.Equals("0"))
                return;
            if (price.Equals("1"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandler.CheckPrice(price))
                DrawEditPrice();
        }
        public void DrawPrice()
        {
            Console.Clear();
            printAboutBooks.InfoTitle();
            printAboutBooks.DrawWritePrice();
            price = Console.ReadLine();
            if (price.Equals("0"))
                return;
            if (price.Equals("1"))
                DrawPublisher();
            if (!exceptionHandler.CheckPrice(price))
                DrawPrice();
        }
        /// <summary>
        /// 새 책을 추가하는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DrawAdd()
        {
            DrawNo();
            if (no.Equals("0"))
                return;

            DrawName();
            if (name.Equals("0"))
                return;
            DrawCountRead();
            if (count.Equals("-1"))
                return;
            DrawAuthor();
            if (author.Equals("0"))
                return;
            DrawPublisher();
            if (publisher.Equals("0"))
                return;
            DrawPrice();
            if (price.Equals("0"))
                return;
            if (!dBExceptionHandler.IsInBookDB(no))
            {
                printAboutBooks.AddResult("F A I L E D !");
            }
            else
            {
                bookDAO.AddBook(new Book(no, name, Convert.ToInt32(count), publisher, author, Convert.ToInt32(price),Convert.ToDateTime(publishDate),information));
                logDAO.AddLog(DateTime.Now, no, "도서 추가");
                printAboutBooks.AddResult("S U C C E S S !");
            }

        }
    }
}
