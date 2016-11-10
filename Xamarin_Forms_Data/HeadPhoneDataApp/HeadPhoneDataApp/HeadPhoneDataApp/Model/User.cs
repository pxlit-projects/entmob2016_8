using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Model
{
    public class User : INotifyPropertyChanged
    {
        //Variabelen
        private int userId;
        private string password;

        //Constructor

        public User()
        {
            Sessions = new List<Session>();
        }

        //Properties
        [JsonProperty(PropertyName = "userId")]
        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [JsonProperty(PropertyName = "password")]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }

        [JsonProperty(PropertyName = "salt")]
        public string Salt { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonIgnore]
        public List<Session> Sessions { get; set; }

        //Implementatie van de Interface 
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
