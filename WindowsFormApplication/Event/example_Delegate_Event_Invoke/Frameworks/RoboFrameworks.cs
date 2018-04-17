using Devices;
using System;
using System.Collections.Generic;
using static Devices.Sensor;

namespace Frameworks
{
    public class RoboFrameworks
    {
        private static RoboFrameworks instance = null;
        public Sensor sensor = new Sensor();
        public List<Sensor> listSensor = new List<Sensor>();

        public static RoboFrameworks getInstance()
        {
            if (instance == null)
            {
                instance = new RoboFrameworks();
            }
            return instance;
        }

        public void CreateListSensor(byte id)
        {
            Sensor sens = null;
            if(sens == null)
            {
                sens = new Sensor();
                listSensor.Add(sens);
            }
            sens.AddSensor(id);

        }
        public void AddSensor(byte id)
        {
            if (!onSensorIds.Contains(id))
            {
                onSensorIds.Add(id);
            }
        }

        public void RemoveSensor(byte id)
        {
            if (onSensorIds.Contains(id))
            {
                onSensorIds.Remove(id);
            }
        }

        private SortedSet<Byte> onSensorIds = new SortedSet<byte>();
        public void SwitchSensor(OnSensorChanged OnSensorChanged)
        {
            sensor.GetSensorValue();
            //RegisterSensorChangeHandler(OnSensorChanged);
        }
        private void RegisterSensorChangeHandler(OnSensorChanged OnSensorChanged)
        {
            foreach(var sens in listSensor)
            {
                sens.RegisterChangeHandler(OnSensorChanged);
            }
        }
    }
}
