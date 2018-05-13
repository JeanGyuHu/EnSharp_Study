using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManagementWithNaverAPI
{
    class RentalDataDAO
    {
        private MySqlConnection connection;         //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;               //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;             //실행을 통해서 읽어온 정보를 지닌 객체
        private RentalData rentalData;              //데이터베이스의 정보를 가져오기 위한 객체

        //기본 생성자로 connection을 localDB에 연결
        public RentalDataDAO()
        {
            connection = new MySqlConnection(LibraryConstants.CONNECTIONINFORMATION);
        }

        /// <summary>
        /// 매개변수로 넘어온 데이터를 가진 대여데이터를 만든다.
        /// </summary>
        /// <param name="rentalData">대여정보가 담겨있는 VO</param>
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

        /// <summary>
        /// 데이터베이스에 저장된 대여정보를 가져온다.
        /// </summary>
        /// <param name="id">가져올 정보의 아이디</param>
        /// <param name="no">가져올 정보의 no</param>
        /// <returns></returns>
        public RentalData GetRentalData(string id, string no)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Select * from rentaldata where bookLender = @id and isbn = @no";
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

        /// <summary>
        /// 시간 연장을 한 후에 정보를 저장하는 기능을 한다.
        /// </summary>
        /// <param name="id">시간 연장할 아이디</param>
        /// <param name="no">시간 연장할 책</param>
        /// <param name="dateTime">연장할 시간</param>
        /// <param name="count">몇번 연장을 했는지</param>
        public void ChangeInformationAfterExtendTime(string id, string no, DateTime dateTime, int count)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "UPDATE rentaldata SET returnDate=@dateTime, extendCount = @count where bookLender = @id and isbn = @no";
            command.Parameters.Add("@dateTime", MySqlDbType.VarChar).Value = dateTime.ToString("yyyy-MM-dd");
            command.Parameters.Add("@count", MySqlDbType.VarChar).Value = count;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@no", MySqlDbType.VarChar).Value = no;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 책을 반납한 후에 데이터 변화를 저장해주는 메서드
        /// </summary>
        /// <param name="id">반납한 사람 아이디</param>
        /// <param name="no">반납한 책 번호</param>
        public void ChangeAfterReturnBook(string id, string no)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "Delete from rentalData where isbn = @bookNo and bookLender = @id";
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
                Console.WriteLine("   " + ConvertLength(reader.GetString(0), 15) + ConvertLength(reader.GetString(1), 20) + ConvertLength(reader.GetString(2), 20) + ConvertLength(reader.GetString(3), 15) + ConvertLength(reader.GetString(4), 20) + ConvertLength(reader.GetDateTime(5).ToString("yyyy-MM-dd"), 15));
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
