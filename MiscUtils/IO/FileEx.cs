using System.IO;
using System.Threading.Tasks;

namespace MiscUtils.IO;

public class FileEx {
    public static async Task WriteAllBytesAsync(string path, byte[] bytes) {
        await using (FileStream fs = OpenWrite(path)) {
            await fs.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
        }
    }

    public static async Task<byte[]> ReadAllBytesAsync(string path) {
        await using (FileStream fs = File.OpenRead(path)) {
            byte[] result = new byte[fs.Length];

            await fs.ReadAsync(result, 0, result.Length).ConfigureAwait(false);

            return result;
        }
    }

    public static FileStream OpenWrite(string path) {
        return File.Open(path, FileMode.Create, FileAccess.Write, FileShare.Read);
    }

    #region Storage formats
    public static string FormatStorage(short bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(ushort bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(int bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(uint bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(long bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(ulong bytesCount) {
        return FormatStorage((float) bytesCount);
    }
    public static string FormatStorage(float bytesCount) {
        string result;

        if (bytesCount < 1ul << 10) {
            result = $"{bytesCount} B";
        } else if (bytesCount < 1ul << 20) {
            result = $"{bytesCount / (1ul << 10):F3} KiB";
        } else if (bytesCount < 1ul << 30) {
            result = $"{bytesCount / (1ul << 20):F3} MiB";
        } else if (bytesCount < 1ul << 40) {
            result = $"{bytesCount / (1ul << 30):F3} GiB";
        } else {
            result = $"{bytesCount / (1ul << 40):F3} TiB";
        }

        return result;
    }

    public static string FormatStorageSpeed(short bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(ushort bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(int bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(uint bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(long bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(ulong bytesCount) {
        return FormatStorageSpeed((float) bytesCount);
    }
    public static string FormatStorageSpeed(float bytesCount) {
        return FormatStorage(bytesCount) + "/s";
    }
    #endregion
}
