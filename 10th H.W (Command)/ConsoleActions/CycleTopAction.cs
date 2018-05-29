
using System;

namespace Hu_s_Command
{
    public class CycleTopAction : IConsoleAction
    {
        public void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo)
        {
            if (!console.PreviousLineBuffer.CycleTop())
                return;
            console.CurrentLine = console.PreviousLineBuffer.LineAtIndex;
            console.CursorPosition = console.CurrentLine.Length;
        }
    }
}
