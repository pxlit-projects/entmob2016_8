﻿using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            characteristicConfig.Write(new byte[] { 0x07 });
            characteristicPeriod.Write(new byte[] { 0xFF });
            if (characteristicData.CanUpdate)
            {
                





                characteristicData.ValueUpdated += CharacteristicData_ValueUpdated;
            }

            characteristicData.StartUpdates();
        }

        private void CharacteristicData_ValueUpdated(object sender, CharacteristicReadEventArgs e)
        {
            GetData(e);
        }

        public void GetData(CharacteristicReadEventArgs e)
        {
            string status = Decode(e.Characteristic.Value);
            Debug.WriteLine("Update: " + e.Characteristic.Value);
            //return status;
        }

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
    }
}