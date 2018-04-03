using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    class StartMenu
    {
        private int intGameMode;
        private string strGameMode;
        private StartMenu startMenu;
        private MakeUserID makeUserID;
        private ScoreBoard scoreBoard;

        public StartMenu()
        {
            Console.Clear();

            Console.WriteLine("\n\n\t\t**************************************************************");
            Console.WriteLine("\t\t**************\t\tTIC TAC TOE GAME\t**************");
            Console.WriteLine("\t\t**************************************************************");

            Console.WriteLine("\n\n\t\t☆★☆★게임 모드☆★☆★");
            Console.WriteLine("\n\n\t\t1. 사용자끼리 플레이");
            Console.WriteLine("\n\t\t2. 컴퓨터와 플레이");
            Console.WriteLine("\n\t\t3. 게임 통계 보기");
            Console.WriteLine("\n\t\t4. 종료하기");
            Console.Write("\n\n\t\t게임 모드를 선택하세요 : ");

            strGameMode = Console.ReadLine();

            if (!Int32.TryParse(strGameMode, out int x))
            {
                Console.WriteLine("\n\n\t\t잘못된 입력입니다. 게임 모드는 1,2번 중에 선택해야합니다.");
                System.Threading.Thread.Sleep(2000);
                startMenu = new StartMenu();
            }
            else
                intGameMode = Convert.ToInt32(strGameMode);

            switch (intGameMode)
            {
                case 1:
                    Console.Clear();
                    makeUserID = new MakeUserID(intGameMode);
                    break;

                case 2:
                    Console.Clear();
                    makeUserID = new MakeUserID(intGameMode);
                    break;
                case 3:
                    Console.Clear();
                    scoreBoard = new ScoreBoard();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n\n\t\t잘못된 입력입니다. 게임 모드는 1,2번 중에 선택해야합니다.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    startMenu = new StartMenu(); 

                    break;
            }
        }
        
    }
}
