using System;
using System.Runtime.InteropServices;

namespace MiscUtils;

/// <summary>
///     Lookup by byte unsafe (via CodesInChaos)
///     http://stackoverflow.com/questions/311165/how-do-you-convert-byte-array-to-hexadecimal-string-and-vice-versa/24343727#24343727
/// </summary>
internal unsafe class UnsafeByteLookup {
    private static readonly uint[] _lookup32Unsafe = CreateLookup32Unsafe();
    private static readonly uint* _lookup32UnsafeP = (uint*) GCHandle.Alloc(_lookup32Unsafe, GCHandleType.Pinned).AddrOfPinnedObject();

    private static uint[] CreateLookup32Unsafe() {
        uint[] result = new uint[256];

        for (int i = 0; i < 256; i++) {
            string s = i.ToString("X2");

            if (BitConverter.IsLittleEndian) {
                result[i] = s[0] + ((uint) s[1] << 16);
            } else {
                result[i] = s[1] + ((uint) s[0] << 16);
            }
        }

        return result;
    }

    internal static string ByteArrayToHexViaLookup32UnsafeDirect(byte[] bytes) {
        uint* lookupP = _lookup32UnsafeP;
        int arrayLen = bytes.Length;
        string result = new string((char) 0, arrayLen * 2);

        fixed (byte* bytesP = bytes)
        fixed (char* resultP = result) {
            uint* resultP2 = (uint*) resultP;

            for (int i = 0; i < arrayLen; i++) {
                resultP2[i] = lookupP[bytesP[i]];
            }
        }

        return result;
    }
}
