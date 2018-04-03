using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    class MakeUserID
    {
        private String strPlayerOne,strPlayerTwo;
        private VsUserMode vsUserMode;
        private VsComputerMode vsComputerMode;

        public MakeUserID(int mode)
        {
            switch (mode)
            {
                case 1:
                    Console.Write("\n\n\t\t첫번째 사용자의 이름을 입력하세요 : ");
                    strPlayerOne = Console.ReadLine();
                    Console.Write("\n\n\t\t두번째 사용자의 이름을 입력하세요 : ");
                    strPlayerTwo = Console.ReadLine();
                    Console.Clear();
                    vsUserMode = new VsUserMode(strPlayerOne, strPlayerTwo);
                    break;

                case 2:
                    Console.Write("\n\n\t\t컴퓨터와 대결할 사용자의 이름을 입력하세요 : ");
                    strPlayerOne = Console.ReadLine();
                    vsComputerMode = new VsComputerMode(strPlayerOne);
                    break;

                default:
                    
                    break;
            }
            


        }
    }
}
