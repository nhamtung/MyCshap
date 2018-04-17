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
        public const byte MOVE_FORWARD = 0x11;
        public const byte MOVE_BACKWARD = 0x12;
        public const byte TURN_LEFT = 0x13;
        public const byte TURN_RIGHT = 0x15;
        public const byte HEAD_UP = 0x16;
        public const byte HEAD_DOWN = 0x17;
        public const byte HANDSHAKE = 0x10;
        public const byte GET_DISTANCE_DATA = 0x21;

        public const byte DISTANCE_SENSOR_TURN = 0x22;
    }
    public class RoboCommand : RoboMessage
    {
        public RoboCommand(byte[] data) : base (data)
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
