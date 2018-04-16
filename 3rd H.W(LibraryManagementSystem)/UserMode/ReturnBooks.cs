using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ReturnBooks
    {
        private DrawAboutBooks drawAboutBooks;
        private ExceptionHandling exceptionHandling;
        private string no;

        public ReturnBooks(List<Book> bookList, List<RentalData> rentalList, string id)
        {
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
        }
        public void ReturnBook(List<Book> bookList, List<RentalData> rentalList, string id)
        {
            int findIndex = -1;

            DrawNo(rentalList, id);
            if (no.Equals("0"))
                return;

            findIndex = FindBookInRentalList(rentalList, id, no);

            if (findIndex.Equals(-1))
            {
                drawAboutBooks.PressAnyKey();
            }
            else
            {
                rentalList.RemoveAt(findIndex);
                FindBookInBookList(bookList, no);
                drawAboutBooks.PressAnyKey();
            }

            
        }

        public void DrawNo(List<RentalData> rentalList, string id)
        {
            drawAboutBooks.ReturnBooksTitle(rentalList, id);
            drawAboutBooks.WriteBookNo();
            no = Console.ReadLine();
            if (no.Equals("0"))
                return;
            if (!exceptionHandling.CheckBookNo(no))
            {
                DrawNo(rentalList, id);
                if (no.Equals("0"))
                    return;
            }
        }
        public int FindBookInBookList(List<Book> bookList, string no)
        {
            for (int search = 0; search < bookList.Count; search++)
            {
                if (bookList[search].No.Equals(no))
                    bookList[search].Count++;
            }

            return -1;
        }

        public int FindBookInRentalList(List<RentalData> rentalList, string id, string no)
        {
            for (int search = 0; search < rentalList.Count; search++)
            {
                if (rentalList[search].BookLender.Equals(id))
                    if (rentalList[search].BookNo.Equals(no))
                        return search;
            }
            return -1;
        }
    }
}
