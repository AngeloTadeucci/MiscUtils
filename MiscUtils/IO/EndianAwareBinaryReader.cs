﻿using System;
using System.IO;
using System.Text;

namespace MiscUtils.IO;

public class EndianAwareBinaryReader : BinaryReader {
    public Endianess Endianess { get; }

    private byte[] EndianAwareRead(int count) {
        byte[] bytes = ReadBytes(count);

        if (Endianess == Endianess.Little && !BitConverter.IsLittleEndian ||
            Endianess == Endianess.Big && BitConverter.IsLittleEndian) {
            Array.Reverse(bytes);
        }

        return bytes;
    }

    public override short ReadInt16() {
        return BitConverter.ToInt16(EndianAwareRead(sizeof(short)), 0);
    }

    public override int ReadInt32() {
        return BitConverter.ToInt32(EndianAwareRead(sizeof(int)), 0);
    }

    public override long ReadInt64() {
        return BitConverter.ToInt64(EndianAwareRead(sizeof(long)), 0);
    }

    public override ushort ReadUInt16() {
        return BitConverter.ToUInt16(EndianAwareRead(sizeof(ushort)), 0);
    }

    public override uint ReadUInt32() {
        return BitConverter.ToUInt32(EndianAwareRead(sizeof(uint)), 0);
    }

    public override ulong ReadUInt64() {
        return BitConverter.ToUInt64(EndianAwareRead(sizeof(ulong)), 0);
    }

    public override float ReadSingle() {
        return BitConverter.ToSingle(EndianAwareRead(sizeof(float)), 0);
    }

    public override double ReadDouble() {
        return BitConverter.ToDouble(EndianAwareRead(sizeof(double)), 0);
    }

    public override decimal ReadDecimal() {
        byte[] bytes = EndianAwareRead(sizeof(decimal));
        int bitsLength = sizeof(decimal) / sizeof(int);
        int[] bits = new int[bitsLength];

        for (int i = 0; i < bitsLength; i++) {
            bits[i] = BitConverter.ToInt32(bytes, i * sizeof(int));
        }

        return new decimal(bits);
    }

    public override string ReadString() {
        return base.ReadString();
    }

    #region Constructors
    public EndianAwareBinaryReader(Stream input, Endianess endianess) : base(input) {
        Endianess = endianess;
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding, Endianess endianess) : base(input, encoding) {
        Endianess = endianess;
    }

    public EndianAwareBinaryReader(Stream input, bool leaveOpen, Endianess endianess) : base(input, Encoding.UTF8, leaveOpen) {
        Endianess = endianess;
    }

    public EndianAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen, Endianess endianess) : base(input, encoding, leaveOpen) {
        Endianess = endianess;
    }
    #endregion
}
