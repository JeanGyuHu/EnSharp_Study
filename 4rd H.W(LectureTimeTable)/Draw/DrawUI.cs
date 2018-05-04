using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;

namespace LectureTimeTable
{
    class DrawUI
    {
        /// <summary>
        /// 기본생성자
        /// </summary>
        public DrawUI()
        {
        }

        /// <summary>
        /// 출력형식에서 위에 과목정보에 대한 카테고리
        /// </summary>
        public void Category()
        {
            Console.Clear();
            Console.SetWindowSize(192, 50);
            Console.WriteLine("===========================================================================================================================================================================================");
            Console.WriteLine("{0,-5}{1,-15}{2,-10}{3,-5}{4,-31}{5,-10}{6,-5}{7,-5}{8,-23}{9,-12}{10,-21}{11}", ConvertLength("NO", 5), ConvertLength("개설학과전공", 15), ConvertLength("학수번호", 10), ConvertLength("분반", 5), ConvertLength("교과목명", 31), ConvertLength("이수구분", 10), ConvertLength("학년", 5), ConvertLength("학점", 5), ConvertLength("요일 및 강의시간", 22), ConvertLength("강의실", 15), ConvertLength("교수명", 20), "강의언어");
            Console.WriteLine("===========================================================================================================================================================================================");
        }

        /// <summary>
        /// 로그인 화면
        /// </summary>
        public void LoginTitle()
        {
            Console.SetWindowSize(33, 10);
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("\tE N #   로 그 인");
            Console.WriteLine("==================================");
            Console.WriteLine("실행 중 ESC 누르면 뒤로가기");
            WriteId();
            WritePassword();
            Console.SetCursorPosition(10, 5);
        }
        /// <summary>
        /// 로그인시 아이디
        /// </summary>
        public void WriteId()
        {
            Console.Write("\n   학번 : ");
        }
        /// <summary>
        /// 로그인시 비밀번호
        /// </summary>
        public void WritePassword()
        {
            Console.Write("\n   비밀번호 : ");
        }

        /// <summary>
        /// 관심과목담기 메뉴
        /// </summary>
        public void InterestSubject()
        {
            Console.SetWindowSize(30, 20);
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("\t관심 과목 담기");
            Console.WriteLine("==================================");
            Console.WriteLine("\n\t1. 과목 검색 & 추가");
            Console.WriteLine("\n\n\t2. 신청 삭제");
            Console.WriteLine("\n\n\t3. 신청 조회");
            Console.WriteLine("\n\n\t4. 뒤로가기");
            Console.Write("\n\n\t>> ");
        }

        /// <summary>
        /// 검색 항목 선택 메뉴
        /// </summary>
        /// <param name="mode"></param>
        public void SearchMenu(string mode)
        {
            Console.SetWindowSize(30, 20);
            Console.Clear();
            switch (mode)
            {
                case TimeTableConstants.INTEREST:
                    Console.WriteLine("==================================");
                    Console.WriteLine("\t검색 항목 선택");
                    Console.WriteLine("==================================");
                    Console.WriteLine("\n\t1. 개설학과전공");
                    Console.WriteLine("\n\t2. 학수번호");
                    Console.WriteLine("\n\t3. 교과목 명");
                    Console.WriteLine("\n\t4. 학년");
                    Console.WriteLine("\n\t5. 교수명");
                    Console.WriteLine("\n\t6. 뒤로가기");
                    Console.Write("\n\n\t>> ");
                    break;

                case TimeTableConstants.REGISTER:
                    Console.WriteLine("==================================");
                    Console.WriteLine("\t검색 항목 선택");
                    Console.WriteLine("==================================");
                    Console.WriteLine("\n\t1. 개설학과전공");
                    Console.WriteLine("\n\t2. 학수번호");
                    Console.WriteLine("\n\t3. 교과목 명");
                    Console.WriteLine("\n\t4. 학년");
                    Console.WriteLine("\n\t5. 교수명");
                    Console.WriteLine("\n\t6. 관심과목");
                    Console.WriteLine("\n\t7. 뒤로가기");
                    Console.Write("\n\n\t>> ");
                    break;
            }
        } 
      
        /// <summary>
        /// 수강신청 메뉴
        /// </summary>
        public void Register()
        {
            Console.SetWindowSize(30, 20);
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("\t수강 신청하기");
            Console.WriteLine("==================================");
            Console.WriteLine("\n\t1. 과목 검색 & 추가");
            Console.WriteLine("\n\n\t2. 신청 삭제");
            Console.WriteLine("\n\n\t3. 신청 조회");
            Console.WriteLine("\n\n\t4. 뒤로가기");
            Console.Write("\n\n\t>> ");
        }
        /// <summary>
        /// 시간표 메뉴
        /// </summary>
        public void ScheduleMenu()
        {
            Console.SetWindowSize(40, 20);
            Console.Clear();
            Console.WriteLine("============================================");
            Console.WriteLine("\t   시간표 조회 메뉴");
            Console.WriteLine("============================================");
            Console.WriteLine("\n\t1. 창에서 시간표 확인");
            Console.WriteLine("\n\n\t2. 시간표 엑셀로 저장");
            Console.WriteLine("\n\n\t3. 뒤로가기");
            Console.Write("\n\n\t>> ");
        }

