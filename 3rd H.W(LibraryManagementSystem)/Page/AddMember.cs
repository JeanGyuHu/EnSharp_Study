using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    class AddMember
    {
        private string strId;

        private SecureString secureResidentNum = new SecureString();    //주민등록번호를 비밀문자로 입력받는다.
        private string stringResidentNum;                               //주민등록번호를 저장하기위해 string으로 변환
        private string strName;                                         //유저의 이름을 받기 위함
        private SecureString securePassword = new SecureString();       //비밀번호를 비밀문자로 입력받는다.
        private string stringPassword;                                  //저장을 위해 string으로 변환하기 위함

        private string strAddress;                                      //주소 입력 받기 위함
        private string strPhoneNumber;                                  //전화번호 입력받기 위함
        private int count;                                              //아이디 체크를 할때 전부다 확인을 했나 체크하기 위함
        private DrawControlMember drawControlMember;                    //출력을 하기 위해 클래스의 객체 선언
        private ExceptionHandling exceptionHandling;                    //예외처리를 위해 클래스의 객체 선언

        /// <summary>
        /// 기본 생성자로써 각각의 객체들의 생성해주고 초기화해준다.
        /// 초기화 후에 회원가입을 진행한다.
        /// </summary>
        /// <param name="list">회원의 정보를 매개변수로 받는다.</param>
        public AddMember(List<Member> list)
        {
            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
            count = 0;
            DrawAndAdd(list);
        }

        /// <summary>
        /// 전체적으로 그리고 입력받고 추가하는 역할을 한다.
        /// </summary>
        /// <param name="list"></param>
        public void DrawAndAdd(List<Member> list)
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
                drawControlMember.DrawPressAnyKey();
            }
            else
            {
                DrawAndAdd(list);
            }
        }
        /// <summary>
        /// 아이디를 입력받는 부분
        /// </summary>
        public void DrawId()
        {
            Console.Clear();
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWriteSignId();
            strId = Console.ReadLine();

            if (!exceptionHandling.CheckId(strId))
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
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWriteSignPassword();
            securePassword = drawControlMember.GetConsoleSecurePassword();
            stringPassword = new NetworkCredential("", securePassword).Password;

            if (!exceptionHandling.CheckPw(stringPassword))
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
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWriteName();
            strName = Console.ReadLine();

            if (!exceptionHandling.CheckName(strName))
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
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWriteResidentNum();
            secureResidentNum = drawControlMember.GetConsoleSecurePassword();
            stringResidentNum = new NetworkCredential("", secureResidentNum).Password;

            if (!exceptionHandling.CheckResidentNum(stringResidentNum))
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
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWritePhone();
            strPhoneNumber = Console.ReadLine();

            if (!exceptionHandling.CheckPhone(strPhoneNumber))
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
            drawControlMember.DrawAddMemberTitle();
            drawControlMember.DrawWriteAddress();
            strAddress = Console.ReadLine();

            if (!exceptionHandling.CheckAddress(strAddress))
            {
                DrawAddress();
            }
        }
        /// <summary>
        /// 이미 아이디가 존재하는지를 체크하는 부분
        /// </summary>
        /// <param name="list">회원정보 리스트</param>
        /// <returns>회원이 있는지 없는지를 bool값으로 리턴</returns>
        public bool CheckId(List<Member> list)
        {
            count = 0;
            foreach (Member mem in list)
            {
                if (mem.Id.Equals(strId))
                {
                    Console.WriteLine("\n\n\t\t\tUsername already taken. Please try another one.");
                    drawControlMember.DrawPressAnyKey();
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
