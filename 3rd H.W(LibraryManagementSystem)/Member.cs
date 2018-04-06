using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Member
    {
        private string memName;
        private string memResidentNum;
        private string memPassword;
        private string memId;
        private string memNumOverdue;
        private string memAddress;
        private string memPhoneNumber;

        public string Name
        {
            get { return memName; }
            set { memName = value; }
        }
        public string ResidentNum
        {
            get { return memResidentNum; }
            set { memResidentNum = value; }
        }
        public string Password
        {
            get { return memPassword; }
            set { memPassword = value; }
        }
        public string Id
        {
            get { return memId; }
            set { memId = value; }
        }
        public string NumOverdue
        {
            get { return memNumOverdue; }
            set { memNumOverdue = value; }
        }
        public string Address
        {
            get { return memAddress; }
            set { memAddress = value; }
        }
        public string PhoneNumber
        {
            get { return memPhoneNumber; }
            set { memPhoneNumber = value; }
        }
        public Member(string name,string residentNum,string password, string id,string due,string address,string phone)
        {
            Name = name;
            ResidentNum = residentNum;
            Password = password;
            Id = id;
            NumOverdue = due;
            Address = address;
            PhoneNumber = phone;
        }
    }
}