        /// <summary>
        /// 메인 메뉴
        /// </summary>
        public void MainMenu()
        {
            Console.SetWindowSize(33,20);
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("\t학사 정보 시스템");
            Console.WriteLine("=================================");
            Console.WriteLine("\n\t1. 관심과목 담기");
            Console.WriteLine("\n\n\t2. 수강신청");
            Console.WriteLine("\n\n\t3. 시간표 조회");
            Console.WriteLine("\n\n\t4. 로그아웃");
            Console.Write("\n\n\t>> ");
        }

        /// <summary>
        /// 검색시에 검색 질문
        /// </summary>
        /// <param name="mode"></param>
        public void SearchQuestion(string mode)
        {
            Console.Clear();
            Console.SetWindowSize(85, 5);

            switch (mode)
            {
                case TimeTableConstants.SEARCH_MAJOR:
                    Console.Write("\n\n\t\t검색 할 개설학과전공을 입력하세요 : ");
                    break;
                case TimeTableConstants.SEARCH_NUMBER:
                    Console.Write("\n\n\t\t검색 할 학수번호 입력하세요 : ");
                    break;
                case TimeTableConstants.SEARCH_SUBJECT:
                    Console.Write("\n\n\t\t검색 할 과목명 입력하세요 : ");
                    break;
                case TimeTableConstants.SEARCH_GRADE:
                    Console.Write("\n\n\t\t검색 할 학년을 입력하세요 : ");
                    break;
                case TimeTableConstants.SEARCH_PROFESSOR:
                    Console.Write("\n\n\t\t검색 할 교수명을 입력하세요 : ");
                    break;
            }
        }

        //아무키나 누르세요
        public void PressAnyKey()
        {
            Console.Write("\n\n\tPress Any Key. . . ");
            Console.ReadKey();
        }
        //추가 성공
        public void AddSuccess()
        {
            Console.WriteLine("\n\t성공적으로 추가되었습니다.");
            PressAnyKey();
        }
        //추가 실패
        public void AddFailed()
        {
            Console.WriteLine("\n\t이미 추가된 과목입니다.");
            PressAnyKey();
        }
        //삭제성공
        public void DeleteSuccess()
        {
            Console.WriteLine("\n\t성공적으로 삭제되었습니다.");
            PressAnyKey();
        }
        //삭제 실패
        public void DeleteFailed()
        {
            Console.WriteLine("\n\t삭제에 실패하였습니다.");
            PressAnyKey();
        }
        //전공 입력 에러
        public void MajorError()
        {
            Console.WriteLine("\n\t전공 입력이 잘못되었습니다.(한글로만 4~10자 사이로 입력!)");
            PressAnyKey();
        }
        //학수번호 입력 에러
        public void NumberError()
        {
            Console.WriteLine("\n\t학수번호 입력이 잘못되었습니다.(6자의 숫자로만 입력!)");
            PressAnyKey();
        }
        //분반 입력 에러
        public void DivisionError()
        {
            Console.WriteLine("\n\t분반 입력이 잘못되었습니다.(3자의 숫자로만 입력!)");
            PressAnyKey();
        }
        //그 시간에 안됩니다!
        public void ThatTimeNo()
        {
            Console.WriteLine("\n\t그 시간에 이미 다른 수업이 있습니다.");
            PressAnyKey();
        }
        //검색 실패
        public void SearchFailed()
        {
            Console.WriteLine("\n\n\t검색 결과가 없습니다.");
            PressAnyKey();
        }
        //추가할 과목 학과
        public void AddInterestQuestionMajor()
        {
            Console.Write("\n\n- 추가할 과목의 개설학과 : ");
        }
        //추가할 과목 학수번호
        public void AddInterestQuestionNumber()
        {
            Console.Write("\n\n- 추가할 과목의 학수번호 : ");
        }
        //추가할 과목 분반
        public void AddInterestQuestionDivision()
        {
            Console.Write("\n\n- 추가할 과목의 분반 : ");
        }
        //삭제할 과목 학수번호
        public void DeleteInterestQuestionNumber()
        {
            Console.Write("\n\n- 삭제할 과목의 학수번호 : ");
        }
        //삭제할 과목 분반
        public void DeleteInterestQuestionDivision()
        {
            Console.Write("\n\n- 삭제할 과목의 분반 : ");
        }

