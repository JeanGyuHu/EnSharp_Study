using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class RentBook
    {
        private string strBookChoice;
        private int count = 0;
        private int findIndex = -1;
        private DrawAboutBooks drawAboutBooks = new DrawAboutBooks();
        private ExceptionHandling exceptionHandling;
        private DateTime now = DateTime.Now;

        public RentBook(List<Book> bookList,List<RentalData> rentalList,string id)
        {
            exceptionHandling = new ExceptionHandling();

            drawAboutBooks.DrawBookInformation(bookList);
            drawAboutBooks.DrawWriteBookName();
            
            strBookChoice = Console.ReadLine();

            findIndex = FindBook(bookList,rentalList,id, strBookChoice);

            if (findIndex.Equals(-1))
            {
                drawAboutBooks.DrawRentalFailed();
            }
            else
            {
                bookList[findIndex].BookCount--;
                rentalList.Add(new RentalData(bookList[findIndex].BookNo, bookList[findIndex].BookName, bookList[findIndex].BookPbls, bookList[findIndex].BookAuthor, id,new DateTime(now.Year,now.Month+1,now.Day+10)));
                drawAboutBooks.DrawRentalSuccess();
            }

            drawAboutBooks.DrawPressAnyKey();
            
        }
        
        public int FindBook(List<Book> bookList,List<RentalData> rentalList,string id, string bookChoice)
        {
            count = 0;

            if (!exceptionHandling.CheckAlreadyRent(rentalList, id, bookChoice))
                return -1;

            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].BookName.Equals(bookChoice))
                    if (bookList[i].BookCount > 0)
                        return i;
                count++;
            }

            return -1;
        }
    }
}
