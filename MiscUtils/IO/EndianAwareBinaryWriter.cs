using System;
using System.IO;
using System.Text;

namespace MiscUtils.IO
{
    public class EndianAwareBinaryWriter : BinaryWriter
    {
        public Endianess Endianess { get; }

        #region Constructors
        public EndianAwareBinaryWriter(Stream output, Endianess endianess) : base(output)
        {
            this.Endianess = endianess;
        }

        public EndianAwareBinaryWriter(Stream output, Encoding encoding, Endianess endianess) : base(output, encoding)
        {
            this.Endianess = endianess;
        }

        public EndianAwareBinaryWriter(Stream output, bool leaveOpen, Endianess endianess) : base(output, Encoding.UTF8, leaveOpen)
        {
            this.Endianess = endianess;
        }

        public EndianAwareBinaryWriter(Stream output, Encoding encoding, bool leaveOpen, Endianess endianess) : base(output, encoding, leaveOpen)
        {
            this.Endianess = endianess;
        }

        protected EndianAwareBinaryWriter(Endianess endianess)
        {
            this.Endianess = endianess;
        }
        #endregion

        private void EndianAwareWrite(byte[] bytes)
        {
            if (this.Endianess == Endianess.Little && !BitConverter.IsLittleEndian ||
                this.Endianess == Endianess.Big && BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            this.Write(bytes);
        }

        public override void Write(short value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(int value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(long value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(ushort value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(uint value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(ulong value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(float value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(double value)
        {
            this.EndianAwareWrite(BitConverter.GetBytes(value));
        }

        public override void Write(decimal value)
        {
            byte[] bytes = new byte[sizeof(decimal)];
            int bitsLength = sizeof(decimal) / sizeof(int);
            int[] bits = Decimal.GetBits(value);

            for (int i = 0; i < bitsLength; i++)
            {
                byte[] intBytes = BitConverter.GetBytes(bits[i]);
                for (int j = 0; j < sizeof(int); j++)
                {
                    bytes[(i * sizeof(int)) + j] = intBytes[j];
                }
            }

            this.EndianAwareWrite(bytes);
        }

        public override void Write(string value)
        {
            base.Write(value);
        }
    }
}
