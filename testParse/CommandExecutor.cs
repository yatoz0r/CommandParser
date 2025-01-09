namespace testParse
{
    public class CommandExecutor
    {
        private Stack<ICommand> _undoStack;
        private Stack<ICommand> _redoStack;
        private TextEditor _editor;
        
        public CommandExecutor(TextEditor editor)
        {
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();
            _editor = editor;
        }

        public void ExecuteCommand(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                if (command is UndoCommand)
                {
                    Undo();
                }
                else if (command is RedoCommand)
                {
                    Redo();
                }
                else
                {
                    command.Execute();
                    _undoStack.Push(command);
                    _redoStack.Clear();
                }
                DisplayState();
            }
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var lastCommand = _undoStack.Pop();
                lastCommand.Undo();
                _redoStack.Push(lastCommand);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var commandToRedo = _redoStack.Pop();
                commandToRedo.Redo();
                _undoStack.Push(commandToRedo);
            }
        }

        public void DisplayState()
        {
            Console.WriteLine($"Current Text: {_editor.Text}");
            Console.WriteLine($"Buffer: '{_editor.Buffer}'");
            Console.WriteLine($"Undo Stack Count: {_undoStack.Count}");
            Console.WriteLine($"Redo Stack Count: {_redoStack.Count}");
            Console.WriteLine(new string('-', 40));
        }

        public string GetFinalText()
        {
            return _editor.Text;
        }
    }
}
