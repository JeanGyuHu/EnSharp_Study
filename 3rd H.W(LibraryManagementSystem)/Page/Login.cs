using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace EnSharp_day3
{
    
    
    class Login
    {
        private const string StartSuperViserMode = "1";
        private const string StartUserMode = "2";

        private DrawControlMember drawControlMember = new DrawControlMember();
        private string id;
        private SecureString securePassword = new SecureString();
        private int idCheck = -1;
        private bool loginFlag = false;

        public Login(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList,List<RentalData> rentalList)
        {
            CheckAndChangeScene(mode,slist, ulist, bookList, rentalList);
        }

        public void CheckAndChangeScene(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList, List<RentalData> rentalList)
        {
            switch (mode)
            {
                case StartSuperViserMode:

                    loginFlag = DrawLoginPage(slist);

                    if (loginFlag)
                    {
                        SuperviserMode super = new SuperviserMode(slist, ulist, bookList);
                    }
                    else
                    {
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    }
                    break;

                case StartUserMode:
                    loginFlag = DrawLoginPage(ulist);

                    if (loginFlag)
                    {
                        UserMode user = new UserMode(ulist, bookList, rentalList, id);
                    }
                    else
                    {
                        CheckAndChangeScene(mode, slist, ulist, bookList, rentalList);
                    }
                    break;
            }
        }
        public bool DrawLoginPage(List<Member> list)
        {
            drawControlMember.DrawLoginPage();
            drawControlMember.DrawWriteId();
            id = Console.ReadLine();
            idCheck = CheckID(list, id);

            if (idCheck != -1)
            {
                drawControlMember.DrawWritePassword();
                securePassword = drawControlMember.GetConsoleSecurePassword();
                string stringPassword = new NetworkCredential("", securePassword).Password;
                if(CheckPW(list, idCheck, stringPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DrawLoginPage(list);
            }
            return false;
        }

        public int CheckID(List<Member> list,string id)
        {
            for(int check = 0;check <list.Count;check++)
            {
                if (list[check].Id.Equals(id))
                    return check;
            }
            return -1;
        }
        public bool CheckPW(List<Member> list,int index, string pw)
        {
            if (list[index].Password.Equals(pw))
                return true;

            return false;
        }
    }
}
