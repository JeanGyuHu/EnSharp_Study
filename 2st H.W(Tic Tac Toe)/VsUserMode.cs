using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    class VsUserMode
    {
        private char[] gameBoard;
        private string strPlayerChoice;
        private int intPlayerChoice;
        private int playerTurnCount=0;
        private StartMenu startMenu;

        public VsUserMode(String name1,String name2)
        {
            gameBoard = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            while (true)
            {
                Console.Clear();

                if((gameBoard[0] == '●' && gameBoard[1] == '●' && gameBoard[2] == '●')||    //첫번째줄 가로
                    (gameBoard[3] == '●' && gameBoard[4] == '●' && gameBoard[5] == '●')||   //두번째줄 가로
                    (gameBoard[6] == '●' && gameBoard[7] == '●' && gameBoard[8] == '●')||   //세번째줄 가로

                    (gameBoard[0] == '●' && gameBoard[3] == '●' && gameBoard[6] == '●')||   //첫번째줄 세로
                    (gameBoard[1] == '●' && gameBoard[4] == '●' && gameBoard[7] == '●')||   //두번째줄 세로
                    (gameBoard[2] == '●' && gameBoard[5] == '●' && gameBoard[8] == '●')||   //세번째줄 세로

                    (gameBoard[0] == '●' && gameBoard[4] == '●' && gameBoard[8] == '●')||   //대각선 2개
                    (gameBoard[2] == '●' && gameBoard[4] == '●' && gameBoard[6] == '●'))
                {
                    Console.WriteLine("\n\n\t\t{0} 님 의 승 리 입 니 다 ! !\n\n\n\n\n\n",name1);
                    System.Threading.Thread.Sleep(2000);
                    break;
                }

                if ((gameBoard[0] == '★' && gameBoard[1] == '★' && gameBoard[2] == '★') ||    //첫번째줄 가로
                    (gameBoard[3] == '★' && gameBoard[4] == '★' && gameBoard[5] == '★') ||   //두번째줄 가로
                    (gameBoard[6] == '★' && gameBoard[7] == '★' && gameBoard[8] == '★') ||   //세번째줄 가로

                    (gameBoard[0] == '★' && gameBoard[3] == '★' && gameBoard[6] == '★') ||   //첫번째줄 세로
                    (gameBoard[1] == '★' && gameBoard[4] == '★' && gameBoard[7] == '★') ||   //두번째줄 세로
                    (gameBoard[2] == '★' && gameBoard[5] == '★' && gameBoard[8] == '★') ||   //세번째줄 세로

                    (gameBoard[0] == '★' && gameBoard[4] == '★' && gameBoard[8] == '★') ||   //대각선 2개
                    (gameBoard[2] == '★' && gameBoard[4] == '★' && gameBoard[6] == '★'))
                {
                    Console.WriteLine("\n\n\t\t{0} 님 의 승 리 입 니 다 ! !\n\n\n\n\n\n", name2);
                    System.Threading.Thread.Sleep(2000);
                    break;
                }
                Console.WriteLine("\n\n\t\t{0}\t{1}\t{2}\n\n", gameBoard[0], gameBoard[1], gameBoard[2]);
                Console.WriteLine("\t\t{0}\t{1}\t{2}\n\n", gameBoard[3], gameBoard[4], gameBoard[5]);
                Console.WriteLine("\t\t{0}\t{1}\t{2}\n\n", gameBoard[6], gameBoard[7], gameBoard[8]);

                if ((gameBoard[0] == '●' || gameBoard[0] == '★') &&
                    (gameBoard[1] == '●' || gameBoard[1] == '★') &&
                    (gameBoard[2] == '●' || gameBoard[2] == '★') &&
                    (gameBoard[3] == '●' || gameBoard[3] == '★') &&
                    (gameBoard[4] == '●' || gameBoard[4] == '★') &&
                    (gameBoard[5] == '●' || gameBoard[5] == '★') &&
                    (gameBoard[6] == '●' || gameBoard[6] == '★') &&
                    (gameBoard[7] == '●' || gameBoard[7] == '★') &&
                    (gameBoard[8] == '●' || gameBoard[8] == '★'))
                {
                    Console.WriteLine("\n\n\t\t 무 승 부 입 니 다 ! !");
                    break;
                }
                    


                if (playerTurnCount % 2 == 0) {

                    Console.Write("\n\n\n{0}의 턴 : 공격할 칸을 입력하세요 : ", name1);
                    strPlayerChoice = Console.ReadLine();
                    if (!Int32.TryParse(strPlayerChoice, out int x))
                    {
                        Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                        System.Threading.Thread.Sleep(2000);
                        continue;
                    }
                    else
                        intPlayerChoice = Convert.ToInt32(strPlayerChoice);
                    switch (intPlayerChoice)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            if (gameBoard[intPlayerChoice - 1] != '●' && gameBoard[intPlayerChoice - 1] != '★')
                            {
                                gameBoard[intPlayerChoice - 1] = '●';
                                playerTurnCount++;
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                            }
                            break;
                        default:
                            Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                            break;
                    }
                }
                
                    else if(playerTurnCount %2 == 1) { 
                        Console.Write("\n\n\n{0}의 턴 : 공격할 칸을 입력하세요 : ", name2);
                    strPlayerChoice = Console.ReadLine();
                    if (!Int32.TryParse(strPlayerChoice, out int x))
                    {
                        Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                        System.Threading.Thread.Sleep(2000);
                        continue;
                    }
                    else
                        intPlayerChoice = Convert.ToInt32(strPlayerChoice);
                    switch (intPlayerChoice)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            if (gameBoard[intPlayerChoice - 1] != '●' && gameBoard[intPlayerChoice - 1] != '★')
                            {
                                gameBoard[intPlayerChoice - 1] = '★';
                                playerTurnCount++;
                            }
                            else
                            {
                                Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                            }
                            break;
                        default:
                            Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                            break;
                    }
                }
                
            }
            startMenu = new StartMenu();
        }
    }
}
