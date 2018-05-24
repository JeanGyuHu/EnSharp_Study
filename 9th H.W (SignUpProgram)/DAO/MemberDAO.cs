using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_SignUp
{
    class MemberDAO
    {
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;

        public MemberDAO()
        {
            connection = new MySqlConnection(Constants.CONNECTIONINFORMATION);
        }

        public void AddMember(MemberVO member)
        {
            connection.Open();

            command = connection.CreateCommand();

            command.CommandText = "INSERT INTO member values(@id,@password,@name,@residentNumber,@addressNumber,@address,@addressDetail,@phoneNumber,@email)";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.Name;
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = member.ResidentNumber;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = member.Id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = member.Password;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.Address;
            command.Parameters.Add("@addressDetail", MySqlDbType.VarChar).Value = member.AddressDetail;
            command.Parameters.Add("@addressNumber", MySqlDbType.VarChar).Value = member.AddressNumber;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.Email;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 회원의 전화번호를 수정하는 역할을 한다.
        /// </summary>
        /// <param name="id">회원의 아이디</param>
        /// <param name="phone">수정할 전화번호</param>
        public void EditMemberInfo(MemberVO member)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE member SET password = @password, name = @name,residentNumber = @residentNumber, " +
                "addressNumber = @addressNumber,address = @address, addressdetail = @addressDetail,phoneNumber = @phoneNumber,email = @email where id = @id";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.Name;
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = member.ResidentNumber;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = member.Id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = member.Password;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.Address;
            command.Parameters.Add("@addressDetail", MySqlDbType.VarChar).Value = member.AddressDetail;
            command.Parameters.Add("@addressNumber", MySqlDbType.VarChar).Value = member.AddressNumber;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.Email;
            command.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// 회원을 삭제한다.
        /// </summary>
        /// <param name="id">삭제할 회원의 아이디</param>
        public void DeleteMember(string id)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from member where id = @id";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public MemberVO FindMember(string input,int mode)
        {
            MemberVO member = null;

            connection.Open();

            command = connection.CreateCommand();

            switch (mode)
            {
                case Constants.SEARCH_WITH_EMAIL:
                    command.CommandText = "select * from member where email = @email";
                    command.Parameters.Add("@email", MySqlDbType.VarChar).Value = input;
                    break;
                case Constants.SEARCH_WITH_ID:
                    command.CommandText = "select * from member where id = @id";
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = input;
                    break;
            }

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                member = new MemberVO();

                member.Id = reader.GetString(0);
                member.Password = reader.GetString(1);
                member.Name = reader.GetString(2);
                member.ResidentNumber = reader.GetString(3);
                member.AddressNumber = reader.GetString(4);
                member.Address = reader.GetString(5);
                member.AddressDetail = reader.GetString(6);
                member.PhoneNumber = reader.GetString(7);
                member.Email = reader.GetString(8);
            }

            reader.Close();
            connection.Close();


            if (member==null)
                return null;
            else
                return member;

        }

        public bool CheckId(string id)
        {
            bool isExist = false;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where id = @id";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                isExist = true;
            }

            reader.Close();
            connection.Close();

            if (isExist)
                return false;
            else
                return true;
        }

        public bool CheckEmail(string email)
        {
            bool LoginFlag = false;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where email = @email";
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
            

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                LoginFlag = true;
            }

            reader.Close();
            connection.Close();

            if (LoginFlag)
                return true;
            else
                return false;
        }

        public bool CheckResidentNumber(string residentNumber)
        {
            bool LoginFlag = false;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where residentNumber = @residentNumber";
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = residentNumber;


            reader = command.ExecuteReader();

            while (reader.Read())
            {
                LoginFlag = true;
            }

            reader.Close();
            connection.Close();

            if (LoginFlag)
                return true;
            else
                return false;
        }

        public bool CheckLogin(string id,string pw)
        {
            bool LoginFlag = false;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member where id = @id and password = @pw";
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@pw", MySqlDbType.VarChar).Value = pw;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                LoginFlag = true;
            }

            reader.Close();
            connection.Close();

            if (LoginFlag)
                return true;
            else
                return false;
        }
    }
}
