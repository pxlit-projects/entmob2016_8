
using HeadphoneApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneApp.ViewModel.ListItems
{
    
        class BluetoothListItemViewModel
        {
            private Model.Device _bluetoothDevice;

            public BluetoothListItemViewModel(Model.Device bluetoothDevice)
            {
                _bluetoothDevice = bluetoothDevice;
            }

            public string Address
            {
                get { return _bluetoothDevice.Address; }
            }

            public string Name
            {
                get { return _bluetoothDevice.Name ?? "Unknown Device"; }
            }

            private Command _navigateToDetails;

            public Command NavigateToDetails
            {
                get
                {
                    return _navigateToDetails ??
                           (_navigateToDetails = new Command(async () => await NavigateToDetailsPage()));
                }
            }

            private async Task NavigateToDetailsPage()
            {
                //DeviceDetailViewModel deviceDetailVm = ViewModelLocator.Current.DeviceDetailViewModel;
                //deviceDetailVm.Device = this._bluetoothDevice;
                //await deviceDetailVm.ConnectToDevice();
                //var navigationPage = ViewLocator.BasePage;
                //await navigationPage.PushAsync(ViewLocator.DeviceDetailPage);
            }
        }
    }