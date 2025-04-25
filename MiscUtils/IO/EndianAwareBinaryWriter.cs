using System;
using System.IO;
using System.Text;

namespace MiscUtils.IO;

public class EndianAwareBinaryWriter : BinaryWriter {
    public Endianess Endianess { get; }

    private void EndianAwareWrite(byte[] bytes) {
        if (Endianess == Endianess.Little && !BitConverter.IsLittleEndian ||
            Endianess == Endianess.Big && BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }

        Write(bytes);
    }

    public override void Write(short value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(int value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(long value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(ushort value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(uint value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(ulong value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(float value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(double value) {
        EndianAwareWrite(BitConverter.GetBytes(value));
    }

    public override void Write(decimal value) {
        byte[] bytes = new byte[sizeof(decimal)];
        int bitsLength = sizeof(decimal) / sizeof(int);
        int[] bits = decimal.GetBits(value);

        for (int i = 0; i < bitsLength; i++) {
            byte[] intBytes = BitConverter.GetBytes(bits[i]);
            for (int j = 0; j < sizeof(int); j++) {
                bytes[i * sizeof(int) + j] = intBytes[j];
            }
        }

        EndianAwareWrite(bytes);
    }

    public override void Write(string value) {
        base.Write(value);
    }

    #region Constructors
    public EndianAwareBinaryWriter(Stream output, Endianess endianess) : base(output) {
        Endianess = endianess;
    }

    public EndianAwareBinaryWriter(Stream output, Encoding encoding, Endianess endianess) : base(output, encoding) {
        Endianess = endianess;
    }

    public EndianAwareBinaryWriter(Stream output, bool leaveOpen, Endianess endianess) : base(output, Encoding.UTF8, leaveOpen) {
        Endianess = endianess;
    }

    public EndianAwareBinaryWriter(Stream output, Encoding encoding, bool leaveOpen, Endianess endianess) : base(output, encoding, leaveOpen) {
        Endianess = endianess;
    }

    protected EndianAwareBinaryWriter(Endianess endianess) {
        Endianess = endianess;
    }
    #endregion
}
