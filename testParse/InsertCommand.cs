using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testParse
{
    public class InsertCommand : ICommand
    {
        private TextEditor editor;
        private string text;
        private int idx;

        public InsertCommand(TextEditor editor, string text, int idx)
        {
            this.editor = editor;
            this.text = text;
            this.idx = idx;
        }

        public void Execute()
        {
            editor.Text = editor.Text.Insert(idx, text);
            Console.WriteLine($"Inserted: '{text}' at index {idx}");
        }

        public void Undo()
        {
            editor.Text = editor.Text.Remove(idx, text.Length);
            Console.WriteLine($"Undo insert command: '{text}'");
        }
    }
}
