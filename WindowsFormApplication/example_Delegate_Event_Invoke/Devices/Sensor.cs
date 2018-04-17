using System.Collections.Generic;
using System.Threading;

namespace Devices
{
    public class Sensor
    {
        public delegate void OnSensorChanged(int value);
        public event OnSensorChanged changeHandler;

        private Thread receiveSensorValueThread = null;

        private int sensor1;

        private List<byte> sensorIds = new List<byte>();

        public void GetSensorValue()
        {
            if (receiveSensorValueThread == null)
            {
                receiveSensorValueThread = new Thread(SensorValue);
                receiveSensorValueThread.Start();
            }
        }
        public void RegisterChangeHandler(OnSensorChanged OnSensorChange)
        {
            this.changeHandler += OnSensorChange;
        }

        private void SensorValue()
        {
            while (true)
            {
                if (sensor1 < 100)
                {
                    sensor1++;
                }
                else
                {
                    sensor1 = 0;
                }
                Thread.Sleep(1000);
                changeHandler?.Invoke(sensor1);
            }
        }
        public void AddSensor(byte id)
        {
            sensorIds.Add(id);
        }
    }
}
