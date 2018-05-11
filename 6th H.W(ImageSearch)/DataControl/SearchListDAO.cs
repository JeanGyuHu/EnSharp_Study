using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSearch
{
    class SearchListDAO
    {
        private MySqlConnection connection;     //DB에 연결할때 쓰이는 객체
        private MySqlCommand command;           //쿼리문을 실행해주는 객체
        private MySqlDataReader reader;         //select 할시에 정보를 읽어오기 위함
        private List<LogData> list;             //읽은 데이터를 받기 위한 리스트
        private LogData log;                    //로그 정보를 저장하기 위함

        /// <summary>
        /// 기본 생성자로써 각각의 객체를 생성, 초기화한다.
        /// </summary>
        public SearchListDAO()
        {
            connection = new MySqlConnection(Constants.CONNECTIONINFORMATION);
            list = new List<LogData>();
            log = new LogData();
        }

        /// <summary>
        /// 검색 결과에 대해서 저장한다.
        /// 만약에 이미 추가 되어있는 정보라면 지우고
        /// 새로 갱신한다.
        /// </summary>
        /// <param name="information">검색한 검색어</param>
        /// <param name="time">검색한 시간</param>
        public void InsertSearchInformation(string information,DateTime time)
        {
            if (IsAlreadyInList(information))
            {
                DeleteInformation("delete from information where info = \"" + information + "\";");
            }

            connection.Open();
            
            command = connection.CreateCommand();
            command.CommandText = "insert into information values(@info,@time)";
            command.Parameters.Add("@info", MySqlDbType.VarChar).Value = information;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = time.ToString("yyyy-MM-dd HH:mm:ss");

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 내가 검색한 검색어가 이미 있는지 없는지 체크해주는 메서드
        /// </summary>
        /// <param name="information">검색한 검색어</param>
        /// <returns>있는지 없는지 여부</returns>
        public bool IsAlreadyInList(string information)
        {
            int count = 0;

            connection.Open();

            list.Clear();
            command = connection.CreateCommand();
            command.CommandText = "Select * from information where info = @info";
            command.Parameters.Add("@info", MySqlDbType.VarChar).Value = information;

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                log = new LogData(reader.GetString(0), reader.GetDateTime(1));

                list.Add(log);
                count++;
            }
            connection.Close();

            if (count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 쿼리문을 인자로 받아서 그 쿼리문에 해당하는 삭제를 해주는 메서드
        /// </summary>
        /// <param name="quary">우리가 삭제하고자 하는 쿼리문</param>
        public void DeleteInformation(string quary)
        {
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = quary;

            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// 모든 정보에 대해서 확인 후 정보를
        /// List에 저장하여 반환
        /// </summary>
        /// <returns>데이터 베이스의 모든 정보</returns>
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
