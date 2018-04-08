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
        private string strId;
        private string strPhoneNumber;
        private string strAddress;
        private string strSearch;
        private int count = 0;
        private int memberIndex = 0;
        private ConsoleKeyInfo keyInfo;

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
                        drawEdit(list);
                        break;

                    case "3":
                        drawDelete(list);
                        break;

                    case "4":
                        drawSearch(list);
                        break;

                    case "5":
                        drawPrint(list);
                        break;

                    case "6":
                        flag = false;
                        break;
                    default:

                        break;
                }
            }
            

        }
        public void drawInformation(List<Member> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌--------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           M E M B E R   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└--------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t┌------------------------------------------------------------------------------------┐");
            Console.WriteLine("\t\t│ Name │ Resident Number │ Id │ Password │ Number of Overdue │ Address │ PhoneNumber │");
            Console.WriteLine("\t\t└------------------------------------------------------------------------------------┘");

            for (int i = 0; i < list.Count; i++)
                Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
            
        }
        public void drawCategory()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌--------------------------------------------------------┐");
            Console.WriteLine("\t\t\t│           M E M B E R   I N F O R M A T I O N          │");
            Console.WriteLine("\t\t\t└--------------------------------------------------------┘");
            Console.WriteLine("\n\n\t\t┌------------------------------------------------------------------------------------┐");
            Console.WriteLine("\t\t│ Name │ Resident Number │ Id │ Password │ Number of Overdue │ Address │ PhoneNumber │");
            Console.WriteLine("\t\t└------------------------------------------------------------------------------------┘");
        }
        public void drawEdit(List<Member> list)
        {
            drawInformation(list);

            Console.Write("\n\n\n\t\t\tChoose person (Id) >>");
            strId = Console.ReadLine();

            count = 0;
            foreach(Member mem in list)
            {
                if (mem.Id.Equals(strId))
                {
                    memberIndex = list.IndexOf(mem);
                    break;
                }
                count++;
            }
            if (count.Equals(list.Count))
                drawEdit(list);
            else
            {
                drawPhoneNum();
                drawAddress();

                list[memberIndex].PhoneNumber = strPhoneNumber;
                list[memberIndex].Address = strAddress;

                Console.WriteLine("\n\n\n\t\t\tE D I T  S U C C E S S !");
                System.Threading.Thread.Sleep(1000);
            }

        }
        public void drawAddress()
        {
            Console.Clear();
            Console.Write("\n\n\t\t\tAddress ::\n\t\t\t >> ");
            strAddress = Console.ReadLine();
        }
        public void drawPhoneNum()
        {
            Console.Clear();
            Console.Write("\n\n\t\t\tPhoneNumber :: (write number only(10 ~ 11))\n\t\t\t >> ");
            strPhoneNumber = Console.ReadLine();

            if (!long.TryParse(strPhoneNumber, out long x))
            {
                Console.WriteLine("\n\n\t\tWrite Number Only !");
                System.Threading.Thread.Sleep(2000);
                drawPhoneNum();
            }
            if (strPhoneNumber.Length > 11)
            {
                Console.WriteLine("\n\n\t\tNumber is too long !");
                System.Threading.Thread.Sleep(2000);
                drawPhoneNum();
            }
            if (strPhoneNumber.Length < 10)
            {
                Console.WriteLine("\n\n\t\tNumber is too short !");
                System.Threading.Thread.Sleep(2000);
                drawPhoneNum();
            }
        }
        public void drawDelete(List<Member> list)
        {
            drawInformation(list);
            
            Console.Write("\n\n\n\t\t\tChoose person (Id) >>");
            strId = Console.ReadLine();

            for (int i = 0;i<list.Count;i++)
            {
                if (list[i].Id.Equals(strId))
                {
                    list.RemoveAt(i);
                }
            }

            Console.WriteLine("\n\n\n\t\t\tD E L E T E  S U C C E S S !");
            System.Threading.Thread.Sleep(1000);
        }
        public void drawSearch(List<Member> list)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t1. Name");
            Console.WriteLine("\n\n\t\t\t\t2. Resident Number");
            Console.WriteLine("\n\n\t\t\t\t3. Id");
            Console.WriteLine("\n\n\t\t\t\t4. Password");
            Console.WriteLine("\n\n\t\t\t\t5. Number of Overdue");
            Console.WriteLine("\n\n\t\t\t\t6. Address");
            Console.WriteLine("\n\n\t\t\t\t7. PhoneNumber");
            Console.Write("\n\t\t\t\t>> ");
            strId = Console.ReadLine();

            switch (strId)
            {
                case "1":
                    Console.Write("\n\n\t\t\t\twrite name : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if(list[i].Name.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;
                case "2":
                    Console.Write("\n\n\t\t\t\twrite Resident Number : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].ResidentNum.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;
                case "3":
                    Console.Write("\n\n\t\t\t\twrite Id : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Id.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;
                case "4":
                    Console.Write("\n\n\t\t\t\twrite Password : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Password.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);

                    }
                    break;

                case "5":
                    Console.Write("\n\n\t\t\t\twrite Number of Overdue : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].NumOverdue.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;
                case "6":
                    Console.Write("\n\n\t\t\t\twrite Address : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Address.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;

                
                case "7":
                    Console.Write("\n\n\t\t\t\twrite PhoneNumber : ");
                    strSearch = Console.ReadLine();
                    drawCategory();
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].PhoneNumber.Equals(strSearch))
                            Console.WriteLine("\t\t\t  {0}\t  {1}\t  {2}\t  {3}\t  {4}\t  {5}\t  {6}", list[i].Name, list[i].ResidentNum, list[i].Id, list[i].Password, list[i].NumOverdue, list[i].Address, list[i].PhoneNumber);
                    }
                    break;
                default:
                    drawSearch(list);
                    break;
            }
            Console.Write("\n\n\n\t\t\tPress any key . . .");
            keyInfo = Console.ReadKey();
        }
        public void drawPrint(List<Member> list)
        {
            drawInformation(list);

            Console.Write("\n\n\n\t\t\tPress any key . . .");
            keyInfo = Console.ReadKey();
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
            Console.Write("\n\n\t\t\t\t >> ");
            strChoice = Console.ReadLine();

        }
    }
}
