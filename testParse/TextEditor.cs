namespace testParse
{
    public class TextEditor
    {
        public string Text { get; set; }
        public string Buffer { get; set; }

        public TextEditor()
        {
            Text = string.Empty;
            Buffer = string.Empty;
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void Copy(int idx1, int idx2)
        {
            Buffer = Text.Substring(idx1, idx2 - idx1);
        }

        public void Paste(int idx)
        {
            Text = Text.Insert(idx, Buffer);
        }

        public void Delete(int idx1, int idx2)
        {
            var deletedText = Text.Substring(idx1, idx2 - idx1);
            Text = Text.Remove(idx1, idx2 - idx1);
        }

        public void Insert(int idx, string text)
        {
            Text = Text.Insert(idx, text);
        }
    }
}
