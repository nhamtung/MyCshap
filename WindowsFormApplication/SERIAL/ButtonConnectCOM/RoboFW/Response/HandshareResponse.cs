using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Response
{
    public enum DeviceType
    {
        DistanceSensor = 1,
        HumanSensor,
        LocationSensor,
        WheelController,
        HeadController
    }
    public class DeviceInfo
    {

        public DeviceInfo(byte type, byte id)
        {
            this.Type = (DeviceType)type;
            this.Id = id;
        }

        public DeviceType Type { get; private set; }
        public byte Id { get; private set; }
    }


    /// <summary>
    /// byte 1: device type
    /// byte 2: device id
    /// ...
    /// byte 2n-1:device type
    /// byte 2n: device id
    /// </summary>
    public class HandshakeResponse : RoboResponse
    {
        public List<DeviceInfo> Devices { get; private set; }

        public HandshakeResponse(byte[] responseBytes) : base(responseBytes)
        {
            Devices = new List<DeviceInfo>();
            if (responseBytes.Length < 3 || responseBytes.Length % 2 == 0)
            {
                return;
            }

            int pos = 1;
            for (int i = 0; i < (responseBytes.Length - 1) / 2; i++)
            {
                Devices.Add(new DeviceInfo(responseBytes[pos++], responseBytes[pos++]));
            }
        }
    }
}
