using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class LogDAO
    {
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;         //실행을 통해서 읽어온 정보를 지닌 객체

        public LogDAO()
        {
            connection = new MySqlConnection(LibraryConstants.CONNECTIONINFORMATION);
        }

        public void AddLog(DateTime time,string info,string mode)
        {
            connection.Open();          //연결

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO logdata values(@time,@info,@mode)";    //SQL문 생성
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = time.ToString("yyyy-MM-dd HH:mm:ss");
            command.Parameters.Add("@info", MySqlDbType.VarChar).Value = info;
            command.Parameters.Add("@mode", MySqlDbType.VarChar).Value = mode;

            command.ExecuteNonQuery();  //DB에 SQL문 실행
            connection.Close();     //연결해제
        }

        public void DeleteAllLog()
        {
            connection.Open();          //연결

            command = connection.CreateCommand();
            command.CommandText = "delete from logdata;";    //SQL문 생성

            command.ExecuteNonQuery();  //DB에 SQL문 실행
            connection.Close();     //연결해제
        }
    }
}
