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
            command.CommandText = "INSERT INTO member values(@name,@residentNumber,@id,@password,@phoneNumber,@address,@email)";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.Name;
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = member.ResidentNumber;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = member.Id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = member.Password;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.Address;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = member.Email;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 회원의 전화번호를 수정하는 역할을 한다.
        /// </summary>
        /// <param name="id">회원의 아이디</param>
        /// <param name="phone">수정할 전화번호</param>
        public void EditMemberPhone(string id, string phone)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE member SET phoneNumber =@phone where id = @id";
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

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
    }
}
