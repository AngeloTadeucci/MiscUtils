using System.IO;
using System.Text;

namespace MiscUtils.IO
{
    public class UnbufferedStreamWriter : TextWriter
    {
        private readonly bool LeaveOpen;

        public Stream Stream { get; }

        public override Encoding Encoding { get; }

        public UnbufferedStreamWriter(Stream stream) : this(stream, Encoding.UTF8)
        {

        }

        public UnbufferedStreamWriter(Stream stream, Encoding encoding) : this(stream, encoding, false)
        {

        }

        public UnbufferedStreamWriter(Stream stream, Encoding encoding, bool leaveOpen)
        {
            this.Stream = stream;
            this.Encoding = encoding;
            this.LeaveOpen = leaveOpen;
        }

        public override void Write(char value)
        {
            byte[] bytes = this.Encoding.GetBytes(new char[] { value });
            this.Stream.Write(bytes, 0, bytes.Length);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!this.LeaveOpen)
                {
                    this.Stream.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
