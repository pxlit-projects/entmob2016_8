using HeadphoneApp.Helpers;
using HeadphoneApp.Model;
using HeadphoneApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneApp.ViewModel
{
    class ReadCharacteristicViewModel
    {
        private IBluetoothSmartService _bluetoothSmartService;
        private Characteristic _characteristic;
        private string _readValue;
        private Command _readCommand;

        public ReadCharacteristicViewModel(IBluetoothSmartService bluetoothSmartService)
        {
            _bluetoothSmartService = bluetoothSmartService;
            _readValue = String.Empty;
        }

        public Characteristic Characteristic
        {
            set { _characteristic = value; }
        }

        public string ReadValue
        {
            get
            {
                return _readValue;
            }
        }

        public Command ReadCommand
        {
            get { return _readCommand ?? (_readCommand = new Command(async () => await ReadCharacteristic())); }
        }

        public async Task ReadCharacteristic()
        {
            _readValue = BluetoothConverter.ByteArrayToString(_bluetoothSmartService.ReadCharacteristic(_characteristic));
        }
    }
}
