using HeadphoneDataApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneDataApp.Repository
{
    interface IRepository
    {
        User GetUserById(int userId);
        bool CheckIfUserIsValid(int userId);
        Task<string> sendSession(Session s);
    }
}
