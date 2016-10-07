using HeadphoneApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneApp.ViewModel.Helpers
{
    class ViewModelLocator
    {
        public static ViewModelLocator Current = new ViewModelLocator();

        private IBluetoothSmartService _bluetoothSmartService = DependencyService.Get<IBluetoothSmartService>();
        private MainPageViewModel _mainPageViewModel;
        private DeviceDetailViewModel _deviceDetailViewModel;
        private WriteModalViewModel _writeModalViewModel;
        private ReadCharacteristicViewModel _readCharacteristicViewModel;

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return _mainPageViewModel ?? (_mainPageViewModel = new MainPageViewModel(_bluetoothSmartService));
            }
        }

        public DeviceDetailViewModel DeviceDetailViewModel
        {
            get
            {
                return _deviceDetailViewModel ??
                       (_deviceDetailViewModel =
                           new DeviceDetailViewModel(_bluetoothSmartService));
            }
        }

        public WriteModalViewModel WriteModalViewModel
        {
            get { return _writeModalViewModel ?? (_writeModalViewModel = new WriteModalViewModel(_bluetoothSmartService)); }
        }

        public ReadCharacteristicViewModel ReadCharacteristicViewModel
        {
            get
            {
                return _readCharacteristicViewModel ?? (_readCharacteristicViewModel = new ReadCharacteristicViewModel(_bluetoothSmartService));
            }
        }
    }
}
