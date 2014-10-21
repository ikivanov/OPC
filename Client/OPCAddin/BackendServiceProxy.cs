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

        public List<TaskItem> Tasks { get; set; }
    }

    public class CreateProjectResult
    {
        public string ProjectId { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }
    }

    public class TaskItem
    {
        public string ProjectId { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public string SchedulePlusPriority { get; set; }
        public int PercentComplete { get; set; }
        public string Body { get; set; }
    }

    public class CreateTaskResult
    {
        public string TaskId { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }
    }

    public class GetAllProjectsResult
    {
        public ProjectItem[] Projects { get; set; }
        public string Msg { get; set; }
        public bool Success { get; set; }
    }

    public class ProjectPlanResult
    {
        public string Data { get; set; }
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
        private static readonly string serviceUrl = AddinModule.CurrentInstance.ServiceUrl;

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

        public static async Task<CreateTaskResult> CreateTask(string userToken, TaskItem task)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PutAsJsonAsync("/api/task", new TransferObject<TaskItem> { UserToken = userToken, Payload = task });
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<CreateTaskResult>();
            }
        }

        public static async Task<GetAllProjectsResult> LookupProjects(string userToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("/api/{0}/projects", userToken));
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<GetAllProjectsResult>();
            }
        }

        public static async Task<GetAllProjectsResult> GetAllProjectsWithChildTasks(string userToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("/api/{0}/projectsWithTasks", userToken));
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<GetAllProjectsResult>();
            }
        }

        public static async Task<ProjectPlanResult> GetProjectsPlan(string userToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("/api/{0}/projectPlan", userToken));
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ProjectPlanResult>();
            }
        }
    }
}
