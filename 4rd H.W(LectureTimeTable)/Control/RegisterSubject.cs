using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class RegisterSubject
    {
        private DrawUI drawUI;      //출력을 담당하는 객체
        private ExceptionHandler exceptionHandler;  //예외처리 담당 객체

        //기본 생성자 객체 초기화 생성
        public RegisterSubject()
        {
            exceptionHandler = new ExceptionHandler();
            drawUI = new DrawUI();
        }

        /// <summary>
        /// 추가하기 전에 검색을 도와주는 메서드
        /// </summary>
        /// <param name="id">현 사용자의 아이디</param>
        /// <param name="dataControl">데이터 정보를 컨트롤 해주는 객체</param>
        /// <param name="readAndWriteExcelFile">액셀 정보를 관리해주는 객체</param>
        public void SearchRegister(string id,DataControl dataControl, ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            bool searchFlag = true;
            string mode;

            while (searchFlag)
            {
                drawUI.SearchMenu(TimeTableConstants.REGISTER);
                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                    return;
                switch (mode)
                {                   //각 모드는 어떤 정보에 대해서 검색할지에 대한 것이다.
                    case TimeTableConstants.SEARCH_MAJOR:
                        Search(TimeTableConstants.SEARCH_MAJOR, id,dataControl,readAndWriteExcelFile);
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
                    case TimeTableConstants.SEARCH_INTEREST:
                        Search(TimeTableConstants.SEARCH_INTEREST,id,dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.SEARCH_REGISTER_BACK:
                        searchFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 무엇에 대해서 검색할지 위의 메서드에서 정해지면 
        /// 여기서 검색을 한다.
        /// </summary>
        /// <param name="mode">어떤 열에 대해서 검색할지</param>
        /// <param name="id">현 사용자 아이디</param>
        /// <param name="dataControl">데이터 정보 관리하는 객체</param>
        /// <param name="readAndWriteExcelFile">액셀 데이터를 관리하는 객체</param>
        public void Search(string mode, string id,DataControl dataControl,ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            int search = 0, count=0;
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
            else if(mode.Equals(TimeTableConstants.SEARCH_INTEREST))
            {
                dataControl.MyInterestLectures(id);
                AddRegister(id, dataControl,readAndWriteExcelFile); //수강신청
                return;
            }
            searchInformation = drawUI.GetConsoleIdNumber(25);
            if (searchInformation.Equals("back"))//esc 눌렀을때
                return;
            if (searchInformation.Length < 1)
            {
                Search(mode, id, dataControl,readAndWriteExcelFile);
                return;
            }
            count = readAndWriteExcelFile.PrintWeFound(searchInformation, search,TimeTableConstants.REGISTER, dataControl);

            if (count.Equals(0))    //검색결과가 없을때
                drawUI.SearchFailed();
            else
                AddRegister(id, dataControl,readAndWriteExcelFile);
        }

        /// <summary>
        /// 수강신청 할 과목에 대한 정보를 받고 수강신청해주는 메서드
        /// </summary>
        /// <param name="id">현 사용자의 아이디</param>
        /// <param name="dataControl">데이터를 관리해주는 객체</param>
        /// <param name="readAndWriteExcelFile">엑셀 정보를 관리해주는 객체</param>
        public void AddRegister(string id, DataControl dataControl, ReadAndWriteExcelFile readAndWriteExcelFile)
        {
            string number, division,major;

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

            
            if (dataControl.CheckRegisterList(number))
            {
                if (readAndWriteExcelFile.GetRegisterLecture(id, major, number, division) != null)
                {
                    dataControl.AddRegisterList(readAndWriteExcelFile.GetRegisterLecture(id, major, number, division), id);
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
        /// 수강신청한 정보를 삭제하는 메서드
        /// </summary>
        /// <param name="id">현 사용자 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리해주는 메서드</param>
        public void DeleteRegister(string id, DataControl dataControl)
        {
            string number, division;

            dataControl.MyRegisterLectures(id);

            drawUI.DeleteInterestQuestionNumber();

            number = drawUI.GetConsoleIdNumber(6);
            if (number.Equals("back"))
                return;

            drawUI.AddInterestQuestionDivision();
            division = drawUI.GetConsoleIdNumber(3);
            if (division.Equals("back"))
                return;

            if (!exceptionHandler.CheckLectureNumber(number))
            {
                drawUI.NumberError();
                return;
            }
            else if (!exceptionHandler.CheckLectureDivision(division))
            {
                drawUI.DivisionError();
                return;
            }

            if (dataControl.DeleteRegisterList(number, division))
            {
                drawUI.DeleteSuccess();
            }
            else
            {
                drawUI.DeleteFailed();
            }

        }
        /// <summary>
        /// 수강신청 내역 조회하는 메서드
        /// </summary>
        /// <param name="id">현 사용자 아이디</param>
        /// <param name="dataControl">데이터 정보를 관리하는 객체</param>
        public void InQuiry(string id, DataControl dataControl)
        {
            dataControl.MyRegisterLectures(id);
            drawUI.PressAnyKey();
        }
    }
}
