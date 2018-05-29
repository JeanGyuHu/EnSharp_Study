
using System;

namespace Hu_s_Command
{
    public class ClearLineAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            console.CurrentLine = string.Empty;
            console.CursorPosition = 0;
        }
    }
}
