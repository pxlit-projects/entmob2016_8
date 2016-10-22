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
        

        public List<Session> GetAllSessions()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Session GetSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        public Session GetSessionByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        //Eerst met andere methode controleren of user bestaat
        public User GetUserById(int userId)
        {
            string url = string.Format("http://127.0.0.1/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            string result = Task.Run(() => response.Content.ReadAsStringAsync()).Result;
            User user = JsonConvert.DeserializeObject<User>(result);
            return user;
        }

        //Deze methode gebruiken om te controleren of de user bestaat
        public bool CheckIfUserIsValid(int userId)
        {
            string url = string.Format("http://127.0.0.1/user/{0}", userId);
            Uri uri = new Uri(url);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = Task.Run(() => client.GetAsync(url)).Result;
            return response.IsSuccessStatusCode;
        }

        public User GetUserBySessionId(int sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
