using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class BookDAO
    {
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;         //실행을 통해서 읽어온 정보를 지닌 객체
        private List<Book> list;
        //기본 생성자로 connection을 localDB에 연결
        public BookDAO()
        {
            connection = new MySqlConnection(LibraryConstants.CONNECTIONINFORMATION);
            list = new List<Book>();
        }


        public void AddBook(Book book)
        {
            connection.Open();          //연결

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO book values(@no,@name,@count,@publisher,@author,@price,@date,@information)";    //SQL문 생성
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = book.Isbn;             //각각에 대한 정보 대입
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = book.Name;
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = book.Count;
            command.Parameters.Add("@publisher", MySqlDbType.VarChar).Value = book.Pbls;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = book.Author;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = book.Price;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = book.PblsDate.ToString("yyyy-MM-dd"); 
            command.Parameters.Add("@information", MySqlDbType.VarChar).Value = book.Information;

            command.ExecuteNonQuery();  //DB에 SQL문 실행
            connection.Close();     //연결해제
        }

        /// <summary>
        /// 해당 no 값을 가진 책에 대한 정보를 return 해주는 메소드
        /// </summary>
        /// <param name="no">찾고자하는 책의 no값</param>
        /// <returns>no 값을 가진 책의 모든 정보</returns>
        public Book GetBook(string no)
        {
            int count = 0;
            Book book = new Book();

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from book where isbn = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            reader = command.ExecuteReader();

            while (reader.Read())   //쿼리문을 수행한 정보들에 대해서
            {
                book = new Book(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5),reader.GetDateTime(6),reader.GetString(7),++count);  //
            }
            connection.Close();

            return book;
        }
        /// <summary>
        /// no의 값을 가진 책을 삭제한다.
        /// </summary>
        /// <param name="no">삭제할 책의 no</param>
        /// <returns>성공 여부</returns>
        public bool DeleteBook(string no)
        {
            int result = 0;
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from book where isbn = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            result = command.ExecuteNonQuery();
            connection.Close();

            if (result == -1)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 책의 수량을 수정해준다.
        /// </summary>
        /// <param name="no">수정할 책의 no</param>
        /// <param name="count">수정할 수량</param>
        public void EditBookCount(string no, int count)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE book SET count =@count where isbn = @no";
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = count;
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 책의 가격을 수정해준다.
        /// </summary>
        /// <param name="no">수정할 책의 no</param>
        /// <param name="price">수정할 가격</param>
        public void EditBookPrice(string no, int price)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE book SET price = @price where isbn = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 인자로 받아온 SQL문으로 검색한다.
        /// </summary>
        /// <param name="quary">검색 SQL 문</param>
        public void SearchWithQuary(string quary)
        {
            int count = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = quary;

            reader = command.ExecuteReader();

            Console.Clear();

            while (reader.Read())
            {
                Console.WriteLine("\n======================================================================================================================================================");
                Console.WriteLine("제목     : {0}", reader.GetString(1));
                Console.WriteLine("저자     : {0}", reader.GetString(4));
                Console.WriteLine("가격     : {0}", reader.GetInt32(5).ToString().Insert(reader.GetInt32(5).ToString().Length, "원"));
                Console.WriteLine("출판사   : {0}", reader.GetString(3));
                Console.WriteLine("출판날짜 : {0}", reader.GetDateTime(6).ToString("yyyy-MM-dd"));
                Console.WriteLine("수량     : {0}", reader.GetInt32(2));
                Console.WriteLine("ISBN     : {0}", reader.GetString(0));
                Console.WriteLine("책 설명  : {0}", reader.GetString(7));
                Console.WriteLine("======================================================================================================================================================");

                count++;
            }
            if (count.Equals(0))
                Console.WriteLine("\n\n검색 결과가 없습니다.");
            connection.Close();
        }

        /// <summary>
        /// 모든 책 정보를 출력한다.
        /// </summary>
        public List<Book> SearchAll()
        {
            list.Clear();
            int count = 0;
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from book";

            reader = command.ExecuteReader();

            Console.Clear();

            while (reader.Read())
            {
                list.Add(new Book(reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetDateTime(6), reader.GetString(7), ++count));

                Console.WriteLine("\n======================================================================================================================================================");
                Console.WriteLine("번호     : {0}", count);
                Console.WriteLine("제목     : {0}", reader.GetString(1));
                Console.WriteLine("저자     : {0}", reader.GetString(4));
                Console.WriteLine("가격     : {0}", reader.GetInt32(5).ToString().Insert(reader.GetInt32(5).ToString().Length, "원"));
                Console.WriteLine("출판사   : {0}", reader.GetString(3));
                Console.WriteLine("출판날짜 : {0}", reader.GetDateTime(6).ToString("yyyy-MM-dd"));
                Console.WriteLine("수량     : {0}", reader.GetInt32(2));
                Console.WriteLine("ISBN     : {0}", reader.GetString(0));
                Console.WriteLine("책 설명  : {0}", reader.GetString(7));
                Console.WriteLine("======================================================================================================================================================");
            }
            connection.Close();

            return list;
        }
    }
}
