using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ExtendRentalTime
    {
        private DrawAboutBooks drawAboutBooks;
        private string bookName;
        private int findIndex = 0;

        /// <summary>
        /// 기본 생성자로 그리고 나머지 모든 동작을 하는 메소드를 호출한다.
        /// </summary>
        /// <param name="memList">회원정보 리스트</param>
        /// <param name="rentalList">대여한 사람들의 리스트</param>
        /// <param name="id">현재 사용중인 사용자의 아이디</param>
        public ExtendRentalTime(List<Member> memList,List<RentalData> rentalList,string id)
        {
            drawAboutBooks = new DrawAboutBooks();
        }
        
        /// <summary>
        /// 실질적으로 모든 작업을 하는 메소드
        /// </summary>
        /// <param name="memList">회원정보 리스트</param>
        /// <param name="rentalList">대여자 리스트</param>
        /// <param name="id">현재 사용중인 사용자 아이디</param>
        public void DrawAndRun(List<Member> memList, List<RentalData> rentalList, string id)
        {
            drawAboutBooks.ExtendTimeTitle(rentalList);
            drawAboutBooks.WriteBookName();
            bookName = Console.ReadLine();
            findIndex = CheckBook(rentalList, bookName, id);

            if (findIndex.Equals(-1))
            {
                drawAboutBooks.ExtendFailed();
            }
            else
            {
                rentalList[findIndex].BookReturnTime = rentalList[findIndex].BookReturnTime.AddDays(10);
                drawAboutBooks.ExtendSuccess();
            }

        }
        /// <summary>
        /// 이미 이책을 대여했다면 위치를 리턴하는 메소드
        /// </summary>
        /// <param name="RentalList">대여자들 리스트</param>
        /// <param name="bookName">책이름</param>
        /// <param name="id">책 빌리려는 사람</param>
        /// <returns>책의 정보가 저장되어있는 위치</returns>
        public int CheckBook(List<RentalData> RentalList,string bookName, string id) 
        {
            int result = -1;

            for (int check = 0; check < RentalList.Count; check++)
            {
                if (RentalList[check].BookLender.Equals(id) && RentalList[check].BookName.Equals(bookName))
                {
                    result = check;
                    return result;
                }
            }
            return result;
        }
    }
}