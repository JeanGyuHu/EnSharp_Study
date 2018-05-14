using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class MemberDAO
    {
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;         //실행을 통해서 읽어온 정보를 지닌 객체

        //기본 생성자로 connection을 localDB에 연결
        public MemberDAO()
        {
            connection = new MySqlConnection(LibraryConstants.CONNECTIONINFORMATION);
        }
        /// <summary>
        /// Member Table에 넘어온 member VO에 담겨있는 정보를 저장한다.
        /// </summary>
        /// <param name="member">저장할 정보가 담겨있는 VO</param>
        public void AddMember(Member member)
        {
            int age = 0;
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO member values(@name,@residentNumber,@id,@password,@phoneNumber,@address,@age)";
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.Name;
            command.Parameters.Add("@residentNumber", MySqlDbType.VarChar).Value = member.ResidentNum;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = member.Id;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = member.Password;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = member.PhoneNumber;
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = member.Address;

            if (member.ResidentNum[7].Equals('1') || member.ResidentNum[7].Equals('2'))             //주민번호 뒷자리가 1이나 2로 시작하면 2000년도 이전 년생이므로 따로 계산
            {
                age = 100 + Convert.ToInt32(DateTime.Now.Year) % 100 - Convert.ToInt32(member.ResidentNum.Substring(0, 2)) + 1;
            }

            if (member.ResidentNum[7].Equals('3') || member.ResidentNum[7].Equals('4'))             //주민번호 뒷자리가 3이나 4 로 시작하면 2000년도 이후 년생이므로 따로 계산
            {
                age = Convert.ToInt32(DateTime.Now.Year) % 100 - Convert.ToInt32(member.ResidentNum.Substring(0, 2)) + 1;
            }

            command.Parameters.Add("@age", MySqlDbType.VarChar).Value = age;

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
        /// 회원의 주소를 수정하는 역할을 한다.
        /// </summary>
        /// <param name="id">회원의 아이디</param>
        /// <param name="address">수정할 주소</param>
        public void EditMemberAddress(string id, string address)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE member SET address = @address where id = @id";
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
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

        /// <summary>
        /// 매개변수로 들어온 쿼리문을 활용하여 검색한다.
        /// </summary>
        /// <param name="quary">SQL문</param>
        public void SearchWithQuary(string quary)
        {
            int count = 0;

            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = quary;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("   " + ConvertLength(reader.GetString(0), 13) + ConvertLength(reader.GetString(1), 21) + ConvertLength(reader.GetString(2), 27) + ConvertLength(reader.GetString(3), 21) + ConvertLength(reader.GetString(4), 20) + ConvertLength(reader.GetString(5), 28) + ConvertLength(reader.GetInt32(6).ToString(), 5));
                count++;
            }
            connection.Close();

            if (count.Equals(0))
                Console.WriteLine("\n\n\t\t\t검색 결과가 없습니다.");
        }

        /// <summary>
        /// 모든 회원정보를 출력한다.
        /// </summary>
        public void SearchAll()
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select * from member";

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("   " + ConvertLength(reader.GetString(0), 13) + ConvertLength(reader.GetString(1), 21) + ConvertLength(reader.GetString(2), 27) + ConvertLength(reader.GetString(3), 21) + ConvertLength(reader.GetString(4), 20) + ConvertLength(reader.GetString(5), 28) + ConvertLength(reader.GetInt32(6).ToString(), 5));
            }
            connection.Close();
        }

        /// <summary>
        /// 인자로 넘어온 문자열을 원하는 길이로 만들어준다.
        /// </summary>
        /// <param name="inputString">길이를 변경하고 싶은 문자열</param>
        /// <param name="length">원하는 길이</param>
        /// <returns>길이가 변환된 문자열</returns>
        public string ConvertLength(string inputString, int length)
        {
            byte[] byteName1 = Encoding.Default.GetBytes(inputString + "                                                                                ");
            byte[] byteName2 = new byte[length];
            Array.Copy(byteName1, byteName2, length);

            return Encoding.Default.GetString(byteName2);
        }
    }
}
