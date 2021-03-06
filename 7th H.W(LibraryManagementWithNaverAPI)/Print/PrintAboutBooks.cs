﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class PrintAboutBooks
    {
        private ConsoleKeyInfo keyInfo;
        private List<Book> list;
        private ParsingData parsingData;

        public PrintAboutBooks()
        {
            parsingData = new ParsingData();
            list = new List<Book>();
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
        /// <summary>
        /// 뒤로 가려면 Enter를 누르세요..
        /// </summary>
        public void ExitMessage()
        {
            Console.WriteLine("\n\n\t\t\t뒤로가려면 Enter를 누르세요.");
        }
        /// <summary>
        /// 책정보 카테고리를 그려주는 메소드
        /// </summary>
        public void Category()
        {
            Console.Clear();
            Console.WriteLine("┌------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│\tNo\t│    \tName\t    │ Count | \tPublisher\t │ \tAuthor\t │ \tPrice\t │");
            Console.WriteLine("└------------------------------------------------------------------------------------------------┘");
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

        public void DrawWritePrice()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 가격을 입력하세요. (뒤로가기 1, 종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 공백을 제외한 3000원 이상 숫자만 가능합니다.");
            Console.Write("\n\n\t\t\t\t>> ");
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
        public void DeleteResult(string result)
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  {0} !", result);
            PressAnyKey();
        }
        public void AddResult(string result)
        {
            Console.WriteLine("\n\n\n\t\t\tA D D   {0} !", result);
            PressAnyKey();
        }
        /// <summary>
        /// 변경 성공 메세지를 띄워주는 메소드
        /// </summary>
        public void EditResult(string status)
        {
            Console.WriteLine("\n\n\n\t\t\tE D I T  {0} !", status);
            PressAnyKey();
        }
        /// <summary>
        /// 책 번호를 적으라는 메소드
        /// </summary>
        public void WriteBookNo()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 고유번호를 입력하세요.(종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 0000000000 0000000000000 (x는 모두 숫자,알파벳(10,13자))");
            Console.Write("\n\n\t\t\t\t>> ");
        }

        public void WriteNumber()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 번호를 입력하세요.(종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식은 99이하의 숫자");
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
        public void RentalResult(string result)
        {
            Console.WriteLine("\n\n\t\t\tR E N T A L  {0} ! !", result);
        }

        public void ReturnResult(string result)
        {
            Console.WriteLine("\n\t\t\tR E T U R N   {0} ! !", result);
        }

        public void WriteEditWhich()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t수정할 부분을 선택하세요 !");
            Console.WriteLine("\n\n\t\t\t\t1. 수량  2. 가격  3. 나가기");
            Console.Write("\n\n\t\t\t\t>> ");
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
        /// 책의 출판날짜를 적으라고 알리는 메소드
        /// </summary>
        public void WriteBookPublishDate()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 출판사 날짜를 입력하세요. (뒤로가기 1, 종료 0)");
            Console.WriteLine("\n\n\t\t\t\t형식 (0000~2018)-(1~12)-(1~31)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        public void WriteBookInformation()
        {
            Console.WriteLine("\n\n\t\t\t\t책의 설명을 입력하세요. (뒤로가기 1, 종료 0)");
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
            Console.WriteLine("\n\n\t\t\t\t6. Search in Naver");
            Console.WriteLine("\n\n\t\t\t\t7. EXIT");
            Console.Write("\n\t\t\t\t>> ");
        }

        public void SearchCategoryInNaver()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t검색할 카테고리를 고르세요 !");
            Console.WriteLine("\n\n\t\t\t\t1. 도서명  2. 출판사  3. 저자  4. 나가기");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 연장 성공을 알리는 메소드
        /// </summary>
        public void ExtendResult(string result)
        {
            Console.WriteLine("\n\n\n\t\t\tE X T E N D   {0} !", result);
            PressAnyKey();
        }
        /// <summary>
        /// 시간 연장 페이지의 UI를 그리는 메소드
        /// </summary>
        /// <param name="list">책을 빌린 사람들의 목록</param>
        public void ExtendTimeTitle()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           E X T E N D   R E N T A L   T I M E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------------┘");
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

        /// <summary>
        /// 로그에 관련된 메뉴를 그리는 메서드
        /// </summary>
        public void ManagementLog()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           L O G  M A N A G E M E N T  M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. 로그 확인하기");
            Console.WriteLine("\n\n\t\t\t\t2. 로그 초기화");
            Console.WriteLine("\n\n\t\t\t\t3. 로그 메모장 파일 만들기");
            Console.WriteLine("\n\n\t\t\t\t4. 로그 메모장 파일 삭제하기");
            Console.WriteLine("\n\n\t\t\t\t5. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");
        }
        /// <summary>
        /// 반납 메뉴에서 반납하는 창을 그리는 메소드
        /// </summary>
        /// <param name="list">대여자 리스트</param>
        /// <param name="id">사용자 이름</param>
        public void ReturnBooksTitle()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------┐");
            Console.WriteLine("\t\t\t│           R E T U R N   B O O K S           │");
            Console.WriteLine("\t\t\t└---------------------------------------------┘");
        }

        /// <summary>
        /// 추가할꺼야말꺼야
        /// </summary>
        public void AddOrNot()
        {
            Console.WriteLine("\n\n\t\t\t\t추가 하시겠습니까?");
            Console.WriteLine("\n\n\t\t\t\t1. 예");
            Console.WriteLine("\n\n\t\t\t\t2. 아니오");
            Console.Write("\n\n\t\t\t\t>> ");
        }

        /// <summary>
        /// API 검색을 통해서 받아온 정보를 띄워주는 메서드
        /// </summary>
        /// <param name="category"></param>
        /// <param name="question"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Book> ResultFromNaver(string category, string question, int count)
        {
            string result = "";
            string quaryCategory = "";

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           R E S U L T  F R O M  N A V E R  ({0})         │", category);
            Console.WriteLine("\t\t\t└---------------------------------------------------------------┘");

            if (category.Equals("도 서 명"))           //쿼리문을 날려줄때 어떤 것에 대한 검색을 할지 위함
                quaryCategory = "d_titl";
            else if (category.Equals("출 판 사"))
                quaryCategory = "d_publ";
            else if (category.Equals("저    자"))
                quaryCategory = "d_auth";   

            //인터넷에서 받아온 정보
            result = parsingData.RequestJson(question, quaryCategory, count);
            list = parsingData.ParseJson(result);   //받아온 정보를 파싱해서 리스트에 담는다.

            if (list.Count < count) //입력한 개수보다 실제 책의 수가 적을때
                count = list.Count;

            if (list.Count.Equals(0))   //검색 결과 없을때
            {
                Console.WriteLine("\n\n\t\t검색 결과가 없습니다 ! !\n");
                PressAnyKey();
                return null;
            }
            else
                for (int i = 0; i < count; i++) //외에는 출력
                {
                    Console.WriteLine("\n======================================================================================================================================================");
                    Console.WriteLine("번호     : {0}", i+1);
                    Console.WriteLine("제목     : {0}", list[i].Name);
                    Console.WriteLine("저자     : {0}", list[i].Author);
                    Console.WriteLine("가격     : {0}", list[i].Price);
                    Console.WriteLine("출판사   : {0}", list[i].Pbls);
                    Console.WriteLine("출판날짜 : {0}", list[i].PblsDate);
                    //Console.WriteLine("\t\t수량     : {0}", list[i].Count);
                    Console.WriteLine("ISBN     : {0}", list[i].Isbn);
                    Console.WriteLine("책 설명  : {0}", list[i].Information);
                    Console.WriteLine("======================================================================================================================================================");
                }
            
            return list;
        }
    }
}
