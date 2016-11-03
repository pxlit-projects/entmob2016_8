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
using HeadphoneDataApp.Model;
using HeadphoneDataApp.Repository;

namespace HeadphoneDataApp.ViewModel
{
    public class AccelerometerData
    {

        private ICharacteristic characteristicData, characteristicConfig, characteristicPeriod;
        private bool isLocked;
        private List<double> xValues = new List<double>();
        private List<double> yValues = new List<double>();
        private DateTime startTime, endTime;
        private int userId;
        private IRepository repository;
        public object WorkThreadFunction { get; private set; }

        public AccelerometerData(ICharacteristic characteristicData, ICharacteristic characteristicConfig, ICharacteristic characteristicPeriod, DateTime startTime, int userId)
        {
            this.characteristicData = characteristicData;
            this.characteristicConfig = characteristicConfig;
            this.characteristicPeriod = characteristicPeriod;
            this.startTime = startTime;
            this.userId = userId;
            repository = new Repository.Repository();
            isLocked = false;
        }

        public void Start()
        {
            characteristicConfig.Write(new byte[] { 0xF7, 0x00 });

            //characteristicPeriod.Write(new byte[] { 0x0A });
            if (characteristicData.CanUpdate)
            {
                characteristicData.ValueUpdated += CharacteristicData_ValueUpdated;
            }

            characteristicData.StartUpdates(); 
        }

        private void CharacteristicData_ValueUpdated(object sender, CharacteristicReadEventArgs e)
        {
            if(e != null)
            {
                Decode(e.Characteristic.Value);
            }
            
        }

        public void GetData(CharacteristicReadEventArgs e)
        {
            Decode(e.Characteristic.Value);
            
            //TO-DO controle sensor voorlopig staat de bool nog op false
            if (isLocked)
            {
                endTime = DateTime.Now;
                SessionEnd(endTime);
            }
            Debug.WriteLine("Update: " + e);
            //return status;
        }

        private async void SessionEnd(DateTime endTime)
        {
            Session s = new Session();
            s.Start_Time = startTime;
            s.End_Time = endTime;
            s.UserId = userId;
            //s.Actual_Time = endTime - startTime;
            await repository.sendSession(s);
        }

        private void Decode(byte[] value)
        {
            var sensorData = value;

            double accX = ((sensorData[6] << 8 | sensorData[7]) * 1.0) / (32768 / 2);
            double accY = ((sensorData[8] << 8 | sensorData[9]) * 1.0) / (32768 / 2);
            double accZ = ((sensorData[10] << 8 | sensorData[11]) * 1.0) / (32768 / 2);

            if(accX != 0 && accY !=0)
            {
                xValues.Add(accX);
                yValues.Add(accY);
                if(xValues.Count == 10)
                {
                    double avgX = 0.0;
                    double avgY = 0.0;
                    foreach(double d in xValues)
                    {
                        avgX += d;
                    }
                    avgX = avgX / 10;
                    foreach(double d in yValues)
                    {
                        avgY += d;
                    }
                    avgY = avgY / 10;
                    Debug.WriteLine("avarage X: " + avgX);
                    Debug.WriteLine("avarage Y: " + avgY);
                    xValues.Clear();
                    yValues.Clear();

                    if (isLocked)
                    {
                        if (avgX > 1.6)
                        {
                            isLocked = false;
                            Debug.WriteLine("UNLOCK");
                        }
                    }
                    if (!isLocked)
                    {
                        if (avgX < 1.5)
                        {
                            isLocked = true;
                            Debug.WriteLine("LOCK");
                        }
                    }
                }
            }

        }
    }
}