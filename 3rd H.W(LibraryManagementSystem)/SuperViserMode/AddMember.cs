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
        private string id;

        private SecureString secureResidentNum = new SecureString();    //주민등록번호를 비밀문자로 입력받는다.
        private string residentNum;                               //주민등록번호를 저장하기위해 string으로 변환
        private string name;                                         //유저의 이름을 받기 위함
        private SecureString securePassword = new SecureString();       //비밀번호를 비밀문자로 입력받는다.
        private string password;                                  //저장을 위해 string으로 변환하기 위함

        private string address;                                      //주소 입력 받기 위함
        private string phoneNumber;                                  //전화번호 입력받기 위함
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
        }

        /// <summary>
        /// 전체적으로 그리고 입력받고 추가하는 역할을 한다.
        /// </summary>
        /// <param name="list"></param>
        public void DrawAndAdd(List<Member> list)
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
            drawControlMember.PressAnyKey();

        }
        /// <summary>
        /// 아이디를 입력받는 부분
        /// </summary>
        public void DrawId(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 비밀번호를 입력받는 부분
        /// </summary>
        public void DrawPassword(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 이름을 입력받는 부분
        /// </summary>
        public void DrawName(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 주민번호를 입력받는 부분
        /// </summary>
        public void DrawResidentNum(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 전화번호를 입력받는 부분
        /// </summary>
        public void DrawPhoneNum(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 주소를 입력받는 부분
        /// </summary>
        public void DrawAddress(List<Member> list)
        {
            Console.Clear();
            drawControlMember.AddMemberTitle();
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
        /// 이미 아이디가 존재하는지를 체크하는 부분
        /// </summary>
        /// <param name="list">회원정보 리스트</param>
        /// <returns>회원이 있는지 없는지를 bool값으로 리턴</returns>
        public bool CheckId(List<Member> list)
        {
            count = 0;
            foreach (Member mem in list)
            {
                if (mem.Id.Equals(id))
                {
                    Console.WriteLine("\n\n\t\t\tUsername already taken. Please try another one.");
                    drawControlMember.PressAnyKey();
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
