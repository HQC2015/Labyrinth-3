namespace LabirynthTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class MyTextWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }

        public override void WriteLine()
        {
            this.Return("\n");
        }

        public override void WriteLine(string msg)
        {
            this.Return(msg);
        }

        public override void Write(string msg)
        {
            this.Write(msg);
        }

        public string Return(string msg)
        {
            return msg;
        }
    }
}
