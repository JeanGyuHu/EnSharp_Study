using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ReturnBooks
    {
        private DrawAboutBooks drawAboutBooks;          //UI를 그리기 위한 객체
        private ExceptionHandling exceptionHandling;    //예외처리를 위한 객체
        private string no;  //번호를 받기 위한 string 변수

        /// <summary>
        /// 생성자 객체들을 초기화하고 생성한다.
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        public ReturnBooks(List<Book> bookList, List<RentalData> rentalList, string id)
        {
            drawAboutBooks = new DrawAboutBooks();
            exceptionHandling = new ExceptionHandling();
        }
        /// <summary>
        /// 책 빌리는 작업을 하는 메소드
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
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

        /// <summary>
        /// 번호를 입력 받는 메소드
        /// </summary>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자 명</param>
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
        /// <summary>
        /// 찾은 책이 책 정보 리스트에 있는지 체크
        /// </summary>
        /// <param name="bookList">책 정보 리스트</param>
        /// <param name="no">책 번호</param>
        /// <returns>실패했을시에만 -1</returns>
        public int FindBookInBookList(List<Book> bookList, string no)
        {
            for (int search = 0; search < bookList.Count; search++)
            {
                if (bookList[search].No.Equals(no))
                    bookList[search].Count++;
            }

            return -1;
        }

        /// <summary>
        /// 입력한 책이 대여자 리스트에 있는지 체크
        /// </summary>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용자명</param>
        /// <param name="no">책 번호</param>
        /// <returns></returns>
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
