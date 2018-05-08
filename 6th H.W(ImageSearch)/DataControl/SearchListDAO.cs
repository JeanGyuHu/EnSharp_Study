using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    class SearchListDAO
    {
        private string connectionInformation = "Server = localhost; Database = imagesearch;Uid=root;Pwd=123123;";     //DB에 연결할때 사용하는 DB 연결정보
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;
        private List<LogData> list;
        private LogData log;

        public SearchListDAO()
        {
            connection = new MySqlConnection(connectionInformation);
            list = new List<LogData>();
            log = new LogData();
        }

        public void InsertSearchInformation(string information,DateTime time)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "insert into information values(@info,@time)";
            command.Parameters.Add("@info", MySqlDbType.VarChar).Value = information;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = time.ToString("yyyy-MM-dd HH:mm:ss");

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteInformation()
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from information";

            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<LogData> SearchAll()
        {
            int count = 0;

            connection.Open();

            list.Clear();
            command = connection.CreateCommand();
            command.CommandText = "Select * from information";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                log = new LogData(reader.GetString(0), reader.GetDateTime(1));

                list.Add(log);
                count++;
            }
            connection.Close();

            if (count > 0)
                return list;
            else
                return null;
        }
    }
}
