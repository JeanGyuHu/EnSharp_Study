
using System;

namespace Hu_s_Command
{
    public class MoveCursorToBeginAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            console.CursorPosition = 0;
        }
    }
}
