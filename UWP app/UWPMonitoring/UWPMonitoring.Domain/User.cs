using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UWPMonitoring.Domain
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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

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

        public string Department { get; set; }

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
