namespace testParse
{
    public class InsertCommand: ICommand
    {
        private TextEditor _editor;
        private string _text;
        private int _idx;
        private string _deletedText;

        public InsertCommand(TextEditor editor, string text, int idx)
        {
            this._editor = editor;
            this._text = text;
            this._idx = idx;
        }

        public void Execute()
        {
            _deletedText = _editor.Text;
            _editor.Insert(_idx, _text);
            Console.WriteLine($"Inserted: '{_text}' at index {_idx}");
        }

        public void Undo()
        {
            _editor.SetText(_deletedText);
            Console.WriteLine($"Undo insert command: '{_text}'");
        }

        public void Redo()
        {
            Console.WriteLine("Redo insert command");
            Execute();
        }
    }
}
