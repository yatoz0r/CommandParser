using testParse;

class Program
{
    static void Main()
    {
        var executor = new CommandExecutor();
        executor.SetText("Привет, мир!");

        var commands = new List<string>
        {
            "copy 1,3",
            "insert \"hello\" 1",
            "paste 6",
            "undo",
            "redo",
            "delete 2,7",
            "undo",
            "undo",
            "redo",
            "redo"
        };

        executor.LoadCommands(commands);
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}