        /// <summary>
        /// 매개변수로 받은 숫자만큼 글자를 받는 메서드
        /// </summary>
        /// <param name="size">문자열 길이</param>
        /// <returns></returns>
        public string GetConsoleIdNumber(int size)
        {
            StringBuilder id = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Enter)
                    break;
                else if (info.Key == ConsoleKey.Escape)
                    return "back";
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (id.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        id.Remove(id.Length - 1, 1);
                    }
                }
                else if (id.Length > size)
                    continue;
                else
                {
                    id.Append(info.KeyChar);
                    Console.Write(info.KeyChar.ToString());
                }
            }
            return id.ToString();
        }
        /// <summary>
        /// 비밀번호 입력받는 메서드 (*로 만듬)
        /// </summary>
        /// <returns></returns>
        public SecureString GetConsoleSecurePassword()
        {
            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Escape)
                { pwd.Clear(); pwd.AppendChar('b'); return pwd; }

                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        pwd.RemoveAt(pwd.Length - 1);
                    }
                }
                else if (pwd.Length > 12)
                    continue;
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
        //글자 길이 정해주는 메소드
        public string ConvertLength(string inputString, int length)
        {
            byte[] byteName1 = Encoding.Default.GetBytes(inputString + "                                                                                 ");
            byte[] byteName2 = new byte[length];
            Array.Copy(byteName1, byteName2, length);

            return Encoding.Default.GetString(byteName2);
        }

        /// <summary>
        /// 시간표 기본 틀
        /// </summary>
        public void TimeTableOutline()
        {
            Console.Clear();
            Console.SetWindowSize(160,30);
            Console.WriteLine("\n\n"+ConvertLength("", 20)+ConvertLength("월", 25) + ConvertLength("화", 25) + ConvertLength("수", 25)+ConvertLength("목", 25) + ConvertLength("금", 25));   //3
            Console.WriteLine("09:00~09:30 |"); //4
            Console.WriteLine("09:30~10:00 |"); //5
            Console.WriteLine("10:00~10:30 |"); //6
            Console.WriteLine("10:30~11:00 |");
            Console.WriteLine("11:00~11:30 |");
            Console.WriteLine("11:30~12:00 |");
            Console.WriteLine("12:00~12:30 |"); //10
            Console.WriteLine("12:30~13:00 |");
            Console.WriteLine("13:00~13:30 |");
            Console.WriteLine("13:30~14:00 |");
            Console.WriteLine("14:00~14:30 |");
            Console.WriteLine("14:30~15:00 |"); //15
            Console.WriteLine("15:00~15:30 |");
            Console.WriteLine("15:30~16:00 |");
            Console.WriteLine("16:00~16:30 |");
            Console.WriteLine("16:30~17:00 |");
            Console.WriteLine("17:00~17:30 |"); //20
            Console.WriteLine("17:30~18:00 |");
            Console.WriteLine("18:00~18:30 |");
            Console.WriteLine("18:30~19:00 |");
            Console.WriteLine("19:00~19:30 |");
            Console.WriteLine("19:30~20:00 |"); //25
            Console.WriteLine("20:00~20:30 |"); 
            Console.WriteLine("20:30~21:00 |"); 
        }

        //저장중...
        public void SaveWaiting()
        {
            Console.SetWindowSize(50, 5);

            for (int i = 0; i <= 100; i=i+10)
            {
                Console.Clear();
                Console.Write("\n\t");
                Console.Write("저장 중 {0}% ",i);
                for (int j = 0; j < i / 10; j++)
                {
                    Console.ForegroundColor = ReturnColor(j);
                    Console.Write("■");
                }
                Thread.Sleep(i*5+75);
            }
            Console.WriteLine("\n\n저장이 완료되었습니다 ! ! (아무 키나 누르세요 !)");
            Console.ReadKey();
        }
        public ConsoleColor ReturnColor(int num)
        {
            if (num.Equals(0)) return ConsoleColor.Red;
            else if (num.Equals(1)) return ConsoleColor.DarkYellow;
            else if (num.Equals(2)) return ConsoleColor.Yellow;
            else if (num.Equals(3)) return ConsoleColor.Green;
            else if (num.Equals(4)) return ConsoleColor.Blue;
            else if (num.Equals(5)) return ConsoleColor.DarkBlue;
            else if (num.Equals(6)) return ConsoleColor.DarkMagenta;
            else if (num.Equals(7)) return ConsoleColor.DarkRed;
            else if (num.Equals(8)) return ConsoleColor.Cyan;
            else if (num.Equals(9)) return ConsoleColor.White;
            else return ConsoleColor.White;
        }
    }
}
