using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    class ReadAndWriteExcelFile
    {
        private DrawUI drawUI;  //그리기 기능을 하기 위함
        private Object[,] lectureInformation;   //엑셀 파일 저장 정보

        /// <summary>
        /// 기본 생성자로써 각각의 객체를 생성해준다.
        /// </summary>
        public ReadAndWriteExcelFile()
        {
            drawUI = new DrawUI();
            lectureInformation = ReadFromExcel();
        }
        /// <summary>
        /// 입력한 문자열을 원하는 길이로 조절해주는 메소드
        /// </summary>
        /// <param name="inputString">입력 문자열</param>
        /// <param name="length">원하는 길이</param>
        /// <returns>원하는 길이로 조절된 문자열</returns>
        public string ConvertLength(string inputString, int length)
        {
            byte[] byteName1 = Encoding.Default.GetBytes(inputString + "                                                                                ");
            byte[] byteName2 = new byte[length];
            Array.Copy(byteName1, byteName2, length);

            return Encoding.Default.GetString(byteName2);
        }

        /// <summary>
        /// 각각 입력이 들어온 열에 대해서 그 열에 맞는 길이로 만들어준다.
        /// </summary>
        /// <param name="excelData">엑셀에 각 열에 들어있는 데이터</param>
        /// <param name="column">몇 열</param>
        /// <returns>원하는 길이로 변환한 데이터</returns>
        public string PrintModeSelect(string excelData, int column)
        {
            switch (column)
            {
                case TimeTableConstants.NO:
                    return ConvertLength(excelData, 5);

                case TimeTableConstants.MAJOR:
                    return ConvertLength(excelData, 22);
                case TimeTableConstants.LECTURE_NUMBER:
                    return ConvertLength(excelData, 13);
                case TimeTableConstants.DIVISION:
                    return ConvertLength(excelData, 7);
                case TimeTableConstants.LECTURE_NAME:
                    return ConvertLength(excelData, 35);
                case TimeTableConstants.COMPLETION_DIVISION:
                    return ConvertLength(excelData, 15);
                case TimeTableConstants.GRADE:
                    return ConvertLength(excelData, 6);
                case TimeTableConstants.CREDIT:
                    return ConvertLength(excelData, 7);
                case TimeTableConstants.TIME:
                    return ConvertLength(excelData, 30);
                case TimeTableConstants.ROOM:
                    return ConvertLength(excelData, 15);
                case TimeTableConstants.PROFESSOR_NAME:
                    return ConvertLength(excelData, 24);
                case TimeTableConstants.LANGUAGE:
                    return excelData;
                default:
                    return "";

            }
        }
        /// <summary>
        /// 엑셀로부터 데이터를 읽어온다.
        /// </summary>
        /// <returns>읽어온 데이터 정보</returns>
        public Object[,] ReadFromExcel()
        {
            Object[,] data = new Object[,] { };

            try
            {
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook workbook = ExcelApp.Workbooks.Open(@"C:\Users\gjwls\Desktop\lectures");
                Excel.Sheets sheets = workbook.Sheets;
                Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;
                Excel.Range cellRange = worksheet.UsedRange;

                data = cellRange.Value;
                ExcelApp.Workbooks.Close();
                ExcelApp.Quit();

            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
            return data;
        }
        /// <summary>
        /// 엑셀에 시간표를 입력한다.
        /// </summary>
        /// <param name="timeTable">시간표 정보</param>
        public void WriteOnExcel(Object[,] timeTable)
        {
            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;
            Object path = new Object();
            path = @"C: \User\gjwls\Desktop\MyTimeTableSub";
            //int row = 23,column = 6;
            try
            {
                excelApp = new Excel.Application();

                wb = excelApp.Workbooks.Open(@"C:\Users\gjwls\Desktop\MyTimeTable");
                // 엑셀파일을 엽니다.
                // ExcelPath 대신 문자열도 가능합니다
                // 예. Open(@"D:\test\test.xlsx");

                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;
                // 첫번째 Worksheet를 선택합니다.

                Excel.Range rng = ws.Range["A1", "F26"];    //ws.Range[ws.Cells[1, 1], ws.Cells[row, column]];
                // 해당 Worksheet에서 저장할 범위를 정합니다.
                // 지금은 저장할 행렬의 크기만큼 지정합니다.
                // 다른 예시 Excel.Range rng = ws.Range["B2", "G8"];

                Object[,] data = timeTable;
                // 저장할 때 사용할 object 행렬

                // for문이 아니더라도 object[,] 형으로 저장된다면 저장이 가능합니다.

                rng.Value = data;
                // data를 불러온 엑셀파일에 적용시킵니다. 아직 완료 X

                 if (path != null)
                // path는 새로 저장될 엑셀파일의 경로입니다.
                // 따로 지정해준다면, "다른이름으로 저장" 의 역할을 합니다.
                // 상대경로도 가능합니다. (예. "secondExcel.xlsx")
                 wb.SaveCopyAs(path);
                else
                // 따로 저장하지 않는다면 지금 파일에 그대로 저장합니다.
                wb.Save();

                wb.Close();
                excelApp.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 학과정보, 학수번호, 분반 정보를 가지고 엑셀정보에서 해당 과목 정보를 가져온다.
        /// </summary>
        /// <param name="id">현재 접속중인 사용자</param>
        /// <param name="major">학과 이름</param>
        /// <param name="number">학수 번호</param>
        /// <param name="division">분반</param>
        /// <returns>엑셀에서 관심과목 담고자 하는 과목 정보</returns>
        public InterestLectureVO GetInterestLecture(string id, string major, string number, string division)
        {
            InterestLectureVO interest = new InterestLectureVO();
            int count = 1;
            for (int row = 2; row <= lectureInformation.GetLength(0); row++)
            {
                if (Regex.IsMatch(lectureInformation[row, 2].ToString(), major) && lectureInformation[row, 3].Equals(number) && lectureInformation[row, 4].Equals(division))
                {
                    interest.Id = id;
                    interest.No = lectureInformation[row, 1].ToString();
                    interest.Major = lectureInformation[row, 2].ToString();
                    interest.Number = lectureInformation[row, 3].ToString();
                    interest.Division = lectureInformation[row, 4].ToString();
                    interest.Name = lectureInformation[row, 5].ToString();
                    interest.Completion = lectureInformation[row, 6].ToString();
                    interest.Grade = lectureInformation[row, 7].ToString();
                    interest.Credit = lectureInformation[row, 8].ToString();
                    interest.Time = lectureInformation[row, 9].ToString();
                    if (lectureInformation[row, 10] != null)
                        interest.Room = lectureInformation[row, 10].ToString();
                    else
                        interest.Room = "";
                    interest.Professor = lectureInformation[row, 11].ToString();
                    interest.Language = lectureInformation[row, 12].ToString();

                    return interest;
                }
                count++;
            }
            if (count.Equals(lectureInformation.GetLength(0)))
                return null;
            else
                return interest;
        }

        /// <summary>
        /// 학과정보, 학수번호, 분반 정보를 가지고 엑셀정보에서 수강신청 할 과목 정보를 불러온다.
        /// </summary>
        /// <param name="id">현재 사용자</param>
        /// <param name="major">학과 정보</param>
        /// <param name="number">학수 번호</param>
        /// <param name="division">분반</param>
        /// <returns>수강신청하고자 하는 과목 정보</returns>
        public RegisterLectureVO GetRegisterLecture(string id, string major, string number, string division)
        {
            RegisterLectureVO register = new RegisterLectureVO();
            int count = 1;

            for (int row = 2; row <= lectureInformation.GetLength(0); row++)
            {
                if (Regex.IsMatch(lectureInformation[row, 2].ToString(), major) && lectureInformation[row, 3].Equals(number) && lectureInformation[row, 4].Equals(division))
                {
                    register.Id = id;
                    register.No = lectureInformation[row, 1].ToString();
                    register.Major = lectureInformation[row, 2].ToString();
                    register.Number = lectureInformation[row, 3].ToString();
                    register.Division = lectureInformation[row, 4].ToString();
                    register.Name = lectureInformation[row, 5].ToString();
                    register.Completion = lectureInformation[row, 6].ToString();
                    register.Grade = lectureInformation[row, 7].ToString();
                    register.Credit = lectureInformation[row, 8].ToString();
                    register.Time = lectureInformation[row, 9].ToString();
                    if (lectureInformation[row, 10] != null)
                        register.Room = lectureInformation[row, 10].ToString();
                    else
                        register.Room = "";
                    register.Professor = lectureInformation[row, 11].ToString();
                    register.Language = lectureInformation[row, 12].ToString();

                    return register;
                }
                count++;
            }
            if (count.Equals(lectureInformation.GetLength(0)))
                return null;
            else
                return register;
        }

        /// <summary>
        /// 내가 찾고자 하는 정보를 가진 과목들의 목록을 출력해준다.
        /// </summary>
        /// <param name="input">사용자가 찾고자 검색한 정보</param>
        /// <param name="mode">무슨 열의 정보인지</param>
        /// <param name="status">관심과목담기인지 수강신청인지</param>
        /// <param name="dataControl">데이터 정보들</param>
        /// <returns>발견한게 몇개인지</returns>
        public int PrintWeFound(string input, int mode, string status, DataControl dataControl)
        {
            Console.SetWindowSize(192, 50);

            int count = 0;
            drawUI.Category();
            switch (status)
            {
                case TimeTableConstants.INTEREST:
                    for (int r = 2; r <= lectureInformation.GetLength(0); r++)
                    {
                        if (!dataControl.InInterestList(lectureInformation[r, 3].ToString()))
                            continue;
                        else if (Regex.IsMatch(lectureInformation[r, mode].ToString(), input))
                        {
                            count++;
                            for (int c = 1; c <= lectureInformation.GetLength(1); c++)
                            {
                                if (lectureInformation[r, c] == null)
                                {
                                    Console.Write(PrintModeSelect("", c));
                                }
                                else
                                {
                                    Console.Write(PrintModeSelect(lectureInformation[r, c].ToString(), c));
                                }

                            }
                        }
                        else
                            continue;
                        Console.WriteLine();
                    }
                    return count;
                case TimeTableConstants.REGISTER:
                    for (int r = 2; r <= lectureInformation.GetLength(0); r++)
                    {
                        if (!dataControl.InRegisterList(lectureInformation[r, 3].ToString()))
                            continue;
                        else if (Regex.IsMatch(lectureInformation[r, mode].ToString(), input))
                        {
                            count++;
                            for (int c = 1; c <= lectureInformation.GetLength(1); c++)
                            {
                                if (lectureInformation[r, c] == null)
                                {
                                    Console.Write(PrintModeSelect("", c));
                                }
                                else
                                {
                                    Console.Write(PrintModeSelect(lectureInformation[r, c].ToString(), c));
                                }

                            }
                        }
                        else
                            continue;
                        Console.WriteLine();
                    }
                    return count;
                default:
                    return count;
            }
        }
    
    /// <summary>
    /// 모든 과목정보 출력
    /// </summary>
    public void PrintAllLecture()
    {
        Console.SetWindowSize(192, 50);

        drawUI.Category();
        for (int r = 2; r <= lectureInformation.GetLength(0); r++)
        {
            for (int c = 1; c <= lectureInformation.GetLength(1); c++)
            {
                if (lectureInformation[r, c] == null)
                {
                    Console.Write(PrintModeSelect("", c));
                }
                else
                {
                    Console.Write(PrintModeSelect(lectureInformation[r, c].ToString(), c));
                }
            }
            Console.WriteLine();
        }

    }
}
}
