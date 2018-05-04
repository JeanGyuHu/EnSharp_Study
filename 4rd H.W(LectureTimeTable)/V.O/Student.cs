using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class Student
    {
        private string id;          //아이디
        private string password;    //비밀번호
        private int interestPoint;  //관심과목 학점
        private int registePoint;   //수강신청 학점

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

        public int InterestPoint
        {
            get { return interestPoint; }
            set { interestPoint = value; }
        }

        public int RegistePoint
        {
            get { return registePoint; }
            set { registePoint = value; }
        }
        public Student (string id,string password)
        {
            this.Id = id;
            this.Password = password;
            InterestPoint = 0;
            RegistePoint = 0;
        }
    }
}
