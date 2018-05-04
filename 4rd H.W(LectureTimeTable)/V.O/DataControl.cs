using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LectureTimeTable
{
    class DataControl
    {
        private List<InterestLectureVO> interestLectureList;    //관심과목담기 목록
        private List<Student> studentList;                      //학생 목록
        private List<RegisterLectureVO> registerLectureList;    //수강신청 목록

        private DrawUI drawUI;  //출력 담당 객체
        private ExceptionHandler exceptionHandler;  //예외처리 객체

        /// <summary>
        /// 기본 생성자 각각의 객체를 생성, 초기화한다.
        /// </summary>
        public DataControl()
        {
            interestLectureList = new List<InterestLectureVO>();
            registerLectureList = new List<RegisterLectureVO>();
            exceptionHandler = new ExceptionHandler();
            studentList = new List<Student>();
            drawUI = new DrawUI();

            AddStudentList(new Student("14010998", "123123"));
        }

        //수강리스트의 get메서드
        public List<RegisterLectureVO> GetRegisterList()
        {
            return registerLectureList;
        }
        //관심과목의 get메서드
        public List<InterestLectureVO> GetInterestList()
        {
            return interestLectureList;
        }
        //학생 목록 추가
        public void AddStudentList(Student student)
        {
            studentList.Add(student);
        }
        /// <summary>
        /// 관심과목 추가하기
        /// </summary>
        /// <param name="interest">관심과목정보</param>
        /// <param name="id">현 사용자 아이디</param>
        public void AddInterestList(InterestLectureVO interest, string id)
        {
            int count = 0;
            
            for (int index = 0; index < studentList.Count; index++)
            {
                if (studentList[index].Id.Equals(id) && (studentList[index].InterestPoint + Convert.ToInt32(interest.Credit[0]-'0')) < 25)
                {
                    studentList[index].InterestPoint += Convert.ToInt32(interest.Credit[0]-'0');
                    break;
                }
                count++;
            }
            if (studentList.Count.Equals(count))
                return;
            else
            {
                interestLectureList.Add(interest);
            }          
        }

        /// <summary>
        /// 수강신청을 하는 메서드
        /// </summary>
        /// <param name="register">수강신청 과목정보</param>
        /// <param name="id">현 사용자 아이디</param>
        public void AddRegisterList(RegisterLectureVO register, string id)
        {
            int count = 0;
            
            if (!exceptionHandler.CheckSameTimeRegisted(registerLectureList, id, register.Time))
            {
                drawUI.ThatTimeNo();
                return;
            }
            for (int index = 0; index < studentList.Count; index++)
            {
                if (studentList[index].Id.Equals(id) && (studentList[index].RegistePoint + Convert.ToInt32(register.Credit[0] - '0')) < 22)
                {
                    studentList[index].RegistePoint += Convert.ToInt32(register.Credit[0] - '0');
                    break;
                }
                count++;
            }
            if (studentList.Count.Equals(count))
                return;
            else
            {
                for(int index = 0; index < interestLectureList.Count; index++)
                {
                    if (interestLectureList[index].Major.Equals(register.Major) && interestLectureList[index].Number.Equals(register.Number) && interestLectureList[index].Division.Equals(register.Division))
                        interestLectureList.RemoveAt(index);
                }
                registerLectureList.Add(register);
                drawUI.AddSuccess();
            }
        }

        /// <summary>
        /// 로그인이 됬는지 안됬는지 최종적으로 묶어주는 메서드
        /// </summary>
        /// <param name="id">입력한 아이디</param>
        /// <param name="password">입력한 비밀번호</param>
        /// <returns>로그인 되는지 안되는지</returns>
        public bool LoginCheck(string id, string password)
        {
            int idIndex = -1;

            idIndex = exceptionHandler.CheckId(id, studentList);

            if (idIndex.Equals(-1))
                return false;
            else
            {
                return exceptionHandler.CheckPassword(password, idIndex, studentList);
            }
        }

        /// <summary>
        /// 관심과목에 담겨있는지 안담겨있는지
        /// </summary>
        /// <param name="number">검색할 과목 학수번호</param>
        /// <returns>담겨있는지 여부</returns>
        public bool CheckInterestList(string number)
        {
            for (int index = 0; index < interestLectureList.Count; index++)
            {
                if (interestLectureList[index].Number.Equals(number))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 수강신청리스트에 담겨있는지 안담겨있는지
        /// </summary>
        /// <param name="number">검색할 과목 학수번호</param>
        /// <returns>담겨있는지 여부</returns>
        public bool CheckRegisterList(string number)
        {
            for (int index = 0; index < registerLectureList.Count; index++)
            {
                if (registerLectureList[index].Number.Equals(number))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 관심과목담기에서 삭제할 과목의 학수번호와 분반을 입력받아 삭제한다.
        /// </summary>
        /// <param name="number">입력 학수번호</param>
        /// <param name="division">입력 분반</param>
        /// <returns>삭제 했는지 못했는지 여부</returns>
        public bool DeleteInterestList(string number,string division)
        {
            for(int index = 0; index < interestLectureList.Count; index++)
            {
                if(interestLectureList[index].Number.Equals(number) && interestLectureList[index].Division.Equals(division))
                {
                    interestLectureList.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 수강신청에서 삭제할 과목의 학수번호와 분반을 입력받아 삭제한다.
        /// </summary>
        /// <param name="number">입력 학수번호</param>
        /// <param name="division">입력 분반</param>
        /// <returns>삭제 했는지 못했는지 여부</returns>
        public bool DeleteRegisterList(string number, string division)
        {
            for (int index = 0; index < registerLectureList.Count; index++)
            {
                if (registerLectureList[index].Number.Equals(number) && registerLectureList[index].Division.Equals(division))
                {
                    registerLectureList.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 내가 관심과목 담은 과목들 리스트 출력
        /// </summary>
        /// <param name="id">현 사용자 아이디</param>
        public void MyInterestLectures(string id)
        {
            drawUI.Category();

            for (int index = 0; index < interestLectureList.Count; index++)
            {
                if (interestLectureList[index].Id.Equals(id))
                    Console.WriteLine(ConvertLength(interestLectureList[index].No, 5) + ConvertLength(interestLectureList[index].Major, 22) + ConvertLength(interestLectureList[index].Number, 13) + ConvertLength(interestLectureList[index].Division, 7) + ConvertLength(interestLectureList[index].Name, 35) + ConvertLength(interestLectureList[index].Completion, 15) + ConvertLength(interestLectureList[index].Grade, 6) + ConvertLength(interestLectureList[index].Credit, 7) + ConvertLength(interestLectureList[index].Time, 30) + ConvertLength(interestLectureList[index].Room, 15) + ConvertLength(interestLectureList[index].Professor, 24) + interestLectureList[index].Language);
            }
            
        }

        /// <summary>
        /// 관심과목담기에 이미 추가됬는지 여부
        /// </summary>
        /// <param name="number">학수 번호</param>
        /// <returns>추가 되어있는지 안되어있는지</returns>
        public bool InInterestList(string number)
        {
            foreach (InterestLectureVO interest in interestLectureList)
                if (interest.Number.Equals(number))
                    return false;
            return true;
        }

        /// <summary>
        /// 수강신청이 이미 되었는지 안되었는지 여부
        /// </summary>
        /// <param name="number">학수 번호</param>
        /// <returns>이미 추가 되어있는지 안되어있는지 여부</returns>
        public bool InRegisterList(string number)
        {
            foreach (RegisterLectureVO register in registerLectureList)
                if (register.Number.Equals(number))
                    return false;
            return true;
        }
        /// <summary>
        /// 내가 수강신청한 목록
        /// </summary>
        /// <param name="id">현 사용자 아이디</param>
        public void MyRegisterLectures(string id)
        {
            drawUI.Category();

            for (int index = 0; index < registerLectureList.Count; index++)
            {
                if (registerLectureList[index].Id.Equals(id))
                    Console.WriteLine(ConvertLength(registerLectureList[index].No, 5)+ ConvertLength(registerLectureList[index].Major, 22)+ ConvertLength(registerLectureList[index].Number, 13)+ ConvertLength(registerLectureList[index].Division, 7)+ ConvertLength(registerLectureList[index].Name, 35)+ ConvertLength(registerLectureList[index].Completion, 15)+ ConvertLength(registerLectureList[index].Grade, 6)+ ConvertLength(registerLectureList[index].Credit, 7)+ ConvertLength(registerLectureList[index].Time, 30)+ ConvertLength(registerLectureList[index].Room, 15)+ ConvertLength(registerLectureList[index].Professor, 24)+ registerLectureList[index].Language);
            }
        }

        /// <summary>
        /// 매개변수로 받은 문자열을 원하는 길이로 바꿔서 보낸다.
        /// </summary>
        /// <param name="inputString">매개변수</param>
        /// <param name="length">원하는 길이</param>
        /// <returns>변환된 문자열</returns>
        public string ConvertLength(string inputString, int length)
        {
            byte[] byteName1 = Encoding.Default.GetBytes(inputString + "                                                                                ");
            byte[] byteName2 = new byte[length];
            Array.Copy(byteName1, byteName2, length);

            return Encoding.Default.GetString(byteName2);
        }
    }
}
