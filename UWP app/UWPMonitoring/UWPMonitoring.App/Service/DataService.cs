using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Utility;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.Service
{
    public class DataService : IDataService
    {
        //Variabelen
        private IRepository repository;
        private string message;
        private User retrievedUser = new User();

        //Properties
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public User RetrievedUser
        {
            get
            {
                return retrievedUser;
            }
        }

        //Constructor
        public DataService(IRepository repository)
        {
            this.repository = repository;
        }

        
        //Methodes voor controle van login
        public bool Login(User user)
        {
            bool userExists = repository.CheckIfUserIsValid(user.UserId);

            if (userExists)
            {
                retrievedUser = repository.GetUserById(user.UserId);
                bool passwordCorrect = CheckUserPassword(retrievedUser, user);

                if (retrievedUser.Role == "admin")
                {
                    if (passwordCorrect)
                    {
                        return true;
                    }
                    else
                    {
                        Message = "Dit is geen geldig wachtwoord.";
                        retrievedUser = new User();
                        return false;
                    }
                }
                else
                {
                    Message = "Deze gebruiker heeft geen admin rechten.";
                    retrievedUser = new User();
                    return false;
                }

            }
            else
            {
                Message = "Het ingevulde id bestaat niet.";
                return false;
            }
        }

        private bool CheckUserPassword(User retrievedUser, User user)
        {
            string password = user.Password; //Wachtwoord die de gebruiker heeft ingegeven
            string salt = retrievedUser.Salt; //Salt van het opgehaalde user object
            string hashedPasswordWithSalt = Hasher.ConvertStringToHash(password, salt);
            bool passwordCorrect = hashedPasswordWithSalt.Equals(retrievedUser.Password);
            return passwordCorrect;

        }


        public Session GetLastSession(int userId)
        {
            SessionWithLongs sessionLong = repository.GetLastSession(userId);
            return sessionLong.ToNormalSession();
        }

        public List<User> GetAllUsersByRole(string role)
        {
            return repository.GetAllUsersByRole(role);
        }

        public int GetAverageTimeForUserId(int userId)
        {
            return repository.GetAverageTimeForUserId(userId);
        }

        public int GetMinimalTimeForUserId(int userId)
        {
            return repository.GetMinimalTimeForUserId(userId);
        }

        public int GetMaximumTimeForUserId(int userId)
        {
            return repository.GetMaximumTimeForUserId(userId);
        }

        public int GetTotalLengthForUserId(int userId)
        {
            return repository.GetTotalLengthForUserId(userId);
        }

        public int RegisterEmployee(User newUser)
        {
            return repository.RegisterEmployee(newUser);
        }
    }
}
