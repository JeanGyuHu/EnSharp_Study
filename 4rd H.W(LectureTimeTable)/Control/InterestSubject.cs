using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class InterestSubject
    {
        private DrawUI drawUI;  //관심과목담기할때 필요한 출력을 해주는 클래스
        private ExceptionHandler exceptionHandler;      //예외처리를 해주는 클래스
        
        //기본 생성자 클래스 생성 및 초기화
        public InterestSubject()
        {
            exceptionHandler = new ExceptionHandler();
            drawUI = new DrawUI();
        }
        /// <summary>
        /// 관심과목담기 시에 찾고자하는 정보로 검색하는 기능을 하는 메서드
        /// </summary>
        /// <param name="id">현재 사용자의 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리해주는 객체</param>
        /// <param name="readAndWriteExcelFile">엑셀 파일 정보를 관리해주는 객체</param>
        public void SearchInterest(string id, DataControl dataControl, ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            string mode;
            bool searchFlag = true;

            while (searchFlag)
            {
                drawUI.SearchMenu(TimeTableConstants.INTEREST);
                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                    return;
                switch (mode)
                {
                    case TimeTableConstants.SEARCH_MAJOR:
                        Search(TimeTableConstants.SEARCH_MAJOR, id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_NUMBER:
                        Search(TimeTableConstants.SEARCH_NUMBER, id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_SUBJECT:
                        Search(TimeTableConstants.SEARCH_SUBJECT, id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_GRADE:
                        Search(TimeTableConstants.SEARCH_GRADE, id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_PROFESSOR:
                        Search(TimeTableConstants.SEARCH_PROFESSOR, id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_INTEREST_BACK:
                        searchFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //관심과목담기 정보를 조회하는 메서드
        public void InQuiry(string id, DataControl dataControl)
        {
            dataControl.MyInterestLectures(id);
            drawUI.PressAnyKey();
        }

        /// <summary>
        /// 검색하는 기능을 카테고리 별로 관리하는 메서드
        /// </summary>
        /// <param name="mode">어떤 열에 대한 정보를 확인할지</param>
        /// <param name="id">현재 사용자의 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리하는 객체</param>
        /// <param name="readAndWriteExcelFile">엑셀 정보를 관리하는 객체</param>
        public void Search(string mode, string id, DataControl dataControl, ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            int search = 0, count = 0; 
            string searchInformation;

            if (mode.Equals(TimeTableConstants.SEARCH_MAJOR))
            { search = 2; drawUI.SearchQuestion(mode); }
            else if (mode.Equals(TimeTableConstants.SEARCH_NUMBER))
            { search = 3; drawUI.SearchQuestion(mode); }
            else if (mode.Equals(TimeTableConstants.SEARCH_SUBJECT))
            { search = 5; drawUI.SearchQuestion(mode); }
            else if (mode.Equals(TimeTableConstants.SEARCH_GRADE))
            { search = 7; drawUI.SearchQuestion(mode); }
            else if (mode.Equals(TimeTableConstants.SEARCH_PROFESSOR))
            { search = 11; drawUI.SearchQuestion(mode); }

            searchInformation = drawUI.GetConsoleIdNumber(25);
            if (searchInformation.Equals("back"))
                return;
            if (searchInformation.Length < 1)
            {
                Search(mode, id, dataControl,readAndWriteExcelFile);
                return;
            }
            count = readAndWriteExcelFile.PrintWeFound(searchInformation, search, TimeTableConstants.INTEREST, dataControl);

            if (count.Equals(0))
                drawUI.SearchFailed();
            else
                AddInterest(id, dataControl,readAndWriteExcelFile);
        }

        /// <summary>
        /// 관심과목으로 추가하는 메서드
        /// </summary>
        /// <param name="id">현재 사용자의 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리해주는 객체</param>
        /// <param name="readAndWriteExcelFile">액셀 데이터를 관리해주는 객체</param>
        public void AddInterest(string id, DataControl dataControl, ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            string number, division, major;

            drawUI.AddInterestQuestionMajor();
            major = drawUI.GetConsoleIdNumber(10);
            if (major.Equals("back"))
                return;
            drawUI.AddInterestQuestionNumber();
            number = drawUI.GetConsoleIdNumber(6);
            if (number.Equals("back"))
                return;
            drawUI.AddInterestQuestionDivision();
            division = drawUI.GetConsoleIdNumber(3);
            if (division.Equals("back"))
                return;

            //각각 전공, 학수번호, 분반에 대한 예외처리
            if (!exceptionHandler.CheckLectureMajor(major))
            {
                drawUI.MajorError();
                return;
            }
            else if (!exceptionHandler.CheckLectureNumber(number))
            {
                drawUI.NumberError();
                return;
            }
            else if (!exceptionHandler.CheckLectureDivision(division))
            {
                drawUI.DivisionError();
                return;
            }

            //이미 추가되어있는 과목은 아닌지
            if (dataControl.CheckInterestList(number))
            {   //입력한 정보의 수업이 존재한다면
                if (readAndWriteExcelFile.GetInterestLecture(id, major, number, division) != null)
                {
                    dataControl.AddInterestList(readAndWriteExcelFile.GetInterestLecture(id, major, number, division), id);
                    drawUI.AddSuccess();
                }
                else
                    drawUI.AddFailed();    
            }

            else
            {
                drawUI.AddFailed();
            }
        }

        /// <summary>
        /// 관심과목 담기를 한 과목에 대해서 취소하는 메서드
        /// </summary>
        /// <param name="id">현재 사용자의 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리해주는 객체</param>
        public void DeleteInterest(string id, DataControl dataControl)
        {
            string number, division;

            dataControl.MyInterestLectures(id);

            drawUI.DeleteInterestQuestionNumber();

            number = drawUI.GetConsoleIdNumber(6);
            if (number.Equals("back"))
                return;
            drawUI.AddInterestQuestionDivision();
            division = drawUI.GetConsoleIdNumber(3);
            if (division.Equals("back"))
                return;
            //각각 전공, 학수번호, 분반에 대한 예외처리
            if (!exceptionHandler.CheckLectureNumber(number))
            {
                drawUI.NumberError();
                DeleteInterest(id, dataControl);
                return;
            }
            else if (!exceptionHandler.CheckLectureDivision(division))
            {
                drawUI.DivisionError();
                DeleteInterest(id, dataControl);
                return;
            }
            if (dataControl.DeleteInterestList(number, division))
            {
                drawUI.DeleteSuccess();
            }
            else
            {
                drawUI.DeleteFailed();
            }
        }
    }
}
