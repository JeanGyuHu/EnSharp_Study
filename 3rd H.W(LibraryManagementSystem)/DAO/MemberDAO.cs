using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace EnSharp_day3
{
    class MemberDAO
    {
        private string connectionInformation = "Server = localhost; Database = ensharpdb;Uid=root;Pwd=123123;";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public MemberDAO()
        {
            connection = new MySqlConnection(connectionInformation);
        }

        public void AddMember(Member member)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO member values(@name,@residentNumber,@id,@password,@phoneNumber,@address)";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value= member.Name;
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = member.ResidentNum;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = member.Id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = member.Password;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.Address;


            command.ExecuteNonQuery();
            connection.Close();
        }

        public void EditMemberInformation(string id,string phone,string address)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE member SET phoneNumber =@phone, address = @address where id = @id";
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteMember(string id)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from member where id = @id";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

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
                Console.WriteLine(reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5));
            }
            connection.Close();
        }

        public void SearchAll()
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5));
            }
            connection.Close();
        }
    }
}
