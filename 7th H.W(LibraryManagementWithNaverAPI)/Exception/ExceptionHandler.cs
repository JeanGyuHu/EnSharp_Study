using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LibraryManagementWithNaverAPI
{
    class ExceptionHandler
    {
        private bool result;
        private DBExceptionHandler dBExceptionHandler;

        public ExceptionHandler()
        {
            dBExceptionHandler = new DBExceptionHandler();
            result = false;
        }

        /// <summary>
        /// 아이디가 있는지 없는지 체크해주는 메소드
        /// </summary>
        /// <param name="list">유저 리스트</param>
        /// <param name="id">입력한 아이디</param>
        /// <returns></returns>
        public bool CheckID(string id, string mode)
        {
            switch (mode)
            {
                case LibraryConstants.LOGIN_SUPERVISER_MODE:
                    if (!dBExceptionHandler.CheckSuperviserID(id))
                        return true;
                    break;
                case LibraryConstants.LOGIN_USER_MODE:
                    if (!dBExceptionHandler.IsIdInMemberDB(id))
                        return true;
                    break;
            }
            return false;
        }
        /// <summary>
        /// 아이디를 체크했을때, 그 아이디에 해당하는 비밀번호가 사용자가 입력한 비밀번호와 일치하는지 체크
        /// </summary>
        /// <param name="list">유저 리스트</param>
        /// <param name="index">아이디가 있는 인덱스정보</param>
        /// <param name="pw">사용자가 입력한 비밀번호</param>
        /// <returns></returns>
        public bool CheckPW(string id,string pw, string mode)
        {
            switch (mode)
            {
                case LibraryConstants.LOGIN_SUPERVISER_MODE:
                    if (!dBExceptionHandler.CheckSuperviserPassword(id, pw))
                        return true;
                    break;
                case LibraryConstants.LOGIN_USER_MODE:
                    if (!dBExceptionHandler.IsPasswordInMemberDB(id, pw))
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// 입력 받은 아이디가 해당 조건에 만족하는지 체크
        /// 숫자가 8자에서 14자 사이이며 영어와 숫자만 입력 받는다.
        /// </summary>
        /// <param name="id">회원이 입력한 아이디</param>
        /// <returns>조건 만족시 true</returns>
        public bool CheckId(string id)
        {
            result = true;


            for (int index = 0; index < id.Length; index++)
            {
                if (Regex.IsMatch(id, @"[a-zA-Z0-9]").Equals(false))
                    return false;
            }
            if (Regex.IsMatch(id, @"[가-힣]"))
                return false;
            if (Regex.IsMatch(id, @"\s"))
                return false;
            if (Regex.IsMatch(id, @"[~`!@#$%%\-+={}[\]|\\;:""<>,.?/]"))
                return false;
            if (id.Length < 8 || id.Length > 14)
                result = false;

            return result;
        }
        /// <summary>
        /// 입력받은 아이디가 조건에 만족하는 체크
        /// 영문자와 숫자 특수문자 외에는 사용 금지 길이제한 8~14
        /// </summary>
        /// <param name="pw">사용자가 입력한 비밀번호</param>
        /// <returns>조건 만족 여부</returns>
        public bool CheckPw(string pw)
        {
            result = true;
            for (int index = 0; index < pw.Length; index++)
                if (Regex.IsMatch(pw, @"[a-zA-Z0-9~`!@#$%%\-+={}[\]|\\;:""<>,.?/]").Equals(false))
                    return false;
            if (Regex.IsMatch(pw, @"[가-힣]"))
                return false;
            if (Regex.IsMatch(pw, @"\s"))
                return false;
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
                    if (rentalList[i].BookNo.Equals(bookChoice))
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

            Regex regex = new Regex(@"[^가-힣]");
            Match m = regex.Match(name);
            while (m.Success)
            {
                return false;
            }
            if (name.Length > 5 || name.Length < 2)
                return false;

            return result;
        }
        /// <summary>
        /// 책 번호를 조건 충족하는지 체크 
        /// </summary>
        /// <param name="bookNo">사용자가 입력한 책번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckBookNo(string bookNo)
        {
            result = true;

            if (bookNo.Length != 24)
                return false;
            //if (Regex.IsMatch(bookNo, @"^ *$"))
            //    return false;
            if (Regex.IsMatch(bookNo, @"[0-9a-zA-Z]{10}\s[0-9a-zA-Z]{13}"))
                return true;

            return false;
        }
        /// <summary>
        /// 책이 조건을 충족하는지 체크
        /// </summary>
        /// <param name="bookCount">사용자가 입력한 책의 권수</param>
        /// <returns>충족 여부</returns>
        public bool CheckBookCount(string bookCount)
        {

            if (bookCount.Length > 2 || bookCount.Length < 1)
                return false;
            if (Regex.IsMatch(bookCount, @"\D"))
                return false;
            if (Regex.IsMatch(bookCount, @"[0-9]{1,2}"))
                return true;
            if (Int32.Parse(bookCount) < 0)
                return false;

            return true;
        }

        /// <summary>
        /// 저자를 확인해주는 메소드
        /// </summary>
        /// <param name="author">사용자가 입력한 저자명</param>
        /// <returns>조건 충족 여부</returns>
        public bool CheckAuthor(string author)
        {
            if (author.Length < 2 || author.Length > 20)
                return false;

            if (Regex.IsMatch(author, @"[~`!@#$%%\-+={}[\]\\;:""<>,?/]"))
                return false;
            //if (Regex.IsMatch(author, @"[0-9]"))
                //return false;
            return true;
        }
        public bool CheckPrice(string price)
        {
            if (price.Length < 4 || price.Length > 8)
                return false;
            if (Regex.IsMatch(price, @"[~`!@#$%%\-+={}[\]|\\;:""<>,?/]"))
                return false;
            if (Regex.IsMatch(price, @"\D"))
                return false;
            if (Int32.Parse(price) < 3000)
                return false;
            return true;

        }
        /// <summary>
        /// 출판사를 확인해주는 메소드
        /// </summary>
        /// <param name="publisher">사용자가 입력한 출판사명</param>
        /// <returns>조건 충족 여부</returns>
        public bool CheckPublisher(string publisher)
        {
            if (publisher.Length < 1 || publisher.Length > 20)
                return false;
            if (Regex.IsMatch(publisher, @"[~`!@#$%%\-+={}[\]|\\;:""<>,?/]"))
                return false;
            //if (Regex.IsMatch(publisher, @"[0-9]"))
             //   return false;

            return true;
        }
        /// <summary>
        /// 주민등록번호 조건 충족 여부
        /// </summary>
        /// <param name="resiNum">사용자의 주민번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckResidentNum(string resiNum)
        {
            char[] inputResinum = resiNum.ToCharArray();
            int year;
            result = true;

            if (!Regex.IsMatch(resiNum, @"[0-9][0-9][01][0-9][0123][0-9]-[1234][0-9]{6}"))
                return false;
            if (resiNum.Length != 14)
                return false;

            if (Convert.ToInt32(resiNum.Substring(0, 2)) > 10 && Convert.ToInt32(resiNum.Substring(0, 2)) < 99)
                year = Convert.ToInt32("20" + resiNum.Substring(0, 2));
            else
                year = Convert.ToInt32("19" + resiNum.Substring(0, 2));

            if (Convert.ToInt32(resiNum.Substring(0, 2)) > 10 && Convert.ToInt32(resiNum.Substring(0, 2)) <= 99 && (resiNum[7].Equals('3') || resiNum[7].Equals('4')))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(01) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(02) && !((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 28))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(02) && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 29))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(03) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(04) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(05) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(06) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(07) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(08) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(09) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(10) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(11) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return false;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(12) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return false;
            if (inputResinum[2].Equals('1') && inputResinum[3] > '2')
                return false;
            if (inputResinum[4].Equals('3') && inputResinum[5] > '1')
                return false;

            return result;
        }

        public bool CheckPublishDate(string date)
        {
            char[] inputDate = date.ToCharArray();
            int year;

            if (!Regex.IsMatch(date, @"[012][0-9]{3}-[01][0-9]-[0123][0-9]"))
                return false;

            if (date.Length != 10)
                return false;
            year = Convert.ToInt32(date.Substring(0, 4));

            if (year > 2018 || year < 1)
                return false;

            if (Convert.ToInt32(date.Substring(5, 2)).Equals(01) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(02) && !((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 28))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(02) && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 29))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(03) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(04) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 30))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(05) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(06) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 30))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(07) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(08) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(09) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 30))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(10) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(11) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 30))
                return false;
            if (Convert.ToInt32(date.Substring(5, 2)).Equals(12) && (Convert.ToInt32(date.Substring(8, 2)) < 1 || Convert.ToInt32(date.Substring(8, 2)) > 31))
                return false;
            if (inputDate[5].Equals('1') && inputDate[6] > '2')
                return false;
            if (inputDate[8].Equals('3') && inputDate[9] > '1')
                return false;

            return true;
        }
        /// <summary>
        /// 전화번호 조건 충족 여부
        /// </summary>
        /// <param name="phone">사용자 입력 번호</param>
        /// <returns>충족 여부</returns>
        public bool CheckPhone(string phone)
        {
            result = true;

            if (phone.Length > 13 || phone.Length < 12)
                result = false;
            if (!Regex.IsMatch(phone, @"01[016789]-\d{3,4}-[0-9]{4}"))
                result = false;

            if (phone.Length.Equals(12))
            {
                if (phone[4].Equals(phone[5]) && phone[5].Equals(phone[6])) return false;
                if (phone[8].Equals(phone[9]) && phone[9].Equals(phone[10]) && phone[10].Equals(phone[11])) return false;
            }
            if (phone.Length.Equals(13))
            {
                if (phone[4].Equals(phone[5]) && phone[5].Equals(phone[6]) && phone[6].Equals(phone[7])) return false;
                if (phone[9].Equals(phone[10]) && phone[10].Equals(phone[11]) && phone[11].Equals(phone[12])) return false;
            }

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

            if (address.Length > 14 || address.Length < 10)
                result = false;

            if (!Regex.IsMatch(address, @"^[가-힣]{2,4}[시도]\s[가-힣]{1,3}[시군구]\s[가-힣]{2,3}[로]$"))
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

            result = true;

            for (int count = 0; count < inputName.Length; count++)
            {
                if (inputName[count].Equals(" "))
                    return false;
            }
            return result;
        }
    }
}

