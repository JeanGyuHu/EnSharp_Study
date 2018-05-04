using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class InterestLectureVO
    {
        private string id;
        private string no;
        private string major;
        private string number;
        private string division;
        private string name;
        private string completion;
        private string grade;
        private string credit;
        private string time;
        private string room;
        private string professor;
        private string language;

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
        public InterestLectureVO() {}
        public InterestLectureVO(string id,string no,string major,string number,string division,string name,string completion,string grade,string credit,string time,string room,string professor,string language)
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
