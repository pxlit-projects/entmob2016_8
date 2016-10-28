using GalaSoft.MvvmLight.Messaging;
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
        private IAdapter adapter;
        private IDevice device;
        private ObservableCollection<IService> services;
        private string deviceName;


        private ICharacteristic characteristicData;
        private ICharacteristic characteristicConfig;
        private ICharacteristic characteristicPeriod;


        /** Service ID. */
        private static string ID_SERVICE = "f000aa80-0451-4000-b000-000000000000";
        /** Data UUID. */
        private static string UUID_DATA = "f000aa81-0451-4000-b000-000000000000";
        /** Configuration UUID. */
        private static string UUID_CONFIG = "f000aa82-0451-4000-b000-000000000000";
        /** Period UUID. */
        private static string UUID_PERIOD = "f000aa83-0451-4000-b000-000000000000";
        private IService _accelerometerService;

        public event PropertyChangedEventHandler PropertyChanged;

        public DeviceServiceViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            Messenger.Default.Register<IDevice>(this, DeviceMessage);
            this.services = new ObservableCollection<IService>();


            this.GetServicesCommand = new Command(() =>
            {
                if (_accelerometerService !=null && _accelerometerService.ID.ToString() == ID_SERVICE)
                {
                //controle op de characteristics
                if (_accelerometerService.Characteristics.Count() >=3)
                    {

                        characteristicData = _accelerometerService.Characteristics[0];
                        characteristicConfig = _accelerometerService.Characteristics[1];
                        characteristicPeriod = _accelerometerService.Characteristics[2];

                        if (characteristicData.Uuid == UUID_DATA &&
                                            characteristicConfig.Uuid == UUID_CONFIG &&
                                           characteristicPeriod.Uuid == UUID_PERIOD)
                        {
                            AccelerometerData data = new AccelerometerData(characteristicData, characteristicConfig, characteristicPeriod);
                            data.Start();
                            //set characteristic 
                            //characteristicConfig.Write(new byte[] { 0x07 });

                            //if (characteristicData.CanUpdate)
                            //{
                                //characteristicData.ValueUpdated += CharacteristicData_ValueUpdated;
                                //characteristicData.ValueUpdated += async (object sender, CharacteristicReadEventArgs e) =>
                                //{
                                //    /*string data = */
                                //    await GetData(e);
                                //    //Debug.WriteLine("*");
                                //    //var status = Decode(e.Characteristic.Value);
                                //    //Debug.WriteLine("Update: " + e.Characteristic.Value);
                                //    //Debug.WriteLine("Decoded: " + status);

                                    //};

                                    //device.ServicesDiscovered -= Device_ServicesDiscovered; ;
                                    //characteristicData.StartUpdates();

                                    //for (int i = 0; i < 1000; i++)
                                    //{
                                    //   Debug.WriteLine(characteristicData.Value[0]);
                                    //   Debug.WriteLine(characteristicData.Value[0]);
                                    //    Debug.WriteLine(characteristicData.Value[0]);
                                    //    Debug.WriteLine("-----");
                                    //}

                            //}
                            //characteristicData.StartUpdates();
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
                    


                    if (characteristicConfig.Uuid == UUID_CONFIG)
                    {
                        //enable the Accelerometer features 
                        //characteristicPeriod.Write(new byte[] { 0x64 });
                        
                    }
                
                    else
                    {
                        Debug.WriteLine("Geen service gevonden");
                    }
                }
            });

        }

        //private async void CharacteristicData_ValueUpdated(object sender, CharacteristicReadEventArgs e)
        //{
        //    //await GetData(e);
        //    await GetData(e);
        //}

        //private async Task GetData(CharacteristicReadEventArgs e)
        //{
        //    string status = Decode(e.Characteristic.Value);
        //    Debug.WriteLine("Update: " + e.Characteristic.Value);
        //    //return status;
        //}
    
        private string Decode(byte[] value)
        {
            var sensorData = value;
            // Accelerometer sensorKXTJ9
            int x = sensorData[0];
            int y = sensorData[1];
            int z = sensorData[2];
            Debug.WriteLine("x: " + x + " y: " + y + " z:" + z);
            string data = "x: " + x + " y: " + y + " z:" + z;
            return data;
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
                //when services are discovered
                device.ServicesDiscovered += Device_ServicesDiscovered;
                //device.ServicesDiscovered += (object se, EventArgs ea) =>
                //{
                //    Debug.WriteLine("device.ServicesDiscovered");
                //    //services = (List<IService>)device.Services;
                //    if (services.Count == 0)
                //        Device.BeginInvokeOnMainThread(() =>
                //        {
                //            foreach (var service in device.Services)
                //            {
                //                services.Add(service);
                //            }
                //        });
                //};
                // start looking for services
                device.DiscoverServices();

            };
            
            //adapter.ConnectToDevice(device);
            
        }

        private void Device_ServicesDiscovered(object sender, EventArgs e)
        {
            Debug.WriteLine("device.ServicesDiscovered");
            //services = (List<IService>)device.Services;
            if (services.Count == 0)
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var service in device.Services)
                    {
                        //services.Add(service);
                        if (service.ID.ToString() == ID_SERVICE)
                        {
                            Debug.WriteLine("Found Accelerometer Service");
                            _accelerometerService = service;
                            device.ServicesDiscovered -= Device_ServicesDiscovered;

                        }
                    }
                });
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
        public object WorkThreadFunction { get; private set; }

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
