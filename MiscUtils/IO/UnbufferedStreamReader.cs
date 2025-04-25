using System.IO;

namespace MiscUtils.IO;

public class UnbufferedStreamReader : TextReader {
    private readonly bool LeaveOpen;

    public UnbufferedStreamReader(Stream stream) : this(stream, false) { }

    public UnbufferedStreamReader(Stream stream, bool leaveOpen) {
        Stream = stream;
        LeaveOpen = leaveOpen;
    }

    public Stream Stream { get; }

    public override int Peek() {
        int result = Stream.ReadByte();
        Stream.Position--;

        return result;
    }

    public override int Read() {
        return Stream.ReadByte();
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
