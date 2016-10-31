using System;
using System.Collections.Generic;
using UWPMonitoring.Domain;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UWPMonitoring.DAL
{
    public class Repository : IRepository
    {
        public List<User> GetAllUsersByRole(string role)
        {
            string url = string.Format("http://127.0.0.1:8181/user/ByRole/{0}", role);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            List<User> users = JsonConvert.DeserializeObject<List<User>>(result);
            return users;
        }

        //Eerst met andere methode controleren of user bestaat
        public User GetUserById(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            User user = JsonConvert.DeserializeObject<User>(result);
            return user;
        }

        //Deze methode gebruiken om te controleren of de user bestaat
        public bool CheckIfUserIsValid(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            return response.IsSuccessStatusCode;

        }

        public int GetAverageTimeForUserId(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/usersession/AverageSessionLength/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            double seconden = JsonConvert.DeserializeObject<double>(result);
            return (int)seconden;
        }

        public int GetMinimalTimeForUserId(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/usersession/MinimalSessionLength/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            int seconden = JsonConvert.DeserializeObject<int>(result);
            return seconden;
        }

        public int GetMaximumTimeForUserId(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/usersession/MaximalSessionLength/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            int seconden = JsonConvert.DeserializeObject<int>(result);
            return seconden;
        }

        public int GetTotalLengthForUserId(int userId)
        {
            string url = string.Format("http://127.0.0.1:8181/usersession/TotalSessionLength/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            int seconden = JsonConvert.DeserializeObject<int>(result);
            return seconden;
        }

        public int RegisterEmployee(User newUser)
        {
            string url = string.Format("http://127.0.0.1:8181/user/");
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpContent json = new StringContent(JsonConvert.SerializeObject(newUser));
            HttpResponseMessage response = Task.Run(() => client.PostAsync(url, json)).Result;
            //response.EnsureSuccessStatusCode();
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            int id = JsonConvert.DeserializeObject<int>(result);
            return id;
        }
    }
}
