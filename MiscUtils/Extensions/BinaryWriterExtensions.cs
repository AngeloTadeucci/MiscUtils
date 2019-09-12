using System;
using System.IO;

namespace MiscUtils
{
    public static class BinaryWriterExtensions
    {
        public static void SetPositionAndWrite<T>(this BinaryWriter bw, long position, Action<T> writeFunc, T value)
        {
            bw.BaseStream.Position = position;

            writeFunc(value);
        }
    }
}
