using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class DBExceptionHandler
    {
        private MySqlConnection connection;             //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;                   //쿼리문을 실행해주는 객체
        private MySqlDataReader reader = null;            //실행을 통해서 읽어온 정보를 지닌 객체

        //기본 생성자로 connection을 localDB에 연결
        public DBExceptionHandler()
        {
            connection = new MySqlConnection(LibraryConstants.CONNECTIONINFORMATION);
        }

        /// <summary>
        /// 이미 있는 아이디인지 아닌지 체크해주는 메서드
        /// </summary>
        /// <param name="id">체크할 아이디</param>
        /// <returns>있는지 여부</returns>
        public bool IsIdInMemberDB(string id)
        {
            int num = 0;

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

        /// <summary>
        /// 비밀번호와 아이디가 일치하는지 체크
        /// </summary>
        /// <param name="id">아이디</param>
        /// <param name="password">비밀번호</param>
        /// <returns>있는지 여부</returns>
        public bool IsPasswordInMemberDB(string id, string password)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where id =@id and password = @password";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

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
        /// <summary>
        /// 있는책인지 없는책인지 체크해주는 메서드
        /// </summary>
        /// <param name="no">있는지 체크할 책의 번호</param>
        /// <returns>책의 존재 여부</returns>
        public bool IsInBookDB(string no)
        {
            int num = 0;

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

        /// <summary>
        /// 주민번호를 가진 사람이 있는지 없는지 여부를 체크한다
        /// </summary>
        /// <param name="residentNumber">확인할 주민번호</param>
        /// <returns>존재 여부</returns>
        public bool CheckResidentNumber(string residentNumber)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where residentNumber = @residentNumber";
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = residentNumber;

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

        /// <summary>
        /// 전화번호가 있는지 없는지 체크해주는 역할
        /// </summary>
        /// <param name="phone">확인할 전화번호</param>
        /// <returns>존재 여부</returns>
        public bool CheckPhoneNumber(string phone)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where phoneNumber = @phone";
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;

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
        /// <summary>
        /// 이미 대여를 한 책인지 아닌지 체크해주는 메서드
        /// </summary>
        /// <param name="id">대여하려는 사람의 아이디</param>
        /// <param name="no">대여하려고 하는 번호</param>
        /// <returns></returns>
        public bool IsInAlreadyRentDB(string id, string no)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from rentaldata where bookNo = @bookNo and bookLender = @bookLender";
            command.Parameters.Add("@bookNo", MySqlDbType.VarChar).Value = no;
            command.Parameters.Add("@bookLender", MySqlDbType.VarChar).Value = id;

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

        /// <summary>
        /// 관리자 아이디가 있는지 체크
        /// </summary>
        /// <param name="id">관리자 아이디</param>
        /// <returns>있는지 여부</returns>
        public bool CheckSuperviserID(string id)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from superviser where id = @id";
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

        /// <summary>
        /// 관리자 비밀번호가 있는지 여부
        /// </summary>
        /// <param name="id">입력 아이디</param>
        /// <param name="password">입력 비밀번호</param>
        /// <returns>존재 여부</returns>
        public bool CheckSuperviserPassword(string id, string password)
        {
            int num = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from superviser where id =@id and password = @password";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

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
