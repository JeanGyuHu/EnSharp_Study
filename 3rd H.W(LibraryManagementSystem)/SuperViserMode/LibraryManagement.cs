using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EnSharp_day3
{
    class LibraryManagement
    {
        private ExceptionHandling exceptionHandling;    //예외처리를 위한 객체 선언
        private DrawAboutBooks drawAboutBooks;          //UI를 그리기 위한 객체 선언
        private DatabaseException databaseException;
        private BookDAO bookDAO;
        private string choice;                       //어떤 작업을 할지 선택받는 변수
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
        /// <summary>
        /// 생성자로써 사용되는 객체를 생성, 초기화한다.
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public LibraryManagement()
        {
            databaseException = new DatabaseException();
            exceptionHandling = new ExceptionHandling();
            drawAboutBooks = new DrawAboutBooks();
            bookDAO = new BookDAO();
        }

        /// <summary>
        /// 기본 메뉴창을 띄우는 메소드
        /// </summary>
        /// <param name="list">책의 리스트</param>
        public void DrawAndSelectMenu()
        {
            flag = true;
            while (flag)
            {
                drawAboutBooks.ManagementMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case LibraryConstants.AddMode:
                        DrawAdd();
                        break;
                    case LibraryConstants.EditMode:
                        DrawEdit();
                        break;
                    case LibraryConstants.DeleteMode:
                        DrawDelete();
                        break;
                    case LibraryConstants.SearchMode:
                        DrawSearch();
                        break;
                    case LibraryConstants.PrintMode:
                        drawAboutBooks.Category();
                        bookDAO.SearchAll();
                        drawAboutBooks.PressAnyKey();
                        break;
                    case LibraryConstants.GoBefore:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 원하는 책을 지울때 사용하는 메소드
        /// </summary>
        /// <param name="list">책 목록</param>
        public void DrawDelete()
        {
            DeleteSub();

            if (bookDAO.DeleteBook(deleteName))
                drawAboutBooks.DeleteResult("S U C C E S S !");
            else
                drawAboutBooks.DeleteResult("F A I L E D !");
        }
        /// <summary>
        /// 책을 삭제할때 기본 키 값인 No값을 체크해주는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DeleteSub()
        {
            drawAboutBooks.Category();
            bookDAO.SearchAll();

            drawAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(deleteName))
                DeleteSub();
        }
        /// <summary>
        /// 원하는 정보로 검색하는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DrawSearch()
        {
            drawAboutBooks.SearchMenu();
            deleteName = Console.ReadLine();
            Console.Clear();
            switch (deleteName)
            {
                case LibraryConstants.SearchBookNo:
                    SearchSub(LibraryConstants.SearchBookNo);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + search + "\"");
                    break;
                case LibraryConstants.SearchBookName:
                    SearchSub(LibraryConstants.SearchBookName);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where name = \"" + search + "\"");
                    break;
                case LibraryConstants.SearchBookCount:
                    SearchSub(LibraryConstants.SearchBookCount);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where count = \"" + search + "\"");
                    break;
                case LibraryConstants.SearchBookAuthor:
                    SearchSub(LibraryConstants.SearchBookAuthor);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where author = \"" + search + "\"");
                    break;
                case LibraryConstants.SearchBookPublisher:
                    SearchSub(LibraryConstants.SearchBookPublisher);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where publisher = \"" + search + "\"");
                    break;
                case LibraryConstants.GoBefore:
                    break;
                default:
                    DrawSearch();
                    break;

            }
            drawAboutBooks.PressAnyKey();
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
                case LibraryConstants.SearchBookNo:
                    drawAboutBooks.WriteBookNo();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckBookNo(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookNo);
                    }
                    break;
                case LibraryConstants.SearchBookName:
                    drawAboutBooks.WriteBookName();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (search.Length < 1 || search.Length > 15)
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookName);
                    }
                    if (Regex.IsMatch(search, @"^\s"))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookName);
                    }
                    break;
                case LibraryConstants.SearchBookCount:
                    drawAboutBooks.WriteBookCount();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (exceptionHandling.CheckBookCount(search).Equals(-1))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookCount);
                    }
                    break;
                case LibraryConstants.SearchBookAuthor:
                    drawAboutBooks.WriteBookAuthor();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckAuthor(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookAuthor);
                    }
                    break;
                case LibraryConstants.SearchBookPublisher:
                    drawAboutBooks.WriteBookPublisher();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPublisher(search))
                    {
                        Console.Clear();
                        SearchSub(LibraryConstants.SearchBookPublisher);
                    }
                    break;
                case LibraryConstants.GoBefore:
                    break;
                default:
                    DrawSearch();
                    break;
            }
        }
        /// <summary>
        /// 책의 이름을 받는 메소드
        /// </summary>
        public void DrawName()
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookName();
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
            drawAboutBooks.Category();
            bookDAO.SearchAll();

            drawAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (deleteName.Equals("1"))
                return;
            if (!exceptionHandling.CheckBookNo(deleteName))
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
                drawAboutBooks.WriteEditWhich();
                mode = Console.ReadLine();

                switch (mode)
                {
                    case LibraryConstants.EDIT_COUNT:
                        DrawCountRead();
                        if (count.Equals("-1"))
                            return;
                        if (count.Equals("-2"))
                            return;

                        if (!databaseException.IsInBookDB(deleteName))
                        {
                            bookDAO.EditBookCount(deleteName, Convert.ToInt32(count));
                            //drawAboutBooks.EditResult("S U C C E S S");
                        }
                        else
                        {
                            //drawAboutBooks.EditResult("F A I L E D");
                        }
                        return;
                    case LibraryConstants.EDIT_PRICE:
                        DrawEditPrice();
                        if (price.Equals("0"))
                            return;
                        if (price.Equals("1"))
                            return;

                        if (!databaseException.IsInBookDB(deleteName))
                        {
                            bookDAO.EditBookPrice(deleteName,Convert.ToInt32(price));
                            //drawAboutBooks.EditResult("S U C C E S S");
                        }
                        else
                        {
                            //drawAboutBooks.EditResult("F A I L E D");
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
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookCount();
            count = Console.ReadLine();
            if (count.Equals("-1"))
                return;
            if (count.Equals("-2"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandling.CheckBookCount(count))
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
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;

            if (!exceptionHandling.CheckBookNo(no))
            {
                DrawNo();
            }
            if (!databaseException.IsInBookDB(no))
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
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookAuthor();
            author = Console.ReadLine();
            if (author.Equals("0"))
                return;
            if (author.Equals("1"))
                DrawCountRead();
            if (!exceptionHandling.CheckAuthor(author))
                DrawAuthor();
        }

        /// <summary>
        /// 출판사를 입력받는 메소드
        /// </summary>
        public void DrawPublisher()
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookPublisher();
            publisher = Console.ReadLine();
            if (publisher.Equals("0"))
                return;
            if (publisher.Equals("1"))
                DrawAuthor();
            if (!exceptionHandling.CheckPublisher(publisher))
                DrawPublisher();
        }
        public void DrawEditPrice()
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.DrawWritePrice();
            price = Console.ReadLine();
            if (price.Equals("0"))
                return;
            if (price.Equals("1"))
            {
                EditWhichOne();
                return;
            }
            if (!exceptionHandling.CheckPrice(price))
                DrawEditPrice();
        }
        public void DrawPrice()
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.DrawWritePrice();
            price = Console.ReadLine();
            if (price.Equals("0"))
                return;
            if (price.Equals("1"))
                DrawPublisher();
            if (!exceptionHandling.CheckPrice(price))
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
            if (!databaseException.IsInBookDB(no))
            {
                drawAboutBooks.AddResult("F A I L E D !");
            }
            else
            {
                bookDAO.AddBook(new Book(no,name,Convert.ToInt32(count),publisher,author,Convert.ToInt32(price)));
                drawAboutBooks.AddResult("S U C C E S S !");
            }

        }
    }
}
