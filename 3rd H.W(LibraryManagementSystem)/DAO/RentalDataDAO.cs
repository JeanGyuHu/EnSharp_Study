﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class RentalDataDAO
    {
        private string connectionInformation = "Server = localhost; Database = ensharpdb;Uid=root;Pwd=123123;";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private RentalData rentalData;

        public RentalDataDAO()
        {
            connection = new MySqlConnection(connectionInformation);
        }
       
        public void AddAfterRent(RentalData rentalData)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO rentaldata values(@no,@name,@publisher,@Author,@Lender,@Date,@extendCount)";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = rentalData.BookNo;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = rentalData.BookName;
            command.Parameters.Add("@publisher", MySqlDbType.VarChar).Value = rentalData.BookPbls;
            command.Parameters.Add("@Author", MySqlDbType.VarChar).Value = rentalData.BookAuthor;
            command.Parameters.Add("@Lender", MySqlDbType.VarChar).Value = rentalData.BookLender;
            command.Parameters.Add("@Date", MySqlDbType.VarChar).Value = rentalData.BookReturnTime.ToString("yyyy-MM-dd");
            command.Parameters.Add("extendCount", MySqlDbType.VarChar).Value = rentalData.ExtendCount;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public RentalData GetRentalData(string id,string no)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Select * from rentaldata where bookLender = @id and bookNo = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                rentalData = new RentalData(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetDateTime(5), reader.GetInt32(6));
            }
            connection.Close();

            return rentalData;
        }

        public void ChangeInformationAfterExtendTime(string id,string no,DateTime dateTime,int count)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE rentaldata SET returnDate=@dateTime, extendCount = @count where bookLender = @id and bookNo = @no";
            command.Parameters.Add("@dateTime", MySqlDbType.VarChar).Value = dateTime.ToString("yyyy-MM-dd");
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = count;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeAfterReturnBook(string id,string no)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from rentalData where bookNo = @bookNo and bookLender = @id";
            command.Parameters.Add("@bookNo", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void SearchAll()
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Select * from rentaldata";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("   "+ConvertLength(reader.GetString(0),15)+ ConvertLength(reader.GetString(1),20)+ ConvertLength(reader.GetString(2),20)+ ConvertLength(reader.GetString(3),15)+ ConvertLength(reader.GetString(4),20)+ ConvertLength(reader.GetDateTime(5).ToString("yyyy-MM-dd"),15));
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
