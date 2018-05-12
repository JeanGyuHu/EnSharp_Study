using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class Member
    {
        private string name;         //회원 이름
        private string residentNum;  //회원 주민번호
        private string password;     //회원 비밀번호
        private string id;           //회원 아이디    
        private string address;      //회원 주소
        private string phoneNumber;  //회원 전화번호
        private int age;
        /// <summary>
        /// 회원명에 대한 get/set
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 주민번호에 대한 get/set
        /// </summary>
        public string ResidentNum
        {
            get { return residentNum; }
            set { residentNum = value; }
        }
        /// <summary>
        /// 비밀번호에 대한 get/set
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// 아이디에 대한 get/set
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 주소에 대한 get/set
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// 전화번호에 대한 get/set
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
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
        public Member(string name, string residentNum, string password, string id, string address, string phone, int age)
        {
            Name = name;
            ResidentNum = residentNum;
            Password = password;
            Id = id;
            Address = address;
            PhoneNumber = phone;
            Age = age;
        }
    }
}
