using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NESDB
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer ser = new XmlSerializer(typeof(database));
            var tr = new StringReader(Properties.Resources.roms);
            var data = (database)ser.Deserialize(tr);

            LiteDatabase db = new LiteDatabase("nesroms.db");

            var col = db.GetCollection<NESRom>();
            //col.EnsureIndex("PAL");
            //col.EnsureIndex("PRGSHA");
            //col.EnsureIndex("CHRSHA");

            //foreach (var game in data.game)
            //{
            //    foreach (var cart in game.cartridge)
            //    {
            //        bool pal = cart.system.Contains("PAL");

            //        var prgSHA = cart.board.prg.sha1;
            //        var chrSHA = cart.board.chr?.sha1 ?? "";

            //        var found = col.Find(r => r.PAL == pal && r.PRGSHA == prgSHA && r.CHRSHA == chrSHA).Any();

            //        if (found)
            //            continue;

            //        NESRom rom = new NESRom { Name = game.name, PAL = pal, PRGSHA = prgSHA, CHRSHA = chrSHA };
            //        col.Insert(rom);
            //    }
            //}

            //db.Dispose();


            SHA1 sha = new SHA1CryptoServiceProvider();

            using (var file = File.OpenRead(@"D:\3DNes\games\Monopoly.nes"))
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

                var rom = col.FindOne(r => r.PRGSHA == prgHash && r.CHRSHA == chrHash);


                //var rom = data.game.Where(g => g.cartridge.Any(c => c.system.Contains(pal ? "PAL" : "NTSC") && c.board.prg.sha1 == prgHash && c.board.chr.sha1 == chrHash)).ToArray();
            }
        }
    }

    class NESRom
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool PAL { get; set; }
        public string PRGSHA { get; set; }
        public string CHRSHA { get; set; }
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
