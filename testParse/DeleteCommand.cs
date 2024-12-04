namespace testParse
{
    public class DeleteCommand : ICommand
    {
        private TextEditor editor;
        private int idx1, idx2;
        private string deletedText;

        public DeleteCommand(TextEditor editor, int idx1, int idx2)
        {
            this.editor = editor;
            this.idx1 = idx1;
            this.idx2 = idx2;
        }

        public void Execute()
        {
            deletedText = editor.Text.Substring(idx1, idx2 - idx1);
            editor.Text = editor.Text.Remove(idx1, idx2 - idx1);
            Console.WriteLine($"Deleted: '{deletedText}'");
        }

        public void Undo()
        {
            editor.Text = editor.Text.Insert(idx1, deletedText);
            Console.WriteLine("Undo delete command");
        }

        public void Redo()
        {
            Execute();
            Console.WriteLine("Redo delete command");
        }
    }
}
