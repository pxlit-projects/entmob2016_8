using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace UWPMonitoring.Domain
{

    public class User : INotifyPropertyChanged
    {
        //Variabelen
        private int userId;
        private string password;
        private string firstName;
        private string lastName;
        private string department;
        private string role;

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
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
                RaisePropertyChanged();
            }
        }

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
        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty(PropertyName = "salt")]
        public string Salt { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
                RaisePropertyChanged();
            }
        }

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
