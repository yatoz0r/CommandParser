using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testParse
{
    public class CopyCommand : ICommand
    {
        private TextEditor editor;
        private int idx1, idx2;
        private string buffer;

        public CopyCommand(TextEditor editor, int idx1, int idx2)
        {
            this.editor = editor;
            this.idx1 = idx1;
            this.idx2 = idx2;
        }

        public void Execute()
        {
            buffer = editor.Text.Substring(idx1, idx2 - idx1);
            editor.Buffer = buffer;
            Console.WriteLine($"Copied: '{buffer}'");
        }

        public void Undo()
        {
            editor.Buffer = string.Empty;
            Console.WriteLine("Undo copy command: buffer cleared.");
        }

        public void Redo()
        {
            Execute();
            Console.WriteLine("Redo copy command");
        }
    }
}
