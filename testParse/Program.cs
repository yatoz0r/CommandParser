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
        /*   List<string> commands;

           foreach (var command in fileCommands)
           {
               commands = command;
           }
           *//*v*//*ar commands = new List<string>
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
           };*/

        executor.LoadCommands(commands);
        Console.WriteLine($"Final text: {executor.GetFinalText()}");
    }
}