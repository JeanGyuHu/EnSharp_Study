using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class LibraryManagement
    {
        private string strChoice;
        private bool flag = true;
        private ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        private string strBookNo;
        private string strBookName;
        private string strBookCount;
        private int intBookCount;
        private string strBookAuthor;
        private string strBookPublisher;
        private string strName;
        private string strSearch;

        public LibraryManagement(List<Book> list)
        {
            while (flag)
            {
                draw();

                switch (strChoice)
                {
                    case "1":
                        drawAdd(list);
                        break;
                    case "2":
                        drawEdit(list);
                        break;
                    case "3":
                        drawDelete(list);
                        break;
                    case "4":
                        drawSearch(list);
                        break;
                    case "5":
                        drawInformation(list);
                        Console.Write("\n\n\n\t\t\tPress any key . . .");
                        keyInfo = Console.ReadKey();
                        break;
                    case "6":
                        flag = false;
                        break;
                    default:
                        LibraryManagement libraryManagement = new LibraryManagement(list);
                        break;
                        
                        
                       
                }
            }
        }

        public void drawDelete(List<Book> list)
        {
            drawInformation(list);

            Console.Write("\n\n\n\t\t\tChoose Book (name) >>");
            strName = Console.ReadLine();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookName.Equals(strName))
                {
                    list.RemoveAt(i);
                }
            }

            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            System.Threading.Thread.Sleep(1000);
        }

        public void drawSearch(List<Book> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Book No");
            Console.WriteLine("\n\n\t\t\t\t2. Book Name");
            Console.WriteLine("\n\n\t\t\t\t3. Book Count");
            Console.WriteLine("\n\n\t\t\t\t4. Book Author");
            Console.WriteLine("\n\n\t\t\t\t5. Book Publisher");
            Console.Write("\n\t\t\t\t>> ");
            strName = Console.ReadLine();

            switch (strName)
            {
                case "1":
                    Console.Write("\n\n\t\t\t\twrite no : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].BookNo.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);
                    }
                    break;
                case "2":
                    Console.Write("\n\n\t\t\t\twrite name : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].BookName.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);
                    }
                    
                    break;
                case "3":

                    Console.Write("\n\n\t\t\t\twrite count : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].BookCount.Equals(Convert.ToInt32(strSearch)))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);
                    }
                    break;
                case "4":

                    Console.Write("\n\n\t\t\t\twrite Author : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].BookAuthor.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);
                    }
                    break;
                case "5":

                    Console.Write("\n\n\t\t\t\twrite Publisher : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].BookPbls.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);
                    }
                    break;
                default:
                    drawSearch(list);
                    break;

            }
            System.Threading.Thread.Sleep(1000);
        }

        public void drawName()
        {
            Console.Clear();
            drawInfo();
            Console.Write("\n\n\t\t\tName ::\n\t\t\t >> ");
            strBookName = Console.ReadLine();
            
        }
        public void drawEdit(List<Book> list)
        {
            int count = 0;
            int memberIndex = 0;

            drawInformation(list);

            Console.Write("\n\n\t\t\tChoose a book, enter the book name>> ");
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
                drawEdit(list);
            else
            {
                drawCount();

                list[memberIndex].BookCount = intBookCount;

                Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void drawNo()
        {
            Console.Clear();
            drawInfo();
            Console.Write("\n\n\t\t\tBook No (xx-xxxxxxxx)::\n\t\t\t >> ");
            strBookNo = Console.ReadLine();

            if (!strBookNo.Equals(""))
                strBookNo = strBookNo.Remove(2, 1);

            if (!long.TryParse(strBookNo, out long x))    //받은 값이 문자열이면 다시 받고, 숫자면 그냥 받는다.
            {
                Console.WriteLine("\n\n\t\tWrite number only !");
                System.Threading.Thread.Sleep(1000);
                drawNo();
            }
            strBookNo = strBookNo.Insert(2, "-");

            if (!strBookNo[2].Equals('-'))
            {
                Console.WriteLine("\n\n\t\tInput format is wrong !");
                System.Threading.Thread.Sleep(1000);
                drawNo();
            }
            if(strBookNo.Length != 11)
            {
                Console.WriteLine("\n\n\t\tInput format is wrong !");
                System.Threading.Thread.Sleep(1000);
                drawNo();
            }
        }

        public int checkBook(List<Book> list,string name)
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
        public void drawCount()
        {
            Console.Clear();
            drawInfo();
            Console.Write("\n\n\t\t\tCount ::\n\t\t\t >> ");
            strBookCount = Console.ReadLine();

            if (!Int32.TryParse(strBookCount, out int x))    //받은 값이 문자열이면 다시 받고, 숫자면 그냥 받는다.
            {
                Console.WriteLine("\n\n\t\twrite number only !");
                System.Threading.Thread.Sleep(1000);
                drawCount();
            }
            else
            {

                if (Convert.ToInt32(strBookCount) >= 0)
                {
                    intBookCount = Convert.ToInt32(strBookCount);
                }
                else
                    drawCount();
            }
        }

        public void drawAuthor()
        {
            Console.Clear();
            drawInfo();
            Console.Write("\n\n\t\t\tAuthor ::\n\t\t\t >> ");
            strBookAuthor = Console.ReadLine();
        }

        public void drawPublisher()
        {
            Console.Clear();
            drawInfo();
            Console.Write("\n\n\t\t\tPublisher ::\n\t\t\t >> ");
            strBookPublisher = Console.ReadLine();
        }

        public void drawAdd(List<Book> list)
        {
            int bookIndex = -1;
            drawNo();

            if (checkNo(list,strBookNo))
            {
                drawName();
                drawCount();
                drawAuthor();
                drawPublisher();

                bookIndex = checkBook(list, strBookName);

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
                drawAdd(list);
            }
        }
        public bool checkNo(List<Book> list,string no)
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
        public void drawInformation(List<Book> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t┌-----------------------------------------------------┐");
            Console.WriteLine("\t\t\t│   No  │   Name   │  Count  │  Author  │  Publisher  │");
            Console.WriteLine("\t\t\t└-----------------------------------------------------┘");

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}", list[i].BookNo, list[i].BookName, list[i].BookCount, list[i].BookAuthor, list[i].BookPbls);

        }

        public void draw()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           L I B R A R Y  M A N A G E M E N T   M O D E           │");
            Console.WriteLine("\t\t\t└------------------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. Add New Book");
            Console.WriteLine("\n\n\t\t\t\t2. Edit Book");
            Console.WriteLine("\n\n\t\t\t\t3. Delete Book");
            Console.WriteLine("\n\n\t\t\t\t4. Search Book");
            Console.WriteLine("\n\n\t\t\t\t5. Print Book");
            Console.WriteLine("\n\n\t\t\t\t6. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");
            strChoice = Console.ReadLine();

        }
        public void drawInfo()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│          W R I T E   B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└-----------------------------------------------------------------┘");
        }
        public void drawCategory()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌-----------------------------------------------------┐");
            Console.WriteLine("\t\t\t│   No  │   Name   │  Count  │  Author  │  Publisher  │");
            Console.WriteLine("\t\t\t└-----------------------------------------------------┘");
        }
    }
}
