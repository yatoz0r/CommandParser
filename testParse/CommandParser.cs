namespace testParse
{
    public class CommandParser
    {
        public static ICommand ParseCommand(TextEditor editor, string line)
        {
            var parts = line.Trim().Split(' ');
            var commandType = parts[0];

            if (commandType == "copy")
            {
                var indices = parts[1].Split(',');
                if (indices.Length != 2 || !int.TryParse(indices[0], out int idx1) || !int.TryParse(indices[1], out int idx2))
                {
                    throw new ArgumentException("Invalid indices for copy command.");
                }
                return new CopyCommand(editor, idx1, idx2);
            }
            else if (commandType == "paste")
            {
                if (!int.TryParse(parts[1], out int idx))
                {
                    throw new ArgumentException("Invalid index for paste command.");
                }
                return new PasteCommand(editor, idx);
            }
            else if (commandType == "insert")
            {
                string text = parts[1].Trim('"');
                if (parts.Length < 3 || !int.TryParse(parts[2], out int idx))
                {
                    throw new ArgumentException("Invalid index for insert command.");
                }
                return new InsertCommand(editor, text, idx);
            }
            else if (commandType == "delete")
            {
                var indices = parts[1].Split(',');
                if (indices.Length != 2 || !int.TryParse(indices[0], out int idx1) || !int.TryParse(indices[1], out int idx2))
                {
                    throw new ArgumentException("Invalid indices for delete command.");
                }
                return new DeleteCommand(editor, idx1, idx2);
            }
            else if (commandType == "undo")
            {
                return null; // специальный случай для undo
            }
            else if (commandType == "redo")
            {
                return null; // специальный случай для redo
            }
            else
            {
                throw new ArgumentException($"Unknown command: {commandType}");
            }
        }
    }
}
