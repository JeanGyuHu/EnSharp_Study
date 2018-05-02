using MySql.Data.MySqlClient;
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

        public RentalDataDAO()
        {
            connection = new MySqlConnection(connectionInformation);
        }

        public void ChangeInformationAfterRent(RentalData rentalData)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO rentaldata values(@no,@name,@publisher,@Author,@Lender,@Date,@extendCount)";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = rentalData.BookNo;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = rentalData.BookName;
            command.Parameters.Add("@publisher", MySqlDbType.VarChar).Value = rentalData.BookPbls;
            command.Parameters.Add("@Author", MySqlDbType.VarChar).Value = rentalData.BookAuthor;
            command.Parameters.Add("@Lender", MySqlDbType.VarChar).Value = rentalData.BookLender;
            command.Parameters.Add("@Date", MySqlDbType.VarChar).Value = rentalData.BookReturnTime;
            command.Parameters.Add("extendCount", MySqlDbType.VarChar).Value = rentalData.ExtendCount;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ChangeInformationAfterExtendTime()
        {

        }
    }
}
