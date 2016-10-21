using GalaSoft.MvvmLight.Messaging;
using Java.Util;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class DeviceServiceViewModel: INotifyPropertyChanged
    {
        private IAdapter adapter;
        private IDevice device;
        private ObservableCollection<IService> services;
        private string deviceName;

        
        /** Data UUID. */
        private static string UUID_DATA = "f000aa81-0451-4000-b000-000000000000";
        /** Configuration UUID. */
        private static string UUID_CONFIG = "f000aa82-0451-4000-b000-000000000000";
        /** Period UUID. */
        private static string UUID_PERIOD = "f000aa83-0451-4000-b000-000000000000";


        public event PropertyChangedEventHandler PropertyChanged;

        public DeviceServiceViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            Messenger.Default.Register<IDevice>(this, DeviceMessage);
            this.services = new ObservableCollection<IService>();


            this.GetServicesCommand = new Command(() =>
            {
                if (services != null)
                {
                    IService accelerometerService = null;
                    //Zoeken naar de juiste juiste service met de acc. data
                    foreach (var item in services)
                    {
                        if (item.Characteristics[0].Uuid == UUID_DATA)
                        {
                            accelerometerService = item;
                        }
                    }
                    if (accelerometerService!=null)
                    {
                        var x = accelerometerService.ToString();
                        Debug.WriteLine("juiste service is gevonden");
                    }
                    
                }
                else
                {
                    Debug.WriteLine("Geen services gevonden");
                }
            });

        }

        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }

        private void DeviceMessage(IDevice obj)
        {
            this.device = obj;
            ScanForServices();
            DeviceName = device.Name;
        }

        public void ScanForServices()
        {
            Debug.WriteLine("***Scan for Services***");

            if (services.Count == 0)
            {
                Debug.WriteLine("No services, attempting to connect to device");
                // start looking for the device
                adapter.ConnectToDevice(device);
            }

            //device.DiscoverServices();
            //var test = device.State;
            adapter.DeviceConnected += (s, e) =>
            {
                device = e.Device; // do we need to overwrite this?
                Debug.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                //when services are discovered
                device.ServicesDiscovered += (object se, EventArgs ea) =>
                {
                    Debug.WriteLine("device.ServicesDiscovered");
                    //services = (List<IService>)device.Services;
                    if (services.Count == 0)
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            foreach (var service in device.Services)
                            {
                                services.Add(service);
                            }
                        });
                };
                // start looking for services
                device.DiscoverServices();

            };
            
            //adapter.ConnectToDevice(device);
            
        }

        public string DeviceName
        {
            get
            {
                return deviceName;
            }
            set
            {
                if (deviceName != value)
                {
                    deviceName = value;
                    OnPropertyChanged("DeviceName");
                }
            }
        }

        public Command GetServicesCommand { get; private set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
