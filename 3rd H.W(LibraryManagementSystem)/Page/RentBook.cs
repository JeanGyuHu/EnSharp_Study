using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class RentBook
    {
        private string strBookChoice;           //빌리려고하는 책정보
        private int count = 0;                  //책을 다 검사했나 체크하기 위한 변수
        private int findIndex = -1;             //대여할때 찾은 책의 인덱스 값
        private DrawAboutBooks drawAboutBooks;   //UI를 그리기 위한  객체
        private ExceptionHandling exceptionHandling;
        private DateTime now;

        /// <summary>
        /// 책 정보, 이미 빌린 사람의 정보, 현재 사용중인 사람의 id를 이용하여 책을 대여해주는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용중인 유저 아이디</param>
        public RentBook(List<Book> bookList,List<RentalData> rentalList,string id)
        {
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
            now = DateTime.Now;

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
        
        /// <summary>
        /// 책이 있는지 체크해주고 책의 개수가 충분히 있다면 인덱스값을 넘겨준다.
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">사용자 아이디</param>
        /// <param name="bookChoice">선택한 책</param>
        /// <returns></returns>
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
