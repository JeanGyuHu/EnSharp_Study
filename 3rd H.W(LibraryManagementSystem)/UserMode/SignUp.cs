using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    class SignUp
    {
        private DrawControlMember drawControlMember;        //UI 그리기 위한 객체 선언
        private ExceptionHandling exceptionHandling;        //예외 처리를 위한 객체 선언
        private SecureString securePassword;                //비밀번호를 받기 위한 보안string
        private SecureString secureResidentNum;             //주민번호를 받기 위한 보안 string     
        private string id;                               //id 입력 받기 위함
        private string residentNum;                   //보안으로 받은 것을 저장하기 위해 string으로 변환해주기 위함
        private string name;                             //이름을 입력 받기 위함
        private string password;                      //보안으로 받은 것을 저장하기 위해 string으로 변환해주기 위함
        private string address;                          //주소를 입력 받기 위함
        private string phoneNumber;                      //전화번호를 입력 받기 위함

        private int count = 0;

        /// <summary>
        /// 각 객체 초기화 후에 회원가입 메소드 호출
        /// </summary>
        /// <param name="list"></param>
        public SignUp(List<Member> list)
        {
            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
            securePassword = new SecureString();
            secureResidentNum = new SecureString();
        }

        /// <summary>
        /// 회원가입 절차를 밟은 후에 회원 추가
        /// </summary>
        /// <param name="list">회원 정보 목록</param>
        public void HelpSignUp(List<Member> list)
        {
            DrawId(list);
            if (id.Equals("0"))
                return;

            DrawPassword(list);
            if (password.Equals("0"))
                return;
            DrawName(list);
            if (name.Equals("0"))
                return;
            DrawResidentNum(list);
            if (residentNum.Equals("0"))
                return;
            DrawPhoneNum(list);
            if (phoneNumber.Equals("0"))
                return;
            DrawAddress(list);
            if (address.Equals("0"))
                return;
            Console.Clear();
            list.Add(new Member(name, residentNum, password, id, 0, address, phoneNumber));
            drawControlMember.SignUpSuccess();

        }
        /// <summary>
        /// 아이디 입력 받는 메소드
        /// </summary>
        public void DrawId(List<Member> list)
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteSignId((int)LibraryConstants.Mode.Add);
            id = Console.ReadLine();
            if (id.Equals("0"))
                return;

            if (!exceptionHandling.CheckId(id))
            {
                DrawId(list);
            }
            if (!CheckId(list))
            {
                DrawId(list);
            }
        }
        /// <summary>
        /// 비밀번호 입력 받는 메소드
        /// </summary>
        public void DrawPassword(List<Member> list)
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteSignPassword((int)LibraryConstants.Mode.Add);
            securePassword = drawControlMember.GetConsoleSecurePassword();
            password = new NetworkCredential("", securePassword).Password;
            if (password.Equals("0"))
                return;
            if (password.Equals("1"))
                DrawId(list);
            if (!exceptionHandling.CheckPw(password))
            {
                DrawPassword(list);
            }
        }
        /// <summary>
        /// 이름 입력 받는 메소드
        /// </summary>
        public void DrawName(List<Member> list)
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteName((int)LibraryConstants.Mode.Add);
            name = Console.ReadLine();

            if (name.Equals("0"))
                return;
            if (name.Equals("1"))
                DrawPassword(list);

            if (!exceptionHandling.CheckName(name))
            {
                DrawName(list);
            }
        }
        /// <summary>
        /// 주민번호 입력 받는 메소드
        /// </summary>
        public void DrawResidentNum(List<Member> list)
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteResidentNum((int)LibraryConstants.Mode.Add);
            secureResidentNum = drawControlMember.GetConsoleSecurePassword();
            residentNum = new NetworkCredential("", secureResidentNum).Password;

            if (residentNum.Equals("0"))
                return;
            if (residentNum.Equals("1"))
                DrawName(list);
            if (!exceptionHandling.CheckResidentNum(residentNum))
            {
                DrawResidentNum(list);
            }
        }
        /// <summary>
        /// 전화번호 입력 받는 메소드
        /// </summary>
        public void DrawPhoneNum(List<Member> list)
        {
            Console.Clear();
            drawControlMember.SignUpTitle();
            drawControlMember.WritePhone((int)LibraryConstants.Mode.Add);
            phoneNumber = Console.ReadLine();

            if (phoneNumber.Equals("0"))
                return;
            if (phoneNumber.Equals("1"))
                DrawResidentNum(list);
            if (!exceptionHandling.CheckPhone(phoneNumber))
            {
                DrawPhoneNum(list);
            }
        }
        /// <summary>
        /// 주소를 입력받는 메소드
        /// </summary>
        public void DrawAddress(List<Member> list)
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteAddress((int)LibraryConstants.Mode.Add);
            address = Console.ReadLine();

            if (address.Equals("0"))
                return;
            if (address.Equals("1"))
                DrawPhoneNum(list);
            if (!exceptionHandling.CheckAddress(address))
            {
                DrawAddress(list);
            }
        }
        /// <summary>
        /// 아이디가 이미 있는지 없는지 여부 체크
        /// </summary>
        /// <param name="list">회원 리스트</param>
        /// <returns>회원가입 가능 아이디인지 아닌지 여부</returns>
        public bool CheckId(List<Member> list)
        {
            count = 0;
            foreach (Member mem in list)
            {
                if (mem.Id.Equals(id))
                {
                    Console.WriteLine("\n\n\t\t\tUsername already taken. Please try another one.");
                    return false;
                }
                count++;
            }
            if (count == list.Count)
            {
                return true;
            }
            return false;
        }
    }
}
