using HeadphoneApp.Helpers;
using HeadphoneApp.Model;
using HeadphoneApp.Services;
using HeadphoneApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneApp.ViewModel
{
    class WriteModalViewModel : BaseViewModel
    {
        private Characteristic _characteristic;
        private IBluetoothSmartService _bluetoothLeService;
        private Command _sendCommand;
        private Command _goBackCommand;

        public WriteModalViewModel(IBluetoothSmartService bluetoothLeService)
        {
            _bluetoothLeService = bluetoothLeService;
        }

        public Characteristic Characteristic
        {
            set
            {
                _characteristic = value;
                RaisePropertyChanged();
            }
        }

        public string WriteText { get; set; }

        public Command SendCommand
        {
            get
            {
                return _sendCommand ?? (_sendCommand = new Command(async () => await SendMessage()));
            }
        }

        public Command GoBackCommand
        {
            get { return _goBackCommand ?? (_goBackCommand = new Command(async () => await GoBack())); }
        }

        private async Task SendMessage()
        {
            try
            {
                await _bluetoothLeService.WriteCharacteristicValue(_characteristic, BluetoothConverter.ConvertHexString(this.WriteText));
            }
            catch (Exception ex)
            {
            }

        }

        private async Task GoBack()
        {
            var navigationPage = ViewLocator.BasePage;
            await navigationPage.PopAsync();
        }
    }
}
