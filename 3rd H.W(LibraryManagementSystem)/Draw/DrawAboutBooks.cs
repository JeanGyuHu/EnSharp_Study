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
        public void PressAnyKey()
        {
            Console.Write("\n\t\t\tPress Any Key . . .");
            keyInfo = Console.ReadKey();
        }
        public void ExitMessage()
        {
            Console.WriteLine("\n\n\t\t\t뒤로가려면 Enter를 누르세요.");
        }
        /// <summary>
        /// 현재 도서관의 책 정보를 보여주는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 담고 있는 리스트</param>
        public void Information(List<Book> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└------------------------------------------------------┘");
            Console.WriteLine("┌-------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t│\tPublisher\t│\tAuthor\t│\tCount\t    │");
            Console.WriteLine("└-------------------------------------------------------------------------------------------┘");

            for (int i = 0; i < list.Count; i++)
            {
                byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                byte[] byteName2 = new byte[20];
                Array.Copy(byteName1, byteName2, 20);

                byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                byte[] bytePublisher2 = new byte[25];
                Array.Copy(bytePublisher1, bytePublisher2, 25);

                byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                byte[] byteAuthor2 = new byte[20];
                Array.Copy(byteAuthor1, byteAuthor2, 20);

                Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No,Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
            }

        }
        /// <summary>
        /// 책정보 카테고리를 그려주는 메소드
        /// </summary>
        public void Category()
        {
            Console.Clear();
            Console.WriteLine("┌-------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t│\tPublisher\t│\tAuthor\t│\tCount\t    │");
            Console.WriteLine("└-------------------------------------------------------------------------------------------┘");
        }
        /// <summary>
        /// 현재 어떤 창인지 위에 제목을 그려주는 메소드
        /// </summary>
        public void InfoTitle()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌------------------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│          W R I T E   B O O K S   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└-----------------------------------------------------------------┘");
        }
        /// <summary>
        /// 책을 선택하라는 메세지를 띄워주는 메소드
        /// </summary>
        public void DeleteMessage()
        {
            Console.Write("\n\n\n\t\t\tChoose Book (name) >> ");
        }
        /// <summary>
        /// 삭제 성공 메세지를 띄워주는 메소드
        /// </summary>
        public void DeleteSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 삭제 실패 메세지를 띄워주는 메소드
        /// </summary>
        public void DeleteFailed()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  F A I L E D !");
            PressAnyKey();
        }
        /// <summary>
        /// 변경 성공 메세지를 띄워주는 메소드
        /// </summary>
        public void EditSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 책 번호를 적으라는 메소드
        /// </summary>
        public void WriteBookNo()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 고유번호를 입력하세요.(종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 12-xxxxxxxx (x는 모두 숫자)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책 이름을 적으라는 메세지를 띄우는 메소드
        /// </summary>
        public void WriteBookName()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 이름을 입력하세요. (뒤로가기 1, 종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 공백을 제외한 모든 이름이 가능합니다.");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책 대여 실패를 알리는 메소드
        /// </summary>
        public void RentalFailed()
        {
            Console.WriteLine("\n\n\t\t\tR E N T A L  F A I L E D ! !");
        }
        /// <summary>
        /// 책 대여 성공을 알리는 메소드
        /// </summary>
        public void RentalSuccess()
        {
            Console.WriteLine("\n\t\t\tR E N T A L   S U C C E S S ! !");
        }
        /// <summary>
        /// 책의 권수를 적으라고 알리는 메소드
        /// </summary>
        public void WriteBookCount()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 권수를 입력하세요. (뒤로가기 -2, 종료 -1)");
            Console.WriteLine("\n\n\t\t\t\t(99개 이상 입력 불가능)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책의 저자를 적으라고 알리는 메소드
        /// </summary>
        public void WriteBookAuthor()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 저자를 입력하세요. (뒤로가기 1, 종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 영어,한글과 특수문자. 사용가능");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책의 출판사를 적으라고 알리는 메소드
        /// </summary>
        public void WriteBookPublisher()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 출판사를 입력하세요. (뒤로가기 1, 종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 영어,한글과 특수문자. 사용가능");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 검색할때 메뉴창을 그리는 메소드
        /// </summary>
        public void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Book No");
            Console.WriteLine("\n\n\t\t\t\t2. Book Name");
            Console.WriteLine("\n\n\t\t\t\t3. Book Count");
            Console.WriteLine("\n\n\t\t\t\t4. Book Author");
            Console.WriteLine("\n\n\t\t\t\t5. Book Publisher");
            Console.WriteLine("\n\n\t\t\t\t6. EXIT");
            Console.WriteLine("\t\t\t검색 중 책 이름이 아닌 아무거나 입력시 종료");
            Console.Write("\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 책 번호 정보를 가지고 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 번호</param>
        public void SearchNo(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].No.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                    byte[] bytePublisher2 = new byte[25];
                    Array.Copy(bytePublisher1, bytePublisher2, 25);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                    byte[] byteAuthor2 = new byte[20];
                    Array.Copy(byteAuthor1, byteAuthor2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
                }
            }
        }
        /// <summary>
        /// 책을 이름으로 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책 이름</param>
        public void SearchName(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                    byte[] bytePublisher2 = new byte[25];
                    Array.Copy(bytePublisher1, bytePublisher2, 25);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                    byte[] byteAuthor2 = new byte[20];
                    Array.Copy(byteAuthor1, byteAuthor2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
                }
            }
        }
        /// <summary>
        /// 책의 권수로 검색 후 출력하는 메소드 
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 권수</param>
        public void SearchCount(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count.Equals(Convert.ToInt32(strSearch)))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                    byte[] bytePublisher2 = new byte[25];
                    Array.Copy(bytePublisher1, bytePublisher2, 25);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                    byte[] byteAuthor2 = new byte[20];
                    Array.Copy(byteAuthor1, byteAuthor2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
                }
            }
        }
        /// <summary>
        /// 책의 저자로 검색 후 출력하는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 저자</param>
        public void SearchAuthor(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Author.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                    byte[] bytePublisher2 = new byte[25];
                    Array.Copy(bytePublisher1, bytePublisher2, 25);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                    byte[] byteAuthor2 = new byte[20];
                    Array.Copy(byteAuthor1, byteAuthor2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
                }
            }
        }
        /// <summary>
        /// 연장 성공을 알리는 메소드
        /// </summary>
        public void ExtendSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE X T E N D   S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 연장 실패를 알리는 메소드
        /// </summary>
        public void ExtendFailed()
        {
            Console.WriteLine("\n\n\n\t\t\tE X T E N D   F A I L E D !");
            PressAnyKey();
        }
        /// <summary>
        /// 출판사로 검색 후 출력해주는 메소드
        /// </summary>
        /// <param name="list">책의 정보를 가지고 있는 리스트</param>
        /// <param name="strSearch">찾는 책의 출판사명</param>
        public void SearchPublisher(List<Book> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Pbls.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(list[i].Pbls + "                              ");
                    byte[] bytePublisher2 = new byte[25];
                    Array.Copy(bytePublisher1, bytePublisher2, 25);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(list[i].Author + "                              ");
                    byte[] byteAuthor2 = new byte[20];
                    Array.Copy(byteAuthor1, byteAuthor2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4,-10}", list[i].No, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(bytePublisher2), Encoding.Default.GetString(byteAuthor2), list[i].Count);
                }
            }
        }
        /// <summary>
        /// 시간 연장 페이지의 UI를 그리는 메소드
        /// </summary>
        /// <param name="list">책을 빌린 사람들의 목록</param>
        public void ExtendTimeTitle(List<RentalData> list,string id)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           E X T E N D   R E N T A L   T I M E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------------┘");
            Console.WriteLine("┌----------------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t   │   \tLender\t     │\tAuthor\t   │\tPublisher\t│\tReturn Time\t  |");
            Console.WriteLine("└----------------------------------------------------------------------------------------------------------------┘");

            foreach (RentalData data in list)
                if (data.BookLender.Equals(id))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(data.BookName + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] byteLender1 = Encoding.Default.GetBytes(data.BookLender + "                              ");
                    byte[] byteLender2 = new byte[20];
                    Array.Copy(byteLender1, byteLender2, 20);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(data.BookAuthor + "                              ");
                    byte[] byteAuthor2 = new byte[15];
                    Array.Copy(byteAuthor1, byteAuthor2, 15);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(data.BookPbls + "                              ");
                    byte[] bytePublisher2 = new byte[20];
                    Array.Copy(bytePublisher1, bytePublisher2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4}{5}", data.BookNo, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(byteLender2), Encoding.Default.GetString(byteAuthor2), Encoding.Default.GetString(bytePublisher2), data.BookReturnTime.ToString("yyyy-MM-dd").PadRight(20));
                }
               
        }

        /// <summary>
        /// 도서관리 메인 메뉴 그리는 메소드
        /// </summary>
        public void ManagementMenu()
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

        public void ReturnBooksTitle(List<RentalData> list, string id)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------┐");
            Console.WriteLine("\t\t\t│           R E T U R N   B O O K S           │");
            Console.WriteLine("\t\t\t└---------------------------------------------┘");
            Console.WriteLine("┌----------------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│\tName\t   │   \tLender\t     │\tAuthor\t   │\tPublisher\t│\tReturn Time\t  |");
            Console.WriteLine("└----------------------------------------------------------------------------------------------------------------┘");

            foreach (RentalData data in list)
                if (data.BookLender.Equals(id))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(data.BookName + "          ");
                    byte[] byteName2 = new byte[20];
                    Array.Copy(byteName1, byteName2, 20);

                    byte[] byteLender1 = Encoding.Default.GetBytes(data.BookLender + "                              ");
                    byte[] byteLender2 = new byte[20];
                    Array.Copy(byteLender1, byteLender2, 20);

                    byte[] byteAuthor1 = Encoding.Default.GetBytes(data.BookAuthor + "                              ");
                    byte[] byteAuthor2 = new byte[15];
                    Array.Copy(byteAuthor1, byteAuthor2, 15);

                    byte[] bytePublisher1 = Encoding.Default.GetBytes(data.BookPbls + "                              ");
                    byte[] bytePublisher2 = new byte[20];
                    Array.Copy(bytePublisher1, bytePublisher2, 20);

                    Console.WriteLine("   {0,-15}{1}{2}{3}{4}{5}", data.BookNo, Encoding.Default.GetString(byteName2), Encoding.Default.GetString(byteLender2), Encoding.Default.GetString(byteAuthor2), Encoding.Default.GetString(bytePublisher2), data.BookReturnTime.ToString("yyyy-MM-dd").PadRight(20));
                }
        }
    }
}
