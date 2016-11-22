using GalaSoft.MvvmLight.Messaging;
using HeadphoneDataApp.Model;
using Java.Lang;
using Java.Util;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class DeviceServiceViewModel: INotifyPropertyChanged
    { 
        
        /** Service ID. */
        private static string ID_SERVICE = "f000aa80-0451-4000-b000-000000000000";
        /** Data UUID. */
        private static string UUID_DATA = "f000aa81-0451-4000-b000-000000000000";
        /** Configuration UUID. */
        private static string UUID_CONFIG = "f000aa82-0451-4000-b000-000000000000";
        /** Period UUID. */
        private static string UUID_PERIOD = "f000aa83-0451-4000-b000-000000000000";

        private IAdapter adapter;
        private IDevice device;
        private string deviceName;
        private User user;
        private ObservableCollection<IService> services;
        private string ready;

        private ICharacteristic characteristicConfig;
        private ICharacteristic characteristicPeriod;
        private ICharacteristic characteristicData;

        private IService _accelerometerService;

        //Properties
        public IDevice Device
        {
            get { return device; }
            set { device = value; }
        }
        public IAdapter Adapter
        {
            get { return adapter; }
            set { adapter = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public string Ready
        {
            get { return ready; }
            set { 
                    ready = value;
                    OnPropertyChanged("Ready");
                }
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
        public ICharacteristic CharacteristicData
        {
            get { return characteristicData; }
        }
        public ICharacteristic CharacteristicConfig
        {
            get { return characteristicConfig; }
        }
        public ICharacteristic CharacteristicPeriod
        {
            get { return characteristicPeriod; }
        }
        public IService AccelerometerService
        {
            get { return _accelerometerService; }
            set { _accelerometerService = value; }
        }
       
        //Command
        public Command GetServicesCommand { get; set; }

        //Constructor
        public DeviceServiceViewModel()
        {

            Ready = "please wait until the correct service has been found.";
            //MESSENGER REGISTER
            //get the adapter, device en user via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            Messenger.Default.Register<IDevice>(this, DeviceMessage);
            Messenger.Default.Register<User>(this, UserMessage);
            this.services = new ObservableCollection<IService>();

            //COMMAND
            this.GetServicesCommand = new Command(() =>
            {
                //Controle als de gevonden service correct is
                if (_accelerometerService != null && _accelerometerService.ID.ToString() == ID_SERVICE)
                {
                    //controle als de service ook characteristics heeft
                    if (_accelerometerService.Characteristics.Count() >= 3)
                    {

                        characteristicData = _accelerometerService.Characteristics[0];
                        characteristicConfig = _accelerometerService.Characteristics[1];
                        characteristicPeriod = _accelerometerService.Characteristics[2];

                        //controle als de service ook de juiste characteristics heeft
                        if (characteristicData.Uuid == UUID_DATA &&
                                            characteristicConfig.Uuid == UUID_CONFIG &&
                                           characteristicPeriod.Uuid == UUID_PERIOD)
                        {
                            //startdatum zetten
                            DateTime now = DateTime.Now;
                            //Hulp klasse 
                            //voor data uit de sensor te halen
                            //voor het locken en unlocken
                            //voor de sessie door te sturen naar de server
                            AccelerometerData data = new AccelerometerData(characteristicData, characteristicConfig, characteristicPeriod, now, user.UserId);
                            data.Start();
                        }
                        else
                        {
                            Debug.WriteLine("foutieve chararcterisics");
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Geen chararcterisics gevonden");
                    }
                }
                else
                {
                    Debug.WriteLine("Geen service gevonden");
                }
                
            });

        }

       
        //Code voor het scannen van naar services van de censortag
        public void ScanForServices()
        {
            Debug.WriteLine("***Scan for Services***");

            if (services.Count == 0)
            {
                Debug.WriteLine("No services, attempting to connect to device");
                Ready = "No services, attempting to connect to device";
                // start looking for the device
                adapter.ConnectToDevice(device);
            }

            
            adapter.DeviceConnected += (s, e) =>
            {
                device = e.Device; // do we need to overwrite this?
                //when services are discovered
                device.ServicesDiscovered += Device_ServicesDiscovered;
                device.DiscoverServices();

            };
            
        }

        private void Device_ServicesDiscovered(object sender, EventArgs e)
        {
            Debug.WriteLine("device.ServicesDiscovered");
            //services = (List<IService>)device.Services;
            if (services.Count == 0)
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    findService();
                });
        }

        public void findService()
        {
            foreach (var service in device.Services)
            {
                //services.Add(service);
                if (service.ID.ToString() == ID_SERVICE)
                {
                    Debug.WriteLine("Found Accelerometer Service");
                    Ready = "Found Accelerometer Service, feel free to press the button";
                    _accelerometerService = service;
                    device.ServicesDiscovered -= Device_ServicesDiscovered;

                }
            }
        }

        //Actions
        //Action wat wordt opgeroepen bij het registreren van de adapter 
        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }
        //Action wat wordt opgeroepen bij het registreren van het device
        //Hier starten we ook het zoeken naar services van de sensortag
        private void DeviceMessage(IDevice obj)
        {
            this.device = obj;
            ScanForServices();
            DeviceName = device.Name;
        }
        //Action wat wordt opgeroepen bij het registreren van de user
        private void UserMessage(User obj)
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
