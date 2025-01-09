namespace testParse
{
    public class TextEditor
    {
        private string _text;
        private string _buffer;
        public string Text => _text;
        public string Buffer => _buffer;

        public TextEditor()
        {
            _text = string.Empty;
            _buffer = string.Empty;
        }

        public void SetText(string text) => _text = text;

        public void ClearBuffer() => _buffer = string.Empty;

        public void Copy(int idx1, int idx2) => _buffer = _text.Substring(idx1, idx2 - idx1);

        public void Paste(int idx)  => _text = _text.Insert(idx, Buffer);

        public void Delete(int idx1, int idx2)
        {
            var deletedText = _text.Substring(idx1, idx2 - idx1);
            _text = _text.Remove(idx1, idx2 - idx1);
        }

        public void Insert(int idx, string text) => _text = _text.Insert(idx, text);
    }
}
