using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore
{
    public static class DbManager
    {
        public static void InitDb()
        {
            if (!File.Exists("nesroms.db"))
            {
                using (var db = File.Create("nesroms.db"))
                {
                    var assembly = typeof(Program).GetTypeInfo().Assembly;

                    using (var resource = assembly.GetManifestResourceStream("3DNesRepositoryCore.Resources.nesroms.db"))
                        resource.CopyTo(db);

                }

                using (var db = new LiteDatabase("nesroms.db"))
                {
                    var users = db.GetCollection<User>();
                    users.EnsureIndex("UserName", true);
                    users.EnsureIndex("LoginName", true);
                    users.EnsureIndex("Password", false);
                    var infos = db.GetCollection<_3DNFileInfo>();
                    infos.EnsureIndex("RomId");
                    var files = db.GetCollection<_3DNFile>();
                    users.EnsureIndex("InfoId", true);
                }
            }
        }

        #region Rom Functions

        public static NESRom FindRom(string PRGSHA, string CHRSHA)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<NESRom>();
                var exact = col.FindOne(r => r.PRGSHA == PRGSHA && r.CHRSHA == CHRSHA);

                if (exact != null)
                    return exact;

                var res = col.FindOne(r => r.PRGSHA == PRGSHA);

                if (res != null)
                    res.PAL = null;

                return res;
            }
        }

        public static bool AddRom(string Name, string PRGSHA, string CHRSHA, bool PAL)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<NESRom>();
                var rom = col.FindOne(r => r.PRGSHA == PRGSHA && r.CHRSHA == CHRSHA);

                if (rom != null)
                    return false;

                col.Insert(new NESRom { Name = Name, PRGSHA = PRGSHA, CHRSHA = CHRSHA, PAL = PAL });
                return true;
            }
        }

        public static bool DeleteRom(string PRGSHA, string CHRSHA, bool PAL)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<NESRom>();
                var rom = col.FindOne(r => r.PRGSHA == PRGSHA && r.CHRSHA == CHRSHA);

                if (rom == null)
                    return false;

                col.Delete(rom.Id);
                return true;
            }
        }

        #endregion

        #region User functions

        public static User FindUser(string LoginName, string Password)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<User>();
                return col.FindOne(u => u.LoginName == LoginName && u.Password == Password);
            }
        }

        public static bool AddUser(string UserName, string LoginName, string Password, bool Admin)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<User>();
                var exists = col.Exists(u => u.LoginName == LoginName || u.UserName == UserName);

                if (exists)
                    return false;

                col.Insert(new User { UserName = UserName, LoginName = LoginName, Password = Password });

                return true;
            }
        }

        public static bool DeleteUser(string LoginName)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<User>();

                int deleted = col.Delete(u => u.LoginName == LoginName);

                return deleted > 0;
            }
        }

        #endregion

        #region 3DN Functions

        public static List<_3DNFileInfo> ListFiles(string Prg)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var infoCol = db.GetCollection<_3DNFileInfo>();
                var romCol = db.GetCollection<NESRom>();

                List<_3DNFileInfo> infos = new List<_3DNFileInfo>();

                var roms = romCol.Find(r => r.PRGSHA == Prg).ToArray();

                if (roms.Length == 0)
                    return infos;


                foreach (var rom in roms)
                {
                    infos.AddRange( infoCol
                        .Include(i => i.Creator)
                        .Include(i => i.Rom)
                        .Find(i => i.Rom.Id == rom.Id));
                }

                return infos;
            }
        }

        public static _3DNFile GetFile(string Id)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var col = db.GetCollection<_3DNFile>();
                ObjectId id = new ObjectId(Id);
                return col.FindById(id);
            }
        }

        public static bool CreateFile(string OwnerLoginName, string Prg, string Chr, string Name, string Notes, bool Official, byte[] Content)
        {

            MemoryStream ms = new MemoryStream(Content);
            var info = _3DNTools.GetFileInfo(ms);
            ms.Dispose();

            if (info == null || info.Title != "3dn")
                return false;

            using (var db = new LiteDatabase("nesroms.db"))
            {
                var users = db.GetCollection<User>();
                var roms = db.GetCollection<NESRom>();
                var infos = db.GetCollection<_3DNFileInfo>();
                var files = db.GetCollection<_3DNFile>();

                var user = users.FindOne(u => u.LoginName == OwnerLoginName);

                if (user == null)
                    return false;

                var rom = roms.FindOne(r => r.PRGSHA == Prg && r.CHRSHA == Chr);

                if (rom == null)
                    return false;

                var exist = infos.Exists(i => i.Creator.Id == user.Id && i.Rom.Id == rom.Id);

                if (exist)
                    return false;

                var newInfo = new _3DNFileInfo { CreationDate = DateTime.Now, Creator = user, Name = Name, Notes = Notes, Official = Official, Rom = rom, TypeVersion = info.Version };
                infos.Insert(newInfo);
                files.Insert(new _3DNFile { Info = newInfo, Content = Content });

                return true;
            }
        }

        public static bool UpdateFile(string OwnerLoginName, string Prg, string Chr, string Name, string Notes, bool Official, byte[] Content)
        {
            string ver = null;

            if (Content != null)
            {
                MemoryStream ms = new MemoryStream(Content);
                var info = _3DNTools.GetFileInfo(ms);
                ms.Dispose();

                if (info == null || info.Title != "3dn")
                    return false;

                ver = info.Version;

            }

            using (var db = new LiteDatabase("nesroms.db"))
            {
                var infos = db.GetCollection<_3DNFileInfo>();

                var actualInfo = infos.FindOne(i => i.Rom.PRGSHA == Prg && i.Rom.CHRSHA == Chr && i.Creator.LoginName == OwnerLoginName);

                if (actualInfo == null)
                    return false;

                if (actualInfo.Creator.LoginName != OwnerLoginName)
                    return false;

                actualInfo.Name = Name;
                actualInfo.Notes = Notes;
                actualInfo.Official = Official;
                actualInfo.CreationDate = DateTime.Now;

                if (Content != null)
                    actualInfo.TypeVersion = ver;

                if (!infos.Update(actualInfo))
                    return false;

                if (Content != null)
                {
                    var files = db.GetCollection<_3DNFile>();

                    var file = files.FindOne(f => f.Info.Id == actualInfo.Id);

                    if (file == null)
                        return false;

                    file.Content = Content;

                    return files.Update(file);
                }
                
                return true;
            }
        }

        public static bool DeleteFile(string Id)
        {
            using (var db = new LiteDatabase("nesroms.db"))
            {
                var infos = db.GetCollection<_3DNFileInfo>();
                var files = db.GetCollection<_3DNFile>();

                ObjectId id = new ObjectId(Id);

                files.Delete(f => f.Info.Id == id);
                infos.Delete(id);
                return true;
            }
        }

        #endregion

    }

    public class NESRom
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool? PAL { get; set; }
        public string PRGSHA { get; set; }
        public string CHRSHA { get; set; }
    }

    public class User
    {
        public ObjectId Id { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
    
    public class _3DNFileInfo
    {
        public ObjectId Id { get; set; }
        [BsonRef("NESRom")]
        public NESRom Rom { get; set; }
        [BsonRef("User")]
        public User Creator { get; set; }
        public string TypeVersion { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public bool Official { get; set; }
    }

    public class _3DNFile
    {
        public ObjectId Id { get; set; }
        [BsonRef("_3DNFileInfo")]
        public _3DNFileInfo Info { get; set; }
        public byte[] Content { get; set; }
    }
}
