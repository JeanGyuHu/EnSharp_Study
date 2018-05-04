using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LectureTimeTable
{
    class ExceptionHandler
    {
        public ExceptionHandler() { }

        /// <summary>
        /// 아이디가 있는지 없는지 체크
        /// </summary>
        /// <param name="id">현재 사용자 아이디</param>
        /// <param name="studentList">학생정보리스트</param>
        /// <returns>있다면 해당 인덱스값 없으면 -1</returns>
        public int CheckId(string id, List<Student> studentList)
        {
            for(int studentIndex = 0;studentIndex < studentList.Count;studentIndex++)
            {
                if (studentList[studentIndex].Id.Equals(id))
                    return studentIndex;
            }
            return -1;
        }
        /// <summary>
        /// 해당하는 인덱스 값에 비밀번호가 일치하는지 체크
        /// </summary>
        /// <param name="password">회원이 입력한 비밀번호</param>
        /// <param name="index">list의 인덱스 값</param>
        /// <param name="studentList">학생 정보</param>
        /// <returns>비번이 일치하면 true, else false</returns>
        public bool CheckPassword(string password,int index,List<Student> studentList)
        {
            if (studentList[index].Password.Equals(password))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 학수번호에 대한 예외처리
        /// </summary>
        /// <param name="number">학수번호</param>
        /// <returns>조건을 통과했는지 못했는지</returns>
        public bool CheckLectureNumber(string number)
        {
            if (number.Length != 6)
                return false;
            if (Regex.IsMatch(number, @"\D"))
                return false;
            return true;
        }

        /// <summary>
        /// 분반에 대한 예외처리
        /// </summary>
        /// <param name="division">분반</param>
        /// <returns>예외처리 통과여부</returns>
        public bool CheckLectureDivision(string division)
        {
            if (division.Length != 3)
                return false;
            if (Regex.IsMatch(division, @"\D"))
                return false;
            return true;
        }
        /// <summary>
        /// 개설학과에 대한 예외처리
        /// </summary>
        /// <param name="major">개설학과</param>
        /// <returns>예외처리 통과여부</returns>
        public bool CheckLectureMajor(string major)
        {
            if (major.Length < 2 || major.Length > 10)
                return false;
            
            if (Regex.IsMatch(major, @"[a-zA-Z0-9]"))
                return false;
            
            if (Regex.IsMatch(major, " "))
                return false;
            
            if (Regex.IsMatch(major, @"[~`!@#$%%\-+={}[\]|\\;:""<>,.?/]"))
                return false;
            
            return true;
        }
        
        /// <summary>
        /// 같은 시간에 수업이 있는지 없는지 체크해준다.
        /// </summary>
        /// <param name="list">수강신청내역</param>
        /// <param name="id">현 사용자명</param>
        /// <param name="time">신청한 시간</param>
        /// <returns>있는지 없는지 여부</returns>
        public bool CheckSameTimeRegisted(List<RegisterLectureVO> list,string id,string time)
        {
            DateTime startTime, finishTime, secondStartTime, secondFinishTime;
            DateTime listStartTime, listFinishTime,listSecondStartTime, listSecondFinishTime;

            //12글자 시간에 대한 예외처리
            if (time.Length.Equals(12))
            {
                startTime = Convert.ToDateTime(time.Substring(1, 5));
                finishTime = Convert.ToDateTime(time.Substring(7,5));

                for(int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id.Equals(id))
                    {
                        if (list[i].Time.Length.Equals(12))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(1, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(7, 5));

                            if (listStartTime < startTime && listFinishTime > startTime&&time[0].Equals(list[i].Time[0]))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && time[0].Equals(list[i].Time[0]))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(13))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && (time[0].Equals(list[i].Time[0]) || time[0].Equals(list[i].Time[1])))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && (time[0].Equals(list[i].Time[0]) || time[0].Equals(list[i].Time[1])))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(26))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            listSecondStartTime = Convert.ToDateTime(list[i].Time.Substring(15, 5));
                            listSecondFinishTime = Convert.ToDateTime(list[i].Time.Substring(21, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && (time[0].Equals(list[i].Time[0]) || time[0].Equals(list[i].Time[1])))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && (time[0].Equals(list[i].Time[0]) || time[0].Equals(list[i].Time[1])))
                                return false;

                            if (listSecondStartTime < startTime && listSecondFinishTime > startTime && time[0].Equals(list[i].Time[14]))
                                return false;
                            if (listSecondStartTime < finishTime && listSecondFinishTime > finishTime && time[0].Equals(list[i].Time[14]))
                                return false;
                        }
                    }
                }
            }
            else if(time.Length.Equals(13))
            {
                startTime = Convert.ToDateTime(time.Substring(2, 5));
                finishTime = Convert.ToDateTime(time.Substring(8, 5));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id.Equals(id))
                    {
                        if (list[i].Time.Length.Equals(12))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(1, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(7, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && (time[0].Equals(list[i].Time[0]) || time[1].Equals(list[i].Time[0])))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && (time[0].Equals(list[i].Time[0]) || time[1].Equals(list[i].Time[0])))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(13))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(26))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            listSecondStartTime = Convert.ToDateTime(list[i].Time.Substring(15, 5));
                            listSecondFinishTime = Convert.ToDateTime(list[i].Time.Substring(21, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;

                            if (listSecondStartTime < startTime && listSecondFinishTime > startTime && (time[0].Equals(list[i].Time[14]) || time[1].Equals(list[i].Time[14])))
                                return false;
                            if (listSecondStartTime < finishTime && listSecondFinishTime > finishTime && (time[0].Equals(list[i].Time[14])|| time[1].Equals(list[i].Time[14])))
                                return false;
                        }
                    }
                }
            }
            else if (time.Length.Equals(26))
            {
                startTime = Convert.ToDateTime(time.Substring(2, 5));
                finishTime = Convert.ToDateTime(time.Substring(8, 5));

                secondStartTime = Convert.ToDateTime(time.Substring(15, 5));
                secondFinishTime = Convert.ToDateTime(time.Substring(21, 5));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Id.Equals(id))
                    {
                        if (list[i].Time.Length.Equals(12))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(1, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(7, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && (time[0].Equals(list[i].Time[0]) || time[1].Equals(list[i].Time[0])))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && (time[0].Equals(list[i].Time[0]) || time[1].Equals(list[i].Time[0])))
                                return false;
                            if (listStartTime < secondStartTime && listFinishTime > secondStartTime && (time[14].Equals(list[i].Time[0])))
                                return false;
                            if (listStartTime < secondFinishTime && listFinishTime > secondFinishTime && (time[14].Equals(list[i].Time[0])))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(13))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                            if (listStartTime < secondStartTime && listFinishTime > secondStartTime && (time[14].Equals(list[i].Time[0]) || time[14].Equals(list[i].Time[1])))
                                return false;
                            if (listStartTime < secondFinishTime && listFinishTime > secondFinishTime && (time[14].Equals(list[i].Time[0]) || time[14].Equals(list[i].Time[1])))
                                return false;
                        }
                        else if (list[i].Time.Length.Equals(26))
                        {
                            listStartTime = Convert.ToDateTime(list[i].Time.Substring(2, 5));
                            listFinishTime = Convert.ToDateTime(list[i].Time.Substring(8, 5));

                            listSecondStartTime = Convert.ToDateTime(list[i].Time.Substring(15, 5));
                            listSecondFinishTime = Convert.ToDateTime(list[i].Time.Substring(21, 5));

                            if (listStartTime < startTime && listFinishTime > startTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;
                            if (listStartTime < finishTime && listFinishTime > finishTime && time[0].Equals(list[i].Time[0]) && time[1].Equals(list[i].Time[1]))
                                return false;

                            if (listStartTime < secondStartTime && listFinishTime > secondStartTime && (time[14].Equals(list[i].Time[0]) || time[14].Equals(list[i].Time[1])))
                                return false;
                            if (listStartTime < secondFinishTime && listFinishTime > secondFinishTime && (time[14].Equals(list[i].Time[0]) || time[14].Equals(list[i].Time[1])))
                                return false;
                            if (listSecondStartTime < secondStartTime && listSecondFinishTime > secondStartTime && time[14].Equals(list[i].Time[14]))
                                return false;
                            if (listSecondStartTime < secondFinishTime && listSecondFinishTime > secondFinishTime && time[14].Equals(list[i].Time[14]))
                                return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
