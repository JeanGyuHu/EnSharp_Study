using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class TimeTable
    {
        DrawUI drawUI;  //출력을 담당하는 메서드
        Object[,] table;//시간표를 가지고 있는 

        /// <summary>
        /// 기본 생성자로써 객체를 초기화 해준다
        /// </summary>
        public TimeTable()
        {
            drawUI = new DrawUI();
            table = new Object[25, 6] { {"","월", "화", "수", "목", "금" },  //시간표 배열!
                                        {"09:00~09:30","","","","","" },
                                        {"09:30~10:00","","","","","" },
                                        {"10:00~10:30","","","","","" },
                                        {"10:30~11:00","","","","","" },
                                        {"11:00~11:30","","","","","" },
                                        {"11:30~12:00","","","","","" },
                                        {"12:00~12:30","","","","","" },
                                        {"12:30~13:00","","","","","" },
                                        {"13:00~13:30","","","","","" },
                                        {"13:30~14:00" ,"","","","",""},
                                        {"14:00~14:30" ,"","","","",""},
                                        {"14:30~15:00" ,"","","","",""},
                                        {"15:00~15:30" ,"","","","",""},
                                        {"15:30~16:00" ,"","","","",""},
                                        {"16:00~16:30" ,"","","","",""},
                                        {"16:30~17:00" ,"","","","",""},
                                        {"17:00~17:30" ,"","","","",""},
                                        {"17:30~18:00" ,"","","","",""},
                                        {"18:00~18:30" ,"","","","",""},
                                        {"18:30~19:00" ,"","","","",""},
                                        {"19:00~19:30" ,"","","","",""},
                                        {"19:30~20:00" ,"","","","",""},
                                        {"20:00~20:30" ,"","","","",""},
                                        {"20:30~21:00" ,"","","","",""}};

        }

        public Object[,] GetTimeTable() { return table; }   //get 메서드


        /// <summary>
        /// 시간표를 만드는 메서드
        /// </summary>
        /// <param name="dataControl">데이터 정보를 관리해주는 객체</param>
        /// <param name="id">현 사용자 아이디</param>
        /// <param name="mode">console 출력을 할 것인지, 아님 액셀 파일을 위해 배열에 저장을 할것인지</param>
        public void MakeTimeTable(DataControl dataControl, string id, string mode)
        {
            List<RegisterLectureVO> list = dataControl.GetRegisterList();

            if (mode.Equals(TimeTableConstants.CONSOLE))
                drawUI.TimeTableOutline();

            //CheckDataLength("월13:30-14:30", "데이터베이스", "율202","1");
            //CheckDataLength("화목14:00-16:00", "운영체제", "율204","1");
            //CheckDataLength("수금15:00-16:30,화18:00-20:00", "자료구조", "율404","1");

            //CheckDataLength("월13:30-14:30", "데이터베이스", "율202", "2");
            //CheckDataLength("화목14:00-16:00", "운영체제", "율204", "2");
            //CheckDataLength("수금15:00-16:30,화18:00-20:00", "자료구조", "율404", "2");

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Id.Equals(id))
                {
                    CheckDataLength(list[index].Time, list[index].Name, list[index].Room,mode);
                }
            }
            Console.SetCursorPosition(5, 26);
        }


        /// <summary>
        /// 시간에 대한 정보를 길이에 따라 분류하고, 무슨 요일에 하는지, 몇시간 하는지 체크한다.
        /// </summary>
        /// <param name="time">수강신청한 과목의 수업시간</param>
        /// <param name="name">과목명</param>
        /// <param name="room">수업 장소</param>
        /// <param name="mode">console 출력인지, Excel저장인지</param>
        public void CheckDataLength(string time, string name, string room,string mode)
        {
            string startHour, startMinute, finishHour, finishMinute,secondStartHour,secondStartMinute,secondFinishHour,secondFinishMinute;

            if (time.Length.Equals(12))     //12글자일때
            {

                startHour = time.Substring(1, 2);
                startMinute = time.Substring(4, 2);

                finishHour = time.Substring(7, 2);
                finishMinute = time.Substring(10, 2);

                int count = 0;

                count = Convert.ToInt32(finishHour) - Convert.ToInt32(startHour);
                count = 2 * count;

                if (!startMinute.Equals(finishMinute))
                    count++;

                switch (mode)
                {
                    case TimeTableConstants.CONSOLE:
                DrawInTimeTable(CheckPositionLeft(time[0].ToString()), CheckPositionTop(time.Substring(1, 5)), count, name, room);
                        break;
                    case TimeTableConstants.EXCEL:
                        SaveData(CheckDayPosition(time[0].ToString()),CheckPositionTop(time.Substring(1,5))-2,count,name,room);
                        break;
                }
            }
            else if (time.Length.Equals(13))        //13글자일때
            {
                startHour = time.Substring(2, 2);
                startMinute = time.Substring(5, 2);

                finishHour = time.Substring(8, 2);
                finishMinute = time.Substring(11, 2);

                int count = 0;

                count = Convert.ToInt32(finishHour) - Convert.ToInt32(startHour);
                count = 2 * count;

                if (!startMinute.Equals(finishMinute))
                    count++;
                switch (mode)
                {
                    case TimeTableConstants.CONSOLE:
                        DrawInTimeTable(CheckPositionLeft(time[0].ToString()), CheckPositionTop(time.Substring(2, 5)), count, name, room);
                        DrawInTimeTable(CheckPositionLeft(time[1].ToString()), CheckPositionTop(time.Substring(2, 5)), count, name, room);
                        break;
                    case TimeTableConstants.EXCEL:
                        SaveData(CheckDayPosition(time[0].ToString()), CheckPositionTop(time.Substring(2, 5))-2, count, name, room);
                        SaveData(CheckDayPosition(time[1].ToString()), CheckPositionTop(time.Substring(2, 5))-2, count, name, room);
                        break;
                }
                
            }
            else if (time.Length.Equals(26))    //26글자일때
            {
                startHour = time.Substring(2, 2);
                startMinute = time.Substring(5, 2);

                finishHour = time.Substring(8, 2);
                finishMinute = time.Substring(11, 2);

                secondStartHour = time.Substring(15,2);
                secondStartMinute = time.Substring(18, 2);

                secondFinishHour = time.Substring(21, 2);
                secondFinishMinute = time.Substring(24, 2);

                int firstCount = 0, secondCount = 0; ;

                firstCount = Convert.ToInt32(finishHour) - Convert.ToInt32(startHour);
                firstCount = 2 * firstCount;

                if (!startMinute.Equals(finishMinute)&&firstCount.Equals(1))
                    firstCount++;
                if (!startMinute.Equals(finishMinute) && firstCount.Equals(4))
                    firstCount--;

                    secondCount = Convert.ToInt32(secondFinishHour) - Convert.ToInt32(secondStartHour);
                secondCount = 2 * secondCount;

                if (!secondStartMinute.Equals(secondFinishMinute)&&firstCount.Equals(1))
                    secondCount++;
                if (!secondStartMinute.Equals(secondFinishMinute) && firstCount.Equals(4))
                    secondCount--;

                    switch (mode)
                {
                    case TimeTableConstants.CONSOLE:
                        DrawInTimeTable(CheckPositionLeft(time[0].ToString()), CheckPositionTop(time.Substring(2, 5)), firstCount, name, room);
                        DrawInTimeTable(CheckPositionLeft(time[1].ToString()), CheckPositionTop(time.Substring(2, 5)), firstCount, name, room);
                        DrawInTimeTable(CheckPositionLeft(time[14].ToString()), CheckPositionTop(time.Substring(15, 5)), secondCount, name, room);
                        break;
                    case TimeTableConstants.EXCEL:
                        SaveData(CheckDayPosition(time[0].ToString()), CheckPositionTop(time.Substring(2, 5))-2, firstCount, name, room);
                        SaveData(CheckDayPosition(time[1].ToString()), CheckPositionTop(time.Substring(2, 5))-2, firstCount, name, room);
                        SaveData(CheckDayPosition(time[14].ToString()), CheckPositionTop(time.Substring(15, 5))-2, secondCount, name, room);
                        break;
                }
                
            }
        }

        /// <summary>
        /// Console 화면에 해당 시간에 출력한다.
        /// </summary>
        /// <param name="left">좌우 좌표값</param>
        /// <param name="top">상하 좌표값</param>
        /// <param name="count">몇시간 수업하는지</param>
        /// <param name="name">과목명</param>
        /// <param name="room">수업위치</param>
        public void DrawInTimeTable(int left, int top, int count, string name, string room)
        {
            for (int i = 0; i < count - 1; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(name);
                top++;
            }
            if (room.Equals(""))
            {
                Console.SetCursorPosition(left, top);
                Console.Write(name);
            }
            else
            {
                Console.SetCursorPosition(left, top);
                Console.Write(room);
            }
        }

        /// <summary>
        /// 배열 정보를 액셀 파일에 저장
        /// </summary>
        /// <param name="readAndWriteExcelFile">액셀데이터를 정보</param>
        /// <param name="dataControl">데이터를 관리하는 객체</param>
        /// <param name="id">사용자 아이디</param>
        /// <param name="mode">console 출력인지, Excel저장인지</param>
        public void SaveTimeTable(ReadAndWriteExcelFile readAndWriteExcelFile, DataControl dataControl, string id, string mode)
        {
            MakeTimeTable(dataControl, id, mode);
            readAndWriteExcelFile.WriteOnExcel(table);

            if (mode.Equals(TimeTableConstants.EXCEL))
                drawUI.SaveWaiting();
            Console.SetCursorPosition(5, 28);
        }

        /// <summary>
        /// 시간표를 배열에 저장
        /// </summary>
        /// <param name="day">무슨 요일인지</param>
        /// <param name="top">몇번에 칸인지</param>
        /// <param name="count">몇시간인지</param>
        /// <param name="name">수업명이 뭔지</param>
        /// <param name="room">어디서 수업하는지</param>
        public void SaveData(int day,int top,int count,string name,string room)
        {
            for (int i = 0; i < count - 1; i++)
            {
                table[top, day] = name;
                top++;
            }
            if (room.Equals(""))
                table[top, day] = name;
            else
                table[top, day] = room;
        }
        /// <summary>
        /// 무슨 요일인지 좌우 커서 위치값
        /// </summary>
        /// <param name="start">수업시작 시간</param>
        /// <returns>커서 위치</returns>
        public int CheckPositionLeft(string start)
        {
            if (start.Equals("월")) { return 20; }
            else if (start.Equals("화")) { return 45; }
            else if (start.Equals("수")) { return 70; }
            else if (start.Equals("목")) { return 95; }
            else if (start.Equals("금")) { return 120; }
            else return 0;
        }

        /// <summary>
        /// 배열의 좌우 인덱스 값
        /// </summary>
        /// <param name="day">요일정보</param>
        /// <returns>몇번째 인덱스 위치인지</returns>
        public int CheckDayPosition(string day)
        {
            if (day.Equals("월")) { return 1; }
            else if (day.Equals("화")) { return 2; }
            else if (day.Equals("수")) { return 3; }
            else if (day.Equals("목")) { return 4; }
            else if (day.Equals("금")) { return 5; }
            else return 0;
        }
        
        //몇시 수업인지에 따라 커서값 return;
        public int CheckPositionTop(string start)
        {
            if (start.Equals("09:00")) { return 3; }
            else if (start.Equals("09:30")) { return 4; }
            else if (start.Equals("10:00")) { return 5; }
            else if (start.Equals("10:30")) { return 6; }
            else if (start.Equals("11:00")) { return 7; }
            else if (start.Equals("11:30")) { return 8; }
            else if (start.Equals("12:00")) { return 9; }
            else if (start.Equals("12:30")) { return 10; }
            else if (start.Equals("13:00")) { return 11; }
            else if (start.Equals("13:30")) { return 12; }
            else if (start.Equals("14:00")) { return 13; }
            else if (start.Equals("14:30")) { return 14; }
            else if (start.Equals("15:00")) { return 15; }
            else if (start.Equals("15:30")) { return 16; }
            else if (start.Equals("16:00")) { return 17; }
            else if (start.Equals("16:30")) { return 18; }
            else if (start.Equals("17:00")) { return 19; }
            else if (start.Equals("17:30")) { return 20; }
            else if (start.Equals("18:00")) { return 21; }
            else if (start.Equals("18:30")) { return 22; }
            else if (start.Equals("19:00")) { return 23; }
            else if (start.Equals("19:30")) { return 24; }
            else if (start.Equals("20:00")) { return 25; }
            else if (start.Equals("20:30")) { return 26; }
            else return 0;
        }
    }
}
