using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwianTimer.EF;

namespace UwianTimer.UWP.DataAccess
{
    public class START_LOGSDataAccess
    {
        public void AddStartLog(DateTime startTime)
        {
            using (var db = new UwianTimerContext())
            {
                db.START_LOGS.Add(new START_LOGS { StartTime = startTime });

                db.SaveChanges();
            }
        }

        public bool CurrentDayStartLogsExists()
        {
            using (var db = new UwianTimerContext())
            {
                return db.START_LOGS.Any(x => x.StartTime.ToLocalTime().Date == DateTime.Now.Date);
            }
        }

        public DateTime GetActiveStartLogToday()
        {
            using (var db = new UwianTimerContext())
            {
                return db.START_LOGS.Where(x => x.StartTime.ToLocalTime().Date == DateTime.Now.Date && x.IsActive).OrderByDescending(x => x.StartTime).First().StartTime;
            }
        }
    }
}
