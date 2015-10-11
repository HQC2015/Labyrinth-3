namespace LabirynthTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class MyTextWriter : TextWriter
    {
        public List<string> messages = new List<string>();

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }

        public override void WriteLine(string msg)
        {
            messages[0] = msg;
            this.Return();
        }

        public string Return()
        {
            return messages[0];
        }
    }
}
