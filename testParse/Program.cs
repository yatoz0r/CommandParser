using testParse;

class Program
{
    static void Main()
    {
        var executor = new CommandExecutor();
        Console.WriteLine("Напишите строку: ");
        executor.SetText(Console.ReadLine());
        var fileCommands = File.ReadAllText("commands.txt");
        var commands = fileCommands.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        executor.LoadCommands(commands);
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}