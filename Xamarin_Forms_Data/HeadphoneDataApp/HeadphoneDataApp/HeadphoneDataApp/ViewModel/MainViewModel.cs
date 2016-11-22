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
using HeadphoneDataApp.Model;

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
        private IAdapter adapter;
        private User user;
        private ObservableCollection<IDevice> devices;

        //Properties
        public IAdapter Adapter
        {
            get { return adapter; }
            set { adapter = value; }
        }
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

        //Commands
        public Command ScanCommand { set; get; }
        public ICommand DeviceSelectedCommand { get; set; }

        //Constructor
        public MainViewModel()
        {
            //MESSENGER REGISTER
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            //get the user via messenger
            Messenger.Default.Register<User>(this, User);

            devices = new ObservableCollection<IDevice>();

            //COMMANDS
            DeviceSelectedCommand = new Command(async (device) =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(ViewLocator.DeviceServicePage);
                //stuur de geselecteerde device en de bluetoothadapter en user door 
                Messenger.Default.Send<IAdapter>(adapter);
                Messenger.Default.Send<IDevice>((IDevice)device);
                Messenger.Default.Send<User>(user);
            });
        
            ScanCommand = new Command(() =>
            {
                StartScanning(0x180D.UuidFromPartial());
            });

           
        }

        //Code voor het starten van het zoeken naar devices
        public void StartScanning()
        {
            StartScanning(Guid.Empty);
        }

        public void StartScanning(Guid forService)
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

        //Code voor het stoppen van het zoeken naar device
        public void StopScanning()
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


        //Actions
        //Action wat wordt opgeroepen bij het registreren van de adapter 
        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    devices.Add(e.Device);
                    //Devices = devices;
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
        //Action wat wordt opgeroepen bij het registreren van de userr 
        private void User(User obj)
        {
            this.user = obj;
        }

        //Implementatie van de interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}