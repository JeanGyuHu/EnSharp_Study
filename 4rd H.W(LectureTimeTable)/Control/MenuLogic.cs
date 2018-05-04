using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace LectureTimeTable
{
    class MenuLogic
    {
        private InterestSubject interestSubject;                //관심과목 담기 기능을 가지고 있는 객체
        private RegisterSubject registerSubject;                //수강신청 기능을 가지고 있는 객체
        private ReadAndWriteExcelFile readAndWriteExcelFile;    //액셀정보를 관리하는 객체
        private TimeTable timeTable;                            //시간표와 관련된 기능을 가지고 있는 객체  
        private ExceptionHandler exceptionHandler;              //예외처리를 하는 기능을 하는 객체
        private DataControl dataControl;                        //데이터들을 관리하는 객체
        private DrawUI drawUI;                                  //출력을 담당하는 객체
        private string id;                                      //로그인한 사람의 아이디
        private SecureString securePassword;                    //입력받은 아이디
        private string stringPassword;                          //저장을 위해 입력받은 객체를 string으로 바꾸기 위함

        private string mode;                                    //화면 변경을 위한 변수

        /// <summary>
        /// 기본 생성자로써 각 객체들을 생성한다.
        /// </summary>
        public MenuLogic()
        {
            readAndWriteExcelFile = new ReadAndWriteExcelFile();
            interestSubject = new InterestSubject();
            registerSubject = new RegisterSubject();
            timeTable = new TimeTable();
            drawUI = new DrawUI();
            dataControl = new DataControl();
            exceptionHandler = new ExceptionHandler();
        }

        /// <summary>
        /// 로그인을 담당하는 메서드
        /// </summary>
        public void Login()
        {
            drawUI.LoginTitle();
            id = drawUI.GetConsoleIdNumber(7);
            if (id.Equals("back"))
            {
                Console.SetCursorPosition(5, 8);
                return;
            }
            if (id.Equals("0"))
            {
                Console.SetCursorPosition(5, 8);
                return;
            }
            Console.SetCursorPosition(14, 6);
            securePassword = drawUI.GetConsoleSecurePassword();
            stringPassword = new NetworkCredential("", securePassword).Password;
            if (stringPassword.Equals("b"))
            {
                Console.SetCursorPosition(5, 8);
                return;
            }
            if (stringPassword.Equals("0"))
            {
                Console.SetCursorPosition(5, 8);
                return;
            }
            if (dataControl.LoginCheck(id, stringPassword))
                MainMenu();
            else
                Login();
        }

        /// <summary>
        /// 메인 메뉴 부분의 로직을 담당하는 메서드
        /// </summary>
        public void MainMenu()
        {
            bool mainMenuExitFlag = true;

            while (mainMenuExitFlag)
            {
                drawUI.MainMenu();
                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                {
                    Login();
                    return;
                }
                switch (mode)
                {
                    case TimeTableConstants.SUBJECTS_INTEREST:      //관심과목담기 메뉴로
                        PutSubjectInterestMenu();
                        break;
                    case TimeTableConstants.REGISTER_CLASSES:       //수강신청 메뉴로
                        RegisterClassMenu();
                        break;
                    case TimeTableConstants.TIMETABLE_CHECK:        //시간표 메뉴로
                        TimeTableMenu();
                        break;
                    case TimeTableConstants.LOGOUT:
                        mainMenuExitFlag = false;
                        Login();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 시간표 메뉴를 담당하는 메서드
        /// </summary>
        public void TimeTableMenu()
        {
            bool TimeTableExitFlag = true;

            while (TimeTableExitFlag)
            {
                drawUI.ScheduleMenu();
                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                    return;
                switch (mode)
                {
                    case TimeTableConstants.TIMETABLE_CONSOLE:  //콘솔로 시간표 출력
                        timeTable.MakeTimeTable(dataControl,id,TimeTableConstants.CONSOLE);
                        drawUI.PressAnyKey();
                        break;
                    case TimeTableConstants.TIMETABLE_SAVE_EXCELFILE:   //엑셀 파일로 저장하기
                        timeTable.SaveTimeTable(readAndWriteExcelFile,dataControl, id, TimeTableConstants.EXCEL);
                        break;
                    case TimeTableConstants.TIMETABLE_BACK:
                        TimeTableExitFlag = false;
                        break;
                    default:
                        break;
                }
            }  
        }

        /// <summary>
        /// 수강신청 메뉴를 담당하는 메서드
        /// </summary>
        public void RegisterClassMenu()
        {
            bool applicationExitFlag = true;

            while (applicationExitFlag)
            {
                drawUI.Register();
                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                    return;
                switch (mode)
                {
                    case TimeTableConstants.REGISTER_SEARCH_ADD:    //수강신청하기
                        registerSubject.SearchRegister(id,dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.REGISTER_DELETE:        //수강신청삭제
                        registerSubject.DeleteRegister(id, dataControl);
                        break;
                    case TimeTableConstants.REGISTER_INQUIRY:       //조회
                        registerSubject.InQuiry(id, dataControl);
                        break;
                    case TimeTableConstants.REGISTER_BACK:
                        applicationExitFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 관심과목 담기를 담당하는 메서드
        /// </summary>
        public void PutSubjectInterestMenu()
        {
            bool interestExitFlag = true;

            while (interestExitFlag)
            {
                drawUI.InterestSubject();

                mode = drawUI.GetConsoleIdNumber(1);
                if (mode.Equals("back"))
                    return;
                switch (mode)
                {
                    case TimeTableConstants.INTEREST_SEARCH_ADD:        //관심과목담기
                        interestSubject.SearchInterest(id, dataControl,readAndWriteExcelFile);
                        break;
                    case TimeTableConstants.INTEREST_DELETE:            //관심과목담기 취소
                        interestSubject.DeleteInterest(id, dataControl);
                        break;
                    case TimeTableConstants.INTEREST_INQUIRY:           //관심과목 조회
                        interestSubject.InQuiry(id, dataControl);
                        break;
                    case TimeTableConstants.INTEREST_BACK:
                        interestExitFlag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
