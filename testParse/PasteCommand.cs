using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testParse
{
    public class PasteCommand : ICommand
    {
        private TextEditor editor;
        private int idx;

        public PasteCommand(TextEditor editor, int idx)
        {
            this.editor = editor;
            this.idx = idx;
        }

        public void Execute()
        {
            editor.Text = editor.Text.Insert(idx, editor.Buffer);
            Console.WriteLine($"Pasted: '{editor.Buffer}' at index {idx}");
        }

        public void Undo()
        {
            editor.Text = editor.Text.Remove(idx, editor.Buffer.Length);
            Console.WriteLine("Undo paste command");
        }

        public void Redo()
        {
            Execute();
            Console.WriteLine("Redo paste command");
        }
    }
}
