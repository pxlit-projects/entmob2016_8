using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

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
    public class MainViewModel : ViewModelBase
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
        private ObservableCollection<IDevice> devices;

        public event PropertyChangedEventHandler PropertyChanged;


        public MainViewModel()
        {
            //get the adapter via messenger
            Messenger.Default.Register<IAdapter>(this, Adapter);
           
           
            //    this.ScanCommand = new Command(() =>
            //    {
            //        StartScanning(0x180D.UuidFromPartial());
            //    });
            //}

            //void StartScanning()
            //{
            //    StartScanning(Guid.Empty);
            //}
            //void StartScanning(Guid forService)
            //{
            //    if (adapter.IsScanning)
            //    {
            //        adapter.StopScanningForDevices();
            //        Debug.WriteLine("adapter.StopScanningForDevices()");
            //    }
            //    else
            //    {
            //        devices.Clear();
            //        adapter.StartScanningForDevices(forService);
            //        Debug.WriteLine("adapter.StartScanningForDevices(" + forService + ")");
            //    }
            //}

            //void StopScanning()
            //{
            //    // stop scanning
            //    new Task(() => {
            //        if (adapter.IsScanning)
            //        {
            //            Debug.WriteLine("Still scanning, stopping the scan");
            //            adapter.StopScanningForDevices();
            //        }
            //    }).Start();
        }

        private void Adapter(IAdapter obj)
        {
            this.adapter = obj;
            adapter.DeviceDiscovered += (object sender, DeviceDiscoveredEventArgs e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    devices.Add(e.Device);
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

        public ICommand ScanCommand { protected set; get; }


    }
}