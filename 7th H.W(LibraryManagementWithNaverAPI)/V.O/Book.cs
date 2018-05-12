using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class Book
    {
        private string isbn;          //책 번호
        private string name;        //책 이름
        private int count;          //책 개수
        private string pbls;        //책 출판사
        private string author;      //책 저자
        private int price;
        private DateTime pblsDate;
        private string information;

        /// <summary>
        /// 책 번호에 대한 get/set
        /// </summary>
        public string Isbn
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }
        /// <summary>
        /// 책 이름에 대한 get/set
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        /// <summary>
        /// 책 개수에 대한 get/set
        /// </summary>
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        /// <summary>
        /// 책 출판사에 대한 get/set
        /// </summary>
        public string Pbls
        {
            get { return this.pbls; }
            set { this.pbls = value; }
        }
        /// <summary>
        /// 책 저자에 대한 get/set
        /// </summary>
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public DateTime PblsDate
        {
            get { return pblsDate; }
            set { pblsDate = value; }
        }

        public string Information
        {
            get { return information; }
            set { information = value; }
        }
        public Book() { }
        /// <summary>
        /// 생성자로써 모든 정보가 들어왔을때 모두다 값을 변경해준다.
        /// </summary>
        /// <param name="isbn">입력 책 번호</param>
        /// <param name="name">입력 책 이름</param>
        /// <param name="count">입력 책 개수</param>
        /// <param name="pbls">입력 책 출판사</param>
        /// <param name="author">입력 책 저자</param>
        public Book(string isbn, string name, int count, string pbls, string author, int price,DateTime pblsDate,string information)
        {
            Isbn = isbn;
            Name = name;
            Count = count;
            Pbls = pbls;
            Author = author;
            Price = price;
            PblsDate = pblsDate;
            Information = information;
        }
    }
}
