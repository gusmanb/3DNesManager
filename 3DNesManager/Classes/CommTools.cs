using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static async Task<Remote3DNInfo[]> ListRomFiles(string Prg, string Chr)
        {

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync($"3DN/{Prg}/{Chr}");
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Remote3DNInfo[]>(responseBody);
            }
            catch { return null; }
        }

        public static async Task<byte[]> GetFileContent(Remote3DNInfo Fileinfo)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
                HttpResponseMessage response = await client.GetAsync($"3DN/{Fileinfo.Id}");
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch { return null; }
        }

        public static async Task<bool> CreateUser(string UserName, string LoginName, string Password)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
                var content = new StringContent(JsonConvert.SerializeObject(new UserData { LoginName = LoginName, Password = Password, UserName = UserName }), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsync($"User", content);
                return response.StatusCode == System.Net.HttpStatusCode.NoContent;
            }
            catch { return false; }
        }

        public static async Task<string> LoginUser(string LoginName, string Password)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseAddress);
                AddAuth(client, LoginName, Password);
                HttpResponseMessage response = await client.GetAsync($"User");

                return await response.Content.ReadAsStringAsync();
            }
            catch { return null; }
        }

        private static void AddAuth(HttpClient client, string LoginName, string Password)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{LoginName}:{Password}")));
        }
    }

    public class UserData
    {
        public string UserName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
    }

    public class RomInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Pal PAL { get; set; }
    }

    public class Remote3DNInfo
    {
        [Browsable(false)]
        public string Id { get; set; }
        [ReadOnly(true)]
        public string TypeVersion { get; set; }
        [ReadOnly(true)]
        public string UserName { get; set; }
        [ReadOnly(true)]
        public string Name { get; set; }
        [ReadOnly(true)]
        public DateTime CreationDate { get; set; }
        [ReadOnly(true)]
        public string Notes { get; set; }
        [ReadOnly(true)]
        public bool Official { get; set; }
        [ReadOnly(true)]
        public bool Exact { get; set; }
    }
}
