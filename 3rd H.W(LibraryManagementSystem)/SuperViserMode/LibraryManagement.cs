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
        private int intCount;                       //책이 몇권인지 int형으로 변환받기 위함
        private string author;                   //책 저자 입력받기 위함
        private string publisher;                //책 출판사 입력받기 위함
        private string deleteName;                         //삭제할 이름 입력받기 위함
        private string search;                       //어떤걸로 검색할지 입력받기 위함

        /// <summary>
        /// 생성자로써 사용되는 객체를 생성, 초기화한다.
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public LibraryManagement(List<Book> list)
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
                drawAboutBooks.DeleteSuccess();
            else
                drawAboutBooks.DeleteFailed();
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
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + no + "\"");
                    break;
                case LibraryConstants.SearchBookName:
                    SearchSub(LibraryConstants.SearchBookName);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + name + "\"");
                    break;
                case LibraryConstants.SearchBookCount:
                    SearchSub(LibraryConstants.SearchBookCount);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + count + "\"");
                    break;
                case LibraryConstants.SearchBookAuthor:
                    SearchSub(LibraryConstants.SearchBookAuthor);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + author + "\"");
                    break;
                case LibraryConstants.SearchBookPublisher:
                    SearchSub(LibraryConstants.SearchBookPublisher);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    bookDAO.SearchWithQuary("Select * from book where no = \"" + publisher + "\"");
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
                DrawCountRead();
                if (count.Equals("-1"))
                    return;
                if (count.Equals("-2"))
                {
                    DrawEdit();
                    return;
                }
                if (!databaseException.IsInBookDB(no))
                {
                    bookDAO.EditBookInformation(no, Convert.ToInt32(count));
                    drawAboutBooks.EditSuccess("S U C C E S S");
                }
                else
                {
                    drawAboutBooks.EditSuccess("F A I L E D");
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
                DrawEdit();
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
            if (!CheckNo(no))
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
        /// <summary>
        /// 새 책을 추가하는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DrawAdd()
        {
            int bookIndex = -1;
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

            if (bookIndex != -1)
            {
                list[bookIndex].Count = list[bookIndex].Count + intCount;
            }
            else
            {
                list.Add(new Book(no, name, intCount, publisher, author));
            }

        }
        /// <summary>
        /// 책번호가 이미 있는지 없는지 체크해주는 메소드
        /// </summary>
        /// <param name="list">책 리스트</param>
        /// <param name="no">사용자가 입력한 책번호</param>
        /// <returns>있으면 false, 없으면 true</returns>
        public bool CheckNo(string no)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].No.Equals(no))
                {
                    return false;
                }
                count++;
            }
            if (count.Equals(list.Count))
                return true;

            return false;
        }
    }
}
