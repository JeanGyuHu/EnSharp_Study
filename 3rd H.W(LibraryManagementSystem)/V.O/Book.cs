using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class Book
    {
        private string bookNo;          //책 번호
        private string bookName;        //책 이름
        private int bookCount;          //책 개수
        private string bookPbls;        //책 출판사
        private string bookAuthor;      //책 저자
        
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
        /// 책 개수에 대한 get/set
        /// </summary>
        public int BookCount
        {
            get { return this.bookCount; }
            set { this.bookCount = value; }
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
        /// 생성자로써 모든 정보가 들어왔을때 모두다 값을 변경해준다.
        /// </summary>
        /// <param name="no">입력 책 번호</param>
        /// <param name="name">입력 책 이름</param>
        /// <param name="count">입력 책 개수</param>
        /// <param name="pbls">입력 책 출판사</param>
        /// <param name="author">입력 책 저자</param>
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
