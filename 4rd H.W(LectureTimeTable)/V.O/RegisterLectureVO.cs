using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class RegisterLectureVO
    {
        private string id;          //수강신청한 사람 아이디
        private string no;          //번호
        private string major;       //개설학과
        private string number;      //학수번호
        private string division;    //분반
        private string name;        //수업명
        private string completion;  //이수구분
        private string grade;       //학년
        private string credit;      //학점
        private string time;        //시간
        private string room;        //교실
        private string professor;   //교수님
        private string language;    //언어
        
        //get/set
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string No
        {
            get { return no; }
            set { no = value; }
        }
        public string Major
        {
            get { return major; }
            set { major = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Division
        {
            get { return division; }
            set { division = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Completion
        {
            get { return completion; }
            set { completion = value; }
        }
        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public string Credit
        {
            get { return credit; }
            set { credit = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Room
        {
            get { return room; }
            set { room = value; }
        }
        public string Professor
        {
            get { return professor; }
            set { professor = value; }
        }
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        public RegisterLectureVO() { }
        public RegisterLectureVO(string id, string no, string major, string number, string division, string name, string completion, string grade, string credit, string time, string room, string professor, string language)
        {
            Id = id;
            No = no;
            Major = major;
            Number = number;
            Division = division;
            Name = name;
            Completion = completion;
            Grade = grade;
            Credit = credit;
            Time = time;
            Room = room;
            Professor = professor;
            Language = language;
        }
    }
}
