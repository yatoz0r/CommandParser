using testParse;

class Program
{
    static void Main()
    {
        var executor = new CommandExecutor();
        var textString = File.ReadAllText("textLine.txt");
        Console.WriteLine($"Start text: {textString}");
        Console.WriteLine($"Start text: {textString}\n");
        Console.WriteLine($"Start text: {textString}\n");
        executor.SetText(textString);
        var fileCommands = File.ReadAllText("commands.txt");
        executor.ExecuteCommand(CommandParser.ParseCommand(executor.Editor, fileCommands));
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}
