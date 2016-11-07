using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.DAL;
using UWPMonitoring.Domain;

namespace UWPMonitoring.App.Service
{
    public class DataService : IDataService
    {
        private IRepository repository;

        public DataService(IRepository repository)
        {
            this.repository = repository;
        }

        public Session GetLastSession(int userId)
        {
            SessionWithLongs sessionLong = repository.GetLastSession(userId);
            return sessionLong.ToNormalSession();
        }
    }
}
