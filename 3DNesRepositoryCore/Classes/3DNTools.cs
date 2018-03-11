using ProtoBuf;
using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesRepositoryCore
{
    public static class _3DNTools
    {
        public static _3DNInfo GetFileInfo(string Path)
        {
            try
            {
                using (var str = File.OpenRead(Path))
                {
                    var model = TypeModel.Create();
                    var data = (_3DNInfo)model.Deserialize(str, null, typeof(_3DNInfo));

                    if (data == null || data.Title != "3dn")
                        return null;

                    return data;
                    //var info = Proto
                }
            }
            catch { return null; }
        }

        public static _3DNInfo GetFileInfo(Stream Content)
        {
            try
            {

                var model = TypeModel.Create();
                var data = (_3DNInfo)model.Deserialize(Content, null, typeof(_3DNInfo));

                if (data == null || data.Title != "3dn")
                    return null;

                return data;
                
            }
            catch { return null; }
        }
    }

    [ProtoContract]
    public class _3DNInfo
    {
        [ProtoMember(1)]
        public string Title { get; set; }
        [ProtoMember(2)]
        public string Version { get; set; }
    }
}
