using System.IO;
using System.Text;

namespace MiscUtils
{
    public static class BinaryReaderExtensions
    {
        public static string ReadNullTerminatedString(this BinaryReader br)
        {
            StringBuilder sb = new StringBuilder();

            char c;
            while ((c = br.ReadChar()) != '\0')
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
