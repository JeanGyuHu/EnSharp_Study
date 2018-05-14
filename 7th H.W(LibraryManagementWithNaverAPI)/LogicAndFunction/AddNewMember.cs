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
        private LogDAO logDAO;

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
            logDAO = new LogDAO();
            count = 0;
        }

        /// <summary>
        /// 전체적으로 그리고 입력받고 추가하는 역할을 한다.
        /// </summary>
        /// <param name="list"></param>
        public void PrintAndAdd()
        {
            PrintId();
            if (id.Equals("0"))
                return;
            PrintPassword();
            if (password.Equals("0"))
                return;
            PrintName();
            if (name.Equals("0"))
                return;
            PrintResidentNum();
            if (residentNum.Equals("0"))
                return;
            PrintPhoneNumber();
            if (phoneNumber.Equals("0"))
                return;
            PrintAddress();
            if (address.Equals("0"))
                return;
            Console.Clear();
            memberDAO.AddMember(new Member(name, residentNum, password, id, address, phoneNumber, 0));
            logDAO.AddLog(DateTime.Now, id, "회원 추가");
            printAboutControlMembers.AddResult("S U C C E S S");
        }



        /// <summary>
        /// 아이디를 입력받는 부분
        /// </summary>
        public void PrintId()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintSignId((int)LibraryConstants.Mode.Add);
            id = Console.ReadLine();
            if (id.Equals("0"))
                return;

            if (!exceptionHandler.CheckId(id))
            {
                PrintId();
            }
            else if (!CheckId())
            {
                PrintId();
            }
        }

        /// <summary>
        /// 비밀번호를 입력받는 부분
        /// </summary>
        public void PrintPassword()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintSignPassword((int)LibraryConstants.Mode.Add);
            securePassword = printAboutControlMembers.GetConsoleSecurePassword();
            password = new NetworkCredential("", securePassword).Password;
            if (password.Equals("0"))
                return;
            if (password.Equals("1"))
                PrintId();
            if (!exceptionHandler.CheckPw(password))
            {
                PrintPassword();
            }
        }
        /// <summary>
        /// 이름을 입력받는 부분
        /// </summary>
        public void PrintName()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintName((int)LibraryConstants.Mode.Add);
            name = Console.ReadLine();
            if (name.Equals("0"))
                return;
            if (name.Equals("1"))
                PrintPassword();

            if (!exceptionHandler.CheckName(name))
            {
                PrintName();
            }
        }
        /// <summary>
        /// 주민번호를 입력받는 부분
        /// </summary>
        public void PrintResidentNum()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintResidentNum((int)LibraryConstants.Mode.Add);
            secureResidentNum = printAboutControlMembers.GetConsoleSecureResidentNumber();
            residentNum = new NetworkCredential("", secureResidentNum).Password;
            if (residentNum.Equals("0"))
                return;
            if (residentNum.Equals("1"))
                PrintName();
            if (!exceptionHandler.CheckResidentNum(residentNum))
            {
                PrintResidentNum();
            }
            if (!dBExceptionHandler.CheckResidentNumber(residentNum))
            {
                PrintResidentNum();
            }
        }
        /// <summary>
        /// 전화번호를 입력받는 부분
        /// </summary>
        public void PrintPhoneNumber()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintPhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
                PrintResidentNum();
            if (!exceptionHandler.CheckPhone(phoneNumber))
            {
                PrintPhoneNumber();
            }
            if (!dBExceptionHandler.CheckPhoneNumber(phoneNumber))
            {
                PrintPhoneNumber();
            }
        }
        /// <summary>
        /// 주소를 입력받는 부분
        /// </summary>
        public void PrintAddress()
        {
            Console.Clear();
            printAboutControlMembers.AddMemberTitle();
            printAboutControlMembers.PrintAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();
            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
                PrintPhoneNumber();
            if (!exceptionHandler.CheckAddress(address))
            {
                PrintAddress();
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
