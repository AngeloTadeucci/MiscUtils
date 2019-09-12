using System;
using System.IO;
using System.Text;

namespace MiscUtils
{
    public static class BinaryReaderExtensions
    {
        public static string ReadNullTerminatedString(this BinaryReader br)
        {
            var sb = new StringBuilder();

            char c;
            while ((c = br.ReadChar()) != '\0')
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        public static T SetPositionAndRead<T>(this BinaryReader br, long position, Func<T> readFunc)
        {
            br.BaseStream.Position = position;

            return readFunc();
        }
    }
}
