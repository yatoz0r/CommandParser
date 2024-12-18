using System.ComponentModel.Design;

namespace testParse
{
    public class CommandExecutor
    {
        private Stack<ICommand> _undoStack;
        private Stack<ICommand> _redoStack;
        private List<ICommand> _commandHistory;
        private TextEditor _editor;
        public TextEditor Editor => _editor;

        public CommandExecutor()
        {
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();
            _editor = new TextEditor();
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

        public void SetText(string text)
        {
            _editor.SetText(text);
        }

        public string GetFinalText()
        {
            return _editor.Text;
        }
    }
}
