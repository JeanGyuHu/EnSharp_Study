
using System;

namespace Hu_s_Command
{
    public class IgnoreAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            // Do nothing. "Ignore" the command
        }
    }
}
