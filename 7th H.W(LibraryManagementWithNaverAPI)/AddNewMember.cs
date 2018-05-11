using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class AddNewMember
    {
        private string id;
        private SecureString secureResidentNum = new SecureString();    //주민등록번호를 비밀문자로 입력받는다.
        private string residentNum;                                     //주민등록번호를 저장하기위해 string으로 변환
        private string name;                                            //유저의 이름을 받기 위함
        private SecureString securePassword = new SecureString();       //비밀번호를 비밀문자로 입력받는다.
        private string password;                                        //저장을 위해 string으로 변환하기 위함
        private string address;                                         //주소 입력 받기 위함
        private string phoneNumber;                                     //전화번호 입력받기 위함
        private int count;                                              //아이디 체크를 할때 전부다 확인을 했나 체크하기 위함
        private PrintAboutControlMembers printAboutControlMembers;                    //출력을 하기 위해 클래스의 객체 선언
        private ExceptionHandler exceptionHandler;                    //예외처리를 위해 클래스의 객체 선언
        private DBExceptionHandler dBExceptionHandler;
        private MemberDAO memberDAO;
        /// <summary>
        /// 기본 생성자로써 각각의 객체들의 생성해주고 초기화해준다.
        /// 초기화 후에 회원가입을 진행한다.
        /// </summary>
        /// <param name="list">회원의 정보를 매개변수로 받는다.</param>
        public AddNewMember()
        {
            printAboutControlMembers = new PrintAboutControlMembers();
            exceptionHandler = new ExceptionHandler();
            dBExceptionHandler = new DBExceptionHandler();
            memberDAO = new MemberDAO();
            count = 0;
        }

        /// <summary>
        /// 전체적으로 그리고 입력받고 추가하는 역할을 한다.
        /// </summary>
        /// <param name="list"></param>
        public void DrawAndAdd()
        {
            DrawId();
            if (id.Equals("0"))
                return;
            DrawPassword();
            if (password.Equals("0"))
                return;
            DrawName();
            if (name.Equals("0"))
                return;
            DrawResidentNum();
            if (residentNum.Equals("0"))
                return;
            DrawPhoneNum();
            if (phoneNumber.Equals("0"))
                return;
            DrawAddress();
            if (address.Equals("0"))
                return;
            Console.Clear();
            memberDAO.AddMember(new Member(name, residentNum, password, id, address, phoneNumber, 0));
            printAboutControlMembers.AddResult("S U C C E S S");
        }

        /// <summary>
        /// 로그인 페이지를 그리고 로그인이 됬는지 안됬는지 체크해주는 메소드
        /// </summary>
        /// <param name="list">멤버 목록이 들어있는 리스트</param>
        /// <returns>로그인 여부</returns>
        public bool DrawLoginPage(string mode)
        {
            printAboutControlMembers.LoginPage();
            printAboutControlMembers.WriteId();
            id = Console.ReadLine();
            if (id.Equals("0"))
                return false;

            if (exceptionHandler.CheckID(id, mode))
            {
                printAboutControlMembers.WritePassword();
                securePassword = printAboutControlMembers.GetConsoleSecurePassword();
                password = new NetworkCredential("", securePassword).Password;
                if (exceptionHandler.CheckPW(id,password, mode))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DrawLoginPage(mode);
            }
            return false;
        }

        /// <summary>
        /// 아이디를 입력받는 부분
        /// </summary>
        public void DrawId()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WriteSignId((int)LibraryConstants.Mode.Add);
            id = Console.ReadLine();
            if (id.Equals("0"))
                return;

            if (!exceptionHandler.CheckId(id))
            {
                DrawId();
            }
            else if (!CheckId())
            {
                DrawId();
            }
        }

        /// <summary>
        /// 비밀번호를 입력받는 부분
        /// </summary>
        public void DrawPassword()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WriteSignPassword((int)LibraryConstants.Mode.Add);
            securePassword = printAboutControlMembers.GetConsoleSecurePassword();
            password = new NetworkCredential("", securePassword).Password;
            if (password.Equals("0"))
                return;
            if (password.Equals("1"))
                DrawId();
            if (!exceptionHandler.CheckPw(password))
            {
                DrawPassword();
            }
        }
        /// <summary>
        /// 이름을 입력받는 부분
        /// </summary>
        public void DrawName()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WriteName((int)LibraryConstants.Mode.Add);
            name = Console.ReadLine();
            if (name.Equals("0"))
                return;
            if (name.Equals("1"))
                DrawPassword();

            if (!exceptionHandler.CheckName(name))
            {
                DrawName();
            }
        }
        /// <summary>
        /// 주민번호를 입력받는 부분
        /// </summary>
        public void DrawResidentNum()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WriteResidentNum((int)LibraryConstants.Mode.Add);
            secureResidentNum = printAboutControlMembers.GetConsoleSecurePassword();
            residentNum = new NetworkCredential("", secureResidentNum).Password;
            if (residentNum.Equals("0"))
                return;
            if (residentNum.Equals("1"))
                DrawName();
            if (!exceptionHandler.CheckResidentNum(residentNum))
            {
                DrawResidentNum();
            }
            if (!dBExceptionHandler.CheckResidentNumber(residentNum))
            {
                DrawResidentNum();
            }
        }
        /// <summary>
        /// 전화번호를 입력받는 부분
        /// </summary>
        public void DrawPhoneNum()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WritePhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
                DrawResidentNum();
            if (!exceptionHandler.CheckPhone(phoneNumber))
            {
                DrawPhoneNum();
            }
            if (!dBExceptionHandler.CheckPhoneNumber(phoneNumber))
            {
                DrawPhoneNum();
            }
        }
        /// <summary>
        /// 주소를 입력받는 부분
        /// </summary>
        public void DrawAddress()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.WriteAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();
            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
                DrawPhoneNum();
            if (!exceptionHandler.CheckAddress(address))
            {
                DrawAddress();
            }
        }
        /// <summary>
        /// 이미 아이디가 존재하는지를 체크하는 부분
        /// </summary>
        /// <param name="list">회원정보 리스트</param>
        /// <returns>회원이 있는지 없는지를 bool값으로 리턴</returns>
        public bool CheckId()
        {
            count = 0;

            if (!dBExceptionHandler.IsIdInMemberDB(id))
            {
                Console.WriteLine("\n\n\t\t\tUsername already taken. Please try another one.");
                printAboutControlMembers.PressAnyKey();
                return false;
            }

            return true;
        }
    }
}
