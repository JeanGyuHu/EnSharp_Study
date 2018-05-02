using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Member
    {
        private string memName;         //회원 이름
        private string memResidentNum;  //회원 주민번호
        private string memPassword;     //회원 비밀번호
        private string memId;           //회원 아이디    
        private string memAddress;      //회원 주소
        private string memPhoneNumber;  //회원 전화번호

        /// <summary>
        /// 회원명에 대한 get/set
        /// </summary>
        public string Name
        {
            get { return memName; }
            set { memName = value; }
        }
        /// <summary>
        /// 주민번호에 대한 get/set
        /// </summary>
        public string ResidentNum
        {
            get { return memResidentNum; }
            set { memResidentNum = value; }
        }
        /// <summary>
        /// 비밀번호에 대한 get/set
        /// </summary>
        public string Password
        {
            get { return memPassword; }
            set { memPassword = value; }
        }
        /// <summary>
        /// 아이디에 대한 get/set
        /// </summary>
        public string Id
        {
            get { return memId; }
            set { memId = value; }
        }
        /// <summary>
        /// 주소에 대한 get/set
        /// </summary>
        public string Address
        {
            get { return memAddress; }
            set { memAddress = value; }
        }
        /// <summary>
        /// 전화번호에 대한 get/set
        /// </summary>
        public string PhoneNumber
        {
            get { return memPhoneNumber; }
            set { memPhoneNumber = value; }
        }
        /// <summary>
        /// 회원에 대한 모든 정보가 들어왔을때 전부 초기화해서 추가하기 위한 생성자
        /// </summary>
        /// <param name="name">입력 회원 이름</param>
        /// <param name="residentNum">입력 회원 주민번호</param>
        /// <param name="password">입력 회원 비밀번호</param>
        /// <param name="id">입력 회원 아이디</param>
        /// <param name="due">입력 회원 연체 횟수</param>
        /// <param name="address">입력 회원 주소</param>
        /// <param name="phone">입력 회원 전화번호</param>
        public Member(string name,string residentNum,string password, string id,string address,string phone)
        {
            Name = name;
            ResidentNum = residentNum;
            Password = password;
            Id = id;
            Address = address;
            PhoneNumber = phone;
        }
    }
}
