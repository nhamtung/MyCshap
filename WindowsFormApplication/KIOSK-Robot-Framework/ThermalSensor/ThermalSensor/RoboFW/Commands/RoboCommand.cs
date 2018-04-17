using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Commands
{

    public static class CommandId
    {
        public const byte HANDSHAKE = 0x10;
        public const byte GET_THERMAL_DATA = 0x33;
        
        public const byte THERMAL_SENSOR_TURN = 0x34;
    }
    public class RoboCommand : RoboMessage
    {
        public RoboCommand(byte[] data) : base (data)  //gọi base của RoboMessage (byte[] data = [0x22, SensorOnFlag])
        {
        }
        public RoboCommand(byte commandId) : base(new byte[] { commandId })
        {
        }
        public byte getResponseId()
        {
            return (byte)(getId() + 0x80);
        }
    }
}
