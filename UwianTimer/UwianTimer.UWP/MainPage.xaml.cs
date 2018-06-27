using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UwianTimer.UWP.DataAccess;
using UwianTimer.UWP.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UwianTimer.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainPageViewModel model;
        START_LOGSDataAccess startLogsDataAccess;

        public MainPage()
        {
            this.InitializeComponent();

            model = new MainPageViewModel();

            startLogsDataAccess = new START_LOGSDataAccess();

            if (!startLogsDataAccess.CurrentDayStartLogsExists())
            {
                model.StartDate = DateTime.UtcNow;
                startLogsDataAccess.AddStartLog(model.StartDate);
            }
            else
            {
                model.StartDate = startLogsDataAccess.GetActiveStartLogToday();
            }

            this.DataContext = model;
        }
    }
}
