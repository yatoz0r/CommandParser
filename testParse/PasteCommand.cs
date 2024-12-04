namespace testParse
{
    public class PasteCommand: ICommand
    {
        private TextEditor _editor;
        private int _idx;

        public PasteCommand(TextEditor editor, int idx)
        {
            this._editor = editor;
            this._idx = idx;
        }

        public void Execute()
        {
            _editor.Paste(_idx);
            Console.WriteLine($"Pasted: '{_editor.Buffer}' at index {_idx}");
        }

        public void Undo()
        {
            _editor.Text = _editor.Text.Remove(_idx, _editor.Buffer.Length);
            Console.WriteLine("Undo paste command");
        }

        public void Redo()
        {
            Console.WriteLine("Redo paste command");
            Execute();
        }
    }
}
