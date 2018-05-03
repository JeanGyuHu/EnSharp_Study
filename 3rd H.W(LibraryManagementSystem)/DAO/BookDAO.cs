using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{

    class BookDAO
    {
        private string connectionInformation = "Server = localhost; Database = ensharpdb;Uid=root;Pwd=123123;";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public BookDAO()
        {
            connection = new MySqlConnection(connectionInformation);
        }

        public void AddBook(Book book)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO book values(@no,@name,@count,@publisher,@author,@price)";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = book.No;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = book.Name;
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = book.Count;
            command.Parameters.Add("@publisher", MySqlDbType.VarChar).Value = book.Pbls;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = book.Author;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = book.Price;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public Book GetBook(string no)
        {
            Book book = new Book();

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from book where no = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
               book = new Book(reader.GetString(0) , reader.GetString(1) , reader.GetInt32(2) , reader.GetString(3) , reader.GetString(4),reader.GetInt32(5));
            }
            connection.Close();

            return book;
        }
        public bool DeleteBook(string no)
        {
            int result=0;
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from book where no = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            result = command.ExecuteNonQuery();
            connection.Close();

            if (result == -1)
                return false;
            else
                return true;
        }

        public void EditBookInformation(string no, int count,int price)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE book SET count =@count, price = @price where no = @no";
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = count;
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void SearchWithQuary(string quary)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = quary;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("   " + ConvertLength(reader.GetString(0), 15) + ConvertLength(reader.GetString(1), 22) + ConvertLength(reader.GetInt32(2).ToString(), 8) + ConvertLength(reader.GetString(3), 23) + ConvertLength(reader.GetString(4), 18) + ConvertLength(reader.GetInt32(5).ToString(), 13) + "원");
            }
            connection.Close();
        }

        public void SearchAll()
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from book";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("   "+ConvertLength(reader.GetString(0),15) + ConvertLength(reader.GetString(1),22) + ConvertLength(reader.GetInt32(2).ToString(),8) + ConvertLength(reader.GetString(3),23) + ConvertLength(reader.GetString(4),18) + ConvertLength(reader.GetInt32(5).ToString().Insert(reader.GetInt32(5).ToString().Length,"원"), 13));
            }
            connection.Close();
        }

        public string ConvertLength(string inputString, int length)
        {
            byte[] byteName1 = Encoding.Default.GetBytes(inputString + "                                                                                ");
            byte[] byteName2 = new byte[length];
            Array.Copy(byteName1, byteName2, length);

            return Encoding.Default.GetString(byteName2);
        }
    }
}
