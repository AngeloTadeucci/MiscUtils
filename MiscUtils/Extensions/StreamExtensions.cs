using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MiscUtils
{
    public static class StreamExtensions
    {
        public static void CopyTo(this Stream stream, string destinationPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            using (FileStream fs = File.OpenWrite(destinationPath))
            {
                stream.CopyTo(fs);
            }
        }

        public static void CopyTo(this Stream stream, string destinationPath, int bufferSize)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            using (FileStream fs = File.OpenWrite(destinationPath))
            {
                stream.CopyTo(fs, bufferSize);
            }
        }

        public static async Task CopyToAsync(this Stream stream, string destinationPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            using (FileStream fs = File.OpenWrite(destinationPath))
            {
                await stream.CopyToAsync(fs);
            }
        }

        public static async Task CopyToAsync(this Stream stream, string destinationPath, int bufferSize)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            using (FileStream fs = File.OpenWrite(destinationPath))
            {
                await stream.CopyToAsync(fs, bufferSize);
            }
        }

        public static async Task CopyToAsync(this Stream stream, string destinationPath, int bufferSize, CancellationToken cancellationToken)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            using (FileStream fs = File.OpenWrite(destinationPath))
            {
                await stream.CopyToAsync(fs, bufferSize, cancellationToken);
            }
        }
    }
}
