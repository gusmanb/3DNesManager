using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesManager.Classes
{
    public static class RomTools
    {
        public static RomData GetRomInfo(string Path)
        {
            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();

                using (var file = File.OpenRead(Path))
                {
                    byte[] headData = new byte[Marshal.SizeOf(typeof(NESHeader))];
                    file.Read(headData, 0, headData.Length);

                    GCHandle handle = GCHandle.Alloc(headData, GCHandleType.Pinned);
                    NESHeader header = (NESHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(NESHeader));
                    handle.Free();

                    int trainerSize = (header.Flags6 & (byte)Flags6.Trainer) > 0 ? 512 : 0;

                    byte[] prgData = new byte[16384 * header.PRGSize];
                    byte[] chrData = new byte[8192 * header.CHRSize];

                    bool pal = (header.Flags9 & 1) == 1;

                    file.Seek(16 + trainerSize, SeekOrigin.Begin);
                    file.Read(prgData, 0, prgData.Length);

                    file.Read(chrData, 0, chrData.Length);

                    var hash = string.Concat(sha.ComputeHash(file).Select(b => b.ToString("X2")));

                    var prgHash = string.Concat(sha.ComputeHash(prgData).Select(b => b.ToString("X2")));
                    var chrHash = string.Concat(sha.ComputeHash(chrData).Select(b => b.ToString("X2")));

                    RomData data = new RomData { PRGSHA = prgHash, CHRSHA = chrHash };

                    return data;
                }
            }
            catch { return null; }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct NESHeader
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string NESIdentifier;
            public byte PRGSize;
            public byte CHRSize;
            public byte Flags6;
            public byte Flags7;
            public byte PRGRamSize;
            public byte Flags9;
            public byte Flags10;
        }

        [Flags]
        public enum Flags6 : byte
        {
            Mirroring = (1 << 0),
            BackedRam = (1 << 1),
            Trainer = (1 << 2),
            IgnoreRam = (1 << 3),

        }
    }

    public class RomData
    {
        public string PRGSHA { get; set; }
        public string CHRSHA { get; set; }
    }
}
