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

        public Login(string mode, List<Member> list)
        {
            switch (mode)
            {
                case "1":
                    drawLoginPage();

                    break;

                case "2":
                    drawLoginPage();

                    break;
            }
        }

        public void drawLoginPage()
        {
            Console.WriteLine("\n\n\t\t\t\tLOGIN PAGE");
            Console.Write("\n\n\t\t\tID ::\n\t\t\t >> ");
            id = Console.ReadLine();
            Console.Write("\n\n\t\t\tPASSWORD ::\n\t\t\t >> ");
            password = Console.ReadLine();
        }
        public Boolean checkID(List<Member> list,string id)
        {
            foreach(Member mem in list)
            {
                if(mem.)
            }
            return false;
        }
        public Boolean checkPW(List<Member> list,string pw)
        {

            return false;
        }
    }
}
