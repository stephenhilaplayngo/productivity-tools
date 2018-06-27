using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwianTimer.UWP.ViewModels
{
    public class MainPageViewModel
    {
        public DateTime StartDate { get; set; }

        TimeSpan _timerLength = (TimeSpan)Windows.Storage.ApplicationData.Current.LocalSettings.Values["TimerLength"];

        public TimeSpan TimeRemaining
        {
            get
            {
                return _timerLength - (DateTime.UtcNow - StartDate);
            }
        }

        public int Hours
        {
            get
            {
                return TimeRemaining.Hours;
            }
        }
    }
}
