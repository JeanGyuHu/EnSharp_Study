using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    class DrawControlMember
    {
        private ConsoleKeyInfo keyInfo;

        /// <summary>
        /// 기본 생성자로써 각각의 변수나 객체를 초기화해준다.
        /// </summary>
        public DrawControlMember()
        {
            keyInfo = new ConsoleKeyInfo();
        }
        /// <summary>
        /// 수정할 사람의 아이디를 입력하는 메소드
        /// </summary>
        public void DrawEditScreen()
        {
            Console.Write("\n\n\n\t\t\tChoose person (Id) >>");
        }
        /// <summary>
        /// 주소를 입력하라고 알리는 메소드
        /// </summary>
        public void DrawAdressScreen()
        {
            Console.Write("\n\n\t\t\tAddress ::\n\t\t\t >> ");
        }
        /// <summary>
        /// 전화번호를 입력하라고 알리는 메소드
        /// </summary>
        public void DrawPhoneScreen()
        {
            Console.Write("\n\n\t\t\tPhoneNumber :: (write number only(10 ~ 11))\n\t\t\t >> ");
        }
        /// <summary>
        /// 지울 사람 아이디를 적으라는 메소드
        /// </summary>
        public void DrawDeleteScreen()
        {
            Console.Write("\n\n\n\t\t\tChoose person (Id) >>");
        }
        /// <summary>
        /// 멤버 정보를 띄우는 창의 제목 부분과 카테고리 출력
        /// </summary>
        public void DrawCategory()
        {
            Console.Clear();
            Console.SetWindowSize(150, 30);
            Console.WriteLine("\n\n\t\t\t┌--------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           M E M B E R   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└--------------------------------------------------------┘");
            Console.WriteLine("\n\n┌---------------------------------------------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│   Name   │   Resident Number   │          Id          │           Password          │ Number of Overdue│      Address      │   PhoneNumber   │");
            Console.WriteLine("└---------------------------------------------------------------------------------------------------------------------------------------------┘");

        }
        /// <summary>
        ///카테고리를 출력하고 그에 해당하는 회원정보를 출력하는 메소드
        /// </summary>
        /// <param name="list">회원정보를 담고 있는 리스트</param>
        public void DrawInformation(List<Member> list)
        {
            DrawCategory();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));

        }
        /// <summary>
        /// 이름으로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 이름</param>
        public void DrawSearchWithName(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 주민번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 주민등록 번호</param>
        public void DrawSearchWithResidentNum(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ResidentNum.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 아이디로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 아이디</param>
        public void DrawSearchWithId(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 비밀번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 비밀번호</param>
        public void DrawSearchWithPassword(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Password.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 연체를 한 횟수로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">연체 횟수</param>
        public void DrawSearchWithOverdue(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].NumOverdue.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 주소로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 주소</param>
        public void DrawSearchWithAddress(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Address.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 전화번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 전화번호</param>
        public void DrawSearchWithPhone(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PhoneNumber.Equals(strSearch))
                    Console.WriteLine("   {0}{1}{2}{3}{4}\t\t\t{5}{6}", list[i].Name.PadRight(10), list[i].ResidentNum.PadRight(25), list[i].Id.PadRight(20), list[i].Password.PadRight(30), list[i].NumOverdue, list[i].Address.PadRight(25), list[i].PhoneNumber.PadRight(15));
            }
            DrawPressAnyKey();
        }
        /// <summary>
        /// 아무키나 입력하시오... 출력
        /// </summary>
        public void DrawPressAnyKey()
        {
            Console.Write("\n\n\n\t\t\tPress any key . . .");
            keyInfo = Console.ReadKey();
        }
        /// <summary>
        /// 이름을 입력하시오 출력
        /// </summary>
        public void DrawWriteName()
        {
            Console.Write("\n\n\t\t\t\twrite name (limit 2 ~ 10) : ");
        }
        /// <summary>
        /// 주민번호 입력하시오 출력
        /// </summary>
        public void DrawWriteResidentNum()
        {
            Console.Write("\n\n\t\t\t\twrite Resident Number (xxxxxx-xxxxxxx) : ");
        }
        /// <summary>
        /// 아이디 입력하시오 출력
        /// </summary>
        public void DrawWriteId()
        {
            Console.Write("\n\n\t\t\t\twrite Id : ");
        }
        /// <summary>
        /// 비밀번호 입력하시오 출력
        /// </summary>
        public void DrawWritePassword()
        {
            Console.Write("\n\n\t\t\t\twrite Password : ");
        }
        /// <summary>
        /// 회원가입할때 아이디 입력하시오.. 출력
        /// </summary>
        public void DrawWriteSignId()
        {
            Console.Write("\n\n\t\t\twrite Id (only number and English ,limit (8 ~ 14) : ");
        }
        /// <summary>
        /// 회원가입할때 비밀번호 입력하시오.. 출력
        /// </summary>
        public void DrawWriteSignPassword()
        {
            Console.Write("\n\n\t\t\t\twrite Password (limit 8 ~ 14): ");
        }
        /// <summary>
        /// 연체 횟수를 입력하시오.. 출력
        /// </summary>
        public void DrawWriteOverdue()
        {
            Console.Write("\n\n\t\t\t\twrite Number of Overdue : ");
        }
        /// <summary>
        /// 주소를 입력하시오.. 출력
        /// </summary>
        public void DrawWriteAddress()
        {
            Console.Write("\n\n\t\t\t\twrite Address (15 ~ 20) : ");
        }
        /// <summary>
        /// login Page임을 알리는 메소드
        /// </summary>
        public void DrawLoginPage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\tLOGIN PAGE");
        }
        /// <summary>
        /// 전화번호 입력하시오.. 출력
        /// </summary>
        public void DrawWritePhone()
        {
            Console.Write("\n\n\t\t\t\twrite PhoneNumber (write number only(10 ~ 11)) : ");
        }
        /// <summary>
        /// 삭제 성공!!
        /// </summary>
        public void DrawDeleteSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 삭제 실패...ㅜ
        /// </summary>
        public void DrawEditSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 회원 가입 창 제목
        /// </summary>
        public void DrawSignUpTitle()
        { 
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------┐");
            Console.WriteLine("\t\t\t│           S I G N   U P   P A G E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------┘");

        }
        /// <summary>
        /// 회원 가입 성공!!
        /// </summary>
        public void DrawSignUpSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tS I G N   U P   S U C C E S S !");
            DrawPressAnyKey();
        }
        /// <summary>
        /// 회원 검색창 메뉴
        /// </summary>
        public void DrawSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Name");
            Console.WriteLine("\n\n\t\t\t\t2. Resident Number");
            Console.WriteLine("\n\n\t\t\t\t3. Id");
            Console.WriteLine("\n\n\t\t\t\t4. Password");
            Console.WriteLine("\n\n\t\t\t\t5. Number of Overdue");
            Console.WriteLine("\n\n\t\t\t\t6. Address");
            Console.WriteLine("\n\n\t\t\t\t7. PhoneNumber");
            Console.Write("\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 회원 관리 창 기본 메뉴
        /// </summary>
        public void DrawMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌----------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           C O N T R O L  M E M B E R   M O D E           │");
            Console.WriteLine("\t\t\t└----------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. New User Registration");
            Console.WriteLine("\n\n\t\t\t\t2. Edit Members");
            Console.WriteLine("\n\n\t\t\t\t3. Delete members");
            Console.WriteLine("\n\n\t\t\t\t4. Search Members");
            Console.WriteLine("\n\n\t\t\t\t5. Print members");
            Console.WriteLine("\n\n\t\t\t\t6. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");
        }
        /// <summary>
        /// 회원 추가할때 제목
        /// </summary>
        public void DrawAddMemberTitle()
        {


            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌-------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           A D D   N E W   M E M B E R           │");
            Console.WriteLine("\t\t\t└-------------------------------------------------┘");

        }

        /// <summary>
        /// 가장 기본 메뉴창
        /// </summary>
        public void DrawBasicMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t****************");
            Console.WriteLine("\t\t\t\t* Hu's Library *");
            Console.WriteLine("\t\t\t\t****************\n\n");
            Console.WriteLine("\n\n\t\t\t\t1. Superviser Mode");
            Console.WriteLine("\n\n\t\t\t\t2. User Mode");
            Console.WriteLine("\n\n\t\t\t\t3. Sign up");
            Console.WriteLine("\n\n\t\t\t\t4. EXIT");
            Console.Write("\n\n\t\t\t >>> ");

        }
        /// <summary>
        /// 관리자모드 메뉴창
        /// </summary>
        public void DrawSuperViserModeMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           S U P E R V I S E R   M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. User Management");
            Console.WriteLine("\n\n\t\t\t\t2. Book Management");
            Console.WriteLine("\n\n\t\t\t\t3. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");

        }
        /// <summary>
        /// 유저모드 메뉴창
        /// </summary>
        public void DrawUserModeMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------┐");
            Console.WriteLine("\t\t\t│           U S E R   M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. Book Rental");
            Console.WriteLine("\n\n\t\t\t\t2. Extend return time");
            Console.WriteLine("\n\n\t\t\t\t3. EXIT");
            Console.Write("\n\n\t\t\t\t >> ");
        }
        /// <summary>
        /// 비밀번호와 주민등록 번호의 경우 보안의 문제가 있기 때문에 보안문자로 입력을 받고, 이용자는 확인할 수 없게 *을 출력해준다.
        /// BackSpace를 눌렀을 경우 한칸전으로 돌아가 write해놓은 걸 " "로 바꿔준다.
        /// Enter를 눌렀을 경우 입력 받는 것을 종료한다.
        /// 그 외에는 입력받은 키의 정보를 SecureString에 한자한자 저장을 하며 *을 출력해준다.
        /// </summary>
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
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if(pwd.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        pwd.RemoveAt(pwd.Length - 1);
                    }
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
    }
}
