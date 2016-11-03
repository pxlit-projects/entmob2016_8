using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadphoneDataApp.Model;
using System.Net;
using System.IO;
using Org.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace HeadphoneDataApp.Repository
{
    public class Repository : IRepository
    {
        public User GetUserById(int userId)
        {
            string url = string.Format("http://192.168.137.1:8181/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            User user = JsonConvert.DeserializeObject<User>(result);
            return user;
        }

        public bool CheckIfUserIsValid(int userId)
        {
            string url = string.Format("http://192.168.137.1:8181/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            return response.IsSuccessStatusCode;
        }

        public async Task<string> sendSession(Session s)
        {
            string url = string.Format("http://192.168.137.1:8181/session");
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(s), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
