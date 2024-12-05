using testParse;

class Program
{
    static void Main()
    {
        var executor = new CommandExecutor();
        var textString = File.ReadAllText("textLine.txt");
        Console.WriteLine($"Start text: {textString}\n");
        /*executor.SetText(Console.ReadLine());*/
        executor.SetText(textString);
        var fileCommands = File.ReadAllText("commands.txt");
        var commands = fileCommands.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        executor.LoadCommands(commands);
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}