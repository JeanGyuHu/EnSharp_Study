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
        public void EditScreen()
        {
            Console.Write("\n\n\n\t\t\tChoose person (Id) (뒤로가기를 원하면 0을 입력) >>");
        }
        /// <summary>
        /// 뒤로가려면 Enter를 누르세요
        /// </summary>
        public void ExitMessage()
        {
            Console.WriteLine("\n\n\t\t\t뒤로가려면 Enter를 누르세요.");
        }
        /// <summary>
        /// 지울 사람 아이디를 적으라는 메소드
        /// </summary>
        public void DeleteScreen()
        {
            Console.Write("\n\n\n\t\t\tChoose person (ID) >>");
        }
        /// <summary>
        /// 멤버 정보를 띄우는 창의 제목 부분과 카테고리 출력
        /// </summary>
        public void Category()
        {
            Console.Clear();
            Console.SetWindowSize(180, 30);
            Console.WriteLine("\n\n\t\t\t┌--------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           M E M B E R   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└--------------------------------------------------------┘");
            Console.WriteLine("\n\n┌----------------------------------------------------------------------------------------------------------------------------------------┐");
            Console.WriteLine("│   Name   │   Resident Number   │          Id          │         Password        │    PhoneNumber    │        Address         │");
            Console.WriteLine("└-----------------------------------------------------------------------------------------------------------------------------------------┘");
        }
        /// <summary>
        ///카테고리를 출력하고 그에 해당하는 회원정보를 출력하는 메소드
        /// </summary>
        /// <param name="list">회원정보를 담고 있는 리스트</param>
        public void Information(List<Member> list)
        {
            Category();
            for (int i = 0; i < list.Count; i++)
            {
                
                byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                byte[] byteName2 = new byte[10];
                Array.Copy(byteName1, byteName2, 10);

                byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                byte[] byteAddress2 = new byte[30];
                Array.Copy(byteAddress1, byteAddress2, 30);

                Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}",Encoding.Default.GetString(byteName2) , list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
            }
        }
        /// <summary>
        /// 이름으로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 이름</param>
        public void SearchWithName(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }
        /// <summary>
        /// 주민번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 주민등록 번호</param>
        public void SearchWithResidentNum(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ResidentNum.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }
        /// <summary>
        /// 아이디로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 아이디</param>
        public void SearchWithId(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }
        /// <summary>
        /// 비밀번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 비밀번호</param>
        public void SearchWithPassword(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Password.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }

        /// <summary>
        /// 주소로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 주소</param>
        public void SearchWithAddress(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Address.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }
        /// <summary>
        /// 전화번호로 검색했을때의 결과값 출력
        /// </summary>
        /// <param name="list">회원 정보를 담고 있는 리스트</param>
        /// <param name="strSearch">검색할 회원의 전화번호</param>
        public void SearchWithPhone(List<Member> list, string strSearch)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PhoneNumber.Equals(strSearch))
                {
                    byte[] byteName1 = Encoding.Default.GetBytes(list[i].Name + "          ");
                    byte[] byteName2 = new byte[10];
                    Array.Copy(byteName1, byteName2, 10);

                    byte[] byteAddress1 = Encoding.Default.GetBytes(list[i].Address + "                              ");
                    byte[] byteAddress2 = new byte[30];
                    Array.Copy(byteAddress1, byteAddress2, 30);

                    Console.WriteLine("   {0}{1,-25}{2,-25}{3,-20}{4,-22}{5}", Encoding.Default.GetString(byteName2), list[i].ResidentNum, list[i].Id, list[i].Password, list[i].PhoneNumber, Encoding.Default.GetString(byteAddress2));
                }
            }
            PressAnyKey();
        }
        /// <summary>
        /// 아무키나 입력하시오... 출력
        /// </summary>
        public void PressAnyKey()
        {
            Console.Write("\n\n\n\t\t\tPress any key . . .");
            keyInfo = Console.ReadKey();
            Console.SetWindowSize(120, 30);
        }
        /// <summary>
        /// 이름을 입력하시오 출력
        /// </summary>
        public void WriteName(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t이름을 입력하세요. (뒤로가기 1,종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t공백을 제외한 완성된 한글만 입력 가능합니다.(글자 제한 : 2 ~ 5)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t이름을 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t공백을 제외한 완성된 한글만 입력 가능합니다.(글자 제한 : 2 ~ 5)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
            }

        }
        /// <summary>
        /// 주민번호 입력하시오 출력
        /// </summary>
        public void WriteResidentNum(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t주민등록번호를 입력하세요. (뒤로가기 1,종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 yymmdd-(1,2)xxxxxx (남자면 1, 여자면 2)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t주민등록번호를 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 yymmdd-(1,2)xxxxxx (남자면 1, 여자면 2)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
            }

        }
        /// <summary>
        /// 아이디 입력하시오 출력 (로그인 화면)
        /// </summary>
        public void WriteId()
        {
            
            Console.WriteLine("\n\n\t\t\t\t아이디를 입력하세요. (종료 0)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 비밀번호 입력하시오 출력 (로그인 화면)
        /// </summary>
        public void WritePassword()
        {
            
            Console.WriteLine("\n\n\t\t\t\t비밀번호를 입력하세요. (아이디 다시 입력 -1,종료 0)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 회원가입할때 아이디 입력하시오.. 출력
        /// </summary>
        public void WriteSignId(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t아이디를 입력하세요. (종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 공백을 제외한 영어와 숫자만 가능합니다. (글자 제한 : 8 ~ 14)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t아이디를 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 공백을 제외한 영어와 숫자만 가능합니다. (글자 제한 : 8 ~ 14)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;                   
            }

        }
        /// <summary>
        /// 회원가입할때 비밀번호 입력하시오.. 출력
        /// </summary>
        public void WriteSignPassword(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t비밀번호를 입력하세요. (뒤로가기 1,종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 공백을 제외한 영어와 숫자,특수문자만 가능합니다. (글자 제한 : 8 ~ 14)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t비밀번호를 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 공백을 제외한 영어와 숫자,특수문자만 가능합니다. (글자 제한 : 8 ~ 14)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
            }

        }
        /// <summary>
        /// 연체 횟수를 입력하시오.. 출력
        /// </summary>
        public void WriteOverdue(int num)
        {
            Console.WriteLine("\n\n\t\t\t\t연체한 횟수를 입력하세요. (숫자만 입력)");
            Console.Write("\n\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 주소를 입력하시오.. 출력
        /// </summary>
        public void WriteAddress(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t주소를 입력하세요. (뒤로가기 1,종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 완성된 한글만 가능합니다.");
                    Console.WriteLine("\n\n\t\t\t\t예시) (00~000시/도) (0~000시/군/구) (00~000로)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t주소를 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 완성된 한글만 가능합니다.");
                    Console.WriteLine("\n\n\t\t\t\t예시) (00~000시/도) (0~000시/군/구) (00~000로)");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
            }
            
        }
        /// <summary>
        /// login Page임을 알리는 메소드
        /// </summary>
        public void LoginPage()
        {
            Console.Clear();
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌-----------------------------------------┐");
            Console.WriteLine("\t\t\t│           L O G I N   P A G E           │");
            Console.WriteLine("\t\t\t└-----------------------------------------┘");
        }
        /// <summary>
        /// 전화번호 입력하시오.. 출력
        /// </summary>
        public void WritePhone(int num)
        {
            switch (num)
            {
                case (int)LibraryConstants.Mode.Add:
                    Console.WriteLine("\n\n\t\t\t\t전화번호를 입력하세요. (뒤로가기 1,종료 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 01(0,1,6,7,8,9)-(xxx,xxxx)-xxxx x는 숫자만 가능합니다.");
                    Console.WriteLine("\n\n\t\t\t\t예시) 010-4701-8554");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
                case (int)LibraryConstants.Mode.Search:
                    Console.WriteLine("\n\n\t\t\t\t전화번호를 입력하세요. (뒤로가기 0)");
                    Console.WriteLine("\n\n\t\t\t\t형식은 01(0,1,6,7,8,9)-(xxx,xxxx)-xxxx x는 숫자만 가능합니다.");
                    Console.WriteLine("\n\n\t\t\t\t예시) 010-4701-8554");
                    Console.Write("\n\n\t\t\t\t>> ");
                    break;
            }
            
        }
        /// <summary>
        /// 삭제 성공!!
        /// </summary>
        public void DeleteSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 삭제 실패...ㅜ
        /// </summary>
        public void DeleteFailed()
        {
            Console.WriteLine("\n\n\n\t\t\tD E L E T E   F A I L E D !");
            PressAnyKey();
        }
        /// <summary>
        /// 수정 성공!!
        /// </summary>
        public void EditSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 회원 가입 창 제목
        /// </summary>
        public void SignUpTitle()
        { 
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------┐");
            Console.WriteLine("\t\t\t│           S I G N   U P   P A G E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------┘");

        }
        /// <summary>
        /// 회원 가입 성공!!
        /// </summary>
        public void SignUpSuccess()
        {
            Console.WriteLine("\n\n\n\t\t\tS I G N   U P   S U C C E S S !");
            PressAnyKey();
        }
        /// <summary>
        /// 회원 검색창 메뉴
        /// </summary>
        public void SearchMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Name");
            Console.WriteLine("\n\n\t\t\t\t2. Resident Number");
            Console.WriteLine("\n\n\t\t\t\t3. Id");
            Console.WriteLine("\n\n\t\t\t\t4. Password");
            Console.WriteLine("\n\n\t\t\t\t5. Address");
            Console.WriteLine("\n\n\t\t\t\t6. PhoneNumber");
            Console.WriteLine("\n\n\t\t\t\t7. EXIT");
            Console.Write("\n\t\t\t\t>> ");
        }
        /// <summary>
        /// 회원 관리 창 기본 메뉴
        /// </summary>
        public void Menu()
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
        public void AddMemberTitle()
        {


            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌-------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           A D D   N E W   M E M B E R           │");
            Console.WriteLine("\t\t\t└-------------------------------------------------┘");

        }

        /// <summary>
        /// 가장 기본 메뉴창
        /// </summary>
        public void BasicMenu()
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
        public void SuperViserModeMenu()
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
        public void UserModeMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------┐");
            Console.WriteLine("\t\t\t│           U S E R   M O D E           │");
            Console.WriteLine("\t\t\t└---------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. Book Rental");
            Console.WriteLine("\n\n\t\t\t\t2. Extend return time");
            Console.WriteLine("\n\n\t\t\t\t3. Return Books");
            Console.WriteLine("\n\n\t\t\t\t4. EXIT");
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
