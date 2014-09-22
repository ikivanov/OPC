using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OPCAddin
{
    public class Credentials
    {
        public string Username {get; set;}
        public string Password {get; set;}
    }

    public class LoginResult
    {
        public string UserToken { get; set; }

        public string Msg { get; set; }

        public bool Success { get; set; }
    }

    public class ProjectItem
    {
        public bool IsInsering()
        {
            return string.IsNullOrEmpty(this.Id);
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class CreateProjectResult
    {
        public string ProjectId { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }
    }

    public class TransferObject<T>
    {
        public string UserToken { get; set; }
        public T Payload { get; set; }
    }

    public class BackendServiceProxy
    {
        private const string serviceUrl = "http://localhost:1337";

        public static async Task<LoginResult> Login(Credentials credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("/api/login", credentials);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync <LoginResult>();
            }
        }

        public static async Task<CreateProjectResult> CreateProject(string userToken, ProjectItem project)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync("/api/project", new TransferObject<ProjectItem> { UserToken = userToken, Payload = project });
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<CreateProjectResult>();
            }
        }

        public static async Task<CreateProjectResult> UpdateProject(string userToken, ProjectItem project)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("/api/project", new TransferObject<ProjectItem> { UserToken = userToken, Payload = project });
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<CreateProjectResult>();
            }
        }

        public static async Task<CreateProjectResult> DeleteProject(string userToken, ProjectItem project)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(string.Format("/api/{0}/project/{1}", userToken, project.Id));
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<CreateProjectResult>();
            }
        }
    }
}
