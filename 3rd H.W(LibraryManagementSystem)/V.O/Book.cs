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
        private int bookCount;
        private string bookPbls;
        private string bookAuthor;
        
        public string BookNo
        {
            get { return this.bookNo; }
            set { this.bookNo = value; }
        }
        
        public string BookName
        {
            get { return this.bookName; }
            set { this.bookName = value; }
        }

        public int BookCount
        {
            get { return this.bookCount; }
            set { this.bookCount = value; }
        }
        
        public string BookPbls
        {
            get { return this.bookPbls; }
            set { this.bookPbls = value; }
        }
        public string BookAuthor
        {
            get { return this.bookAuthor; }
            set { this.bookAuthor = value; }
        }

        public Book(string no,string name,int count,string pbls,string author)
        {
            BookNo = no;
            BookName = name;
            BookCount = count;
            BookPbls = pbls;
            BookAuthor = author;
        }
    }
}
