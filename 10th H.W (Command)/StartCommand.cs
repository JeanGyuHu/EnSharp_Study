using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hu_s_Command
{
    class StartCommand
    {
        Operations operations;
        Print print;
        string path;
        string command;
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

                if (command.Equals(Constants.CLS, StringComparison.OrdinalIgnoreCase))
                    command = Constants.CLS;
                else if (command.Equals(Constants.HELP, StringComparison.OrdinalIgnoreCase))
                    command = Constants.HELP;
                else if (command.Equals(Constants.DIR, StringComparison.OrdinalIgnoreCase))
                    command = Constants.DIR;
                else if (command.Substring(0, 2).Equals(Constants.CD, StringComparison.OrdinalIgnoreCase))
                    command = Constants.CD;

                switch (command)
                {
                    case Constants.CLS:
                        operations.Cls();
                        break;
                    case Constants.HELP:
                        operations.Help();
                        break;
                    case Constants.CD:

                        break;
                    case Constants.COPY:

                        break;
                    case Constants.DIR:

                        break;
                    case Constants.MOVE:

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
