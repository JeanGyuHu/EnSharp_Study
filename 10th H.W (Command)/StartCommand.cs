using System;
using System.Collections.Generic;
using System.Globalization;
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
            Console.Title = "명령 프롬프트";
            print.StartPhrase();    //맨 처음 알림 말

            while (exitFlag)
            {
                mode = "";
                
                directoryList.Clear();
                //directoryList = operations.FindDirectories(path);

                Console.Write(path + ">");
                command = Console.ReadLine();
                //ReadCommand(directoryList);

                command = command.Replace("/", "\\");         // \뿐만 아니라 /가 들어왔을때도 똑같이 동작하므로 /가 들어왔을때 전부 \로 바꿔준다.
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

                if (Regex.IsMatch(command, @"^[cC][:]$"))
                    mode = Constants.CDRIVE;
                if (Regex.IsMatch(command, @"^[dD][:]$"))
                    mode = Constants.DDRIVE;
                if (Regex.IsMatch(command, @"^[cC][lL][sS]"))      //cls 대소문자 관계없이 일치 확인
                    mode = Constants.CLS;
                else if (Regex.IsMatch(command, @"^[Hh][Ee][lL][pP]"))    //help 대소문자 관계없이 일치 확인
                    mode = Constants.HELP;
                else if (Regex.IsMatch(command, @"^[dD][iI][rR]"))                          //dir 일치 확인
                    mode = Constants.DIR;
                else if (Regex.IsMatch(command, @"^[cC][dD][\\\s.]"))      //cd 일치 확인
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
                        operations.Help(command);
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
                    case Constants.DDRIVE:
                        operations.ChangeDrive(ref path,command,Constants.DDRIVE);
                        break;
                    case Constants.CDRIVE:
                        operations.ChangeDrive(ref path, command,Constants.CDRIVE);
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
        //    var builder = new StringBuilder();
        //    var input = Console.ReadKey(intercept: true);

        //    while (input.Key != ConsoleKey.Enter)
        //    {
        //        if (input.Key == ConsoleKey.Tab)
        //        {
        //            HandleTabInput(builder, commands);
        //        }
        //        else if (input.Key == ConsoleKey.Backspace)
        //        {
        //            if (builder.Length <= 0)
        //                continue;
        //            else
        //                HandleKeyInput(builder, commands, input);
        //        }
        //        else
        //        {
        //            HandleKeyInput(builder, commands, input);
        //        }

        //        input = Console.ReadKey(intercept: true);
        //    }
        //    Console.Write(input.KeyChar);
        //}

        //public void ClearCurrentLine()
        //{
        //    var currentLine = Console.CursorTop;
        //    Console.SetCursorPosition(path.Length + 1, Console.CursorTop);
        //    Console.Write(new string(' ', Console.WindowWidth));
        //    Console.SetCursorPosition(path.Length + 1, currentLine);
        //}

        //public void HandleTabInput(StringBuilder builder, IEnumerable<string> data)
        //{
        //    var currentInput = builder.ToString();

        //    if (Regex.IsMatch(command, @"^[dD][iI][rR]"))                          //dir 일치 확인
        //        currentInput = currentInput.Remove(0, 4);
        //    else if (Regex.IsMatch(command, @"^[cC][dD]"))      //cd 일치 확인
        //        currentInput = currentInput.Remove(0, 3);


        //    var match = data.FirstOrDefault(item => item != currentInput && item.StartsWith(currentInput, true, CultureInfo.InvariantCulture));
        //    if (string.IsNullOrEmpty(match))
        //    {
        //        return;
        //    }

        //    ClearCurrentLine();
        //    builder.Clear();

        //    Console.Write(match);
        //    builder.Append(match);
        //}

        //public void HandleKeyInput(StringBuilder builder, IEnumerable<string> data, ConsoleKeyInfo input)
        //{
        //    var currentInput = builder.ToString();
        //    if (input.Key == ConsoleKey.Backspace && currentInput.Length > 0)
        //    {
        //        builder.Remove(builder.Length - 1, 1);
        //        ClearCurrentLine();

        //        currentInput = currentInput.Remove(currentInput.Length - 1);
        //        Console.Write(currentInput);
        //    }
        //    else
        //    {
        //        var key = input.KeyChar;
        //        builder.Append(key);
        //        Console.Write(key);
        //    }
        //}
    }
}

