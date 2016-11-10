using System;
using System.Threading.Tasks;
using HeadphoneDataApp.Model;
using HeadphoneDataApp.Repository;

namespace HeadphoneDataApp.Tests.Mocks
{
    class RepositoryMock : IRepository
    {
        public bool CheckIfUserIsValid(int userId)
        {
            if (userId == 7)
            {
                return true;
            }
            return false;
        }

        public User GetUserById(int userId)
        {
            User u = new User();
            u.FirstName = "koen";
            u.LastName = "castermans";
            u.Password = "d18219f3d7dacf0acfe3a0941f761fd3fa76d39da497eb5bb5abce728484910b5cd8d3eb8a81bc3ce6332bf7b88e380aa9922df150d3bd4e1b1ff58f860751c8";
            u.Role = "admin";
            u.Department = "verkoop";
            u.Sessions = null;
            u.UserId = 7;
            u.Salt = "koen";

            return u;
        }

        public Task<string> sendSession(Session s)
        {
            throw new NotImplementedException();
        }
    }
}
