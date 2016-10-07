using HeadphoneApp.Services;
using HeadphoneApp.ViewModel.Helpers;
using HeadphoneApp.ViewModel.ListItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadphoneApp.ViewModel
{
    class DeviceDetailViewModel : BaseViewModel
    {
        private Model.Device _device;
        private IBluetoothSmartService _bluetoothService;

        public DeviceDetailViewModel(IBluetoothSmartService bluetoothService)
        {
            _bluetoothService = bluetoothService;
        }

        public Model.Device Device
        {
            set
            {
                _device = value;
                base.RaisePropertyChanged("");
            }
        }

        public string Title
        {
            get { return "Device Details"; }
        }

        public string Name
        {
            get { return _device.Name; }
        }

        public IEnumerable<ServiceListItemViewModel> Services
        {
            get { return _device.Services.Select(x => new ServiceListItemViewModel(x)); }
        }

        public async Task ConnectToDevice()
        {
            await _bluetoothService.ConnectToDevice(_device);
        }
    }
}
