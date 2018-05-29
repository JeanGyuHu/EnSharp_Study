
using System;

namespace Hu_s_Command
{
    public class MoveCursorLeftAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            console.CursorPosition = Math.Max(0, console.CursorPosition - 1);
        }
    }
}
