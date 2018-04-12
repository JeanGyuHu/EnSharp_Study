using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class RentalData
    {
        private string bookNo;
        private string bookName;
        private string bookPbls;
        private string bookAuthor;
        private string bookLender;
        private DateTime bookReturnTime;

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
        public string BookLender
        {
            get { return this.bookLender; }
            set { this.bookLender = value; }
        }
        public DateTime BookReturnTime
        {
            get { return this.bookReturnTime; }
            set { bookReturnTime = value; }
        }

        public RentalData(string no, string name, string pbls, string author,string lender,DateTime date)
        {
            BookNo = no;
            BookName = name;
            BookPbls = pbls;
            BookAuthor = author;
            BookLender = lender;
            BookReturnTime = date;
        }
    }
}
