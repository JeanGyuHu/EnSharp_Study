using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enjoy_Day2
{
    class VsComputerMode
    {
        private int[] gameBoard;
        private int intTurn;
        private string strTurn;
        private VsComputerMode vsComputer;
        private int intCount=0;

        public VsComputerMode(string playName,ArrayList array)
        {
            gameBoard = new int[9]{ 0,0,0,0,0,0,0,0,0};

            Console.Write("\n\n\t\t선공하시겠습니까? 후공하시겠습니까? (선공 1, 후공 2) : ");
            strTurn = Console.ReadLine();

            if (!Int32.TryParse(strTurn, out int x))
            {
                Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                vsComputer = new VsComputerMode(playName,array);
            }
            else
                intTurn = Convert.ToInt32(strTurn);

            draw(gameBoard);
            switch (intTurn)
            {
                case 1:
                case 2:
                    while (win(gameBoard)==0)
                    {
                        if (gameBoard[0] != 0 && gameBoard[1] != 0 && gameBoard[2] != 0
                            && gameBoard[3] != 0 && gameBoard[4] != 0 && gameBoard[5] != 0
                            && gameBoard[6] != 0 && gameBoard[7] != 0 && gameBoard[8] != 0
                            ) break;

                        if ((intCount + intTurn) % 2 == 0)
                        {
                            computerPlay(gameBoard);
                            System.Threading.Thread.Sleep(500);
                            draw(gameBoard);
                        }
                        else if ((intCount + intTurn) % 2 == 1)
                        {
                            userPlay(gameBoard);
                            draw(gameBoard);
                        }
                        intCount++;
                    }
                        
                    

                    break;
                default:
                    Console.WriteLine("\n\n\t\t잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    vsComputer = new VsComputerMode(playName,array);
                    break;

            }
            switch (win(gameBoard))
            {
                case 0:
                    Console.WriteLine("\n\n\t\t 무 승 부 입 니 다 ! !");
                    System.Threading.Thread.Sleep(1000);
                    break;
                case 1:
                    Console.WriteLine("\n\n\t\t{0} 님 의 패 배 입 니 다 ! !\n\n\n\n\n\n", playName);
                    System.Threading.Thread.Sleep(1000);
                    break;
                case -1:
                    Console.WriteLine("\n\n\t\t{0} 님 의 승 리 입 니 다 ! !\n\n\n\n\n\n", playName);
                    array.Add(playName);
                    System.Threading.Thread.Sleep(1000);
                    break;
            }

        }
        public int minMax(int[] board,int player)
        {
            int move = -1;
            int score = -2;

            if (win(board) != 0) return win(board) * player;

            for(int check =0;check < 9; ++check)
            {
                if (board[check] == 0)
                {
                    board[check] = player;
                    int thisScore = -minMax(board, player * -1);
                    if (thisScore > score)
                    {
                        score = thisScore;
                        move = check;
                    }
                    board[check] = 0;
                }
            }
            if (move == -1) return 0;
            return score;
        }
        public char changeMarker(int num)
        {
            switch (num)
            {
                case -1:
                    return '☆';
                case 0:
                    return '■';
                case 1:
                    return '♡';
            }
            return ' ';
        }
        public void draw(int[] board)
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t유저 : ☆, 컴퓨터 : ♡\n");
            Console.WriteLine("\n\n\t\t{0}\t{1}\t{2}\n\n", changeMarker(gameBoard[0]), changeMarker(gameBoard[1]), changeMarker(gameBoard[2]));
            Console.WriteLine("\t\t{0}\t{1}\t{2}\n\n", changeMarker(gameBoard[3]), changeMarker(gameBoard[4]), changeMarker(gameBoard[5]));
            Console.WriteLine("\t\t{0}\t{1}\t{2}\n\n", changeMarker(gameBoard[6]), changeMarker(gameBoard[7]), changeMarker(gameBoard[8]));
        }
        public int win(int[] board)
        {
            int[,] wins = new int[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };

            for(int check =0;check <8;++check)
            {
                if (board[wins[check, 0]] != 0 && board[wins[check, 0]] == board[wins[check, 1]] && board[wins[check, 0]] == board[wins[check, 2]])
                    return board[wins[check, 2]];
            }
            return 0;
        }

        public void computerPlay (int[] board)
        {
            int move = -1;
            int score = -2;

            for(int check = 0;check < 9; check++)
            {
                if(board[check] == 0)
                {
                    board[check] = 1;
                    int temp = -minMax(board, -1);
                    board[check] = 0;
                    if(temp > score)
                    {
                        score = temp;
                        move = check;
                    }
                }
            }
            if(board[move]==0&&board[move] != -1&&board[move] != 1)
            board[move] = 1;
        }

        public void userPlay(int[] board)
        {
            string strChoice;
            int intChoice=0;

            Console.Write("\n\n\t\t공격할 위치를 말하세요. (1 ~ 9)  : ");
            strChoice = Console.ReadLine();

            if (!Int32.TryParse(strChoice, out int x))
            {
                Console.Clear();
                draw(board);
                userPlay(board);
                return;
            }
            else
            {
                intChoice = Convert.ToInt32(strChoice);
                intChoice--;
            }
            if (intChoice >= 0 && intChoice <= 8)
            {
                if (board[intChoice] == 0 && board[intChoice] != 1 && board[intChoice] != -1)
                    board[intChoice] = -1;
                else
                    userPlay(board);
            }
            else
            {
                Console.WriteLine("\n\n\t\t잘못된 입력입니다.\n");
                Console.Clear();
                draw(board);
                userPlay(board);
            }

        }
    }
}
