
using System;

namespace Hu_s_Command
{
    public class RemovePrecedingAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            if (console.CursorPosition > 0)
            {
                console.CurrentLine = console.CurrentLine.Remove(0, console.CursorPosition);
                console.CursorPosition = 0;
            }
        }
    }
}
