using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _3DNesManager.Classes
{
    public static class CommTools
    {
        const string baseAddress = "http://localhost:9080/api/";

        public static async Task<RomInfo> GetRomInfo(RomData Data)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"Roms/{Data.PRGSHA}/{Data.CHRSHA}");
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RomInfo>(responseBody);
            }
            catch { return null; }
        }
    }

    public class RomInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Pal PAL { get; set; }
    }

    public class Remote3DNInfo
    {
        public string _3DNVersion { get; set; }
        public string User { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }
        public bool Local { get; set; }
    }
}
