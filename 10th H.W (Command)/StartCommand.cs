using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hu_s_Command
{
    class StartCommand
    {
        Operations operations;
        Print print;
        string path;
        string command;
        string mode;
        bool exitFlag = true;

        public StartCommand()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            operations = new Operations();
            print = new Print();
        }

        public void Waiting()
        {
            print.StartPhrase();

            while (exitFlag)
            {
                Console.Write(path +">");
                command = Console.ReadLine();

                if (Regex.IsMatch(command, @"^\s*$"))
                    continue;
                while (true)
                {
                    if (Regex.IsMatch(command, @"^\s"))
                        command = command.Remove(0,1);
                    if (!command[0].Equals(' '))
                        break;
                }

                if (command.Equals(Constants.CLS, StringComparison.OrdinalIgnoreCase))
                    mode = Constants.CLS;
                else if (command.Equals(Constants.HELP, StringComparison.OrdinalIgnoreCase))
                    mode = Constants.HELP;
                else if (command.Equals(Constants.DIR, StringComparison.OrdinalIgnoreCase))
                    mode = Constants.DIR;
                else if (Regex.IsMatch(command, @"[cC][dD]"))
                    mode = Constants.CD;

                switch (mode)
                {
                    case Constants.CLS:
                        operations.Cls();
                        break;
                    case Constants.HELP:
                        operations.Help();
                        break;
                    case Constants.CD:
                        operations.Cd(command,ref path);
                        break;
                    case Constants.COPY:

                        break;
                    case Constants.DIR:
                        operations.Dir(path);
                        break;
                    case Constants.MOVE:

                        break;
                    default:
                        print.PrintNotCommand(command);
                        break;
                }
            }
        }
    }
}
