
using System;

namespace Hu_s_Command
{
    public class MoveCursorToEndAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            console.CursorPosition = console.CurrentLine.Length;
        }
    }
}
