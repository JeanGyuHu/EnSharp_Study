using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class RentalData
    {
        private string bookNo;      //책 번호
        private string bookName;    //책 이름
        private string bookPbls;    //책 출판사
        private string bookAuthor;  //책 저자
        private string bookLender;  //책 대여자
        private DateTime bookReturnTime;    //반납일자
        private int extendCount;
        /// <summary>
        /// 책 번호에 대한 get/set
        /// </summary>
        public string BookNo
        {
            get { return this.bookNo; }
            set { this.bookNo = value; }
        }

        /// <summary>
        /// 책 이름에 대한 get/set
        /// </summary>
        public string BookName
        {
            get { return this.bookName; }
            set { this.bookName = value; }
        }

        /// <summary>
        /// 책 출판사에 대한 get/set
        /// </summary>
        public string BookPbls
        {
            get { return this.bookPbls; }
            set { this.bookPbls = value; }
        }
        /// <summary>
        /// 책 저자에 대한 get/set
        /// </summary>
        public string BookAuthor
        {
            get { return this.bookAuthor; }
            set { this.bookAuthor = value; }
        }
        /// <summary>
        /// 책 대여자에 대한 get/set
        /// </summary>
        public string BookLender
        {
            get { return this.bookLender; }
            set { this.bookLender = value; }
        }
        /// <summary>
        /// 반납 일자에 대한 get/set
        /// </summary>
        public DateTime BookReturnTime
        {
            get { return this.bookReturnTime; }
            set { bookReturnTime = value; }
        }

        public int ExtendCount
        {
            get { return this.extendCount; }
            set { extendCount = value; }
        }

        public RentalData() { }
        /// <summary>
        /// 대여자에 대한 정보가 들어왔을때 초기화 해주는 생성자
        /// </summary>
        /// <param name="no">입력 책 번호</param>
        /// <param name="name">입력 책 이름</param>
        /// <param name="pbls">입력 책 출판사</param>
        /// <param name="author">입력 책 저자</param>
        /// <param name="lender">입력 책 대여자</param>
        /// <param name="date">입력 책 반납일자</param>
        public RentalData(string no, string name, string pbls, string author, string lender, DateTime date, int extendCount)
        {
            BookNo = no;
            BookName = name;
            BookPbls = pbls;
            BookAuthor = author;
            BookLender = lender;
            BookReturnTime = date;
            ExtendCount = extendCount;
        }
    }
}
