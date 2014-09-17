using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OPCAddin
{
    public class Credentials
    {
        public string Usename {get; set;}
        public string Password {get; set;}
    }

    public class BackendServiceProxy
    {
        private const string serviceUrl = "";

        public static async Task<string> Login(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4321/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var credentials = new Credentials() { Usename = "ikivanov", Password = "123" };

                var response = await client.PostAsJsonAsync("login", credentials);
                if (response.IsSuccessStatusCode)
                {
                }

                return "";
            }
        }
    }
}
