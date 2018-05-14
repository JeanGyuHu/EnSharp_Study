using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

        /// <summary>
        /// 로그 정보를 전부 띄워주는 메서드
        /// </summary>
        public void CheckLog()
        {
            connection.Open();          //연결

            command = connection.CreateCommand();
            command.CommandText = "select * from logdata;";    //SQL문 생성

            reader = command.ExecuteReader();  //DB에 SQL문 실행

            Console.Clear();
            while (reader.Read())
            {
                Console.WriteLine("\n======================================================================================================================================================");
                Console.WriteLine("검색 시간 : "+reader.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("정 보 :" + reader.GetString(1));
                Console.WriteLine("모 드 :" + reader.GetString(2));
                Console.WriteLine("======================================================================================================================================================");
            }

            connection.Close();     //연결해제

            Console.Write("PRESS ANY KEY. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// 텍스트 파일에 로그 정보 전부 데이터 베이스에서 불러와서 저장하기
        /// </summary>
        public void SaveInTextFile()
        {
            connection.Open();          //연결

            command = connection.CreateCommand();
            command.CommandText = "select * from logdata;";    //SQL문 생성

            reader = command.ExecuteReader();  //DB에 SQL문 실행

            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            File.WriteAllText(savePath,"로 그 정 보\r\n",Encoding.Default);

            while (reader.Read())
            {
                File.AppendAllText(savePath, "\r\n======================================================================================================================================================",Encoding.Default);
                File.AppendAllText(savePath, "\r\n검색 시간 : " + reader.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss"), Encoding.Default);
                File.AppendAllText(savePath, "\r\n정 보 :" + reader.GetString(1), Encoding.Default);
                File.AppendAllText(savePath, "\r\n모 드 :" + reader.GetString(2), Encoding.Default);
                File.AppendAllText(savePath, "\r\n======================================================================================================================================================", Encoding.Default);
            }

            connection.Close();     //연결해제

            Console.Write("저장 성공. . .");
            Console.ReadKey();
        }

        /// <summary>
        /// 로그 데이터 초기화
        /// </summary>
        public void DeleteTextFile()
        {
            FileInfo fileDel = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            if (fileDel.Exists) //삭제할 파일이 있는지
            {
                fileDel.Delete(); //없어도 에러안남
            }
        }
    }
}
