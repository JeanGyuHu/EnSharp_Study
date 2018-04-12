using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{

    class DrawAboutBooks
    {
        private ConsoleKeyInfo keyInfo;
        public DrawAboutBooks()
        {
            keyInfo = new ConsoleKeyInfo();
        }
        /// <summary>
        /// 아무키나 누르세요... 를 띄워주는 메소드
        /// </summary>
        public void DrawPressAnyKey()
        {
            Console.Write("\n\n\n\t\t\tPress Any Key . . .");
            keyInfo = Console.ReadKey();
        }
        /// <summary>
        /// 현재 도서관의 책 정보를 보여주는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 담고 있는 리스트</param>
        public void DrawBookInformation(List<Book> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└------------------------------------------------------┘");
            Console.WriteLine("┌---------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t│\tCount\t│\tAuthor\t│\tPublisher\t│");
            Console.WriteLine("└---------------------------------------------------------------------------------------┘");

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));

        }
        /// <summary>
        /// 책정보 카테고리를 그려주는 메소드
        /// </summary>
        public void DrawBookCategory()
        {
            Console.Clear();
            Console.WriteLine("┌---------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t│\tCount\t│\tAuthor\t│\tPublisher\t│");
            Console.WriteLine("└---------------------------------------------------------------------------------------┘");
        }
        /// <summary>
        /// 현재 어떤 창인지 위에 제목을 그려주는 메소드
        /// </summary>
        public void DrawBookInfoTitle()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│          W R I T E   B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└-----------------------------------------------------------------┘");
        }
        /// <summary>
        /// 책을 선택하라는 메세지를 띄워주는 메소드
        /// </summary>
        public void DrawDeleteMessage()
        {
            Console.Write("\n\n\n\t\t\tChoose Book (name) >> ");
        }
        /// <summary>
        /// 삭제 성공 메세지를 띄워주는 메소드
        /// </summary>
        public void DrawDeleteSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 삭제 실패 메세지를 띄워주는 메소드
        /// </summary>
        public void DrawDeleteFailed()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  F A I L E D !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 변경 성공 메세지를 띄워주는 메소드
        /// </summary>
        public void DrawEditSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 책 번호를 적으라는 메소드
        /// </summary>
        public void DrawWriteBookNo()
        {
            Console.Write("\n\n\t\t\t\twrite Book no (xx-xxxxxxxx) : ");
        }
        /// <summary>
        /// 책 이름을 적으라는 메세지를 띄우는 메소드
        /// </summary>
        public void DrawWriteBookName()
        {
            Console.Write("\n\n\t\t\t\twrite Book name : ");
        }
        /// <summary>
        /// 책 대여 실패를 알리는 메소드
        /// </summary>
        public void DrawRentalFailed()
        {
            Console.WriteLine("\n\n\t\t\tR E N T A L  F A I L E D ! !");
        }
        /// <summary>
        /// 책 대여 성공을 알리는 메소드
        /// </summary>
        public void DrawRentalSuccess()
        {
            Console.WriteLine("\n\t\t\tR E N T A L   S U C C E S S ! !");
        }
        /// <summary>
        /// 책의 권수를 적으라고 알리는 메소드
        /// </summary>
        public void DrawWriteBookCount()
        {
            Console.Write("\n\n\t\t\t\twrite Book count : ");
        }
        /// <summary>
        /// 책의 저자를 적으라고 알리는 메소드
        /// </summary>
        public void DrawWriteBookAuthor()
        {
            Console.Write("\n\n\t\t\t\twrite Book Author : ");
        }
        /// <summary>
        /// 책의 출판사를 적으라고 알리는 메소드
        /// </summary>
        public void DrawWriteBookPublisher()
        {
            Console.Write("\n\n\t\t\t\twrite Book Publisher (Only English): ");
        }
        /// <summary>
        /// 검색할때 메뉴창을 그리는 메소드
        /// </summary>
        public void DrawSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Book No");
            Console.WriteLine("\n\n\t\t\t\t2. Book Name");
            Console.WriteLine("\n\n\t\t\t\t3. Book Count");
            Console.WriteLine("\n\n\t\t\t\t4. Book Author");
            Console.WriteLine("\n\n\t\t\t\t5. Book Publisher");
            Console.Write("\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책 번호 정보를 가지고 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 번호</param>
        public void DrawSearchNo(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookNo.Equals(strSearch))
                    Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));
            }
        }
        /// <summary>
        /// 책을 이름으로 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책 이름</param>
        public void DrawSearchName(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookName.Equals(strSearch))
                    Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));
            }
        }
        /// <summary>
        /// 책의 권수로 검색 후 출력하는 메소드 
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 권수</param>
        public void DrawSearchCount(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookCount.Equals(Convert.ToInt32(strSearch)))
                    Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));
            }
        }
        /// <summary>
        /// 책의 저자로 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 저자</param>
        public void DrawSearchAuthor(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookAuthor.Equals(strSearch))
                    Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));
            }
        }
        /// <summary>
        /// 연장 성공을 알리는 메소드
        /// </summary>
        public void DrawExtendSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE X T E N D   S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 연장 실패를 알리는 메소드
        /// </summary>
        public void DrawExtendFailed()
        {
            Console.WriteLine("\n\n\n\t\t\tE X T E N D   F A I L E D !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 출판사로 검색 후 출력해주는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 출판사명</param>
        public void DrawSearchPublisher(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].BookPbls.Equals(strSearch))
                    Console.WriteLine("{0}\t{1}{2}\t{3}{4}", list[i].BookNo.PadLeft(13), list[i].BookName.PadRight(20), list[i].BookCount, list[i].BookAuthor.PadRight(20), list[i].BookPbls.PadRight(20));
            }
        }
        /// <summary>
        /// 시간 연장 페이지의 UI를 그리는 메소드
        /// </summary>
        /// <param name="list">책을 빌린 사람들의 목록</param>
        public void DrawExtendTimeTitle(List<RentalData> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           E X T E N D   R E N T A L   T I M E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------------┘");
            Console.WriteLine("┌----------------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t   │\tLender\t  │\tAuthor\t│\tPublisher\t│\tReturn Time\t  |");
            Console.WriteLine("└----------------------------------------------------------------------------------------------------------------┘");

            foreach (RentalData data in list)
                Console.WriteLine("{0}\t{1}{2}{3}{4}{5}", data.BookNo.PadRight(13), data.BookName.PadRight(20), data.BookLender.PadRight(10), data.BookAuthor.PadRight(20), data.BookPbls.PadRight(20), data.BookReturnTime.ToString("yyyy-MM-dd").PadRight(20));
        }

        /// <summary>
        /// 도서관리 메인 메뉴 그리는 메소드
        /// </summary>
        public void DrawBookManagementMenu()
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
        }
    }
}
