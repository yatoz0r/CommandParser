namespace testParse
{
    public class CommandParser
    {
        public static ICommand ParseCommand(TextEditor editor, string line)
        {
            var parts = line.Trim().Split(' ');
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
                        return null;
                    }
                    return new CopyCommand(editor, copyIdx1, copyIdx2);

                case "paste":
                    if (!int.TryParse(parts[1], out int pasteIdx))
                    {
                        Console.WriteLine("Invalid index for paste command.");
                        return null;
                    }
                    return new PasteCommand(editor, pasteIdx);

                case "insert":
                    string insertText = parts[1].Trim('"');
                    if (parts.Length < 3 || !int.TryParse(parts[2], out int insertIdx))
                    {
                        Console.WriteLine("Invalid index for insert command.");
                        return null;
                    }
                    return new InsertCommand(editor, insertText, insertIdx);

                case "delete":
                    var deleteIndices = parts[1].Split(',');
                    if (deleteIndices.Length != 2 ||
                        !int.TryParse(deleteIndices[0], out int deleteIdx1) ||
                        !int.TryParse(deleteIndices[1], out int deleteIdx2))
                    {
                        Console.WriteLine("Invalid indices for delete command.");
                        return null;
                    }
                    return new DeleteCommand(editor, deleteIdx1, deleteIdx2);

                case "undo":
                    return null; // Предполагается, что у вас есть класс UndoCommand

                case "redo":
                    return null; // Предполагается, что у вас есть класс RedoCommand

                default:
                    Console.WriteLine($"Unknown command: {commandType}");
                    break;
            }
            return null;
        }
    }
}
