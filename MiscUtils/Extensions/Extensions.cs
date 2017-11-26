using System;
using System.Text;

namespace MiscUtils
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a byte array to its hex representation as text.
        /// </summary>
        /// <param name="byteArray">The byte array to be converted.</param>
        /// <returns>The hex representation as text of the byte array.</returns>
        public static string ToHexString(this byte[] byteArray)
        {
            return UnsafeByteLookup.ByteArrayToHexViaLookup32UnsafeDirect(byteArray);
        }

        /// <summary>
        /// Converts a byte array to its hex representation as formatted text.
        /// By default, 16 bytes per line are formatted, the line separator is "\n" and values separator is " ".
        /// </summary>
        /// <param name="byteArray">The byte array to be converted.</param>
        /// <param name="bytesPerLine">Optional, the number of bytes formatted to one line of text.</param>
        /// <param name="lineSeparator">Optional, the string that separates the lines.</param>
        /// <param name="valueSeparator">Optional, the string that separates the values.</param>
        /// <returns>The hex representation as formatted text of the byte array.</returns>
        public static string ToFormattedHexString(this byte[] byteArray, byte bytesPerLine = 16, string lineSeparator = "\n", string valueSeparator = " ")
        {
            string hexData = ToHexString(byteArray);
            int arrayLen = hexData.Length;
            var sb = new StringBuilder();

            int i = 0;
            while (i < arrayLen)
            {
                sb.Append(hexData.Substring(i, 2));
                sb.Append(valueSeparator);

                i += 2;
                if (i % bytesPerLine == 0 && i < arrayLen)
                {
                    if (i % (bytesPerLine * 2) == 0)
                    {
                        sb.Append(lineSeparator);
                    }
                    else
                    {
                        sb.Append(valueSeparator);
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts a byte to it's ASCII representation.
        /// </summary>
        /// <param name="b">The byte to be converted.</param>
        /// <returns>An ASCII character.</returns>
        public static char ToAsciiChar(this byte b)
        {
            if (b < 0x20 || b > 0x7E)
            {
                return (char)0x2E;
            }
            else
            {
                return (char)b;
            }
        }

        /// <summary>
        /// Converts a byte array to its hex representation as formatted text.
        /// By default, 16 bytes per line are formatted, the line separator is "\n" and values separator is " ".
        /// </summary>
        /// <param name="byteArray">The byte array to be converted.</param>
        /// <param name="bytesPerLine">Optional, the number of bytes formatted to one line of text.</param>
        /// <param name="lineSeparator">Optional, the string that separates the lines.</param>
        /// <param name="valueSeparator">Optional, the string that separates the values.</param>
        /// <param name="asciiSeparator">Optional, the string that separates the ASCII characters.</param>
        /// <param name="hexAndAsciiSeparator">Optional, the string that separates the hex and ASCII parts.</param>
        /// <returns>The hex representation and ASCII representation as formatted text of the byte array.</returns>
        public static string ToFormattedHexStringWithAscii(this byte[] byteArray, byte bytesPerLine = 16, string lineSeparator = "\n", string valueSeparator = " ", string asciiSeparator = "", string hexAndAsciiSeparator = "| ")
        {
            string formattedHexData = ToFormattedHexString(byteArray, bytesPerLine, lineSeparator, valueSeparator);
            var sbWithAscii = new StringBuilder();

            string[] lines = formattedHexData.Split(new[] { lineSeparator }, StringSplitOptions.None);
            int firstLineLength = 0;

            int i = 0;
            while (i < lines.Length)
            {
                string line = lines[i];
                if (firstLineLength == 0)
                {
                    firstLineLength = line.Length;
                }

                var sbAscii = new StringBuilder();
                for (int j = i++ * bytesPerLine; j < i * bytesPerLine && j < byteArray.Length; j++)
                {
                    sbAscii.Append(byteArray[j].ToAsciiChar());
                    sbAscii.Append(asciiSeparator);
                }

                sbWithAscii.Append(line.PadRight(firstLineLength));
                sbWithAscii.Append(hexAndAsciiSeparator);
                sbWithAscii.Append(sbAscii);
                if (i < lines.Length)
                {
                    sbWithAscii.Append(lineSeparator);
                }
            }

            return sbWithAscii.ToString();
        }
    }
}
