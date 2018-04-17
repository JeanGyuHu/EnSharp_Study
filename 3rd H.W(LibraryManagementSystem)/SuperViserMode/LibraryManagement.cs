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
            exceptionHandling = new ExceptionHandling();
            drawAboutBooks = new DrawAboutBooks();
        }

        /// <summary>
        /// 기본 메뉴창을 띄우는 메소드
        /// </summary>
        /// <param name="list">책의 리스트</param>
        public void DrawAndSelectMenu(List<Book> list)
        {
            flag = true;
            while (flag)
            {
                drawAboutBooks.ManagementMenu();
                choice = Console.ReadLine();
                switch (choice)
                {
                    case LibraryConstants.AddMode:
                        DrawAdd(list);
                        break;
                    case LibraryConstants.EditMode:
                        DrawEdit(list);
                        break;
                    case LibraryConstants.DeleteMode:
                        DrawDelete(list);
                        break;
                    case LibraryConstants.SearchMode:
                        DrawSearch(list);
                        break;
                    case LibraryConstants.PrintMode:
                        drawAboutBooks.Information(list);
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
        public void DrawDelete(List<Book> list)
        {
            DeleteSub(list);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].No.Equals(deleteName))
                {
                    list.RemoveAt(i);
                    drawAboutBooks.DeleteSuccess();
                    return;
                }
            }
            drawAboutBooks.DeleteFailed();
        }
        /// <summary>
        /// 책을 삭제할때 기본 키 값인 No값을 체크해주는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DeleteSub(List<Book> list)
        {
            drawAboutBooks.Information(list);

            drawAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(deleteName))
                DeleteSub(list);
        }
        /// <summary>
        /// 원하는 정보로 검색하는 메소드
        /// </summary>
        /// <param name="list">책 정보 리스트</param>
        public void DrawSearch(List<Book> list)
        {
            drawAboutBooks.SearchMenu();
            deleteName = Console.ReadLine();
            Console.Clear();
            switch (deleteName)
            {
                case LibraryConstants.SearchBookNo:
                    SearchSub(list, LibraryConstants.SearchBookNo);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    drawAboutBooks.SearchNo(list, search);
                    break;
                case LibraryConstants.SearchBookName:
                    SearchSub(list, LibraryConstants.SearchBookName);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    drawAboutBooks.SearchName(list, search);
                    break;
                case LibraryConstants.SearchBookCount:
                    SearchSub(list, LibraryConstants.SearchBookCount);
                    if (search.Equals("0")) return;
                        drawAboutBooks.Category();
                        drawAboutBooks.SearchCount(list, search);
                    break;
                case LibraryConstants.SearchBookAuthor:
                    SearchSub(list, LibraryConstants.SearchBookAuthor);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    drawAboutBooks.SearchAuthor(list, search);
                    break;
                case LibraryConstants.SearchBookPublisher:
                    SearchSub(list, LibraryConstants.SearchBookPublisher);
                    if (search.Equals("0")) return;
                    drawAboutBooks.Category();
                    drawAboutBooks.SearchPublisher(list, search);
                    break;
                case LibraryConstants.GoBefore:
                    break;
                default:
                    DrawSearch(list);
                    break;

            }
            drawAboutBooks.PressAnyKey();
        }
        /// <summary>
        /// 검색할때 들어오는 입력값에 대해서 예외처리를 해주는 메소드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mode"></param>
        public void SearchSub(List<Book> list,string mode)
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
                        SearchSub(list, LibraryConstants.SearchBookNo);
                    }
                    break;
                case LibraryConstants.SearchBookName:
                    drawAboutBooks.WriteBookName();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (search.Length < 1 || search.Length > 15)
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchBookName);
                    }
                    if (Regex.IsMatch(search, @"^\s"))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchBookName);
                    }
                    break;
                case LibraryConstants.SearchBookCount:
                    drawAboutBooks.WriteBookCount();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (exceptionHandling.CheckBookCount(search).Equals(-1))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchBookCount);
                    }
                    break;
                case LibraryConstants.SearchBookAuthor:
                    drawAboutBooks.WriteBookAuthor();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckAuthor(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchBookAuthor);
                    }
                    break;
                case LibraryConstants.SearchBookPublisher:
                    drawAboutBooks.WriteBookPublisher();
                    search = Console.ReadLine();
                    if (search.Equals("0")) return;
                    if (!exceptionHandling.CheckPublisher(search))
                    {
                        Console.Clear();
                        SearchSub(list, LibraryConstants.SearchBookPublisher);
                    }
                    break;
                case LibraryConstants.GoBefore:
                    break;
                default:
                    DrawSearch(list);
                    break;
            }
        }
        /// <summary>
        /// 책의 이름을 받는 메소드
        /// </summary>
        public void DrawName(List<Book> list)
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookName();
            name = Console.ReadLine();
            if (name.Equals("0"))
                return;
            if (name.Equals("1"))
                DrawNo(list);
            if (name.Length < 1 || name.Length > 15)
                DrawName(list);
            if (Regex.IsMatch(name, @"^\s"))
                DrawName(list);
        }
        /// <summary>
        /// 책의 정보를 입력받고 수정하는 메소드를 호출
        /// </summary>
        /// <param name="list">모든 책 리스트</param>
        public void DrawEdit(List<Book> list)
        {
            int inputCount = 0;
            int count2 = 0;

            drawAboutBooks.Information(list);

            drawAboutBooks.WriteBookNo();
            deleteName = Console.ReadLine();
            if (deleteName.Equals("0"))
                return;
            if (deleteName.Equals("1"))
                return;
            if (!exceptionHandling.CheckBookNo(deleteName))
                DrawEdit(list);
            else
            {
                for (int search = 0; search < list.Count; search++)
                {
                    if (list[search].No.Equals(deleteName))
                    {
                        inputCount = DrawCountEdit(list);
                        if (inputCount.Equals(-1))
                            return;
                        else if (inputCount.Equals(-2))
                            DrawEdit(list);
                        else if(exceptionHandling.CheckBookCount(count).Equals(-1))
                            inputCount = DrawCountEdit(list);
                            
                        
                        if(inputCount!=-1&&inputCount!=-2&&inputCount!=-3)
                        {
                            list[search].Count = inputCount;

                            drawAboutBooks.EditSuccess();
                        }
                        break;
                    }
                    count2++;
                }
                if (list.Count.Equals(count2))
                    DrawEdit(list);
            }
        }

        /// <summary>
        /// 책 번호를 입력받는 메소드
        /// </summary>
        public void DrawNo(List<Book> list)
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;
            
            if (!exceptionHandling.CheckBookNo(no))
            {
                DrawNo(list);
            }
            if (!CheckNo(list, no))
            {
                DrawNo(list);
            }
        }
        /// <summary>
        /// 책이 있는지 판단하고 있으면 그 책이 있는 위치를 반환
        /// </summary>
        /// <param name="list">모든 책 리스트</param>
        /// <param name="name">책 이름</param>
        /// <returns>책이 있으면 그 책의 위치, 아니면 -1 리턴</returns>
        public int CheckBook(List<Book> list, string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(name))
                {
                    return i;
                }
            }

            return -1;
        }
        public int DrawCountEdit(List<Book> list)
        {
            int inputIndex = -3;

            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookCount();
            count = Console.ReadLine();
            if (count.Equals("-1"))
                return -1;
            if (count.Equals("-2"))
                return -2;
            inputIndex = exceptionHandling.CheckBookCount(count);

            if (inputIndex.Equals(-1))
            {
                DrawCountEdit(list);
            }
            else
            {
                return inputIndex;
            }
            return inputIndex;
        }
        /// <summary>
        /// 숫자를 입력받는 메소드
        /// </summary>
        /// <returns>입력 받은 숫자를 int형으로 바꿔서 반환</returns>
        public int DrawCount(List<Book> list)
        {
            int inputIndex = -1;

            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookCount();
            count = Console.ReadLine();
            if (count.Equals("-1"))
                return -1;
            if (count.Equals("-2"))
                DrawName(list);
            inputIndex = exceptionHandling.CheckBookCount(count);

            if (inputIndex.Equals(-1))
            {
                DrawCount(list);

            }
            else
            {
                return inputIndex;
            }
            return inputIndex;
        }

        /// <summary>
        /// 저자를 입력받는 메소드
        /// </summary>
        public void DrawAuthor(List<Book> list)
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookAuthor();
            author = Console.ReadLine();
            if (author.Equals("0"))
                return;
            if (author.Equals("1"))
                DrawCount(list);
            if (!exceptionHandling.CheckAuthor(author))
                DrawAuthor(list);
        }

        /// <summary>
        /// 출판사를 입력받는 메소드
        /// </summary>
        public void DrawPublisher(List<Book> list)
        {
            Console.Clear();
            drawAboutBooks.InfoTitle();
            drawAboutBooks.WriteBookPublisher();
            publisher = Console.ReadLine();
            if (publisher.Equals("0"))
                return;
            if (publisher.Equals("1"))
                DrawAuthor(list);
            if (!exceptionHandling.CheckPublisher(publisher))
                DrawPublisher(list);
        }
            /// <summary>
            /// 새 책을 추가하는 메소드
            /// </summary>
            /// <param name="list">책 정보 리스트</param>
            public void DrawAdd(List<Book> list)
            {
                int bookIndex = -1;
                DrawNo(list);
                if (no.Equals("0"))
                    return;

                DrawName(list);
                if (name.Equals("0"))
                    return;
                DrawCount(list);
                if (count.Equals("-1"))
                    return;
                DrawAuthor(list);
                if (author.Equals("0"))
                    return;
                DrawPublisher(list);
                if (publisher.Equals("0"))
                    return;
                bookIndex = CheckBook(list, name);

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
            public bool CheckNo(List<Book> list, string no)
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
