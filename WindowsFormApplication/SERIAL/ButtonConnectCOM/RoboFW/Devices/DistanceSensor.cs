using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Sensors
{
    public class DistanceSensor : DeviceSensor
    {
        public delegate void OnDistanceChanged(Dictionary<byte, int> distances);

        private static Dictionary<byte, int> Distances = new Dictionary<byte, int>();
    
        public DateTime UpdatedTime { get; private set; }

        OnDistanceChanged changeHandler;

        private List<byte> sensorIds = new List<byte>();

        public DistanceSensor(IMessageTransporter messageTransporter) : base (messageTransporter)
        {

        }

        public void RegisterDistanceChangeHandler(OnDistanceChanged changeHandler)
        {
            this.changeHandler += changeHandler;
        }

        public override void OnReceive(RoboMessage msg)
        {
            byte[] responseBytes = msg.GetData();
            if (responseBytes == null || responseBytes.Length < 2)
            {
                return;
            }

            int count = responseBytes[1];

            if (sensorIds.Count != count || count == 0 || responseBytes.Length < 2 * (1 + count))
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                int pos = (i + 1) * 2;
                Distances[sensorIds[i]] = responseBytes[pos] + (responseBytes[pos + 1] << 8);
            }

            UpdatedTime = DateTime.Now;

            changeHandler?.Invoke(Distances);
        }

        //public void TurnOff()
        //{
        //    throw new NotImplementedException();
        //}

        public void UnRegisterDistanceChangeHandler()
        {
            this.changeHandler = null;
        }

        internal void AddSensor(byte id)
        {
            sensorIds.Add(id);
        }

        internal static Dictionary<byte, int> GetSensorData()
        {
            return Distances;
        }

        internal void Switch(ICollection<byte> onSensorIds)
        {
            int sensorOnFlag = 0;
            for (int i = 0; i < sensorIds.Count; i++)
            {
                if (onSensorIds.Contains(sensorIds[i]))
                {
                    sensorOnFlag = sensorOnFlag | (1 << i);
                }
            }
            SendCommand(new byte[] { CommandId.DISTANCE_SENSOR_TURN, (byte)sensorOnFlag });

            StartListener(CommandId.GET_DISTANCE_DATA + 0x80);
        }
    }
}
