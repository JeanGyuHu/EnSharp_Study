using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class DatabaseException
    {
        private string connectionInformation = "Server = localhost; Database = ensharpdb;Uid=root;Pwd=123123;";
        private MySqlConnection connection;
        private string sql;
        private MySqlCommand command;
        private MySqlDataReader reader=null;

        public DatabaseException()
        {
            connection = new MySqlConnection(connectionInformation);
        }

        public bool IsInMemberDB(string id)
        {
            int num=0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where id = @id";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                num++;
            }
            connection.Close();

            if (num > 0) 
                return false;
            else
                return true;
        }

        public bool IsInBookDB(string no)
        {
            int num=0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from book where no = @no";
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            reader = command.ExecuteReader();
            

            while (reader.Read())
            {
                num++;
            }
            connection.Close();

            if (num > 0)
                return false;
            else
                return true;
        }
    }
}
