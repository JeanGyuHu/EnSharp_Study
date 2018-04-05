using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Book
    {
        private string bookNo;
        private string bookName;
        private string bookNum;
        private string bookPbls;
        private string bookAuthor;
        
        public string BookNo
        {
            get { return bookNo; }
            set { bookNo = value; }
        }
        
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string BookNum
        {
            get { return bookNum; }
            set { bookNum = value; }
        }
        
        public string BookPbls
        {
            get { return BookPbls; }
            set { bookPbls = value; }
        }
        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        public Book(string no,string name,string num,string pbls,string author)
        {
            BookNo = no;
            BookName = name;
            BookNum = num;
            BookPbls = pbls;
            BookAuthor = author;
        }
    }
}
