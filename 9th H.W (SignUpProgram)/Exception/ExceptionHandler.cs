using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hu_s_SignUp
{
    class ExceptionHandler
    {
        MemberDAO memberDAO;

        public ExceptionHandler()
        {
            memberDAO = new MemberDAO();
        }

        public int CheckId(string id)
        {
            if (id.Length > 15 || id.Length < 5)
                return Constants.ERROR_ID_LENGTH;

            if (Regex.IsMatch(id, @"[~`^!@#$%%\-+={}[\]|\\;:""<>,?/]"))
                return Constants.ERROR_ID_SPECIAL;

            if (!memberDAO.CheckId(id))
                return Constants.ERROR_ID_ALREADY;

            if (Regex.IsMatch(id, @"\s"))
                return Constants.ERROR_ID_SPACE;

            return Constants.SUCCESS_ID;
        }

        public int CheckPw(string pw)
        {
            if (pw.Length > 15 || pw.Length < 5)
                return Constants.ERROR_PW_LENGTH;

            if (Regex.IsMatch(pw, @"[가-힣]"))
                return Constants.ERROR_PW_KOREAN;

            if (Regex.IsMatch(pw, @"\s"))
                return Constants.ERROR_PW_SPACE;

            return Constants.SUCCESS_PW;
        }
        public int CheckName(string name)
        {
            if (name.Length > 5 || name.Length < 2)
                return Constants.ERROR_NAME_LENGTH;

            if (Regex.IsMatch(name, @"\s"))
                return Constants.ERROR_NAME_SPACE;

            if (!Regex.IsMatch(name, @"^[가-힣]$"))
                return Constants.ERROR_NAME_NOTKOREAN;

            return Constants.SUCCESS_NAME;
        }
        public int CheckResidentNumber(string resiNum)
        {
            char[] inputResinum = resiNum.ToCharArray();
            int year;

            if (!Regex.IsMatch(resiNum, @"[0-9][0-9][01][0-9][0123][0-9][1234][0-9]{6}"))
                return Constants.ERROR_RESINUM_FORMAT;
            if (resiNum.Length != 13)
                return Constants.ERROR_RESINUM_FORMAT;

            if (!memberDAO.CheckResidentNumber(resiNum))
                return Constants.ERROR_RESINUM_ALREADY;

            if (Convert.ToInt32(resiNum.Substring(0, 2)) > 10 && Convert.ToInt32(resiNum.Substring(0, 2)) < 99)
                year = Convert.ToInt32("20" + resiNum.Substring(0, 2));
            else
                year = Convert.ToInt32("19" + resiNum.Substring(0, 2));

            if (Convert.ToInt32(resiNum.Substring(0, 2)) > 18 && Convert.ToInt32(resiNum.Substring(0, 2)) <= 99 && (resiNum[6].Equals('3') || resiNum[6].Equals('4')))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(01) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(02) && !((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 28))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(02) && ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 29))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(03) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(04) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(05) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(06) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(07) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(08) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(09) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(10) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(11) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 30))
                return Constants.ERROR_RESINUM_FORMAT;
            if (Convert.ToInt32(resiNum.Substring(2, 2)).Equals(12) && (Convert.ToInt32(resiNum.Substring(4, 2)) < 1 || Convert.ToInt32(resiNum.Substring(4, 2)) > 31))
                return Constants.ERROR_RESINUM_FORMAT;
            if (inputResinum[2].Equals('1') && inputResinum[3] > '2')
                return Constants.ERROR_RESINUM_FORMAT;
            if (inputResinum[4].Equals('3') && inputResinum[5] > '1')
                return Constants.ERROR_RESINUM_FORMAT;

            return Constants.SUCCESS_RESINUM;
        }

        public bool CheckPhoneNumber(string phone)
        {

            if (phone.Length > 11 || phone.Length < 10)
                return false;
            if (!Regex.IsMatch(phone, @"01[016789]\d{3,4}[0-9]{4}"))
                return false;

            if (phone.Length.Equals(10))
            {
                if (phone[3].Equals(phone[4]) && phone[4].Equals(phone[5])) return false;
                if (phone[6].Equals(phone[7]) && phone[7].Equals(phone[8]) && phone[8].Equals(phone[9])) return false;
            }
            if (phone.Length.Equals(11))
            {
                if (phone[3].Equals(phone[4]) && phone[4].Equals(phone[5]) && phone[5].Equals(phone[6])) return false;
                if (phone[7].Equals(phone[8]) && phone[8].Equals(phone[9]) && phone[9].Equals(phone[10])) return false;
            }

            return true;
        }

        public int CheckEmail(string email)
        {
            if (email.Length > 15 || email.Length < 5)
                return Constants.ERROR_EMAIL_LENGTH;

            if (Regex.IsMatch(email, @"[~`^!@#$%%\-+={}[\]|\\;:""<>,?/]"))
                return Constants.ERROR_EMAIL_SPECIAL;

            if (!memberDAO.CheckEmail(email))
                return Constants.ERROR_EMAIL_ALREADY;

            if (Regex.IsMatch(email, @"\s"))
                return Constants.ERROR_EMAIL_SPACE;

            return Constants.SUCCESS_EMAIL;
        }
    }
}
