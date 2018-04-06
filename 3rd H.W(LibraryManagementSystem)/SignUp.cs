using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnSharp_day3
{
    class SignUp
    {
        private string strId;
        private string strResidentNum;
        private string strName;
        private string strPassword;
        private string strAddress;
        private string strPhoneNumber;

        private int count = 0;
        public SignUp(List<Member> list)
        {
            drawId();

            if (checkId(list))
            {
                drawPassword();
                drawName();
                drawResidentNum();
                drawPhoneNum();
                drawAddress();
                Console.Clear();
                list.Add(new Member(strName, strResidentNum, strPassword, strId, "0", strAddress, strPhoneNumber));
                Console.Write("\n\n\n\n\n\n\t\t\t가입을 성공적으로 마쳤습니다!!");
                System.Threading.Thread.Sleep(2000);
            }
            else
            {
                drawId();
            }

        }
        public void drawId()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tID ::\n\t\t\t >> ");
            strId = Console.ReadLine();
        }
        public void drawPassword()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tPassword ::\n\t\t\t >> ");
            strPassword = Console.ReadLine();
        }
        public void drawName()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tName ::\n\t\t\t >> ");
            strName = Console.ReadLine();
        }
        public void drawResidentNum()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tResidentNumber ::(xxxxxx-xxxxxxx)\n\t\t\t >> ");
            strResidentNum = Console.ReadLine();
            if (!strResidentNum.Equals(""))
                strResidentNum = strResidentNum.Remove(6, 1);

            if (!long.TryParse(strResidentNum, out long x))    //받은 값이 문자열이면 다시 받고, 숫자면 그냥 받는다.
            {
                Console.WriteLine("\n\n\t\t숫자를 입력해주세요 !");
                System.Threading.Thread.Sleep(2000);
                drawResidentNum();
            }
            strResidentNum = strResidentNum.Insert(6, "-");

            if (!strResidentNum[6].Equals('-'))
            {
                Console.WriteLine("\n\n\t\t입력 형식이 틀렸습니다 !");
                System.Threading.Thread.Sleep(2000);
                drawResidentNum();
            }

        }
        public void drawPhoneNum()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tPhoneNumber :: (write number only(max 11))\n\t\t\t >> ");
            strPhoneNumber = Console.ReadLine();

            if (!long.TryParse(strPhoneNumber, out long x))    //받은 값이 문자열이면 다시 받고, 숫자면 그냥 받는다.
            {
                Console.WriteLine("\n\n\t\t숫자를 입력해주세요 !");
                System.Threading.Thread.Sleep(2000);
                drawPhoneNum();
            }
            if (strPhoneNumber.Length > 11)
            {
                Console.WriteLine("\n\n\t\t전화번호의 길이가 너무 깁니다 !");
                System.Threading.Thread.Sleep(2000);
                drawPhoneNum();
            }
        }
        public void drawAddress()
        {
            Console.Clear();
            draw();
            Console.Write("\n\n\t\t\tAddress ::\n\t\t\t >> ");
            strAddress = Console.ReadLine();
        }
        public bool checkId(List<Member> list)
        {
            count = 0;
            foreach (Member mem in list)
            {
                if (mem.Id.Equals(strId))
                {
                    Console.WriteLine("\n\n\t\t\t이미 존재하는 아이디입니다.");
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
        public void draw()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t┌---------------------------------------------┐");
            Console.WriteLine("\t\t\t│           S I G N   U P   P A G E           │");
            Console.WriteLine("\t\t\t└---------------------------------------------┘");
        }
    }
}
