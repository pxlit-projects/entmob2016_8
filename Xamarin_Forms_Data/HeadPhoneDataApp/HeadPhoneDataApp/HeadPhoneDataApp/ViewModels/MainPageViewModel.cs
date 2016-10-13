using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModels
{

    public class MainPageViewModel: INotifyPropertyChanged
    {
        private IAdapter adapter;
        private ObservableCollection<IDevice> devices;

        public event PropertyChangedEventHandler PropertyChanged;

        
        public MainPageViewModel(IAdapter adapter)
        {
            this.adapter = adapter;
            this.devices = new ObservableCollection<IDevice>();

            this.ScanCommand = new Command(() =>
            {
                StartScanning(0x180D.UuidFromPartial());
            });
        }

        void StartScanning()
        {
            StartScanning(Guid.Empty);
        }
        void StartScanning(Guid forService)
        {
            if (adapter.IsScanning)
            {
                adapter.StopScanningForDevices();
                Debug.WriteLine("adapter.StopScanningForDevices()");
            }
            else
            {
                devices.Clear();
                adapter.StartScanningForDevices(forService);
                Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
            }
        }

        public ICommand ScanCommand { protected set; get; }

        
    }
}
