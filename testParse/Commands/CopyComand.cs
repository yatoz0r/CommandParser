namespace testParse
{
    public class CopyCommand: ICommand
    {
        private TextEditor _editor;
        private int _idx1, _idx2;

        public CopyCommand(TextEditor editor, int idx1, int idx2)
        {
            this._editor = editor;
            this._idx1 = idx1;
            this._idx2 = idx2;
        }

        public void Execute()
        {
            _editor.Copy(_idx1, _idx2);
            Console.WriteLine($"Copied: '{_editor.Buffer}'");
        }

        public void Undo()
        {
            _editor.ClearBuffer();
            Console.WriteLine("Undo copy command: buffer cleared.");
        }

        public void Redo()
        {
            Console.WriteLine("Redo copy command");
            Execute();
        }
    }
}
