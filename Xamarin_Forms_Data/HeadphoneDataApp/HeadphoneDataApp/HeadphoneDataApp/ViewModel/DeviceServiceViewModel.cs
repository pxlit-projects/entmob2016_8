using GalaSoft.MvvmLight.Messaging;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class DeviceServiceViewModel
    {
        private IAdapter adapter;
        private IDevice device;
        private ObservableCollection<IService> services;

        public DeviceServiceViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, AdapterMessage);
            Messenger.Default.Register<IDevice>(this, DeviceMessage);


        }

        private void AdapterMessage(IAdapter obj)
        {
            this.adapter = obj;
        }

        private void DeviceMessage(IDevice obj)
        {
            this.device = obj;
            ScanForServices();
        }

        public void ScanForServices()
        {
            Debug.WriteLine("***Scan for Services***");

            //device.DiscoverServices();
            var test = device.State;
            adapter.DeviceConnected += (s, e) =>
            {
                device = e.Device; // do we need to overwrite this?
                Debug.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
                // when services are discovered
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
    }
}
