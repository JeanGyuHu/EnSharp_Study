using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class ControlMember
    {
        private AddMember addMember;
        private string strChoice;
        private bool flag = true;
        public ControlMember(List<Member> list){

            while (flag)
            {
                draw();

                switch (strChoice)
                {
                    case "1":
                        addMember = new AddMember(list);
                        break;
                    case "2":

                        break;

                    case "3":

                        break;
                    case "4":

                        break;

                    case "5":

                        break;
                    case "6":
                        flag = false;
                        break;
                    default:

                        break;
                }
            }
            

        }

        public void draw()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌----------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           C O N T R O L  M E M B E R   M O D E           │");
            Console.WriteLine("\t\t\t└----------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t\t\t1. New User Registration");
            Console.WriteLine("\n\n\t\t\t\t2. Edit Members");
            Console.WriteLine("\n\n\t\t\t\t3. Delete members");
            Console.WriteLine("\n\n\t\t\t\t4. Search Members");
            Console.WriteLine("\n\n\t\t\t\t5. Print members");
            Console.WriteLine("\n\n\t\t\t\t6. EXIT");
            strChoice = Console.ReadLine();

        }
    }
}
