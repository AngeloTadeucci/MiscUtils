using System.IO;
using System.Text;

namespace MiscUtils.IO;

public class UnbufferedStreamWriter : TextWriter {
    private readonly bool LeaveOpen;

    public UnbufferedStreamWriter(Stream stream) : this(stream, Encoding.UTF8) { }

    public UnbufferedStreamWriter(Stream stream, Encoding encoding) : this(stream, encoding, false) { }

    public UnbufferedStreamWriter(Stream stream, Encoding encoding, bool leaveOpen) {
        Stream = stream;
        Encoding = encoding;
        LeaveOpen = leaveOpen;
    }

    public Stream Stream { get; }

    public override Encoding Encoding { get; }

    public override void Write(char value) {
        byte[] bytes = Encoding.GetBytes(new[] {
            value,
        });
        Stream.Write(bytes, 0, bytes.Length);
    }

    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (!LeaveOpen) {
                Stream.Dispose();
            }
        }

        base.Dispose(disposing);
    }
}
