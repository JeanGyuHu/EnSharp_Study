using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ExceptionHandling
    {
        private bool result;
    
        /// <summary>
        /// 기본 생성자로써 변수를 초기화해준다.
        /// </summary>
        public ExceptionHandling()
        {
            result = false;
        }
        /// <summary>
        /// 입력 받은 아이디가 해당 조건에 만족하는지 체크
        /// </summary>
        /// <param name="id">회원이 입력한 아이디</param>
        /// <returns>조건 만족시 true</returns>
        public bool CheckId(string id)
        {
            result = true;

            if (!CheckIsNumAndChar(id))
                result = false;
            if (id.Length < 8 || id.Length > 14)
                result = false;
            return result; 
        }
        /// <summary>
        /// 입력받은 아이디가 조건에 만족하는 체크
        /// </summary>
        /// <param name="pw">사용자가 입력한 비밀번호</param>
        /// <returns>조건 만족 여부</returns>
        public bool CheckPw(string pw)
        {
            result = true;

            if (!CheckIsNumAndChar(pw))
            {
                result = false;
            }
            if (pw.Length < 8 || pw.Length > 14)
                result = false;

            return result;
        }
        /// <summary>
        /// 이 책을 이미 빌렸는지 안빌렸는지 체크
        /// </summary>
        /// <param name="rentalList">빌린 사람 리스트</param>
        /// <param name="id">빌리려는 사람의 아이디</param>
        /// <param name="bookChoice">어떤 책을 빌리려는지</param>
        /// <returns>해당 책을 이미 빌렸으면 false</returns>
        public bool CheckAlreadyRent(List<RentalData> rentalList, string id, string bookChoice)
        {
            for (int i = 0; i < rentalList.Count; i++)
            {
                if (rentalList[i].BookLender.Equals(id))
                {
                    if (rentalList[i].BookName.Equals(bookChoice))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// 아이디가 조건을 충족하는지 체크
        /// </summary>
        /// <param name="name">사용자가 입력한 이름</param>
        /// <returns>조건 충족 여부</returns>
        public bool CheckName(string name)
        {
            result = true;

            if (!CheckIsChar(name))
                result = false;

            if (name.Length < 1 || name.Length > 10)
                result = false;

            return result;
        }
        /// <summary>
        /// 책 번호를 조건 충족하는지 체크 
        /// </summary>
        /// <param name="bookNo">사용자가 입력한 책번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckBookNo (string bookNo)
        {
            result = true;

            if (bookNo.Length != 11)
                return false;

            if (!CheckPartNum(bookNo, 0, 1))
            {
                result = false;
            }
            if (!bookNo[2].Equals('-'))
            {
                result = false;
            }
            if (!CheckPartNum(bookNo, 3, 10))
                result = false;

            return result;
        }
        /// <summary>
        /// 책이 조건을 충족하는지 체크
        /// </summary>
        /// <param name="bookCount">사용자가 입력한 책의 권수</param>
        /// <returns>충족 여부</returns>
        public int CheckBookCount (string bookCount)
        {
            if (bookCount.Length > 4)
                return -1;
            if (!CheckIsNum(bookCount))
                return -1;

            int result = Int32.Parse(bookCount);


            if (Int32.Parse(bookCount) < 0)
                return -1;

            return result;
        }
        /// <summary>
        /// 주민등록번호 조건 충족 여부
        /// </summary>
        /// <param name="resiNum">사용자의 주민번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckResidentNum(string resiNum)
        {
            result = true;

            if (resiNum.Length != 14)
                return false;

            if (!CheckPartNum(resiNum, 0, 5))
            {
                result = false;
            }
            if (!resiNum[6].Equals('-'))
            {
                result = false;
            }
            if (!CheckPartNum(resiNum, 7, 13))
                result = false;

            return result;
        }
        /// <summary>
        /// 전화번호 조건 충족 여부
        /// </summary>
        /// <param name="phone">사용자 입력 번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckPhone(string phone)
        {
            result = true;

            if (!CheckIsNum(phone))
                result = false;
            if (phone.Length > 11 || phone.Length < 10)
                result = false;
            return result;
        }
        /// <summary>
        /// 주소의 조건 충족 여부
        /// </summary>
        /// <param name="address">사용자 입력 주소</param>
        /// <returns>충족 여부</returns>
        public bool CheckAddress(string address)
        {
            result = true;

            if (!CheckIsNumAndChar(address))
                result = false;
            if (address.Length > 20 || address.Length < 15)
                result = false;

            return result;
        }
        /// <summary>
        /// 일정 부분이 숫자인지 체크해주는 메소드
        /// </summary>
        /// <param name="input">체크를 받을 문자열</param>
        /// <param name="start">체크받을 시작부분</param>
        /// <param name="finish">체크받을 끝부분</param>
        /// <returns></returns>
        public bool CheckPartNum(string input, int start, int finish)
        {
            result = false;

            char[] inputName = input.ToCharArray();

            for (int count = start; count < finish; count++)
            {
                if (inputName[count] >= '0' && inputName[count] <= '9')
                    result = true;
                else return false;
            }
            return result;
        }
        /// <summary>
        /// 입력한 문자열이 문자와 숫자로만 이루어졌는지 체크해주는 메소드
        /// </summary>
        /// <param name="name">입력 문자열</param>
        /// <returns>문자와 숫자로만 이루졌는지 여부</returns>
        public bool CheckIsNumAndChar(string name)
        {
            char[] inputName = name.ToCharArray();
            result = false;
            for (int count = 0; count < inputName.Length; count++)
            {
                if (inputName[count] >= '0' && inputName[count] <= '9') result = true;
                else if (inputName[count] >= 'a' && inputName[count] <= 'z') result = true;
                else if (inputName[count] >= 'A' && inputName[count] <= 'Z') result = true;
                else return false;
            }
            return result;
        }
        /// <summary>
        /// 입력받은 문자열이 숫자로만 이루어졌는지 체크
        /// </summary>
        /// <param name="name">입력 문자열</param>
        /// <returns>숫자로만 되어있는지 여부</returns>
        public bool CheckIsNum(string name)
        {
            char[] inputName = name.ToCharArray();

            result = false;

            for (int count = 0; count < inputName.Length; count++)
            {
                if (inputName[count] >= '0' && inputName[count] <= '9')
                    result = true;
                else return false;
            }
            return result;
        }
        /// <summary>
        /// 입력 문자열이 문자로만 되어있는지 체크
        /// </summary>
        /// <param name="name">입력문자열</param>
        /// <returns>문자로만 되어있는지 여부</returns>
        public bool CheckIsChar(string name)
        {
            char[] inputName = name.ToCharArray();

            result = false;

            for (int count = 0; count < inputName.Length; count++)
            {
                if (inputName[count] >= 'a' && inputName[count] <= 'z') result = true;
                else if (inputName[count] >= 'A' && inputName[count] <= 'Z') result = true;
                else return false;
            }
            return result;
        }
        /// <summary>
        /// 입력 문자열에 공백이 있는지 없는지 체크
        /// </summary>
        /// <param name="name">입력 문자열</param>
        /// <returns>빈칸이 있는지 없는지 여부</returns>
        public bool CheckHaveSpace(string name)
        {
            char[] inputName = name.ToCharArray();

            result = true ;

            for (int count = 0; count < inputName.Length; count++)
            {
                if (inputName[count] == ' ')
                    return false;
            }
            return result;
        }
    }
}
