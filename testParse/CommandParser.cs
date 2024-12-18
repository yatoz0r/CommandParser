namespace testParse
{
    public class CommandParser
    {
        public static List<ICommand> ParseCommand(TextEditor editor, string commands)
        {
            var commandsList = new List<ICommand>();
            var commandLines = commands.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var commandLine in commandLines)
            {
                var parts = commandLine.Trim().Split(' ');
                var commandType = parts[0];

                switch (commandType)
                {
                    case "copy":
                        var copyIndices = parts[1].Split(',');
                        if (copyIndices.Length != 2 ||
                            !int.TryParse(copyIndices[0], out int copyIdx1) ||
                            !int.TryParse(copyIndices[1], out int copyIdx2))
                        {
                            Console.WriteLine("Invalid indices for copy command.");
                            break;
                        }
                        commandsList.Add(new CopyCommand(editor, copyIdx1 - 1, copyIdx2 - 1));
                        break;

                    case "paste":
                        if (!int.TryParse(parts[1], out int pasteIdx))
                        {
                            Console.WriteLine("Invalid index for paste command.");
                            break;
                        }
                        commandsList.Add(new PasteCommand(editor, pasteIdx - 1));
                        break;

                    case "insert":
                        string insertText = parts[1].Trim('"');
                        if (parts.Length < 3 || !int.TryParse(parts[2], out int insertIdx))
                        {
                            Console.WriteLine("Invalid index for insert command.");
                            break;
                        }
                        commandsList.Add(new InsertCommand(editor, insertText, insertIdx - 1));
                        break;

                    case "delete":
                        var deleteIndices = parts[1].Split(',');
                        if (deleteIndices.Length != 2 ||
                            !int.TryParse(deleteIndices[0], out int deleteIdx1) ||
                            !int.TryParse(deleteIndices[1], out int deleteIdx2))
                        {
                            Console.WriteLine("Invalid indices for delete command.");
                            break;
                        }
                        commandsList.Add(new DeleteCommand(editor, deleteIdx1 - 1, deleteIdx2 - 1));
                        break;

                    case "undo":
                        commandsList.Add(new UndoCommand());
                        break;
                    case "redo":
                        commandsList.Add(new RedoCommand());
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {commandType}");
                        break;
                }
                
            }
            return commandsList;
        }
    }
}
