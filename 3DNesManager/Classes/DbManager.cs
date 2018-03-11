using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesManager.Classes
{
    public static class DbManager
    {
        const string dbName = "roms.db";

        public static void InitDb()
        {
            using (LiteDatabase db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<RomModel>();
                col.EnsureIndex("Id");
                col.EnsureIndex("Prg");
                col.EnsureIndex("Chr");
            }
        }

        public static RomModel FindRom(RomData Data)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<RomModel>();
                return col.FindOne(r => r.PRGSHA == Data.PRGSHA && r.CHRSHA == Data.CHRSHA);
            }
        }

        public static bool AddRom(string RemoteId, string Name, string PRGSHA, string CHRSHA, Pal PAL)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<RomModel>();
                var rom = col.FindOne(r => r.PRGSHA == PRGSHA && r.CHRSHA == CHRSHA);

                if (rom != null)
                    return false;

                col.Insert(new RomModel { RemoteId = RemoteId, Name = Name, PRGSHA = PRGSHA, CHRSHA = CHRSHA, PAL = PAL });
                return true;
            }
        }

        public static bool DeleteRom(string PRGSHA, string CHRSHA, bool PAL)
        {
            using (var db = new LiteDatabase(dbName))
            {
                var col = db.GetCollection<RomModel>();
                var rom = col.FindOne(r => r.PRGSHA == PRGSHA && r.CHRSHA == CHRSHA);

                if (rom == null)
                    return false;

                col.Delete(rom.Id);
                return true;
            }
        }
    }

    public class RomModel
    {
        public ObjectId Id { get; set; }
        public string RemoteId { get; set; }
        public string Name { get; set; }
        public string PRGSHA { get; set; }
        public string CHRSHA { get; set; }
        public Pal PAL { get; set; }
    }

    public enum Pal
    {
        Yes,
        No,
        Unknown
    }
}
