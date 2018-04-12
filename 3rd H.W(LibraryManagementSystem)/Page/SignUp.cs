using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    class SignUp
    {
        private DrawControlMember drawControlMember;
        private ExceptionHandling exceptionHandling;
        private SecureString securePassword;
        private SecureString secureResidentNum;
        private string strId;
        private string stringResidentNum;
        private string strName;
        private string stringPassword;
        private string strAddress;
        private string strPhoneNumber;

        private int count = 0;

        public SignUp(List<Member> list)
        {
            HelpSignUp(list);
        }

        public void HelpSignUp(List<Member> list)
        {
            drawControlMember = new DrawControlMember();
            exceptionHandling = new ExceptionHandling();
            securePassword = new SecureString();
            secureResidentNum = new SecureString();

            DrawId();

            if (CheckId(list))
            {
                DrawPassword();
                DrawName();
                DrawResidentNum();
                DrawPhoneNum();
                DrawAddress();
                Console.Clear();
                list.Add(new Member(strName, stringResidentNum, stringPassword, strId, 0, strAddress, strPhoneNumber));
                drawControlMember.DrawSignUpSuccess();
            }
            else
            {
                HelpSignUp(list);
            }
        }

        public void DrawId()
        {
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWriteSignId();
            strId = Console.ReadLine();
            if (!exceptionHandling.CheckId(strId))
            {
                DrawId();
            }
        }
        public void DrawPassword()
        {
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWriteSignPassword();
            securePassword = drawControlMember.GetConsoleSecurePassword();
            stringPassword = new NetworkCredential("", securePassword).Password;
            if (!exceptionHandling.CheckPw(stringPassword))
            {
                DrawPassword();
            }
        }
        public void DrawName()
        {
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWriteName();
            strName = Console.ReadLine();
        }
        public void DrawResidentNum()
        {
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWriteResidentNum();
            secureResidentNum = drawControlMember.GetConsoleSecurePassword();
            stringResidentNum = new NetworkCredential("", secureResidentNum).Password;

            if (!exceptionHandling.CheckResidentNum(stringResidentNum))
            {
                DrawResidentNum();
            }
        }
        public void DrawPhoneNum()
        {
            Console.Clear();
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWritePhone();
            strPhoneNumber = Console.ReadLine();

            if (!exceptionHandling.CheckPhone(strPhoneNumber))
            {
                DrawPhoneNum();
            }
        }
        public void DrawAddress()
        {
            drawControlMember.DrawSignUpTitle();
            drawControlMember.DrawWriteAddress();
            strAddress = Console.ReadLine();

            if (!exceptionHandling.CheckAddress(strAddress))
            {
                DrawAddress();
            }
        }
        public bool CheckId(List<Member> list)
        {
            count = 0;
            foreach (Member mem in list)
            {
                if (mem.Id.Equals(strId))
                {
                    Console.WriteLine("\n\n\t\t\tUsername already taken. Please try another one.");
                    return false;
                }
                count++;
            }
            if (count == list.Count)
            {
                return true;
            }
            return false;
        }
    }
}
