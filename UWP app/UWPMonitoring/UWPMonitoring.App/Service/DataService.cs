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

        //Bron voor het omzetten: http://stackoverflow.com/questions/249760/how-to-convert-a-unix-timestamp-to-datetime-and-vice-versa
        public Session GetLastSession(int userId)
        {
            SessionWithLongs sessionLong = repository.GetLastSession(userId);
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            DateTime startTime = dtDateTime.AddMilliseconds(sessionLong.Start_Time).ToLocalTime();
            DateTime endTime = dtDateTime.AddMilliseconds(sessionLong.End_Time).ToLocalTime();

            Session session = new Session();
            session.SessionId = sessionLong.SessionId;
            session.UserId = sessionLong.UserId;
            session.Start_Time = startTime;
            session.End_Time = endTime;
            session.Actual_Time = sessionLong.Actual_Time;

            return session;

        }
    }
}
