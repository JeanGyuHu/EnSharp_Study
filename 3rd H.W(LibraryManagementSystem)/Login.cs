using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    
    
    class Login
    {
        private string id;
        private string password;
        private int idCheck = -1;
        private bool loginFlag = false;

        public Login(string mode, List<Member> slist, List<Member> ulist, List<Book> bookList)
        {
            switch (mode)
            {
                case "1":

                    loginFlag = drawLoginPage(slist);

                    if (loginFlag)
                    {
                        SuperviserMode super = new SuperviserMode(slist,ulist,bookList);
                    }
                    else
                    {
                        loginFlag = drawLoginPage(slist);
                    }
                    break;

                case "2":
                    loginFlag = drawLoginPage(ulist);

                    if (loginFlag)
                    {
                        UserMode super = new UserMode();
                    }
                    else
                    {
                        loginFlag = drawLoginPage(slist);
                    }
                    break;
            }
        }

        public bool drawLoginPage(List<Member> list)
        {
            Console.WriteLine("\n\n\t\t\t\tLOGIN PAGE");
            Console.Write("\n\n\t\t\tID ::\n\t\t\t >> ");
            id = Console.ReadLine();
            idCheck = checkID(list, id);

            if (idCheck != -1)
            {
                Console.Write("\n\n\t\t\tPASSWORD ::\n\t\t\t >> ");
                password = Console.ReadLine();
                if(checkPW(list, idCheck, password))
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
                drawLoginPage(list);
            }
            return false;
        }

        public int checkID(List<Member> list,string id)
        {
            foreach(Member mem in list)
            {
                if (mem.Id.Equals(id))
                    return mem.Id.IndexOf(id);
            }
            return -1;
        }
        public bool checkPW(List<Member> list,int index, string pw)
        {
            if (list[index].Password.Equals(pw))
                return true;

            return false;
        }
    }
}
