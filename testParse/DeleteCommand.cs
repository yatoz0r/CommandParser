namespace testParse
{
    public class DeleteCommand: ICommand
    {
        private TextEditor _editor;
        private int _idx1, _idx2;
        private string _deletedText;

        public DeleteCommand(TextEditor editor, int idx1, int idx2)
        {
            this._editor = editor;
            this._idx1 = idx1;
            this._idx2 = idx2;
        }

        public void Execute()
        {
            _deletedText = _editor.Text.Substring(_idx1, _idx2 - _idx1);
            _editor.Delete(_idx1, _idx2);
            Console.WriteLine($"Deleted: '{_deletedText}'");
        }

        public void Undo()
        {
            _editor.Text = _editor.Text.Insert(_idx1, _deletedText);
            Console.WriteLine("Undo delete command");
        }

        public void Redo()
        {
            Console.WriteLine("Redo delete command");
            Execute();
        }
    }
}
