using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPMonitoring.App.Utility;

namespace UWPMonitoring.Test.Mocks
{
    public class NavigationServiceMock : INavigationService
    {
        public string Key { get; set; }

        public void NavigateTo(string key)
        {
            Key = key;
        }
    }
}
