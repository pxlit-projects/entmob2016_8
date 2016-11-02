using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadphoneDataApp.ViewModel
{
    public class AccelerometerData
    {

        private ICharacteristic characteristicData, characteristicConfig, characteristicPeriod;

        public object WorkThreadFunction { get; private set; }

        public AccelerometerData(ICharacteristic characteristicData, ICharacteristic characteristicConfig, ICharacteristic characteristicPeriod)
        {
            this.characteristicData = characteristicData;
            this.characteristicConfig = characteristicConfig;
            this.characteristicPeriod = characteristicPeriod;
        }

        public void Start()
        {
            characteristicConfig.Write(new byte[] { 0xF7, 0x00 });

            //characteristicPeriod.Write(new byte[] { 0x0A });
            if (characteristicData.CanUpdate)
            {

                characteristicData.ValueUpdated += CharacteristicData_ValueUpdated;
                /*Device.StartTimer(new TimeSpan(0, 0, 1), () => {
                    CharacteristicData_ValueUpdated(characteristicData.Value);
                    return true; });*///always return true, timer should never stop.
            }

            characteristicData.StartUpdates(); 


            //characteristicData.ValueUpdated();

        }

        private void CharacteristicData_ValueUpdated(object sender, CharacteristicReadEventArgs e)
        {
            Debug.WriteLine("CHECK");
            if(e != null)
            {
                GetData(e);
            }
            
        }

        public void GetData(CharacteristicReadEventArgs e)
        {
            string data = Decode(e.Characteristic.Value);
            Debug.WriteLine("Update: " + e);
            //return status;
        }

        private string Decode(byte[] value)
        {
            var sensorData = value;
            // Accelerometer sensorKXTJ9
            int x = sensorData[0];
            int y = sensorData[1];
            int z = sensorData[2];
            Debug.WriteLine("x: " + x + " y: " + y + " z: " + z);
            string data = "x: " + x + " y: " + y + " z:" + z;
            return data;
        }
    }
}