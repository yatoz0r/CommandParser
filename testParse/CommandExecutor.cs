using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testParse
{
    using System.Collections.Generic;
    using static System.Net.Mime.MediaTypeNames;

    public class CommandExecutor
    {
        private Stack<ICommand> undoStack;
        private Stack<ICommand> redoStack;
        private TextEditor editor;

        public CommandExecutor()
        {
            undoStack = new Stack<ICommand>();
            redoStack = new Stack<ICommand>();
            editor = new TextEditor();
        }

        public void ExecuteCommand(ICommand command)
        {
            if (command == null)
            {
                // Обработка undo/redo
                if (undoStack.Count > 0)
                {
                    var lastCommand = undoStack.Pop();
                    lastCommand.Undo();
                    redoStack.Push(lastCommand);
                }
                else if (redoStack.Count > 0)
                {
                    var commandToRedo = redoStack.Pop();
                    commandToRedo.Execute();
                    undoStack.Push(commandToRedo);
                }
            }
            else
            {
                command.Execute();
                undoStack.Push(command);
                redoStack.Clear();
            }
            DisplayState();
        }
        
        public void DisplayState()
        {
            Console.WriteLine($"Current Text: {editor.Text}");
            Console.WriteLine($"Buffer: '{editor.Buffer}'");
            Console.WriteLine($"Undo Stack Count: {undoStack.Count}");
            Console.WriteLine($"Redo Stack Count: {redoStack.Count}");
            Console.WriteLine(new string('-', 40));
        }
        
        public void LoadCommands(IEnumerable<string> commandLines)
        {
            foreach (var line in commandLines)
            {
                var command = CommandParser.ParseCommand(editor, line);
                ExecuteCommand(command);
            }
        }

        public void SetText(string text)
        {
            editor.SetText(text);
        }

        public string GetFinalText()
        {
            return editor.Text;
        }
    }
}
