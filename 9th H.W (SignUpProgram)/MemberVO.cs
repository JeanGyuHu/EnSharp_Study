using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_SignUp
{
    class MemberVO
    {
        string id;
        string password;
        string name;
        string residentNumber;
        string address;
        string phoneNumber;
        string email;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ResidentNumber
        {
            get { return residentNumber; }
            set { residentNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public MemberVO (string id, string pw, string name, string residentNumber, string address, string phone, string email)
        {
            Id = id;
            Password = pw;
            Name = name;
            ResidentNumber = residentNumber;
            Address = address;
            PhoneNumber = phone;
            Email = email;
        }
    }
}
