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
        private string strId;                               //id 입력 받기 위함
        private string stringResidentNum;                   //보안으로 받은 것을 저장하기 위해 string으로 변환해주기 위함
        private string strName;                             //이름을 입력 받기 위함
        private string stringPassword;                      //보안으로 받은 것을 저장하기 위해 string으로 변환해주기 위함
        private string strAddress;                          //주소를 입력 받기 위함
        private string strPhoneNumber;                      //전화번호를 입력 받기 위함

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
            DrawId();

            if (CheckId(list))
            {
                DrawPassword();
                DrawName();
                DrawResidentNum();
                DrawPhoneNum();
                DrawAddress();
                Console.Clear();
                list.Add(new Member(strName, stringResidentNum, stringPassword, strId, 0, strAddress, strPhoneNumber));
                drawControlMember.SignUpSuccess();
            }
            else
            {
                HelpSignUp(list);
            }
        }
        /// <summary>
        /// 아이디 입력 받는 메소드
        /// </summary>
        public void DrawId()
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteSignId();
            strId = Console.ReadLine();
            if (!exceptionHandling.CheckId(strId))
            {
                DrawId();
            }
        }
        /// <summary>
        /// 비밀번호 입력 받는 메소드
        /// </summary>
        public void DrawPassword()
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteSignPassword();
            securePassword = drawControlMember.GetConsoleSecurePassword();
            stringPassword = new NetworkCredential("", securePassword).Password;
            if (!exceptionHandling.CheckPw(stringPassword))
            {
                DrawPassword();
            }
        }
        /// <summary>
        /// 이름 입력 받는 메소드
        /// </summary>
        public void DrawName()
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteName();
            strName = Console.ReadLine();
        }
        /// <summary>
        /// 주민번호 입력 받는 메소드
        /// </summary>
        public void DrawResidentNum()
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteResidentNum();
            secureResidentNum = drawControlMember.GetConsoleSecurePassword();
            stringResidentNum = new NetworkCredential("", secureResidentNum).Password;

            if (!exceptionHandling.CheckResidentNum(stringResidentNum))
            {
                DrawResidentNum();
            }
        }
        /// <summary>
        /// 전화번호 입력 받는 메소드
        /// </summary>
        public void DrawPhoneNum()
        {
            Console.Clear();
            drawControlMember.SignUpTitle();
            drawControlMember.WritePhone();
            strPhoneNumber = Console.ReadLine();

            if (!exceptionHandling.CheckPhone(strPhoneNumber))
            {
                DrawPhoneNum();
            }
        }
        /// <summary>
        /// 주소를 입력받는 메소드
        /// </summary>
        public void DrawAddress()
        {
            drawControlMember.SignUpTitle();
            drawControlMember.WriteAddress();
            strAddress = Console.ReadLine();

            if (!exceptionHandling.CheckAddress(strAddress))
            {
                DrawAddress();
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
                if (mem.Id.Equals(strId))
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
