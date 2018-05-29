namespace Hu_s_Command
{
    public interface IConsole
    {
        PreviousLineBuffer PreviousLineBuffer { get; }
        string CurrentLine { get; set; }
        int CursorPosition { get; set; }
    }
}