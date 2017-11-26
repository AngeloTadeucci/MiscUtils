using System.IO;

namespace MiscUtils.IO
{
    public class UnbufferedStreamReader : TextReader
    {
        private readonly bool LeaveOpen;

        public Stream Stream { get; }

        public UnbufferedStreamReader(Stream stream) : this(stream, false)
        {

        }

        public UnbufferedStreamReader(Stream stream, bool leaveOpen)
        {
            this.Stream = stream;
            this.LeaveOpen = leaveOpen;
        }

        public override int Peek()
        {
            int result = this.Stream.ReadByte();
            this.Stream.Position--;

            return result;
        }

        public override int Read()
        {
            return this.Stream.ReadByte();
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
