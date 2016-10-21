using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using HeadphoneDataApp.View;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace HeadphoneDataApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //public MainViewModel()
        //{
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}


        private IAdapter adapter;
        private string deviceName;
        ObservableCollection<IService> services;

        private ObservableCollection<IDevice> devices;
        public event PropertyChangedEventHandler PropertyChanged;

        private Command _selectedDeviceCommand;

        public ObservableCollection<IDevice> Devices
        {
            get
            {
                return devices;
            }
            set
            {
                devices = value;
                OnPropertyChanged("Devices");
            }
        }

        public MainViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, Adapter);
            devices = new ObservableCollection<IDevice>();
            this.services = new ObservableCollection<IService>();


            //navigation

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

        private void Adapter(IAdapter obj)
        {
            this.adapter = obj;
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    devices.Add(e.Device);
                    Devices = devices;
                    DeviceName = e.Device.Name;
                });
            };

            adapter.ScanTimeoutElapsed += (sender, e) =>
            {
                adapter.StopScanningForDevices(); // not sure why it doesn't stop already, if the timeout elapses... or is this a fake timeout we made?
                Device.BeginInvokeOnMainThread(() =>
                {
                    Debug.WriteLine("Timeout");
                });
            };
        }

        void StopScanning()
        {
            // stop scanning
            new Task(() =>
            {
                if (adapter.IsScanning)
                {
                    Debug.WriteLine("Still scanning, stopping the scan");
                    adapter.StopScanningForDevices();
                }
            }).Start();
        }

        public ICommand ScanCommand { protected set; get; }

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

        public ICommand SelectedDeviceCommand
        {
            get
            {
                return _selectedDeviceCommand ?? (_selectedDeviceCommand = new Command(async() =>await OpenDeviceServiceView()));
            }
        }

        private async Task OpenDeviceServiceView()
        {
            //controleren als er een device is
            if (Devices != null)
            {
                var x = devices[0].Name;
                int i = 0;
                //controlern als het een sensortag is
                if (devices[i].Name == "CC2650 SensorTag")
                {
                    //IDevice sensortag = devices[i];
                    StopScanning();
                    Debug.WriteLine("De sensortag is gevonden");
                    //connect Device
                    adapter.ConnectToDevice(devices[i]);
                    var status = adapter.ConnectedDevices;
                    //via Messenger adapter en device meesturen
                    await App.Current.MainPage.Navigation.PushModalAsync(ViewLocator.DeviceServicePage);

                    Messenger.Default.Send<IAdapter>(adapter);
                    Messenger.Default.Send<IDevice>(devices[i]);
                }
                else
                {
                    Debug.WriteLine("Geen sensortag geconnecteerd");
                }
            }
            else
            {
                Debug.WriteLine("Geen device gevonden");
            }    
        }

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