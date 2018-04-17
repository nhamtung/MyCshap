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
    public class DirectionSensor : DeviceSensor
    {
        public delegate void OnDirectionChanged(Dictionary<byte, int> angle);

        private static Dictionary<byte, int> Angle = new Dictionary<byte, int>();
    
        public DateTime UpdatedTime { get; private set; }

        OnDirectionChanged changeHandler;

        private List<byte> sensorIds = new List<byte>();

        public DirectionSensor(IMessageTransporter messageTransporter) : base (messageTransporter)
        {}

        public void RegisterDirectionChangeHandler(OnDirectionChanged changeHandler)
        {
            this.changeHandler += changeHandler;
        }

        public override void OnReceive(RoboMessage msg)   //nhận giá trị cảm biến liên tục
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
            }//*/

            for (int i = 0; i < count; i++)
            {
                int pos = (i + 1) * 2;
                Angle[sensorIds[i]] = responseBytes[pos] + (responseBytes[pos + 1] << 8);
            }

            UpdatedTime = DateTime.Now;

            changeHandler?.Invoke(Angle);
        }

        //public void TurnOff()
        //{
        //    throw new NotImplementedException();
        //}

        public void UnRegisterDirectionChangeHandler()
        {
            this.changeHandler = null;
        }

        internal void AddSensor(byte id)
        {
            sensorIds.Add(id);
        }

        internal static Dictionary<byte, int> GetSensorData()
        {
            return Angle;
        }

        internal void Switch(ICollection<byte> onSensorIds)
        {
            int sensorOnFlag = 0;
            for (int i = 0; i < sensorIds.Count; i++)
            {
                if (onSensorIds.Contains(sensorIds[i]))  //nếu list onSenserIds có trong sensorIds
                {
                    sensorOnFlag = sensorOnFlag | (1 << i);  //xác định cờ tương ứng với từng cảm biến
                }
            }
            SendCommand(new byte[] { CommandId.DIRECTION_SENSOR_TURN, (byte)sensorOnFlag });   //Send data với tham biến (0x32,sensorOnFlag)

            StartListener(CommandId.GET_DIRECTION_DATA + 0x80);  //đăng ký nhận data (0x31 + 0x80 = 0xB1)
        }
    }
}
