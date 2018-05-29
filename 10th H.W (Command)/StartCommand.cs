using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hu_s_Command
{
    class StartCommand
    {
        Operations operations;      //cd, dir, cls, 등등의 기능을 하는 메서드
        List<string> directoryList; //추가기능에 사용하려했으나 실패 ㅜ
        Print print;                //print를 담당하는 메서드
        string path;                //현재 경로
        string command;             //입력 명령어
        string mode;                //어떤 명령어를 수행해야되는지 표시
        bool exitFlag = true;       //while문 flag

        /// <summary>
        /// 기본 생성자 객체들 초기화
        /// </summary>
        public StartCommand()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            operations = new Operations();
            directoryList = new List<string>();
            print = new Print();
        }

        /// <summary>
        /// 프로그램 시작 메서드 여기서 무한루프로 입력을 받고
        /// 입력값에 따라 메서드 호출
        /// </summary>
        public void Waiting()
        {
            print.StartPhrase();    //맨 처음 알림 말

            while (exitFlag)
            {
                mode = "";
                
                //directoryList.Clear();
                //directoryList = operations.FindDirectories(path);

                Console.Write(path + ">");
                command = Console.ReadLine();
                //ReadCommand(directoryList);

                command.Replace("/", "\\");         // \뿐만 아니라 /가 들어왔을때도 똑같이 동작하므로 /가 들어왔을때 전부 \로 바꿔준다.
                if (Regex.IsMatch(command, @"^\s*$"))   //공백이 입력으로 들어왔을때
                    continue;

                //명령어 앞에 있는 공백 제거
                while (true)
                {
                    if (Regex.IsMatch(command, @"^\s"))
                        command = command.Remove(0, 1);
                    if (!command[0].Equals(' '))
                        break;
                }

                if (command.Equals(Constants.CLS, StringComparison.OrdinalIgnoreCase))      //cls 대소문자 관계없이 일치 확인
                    mode = Constants.CLS;
                else if (command.Equals(Constants.HELP, StringComparison.OrdinalIgnoreCase))    //help 대소문자 관계없이 일치 확인
                    mode = Constants.HELP;
                else if (Regex.IsMatch(command, @"^[dD][iI][rR]"))                          //dir 일치 확인
                    mode = Constants.DIR;
                else if (Regex.IsMatch(command, @"^[cC][dD]"))      //cd 일치 확인
                    mode = Constants.CD;
                else if (Regex.IsMatch(command, @"^[cC][oO][pP][yY]"))  //copy 일치 확인
                    mode = Constants.COPY;
                else if (Regex.IsMatch(command, @"^[mM][oO][vV][eE]"))  // move 일치 확인
                    mode = Constants.MOVE;

                switch (mode)
                {
                    case Constants.CLS:
                        operations.Cls();
                        break;
                    case Constants.HELP:
                        operations.Help();
                        break;
                    case Constants.CD:
                        operations.Cd(command, ref path);
                        break;
                    case Constants.COPY:
                        operations.CopyAndMove(command, path,mode);
                        break;
                    case Constants.DIR:
                        operations.Dir(command, path);
                        break;
                    case Constants.MOVE:
                        operations.CopyAndMove(command, path, mode);
                        break;
                    default:
                        print.PrintNotCommand(command);
                        break;
                }
            }
        }

        //public void ReadCommand(List<string> list)
        //{
        //    var commands = list;
        //    bool runningFlag = true;
            
        //    while (runningFlag)
        //    {
        //        var result = ConsoleExt.ReadKey();
        //        switch (result.Key)
        //        {
        //            case ConsoleKey.Enter:
        //                runningFlag = false;
        //                break;
        //            case ConsoleKey.Tab:
        //                string autoCompletedLine =
        //                    AutoComplete.GetComplimentaryAutoComplete(result.LineBeforeKeyPress.LineBeforeCursor,
        //                        commands);
        //                ConsoleExt.SetLine(autoCompletedLine);
        //                break;
        //        }
        //    }
        //}
    }
}

