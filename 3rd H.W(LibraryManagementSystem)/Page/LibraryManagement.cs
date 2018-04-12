using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class LibraryManagement
    {
        //메인 메뉴에서의 매직넘버
        private const string AddMode = "1";
        private const string EditMode = "2";
        private const string DeleteMode = "3";
        private const string SearchMode = "4";
        private const string PrintMode = "5";
        private const string Exit = "6";

        //검색모드에서의 매직넘번
        private const string SearchBookNo = "1";
        private const string SearchBookName="2";
        private const string SearchBookCount="3";
        private const string SearchBookAuthor="4";
        private const string SearchBookPublisher="5";

        private ExceptionHandling exceptionHandling;    //예외처리를 위한 객체 선언
        private DrawAboutBooks drawAboutBooks;          //UI를 그리기 위한 객체 선언
        private string strChoice;                       //어떤 작업을 할지 선택받는 변수
        private bool flag = true;                       //이전 메뉴로 돌아가기 위한 flag
        private string strBookNo;                       //책 번호 입력받기 위함
        private string strBookName;                     //책 이름 입력받기 위함
        private string strBookCount;                    //책 개수 입력받기 위함
        private int intBookCount;                       //책이 몇권인지 int형으로 변환받기 위함
        private string strBookAuthor;                   //책 저자 입력받기 위함
        private string strBookPublisher;                //책 출판사 입력받기 위함
        private string strName;                         //삭제할 이름 입력받기 위함
        private string strSearch;                       //어떤걸로 검색할지 입력받기 위함

        public LibraryManagement(List<Book> list)
        {
            exceptionHandling = new ExceptionHandling();
            drawAboutBooks = new DrawAboutBooks();

            DrawAndSelectMenu(list);
        }

        public void DrawAndSelectMenu(List<Book> list)
        {
            while (flag)
            {
                drawAboutBooks.DrawBookManagementMenu();
                strChoice = Console.ReadLine();
                switch (strChoice)
                {
                    case AddMode:
                        DrawAdd(list);
                        break;
                    case EditMode:
                        DrawEdit(list);
                        break;
                    case DeleteMode:
                        DrawDelete(list);
                        break;
                    case SearchMode:
                        DrawSearch(list);
                        break;
                    case PrintMode:
                        drawAboutBooks.DrawBookInformation(list);
                        drawAboutBooks.DrawPressAnyKey();
                        break;
                    case Exit:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void DrawDelete(List<Book> list)
        {
            drawAboutBooks.DrawBookInformation(list);

            drawAboutBooks.DrawDeleteMessage();
            strName = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookName.Equals(strName))
                {
                    list.RemoveAt(i);
                    drawAboutBooks.DrawDeleteSuccess();
                }
            }
            drawAboutBooks.DrawDeleteFailed();
        }

        public void DrawSearch(List<Book> list)
        {
            drawAboutBooks.DrawSearchMenu();
            strName = Console.ReadLine();

            switch (strName)
            {
                case SearchBookNo:
                    drawAboutBooks.DrawWriteBookNo();
                    strSearch = Console.ReadLine();
                    drawAboutBooks.DrawBookCategory();
                    drawAboutBooks.DrawSearchNo(list, strSearch);
                    break;
                case SearchBookName:
                    drawAboutBooks.DrawWriteBookName();
                    strSearch = Console.ReadLine();
                    drawAboutBooks.DrawBookCategory();
                    drawAboutBooks.DrawSearchName(list,strSearch);
                    break;
                case SearchBookCount:
                    drawAboutBooks.DrawWriteBookCount();
                    strSearch = Console.ReadLine();
                    if (!exceptionHandling.CheckBookCount(strSearch).Equals(-1))
                    {
                        drawAboutBooks.DrawBookCategory();
                        drawAboutBooks.DrawSearchCount(list, strSearch);
                    }
                    break;
                case SearchBookAuthor:
                    drawAboutBooks.DrawWriteBookAuthor();
                    strSearch = Console.ReadLine();
                    drawAboutBooks.DrawBookCategory();
                    drawAboutBooks.DrawSearchAuthor(list,strSearch);
                    break;
                case SearchBookPublisher:
                    drawAboutBooks.DrawWriteBookPublisher();
                    strSearch = Console.ReadLine();
                    drawAboutBooks.DrawBookCategory();
                    drawAboutBooks.DrawSearchPublisher(list, strSearch);
                    break;
                default:
                    DrawSearch(list);
                    break;

            }
            drawAboutBooks.DrawPressAnyKey();
        }

        public void DrawName()
        {
            Console.Clear();
            drawAboutBooks.DrawBookInfoTitle();
            drawAboutBooks.DrawWriteBookName();
            strBookName = Console.ReadLine();
            
        }
        public void DrawEdit(List<Book> list)
        {
            int count = 0;
            int memberIndex = 0;
            int inputCount = 0;

            drawAboutBooks.DrawBookInformation(list);

            drawAboutBooks.DrawWriteBookName();
            strName = Console.ReadLine();

            count = 0;
            foreach (Book book in list)
            {
                if (book.BookName.Equals(strName))
                {
                    memberIndex = list.IndexOf(book);
                    break;
                }
                count++;
            }
            if (count.Equals(list.Count))
                drawAboutBooks.DrawPressAnyKey();
            else
            {
                inputCount = DrawCount();

                if (inputCount.Equals(-1))
                    DrawCount();
                else
                {
                    list[memberIndex].BookCount = inputCount;

                    drawAboutBooks.DrawEditSuccess();
                }
            }
        }

        public void DrawNo()
        {
            Console.Clear();
            drawAboutBooks.DrawBookInfoTitle();
            drawAboutBooks.DrawWriteBookNo();
            strBookNo = Console.ReadLine();

            if (!exceptionHandling.CheckBookNo(strBookNo))
            {
                DrawNo();
            }
        }

        public int CheckBook(List<Book> list,string name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookName.Equals(name))
                {
                    return i;
                }
            }

            return -1;
        }
        public int DrawCount()
        {
            int inputIndex = -1;

            Console.Clear();
            drawAboutBooks.DrawBookInfoTitle();
            drawAboutBooks.DrawWriteBookCount();
            strBookCount = Console.ReadLine();

            inputIndex = exceptionHandling.CheckBookCount(strBookCount);

            if (inputIndex.Equals(-1))
            {
                DrawCount();
             
            }
            else
            {
                return inputIndex;
            }
            return inputIndex;
        }

        public void DrawAuthor()
        {
            Console.Clear();
            drawAboutBooks.DrawBookInfoTitle();
            drawAboutBooks.DrawWriteBookAuthor();
            strBookAuthor = Console.ReadLine();

            if (!exceptionHandling.CheckName(strBookAuthor))
                DrawAuthor();
        }

        public void DrawPublisher()
        {
            Console.Clear();
            drawAboutBooks.DrawBookInfoTitle();
            drawAboutBooks.DrawWriteBookPublisher();
            strBookPublisher = Console.ReadLine();
        }

        public void DrawAdd(List<Book> list)
        {
            int bookIndex = -1;
            DrawNo();

            if (CheckNo(list,strBookNo))
            {
                DrawName();
                DrawCount();
                DrawAuthor();
                DrawPublisher();

                bookIndex = CheckBook(list, strBookName);

                if (bookIndex != -1)
                {
                    list[bookIndex].BookCount = list[bookIndex].BookCount + intBookCount;
                }
                else
                {
                    list.Add(new Book(strBookNo, strBookName, intBookCount, strBookPublisher, strBookAuthor));
                }
            }
            else
            {
                DrawAdd(list);
            }
        }
        public bool CheckNo(List<Book> list,string no)
        {
            int count = 0;

            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].BookNo.Equals(no))
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
