using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
