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
            command.CommandText = "INSERT INTO book values(@no,@name,@count,@publisher,@author)";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = book.No;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = book.Name;
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = book.Count;
            command.Parameters.Add("@publisher", MySqlDbType.VarChar).Value = book.Pbls;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = book.Author;

            command.ExecuteNonQuery();
            connection.Close();
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
                return true;
            else
                return false;
        }

        public void EditBookInformation(string no, int count)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE book SET count =@count where no = @no";
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = count;
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

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
                Console.WriteLine(reader.GetString(0) + reader.GetString(1) + reader.GetInt32(2) + reader.GetString(3) + reader.GetString(4));
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
                Console.WriteLine(reader.GetString(0) + reader.GetString(1) + reader.GetInt32(2) + reader.GetString(3) + reader.GetString(4));
            }
            connection.Close();
        }
    }
}
