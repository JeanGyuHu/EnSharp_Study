using System;

namespace Hu_s_Command
{
    public interface IConsoleAction
    {
        void Execute(IConsole console, ConsoleKeyInfo consoleKeyInfo);
    }
}