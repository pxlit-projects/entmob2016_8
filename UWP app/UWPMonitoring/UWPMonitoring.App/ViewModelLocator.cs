using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.ViewModels;

namespace UWPMonitoring.App
{
    public class ViewModelLocator
    {
        private static MainViewViewModel mainViewViewModel = new MainViewViewModel();

        public static MainViewViewModel MainViewViewModel
        {
            get
            {
                return mainViewViewModel;
            }
        }
    }
}
