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
        private DateTime startTime;
        private int userId;
        private IRepository repository;
        

        //Constructor
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
        //De sensor aanzetten en zorgen dat we updates krijgen
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

        //Converter voor datetime naar double
        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        //Decoderen van de data
        //En ook het locken en unlocken
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
                    xValues.Clear();
                    yValues.Clear();

                    if (isLocked)
                    {
                        if (avgX > 1.6)
                        {
                            Debug.WriteLine("UNLOCKED");
                            isLocked = false;
                            startTime = DateTime.Now;
                        }
                    }
                    if (!isLocked)
                    {
                        if (avgX < 1.5)
                        {
                            Debug.WriteLine("LOCKED");
                            isLocked = true;
                            SessionEnd();
                        }
                    }
                }
            }

        }
        // sessie naar de server sturen
        private async void SessionEnd()
        {
            Session s = new Session();
            DateTime endTime = DateTime.Now;
            s.Start_Time = (long)ConvertToUnixTimestamp(startTime);
            s.End_Time = (long)ConvertToUnixTimestamp(endTime);
            s.UserId = userId;
            s.Actual_Time = (int)((endTime.Ticks - startTime.Ticks) / 10000000);
            await repository.sendSession(s);
        }
    }
}