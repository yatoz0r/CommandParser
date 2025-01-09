using testParse;

class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var executor = new CommandExecutor(editor);
        var textString = File.ReadAllText("textLine.txt");
        Console.WriteLine($"Start text: {textString}\n");
        editor.SetText(textString);
        var fileCommands = File.ReadAllText("commands.txt");
        executor.ExecuteCommand(CommandParser.ParseCommand(editor, fileCommands));
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}
