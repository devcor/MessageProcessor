using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WordGenerator.Models;

namespace WordGenerator.Business
{
    public class ServiceClient
    {
        private static HttpClient HttpClient = new HttpClient();
        private static bool ServerIsConfigured = false;

        public static void ConsigureServer(string url)
        {
            if (ServerIsConfigured) return;
            HttpClient.BaseAddress = new Uri(url);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServerIsConfigured = true;
        }

        public static async Task<bool> CreateMessageAsync(Message message)
        {            
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync("api/message", message);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
