using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Sensors;

namespace Vn.Ntq.RoboFW.Devices
{
    public class WheelController : DeviceSensor
    {
        public WheelController(IMessageTransporter messageTransporter) : base(messageTransporter)
        {

        }

        public void MoveForward(int distanceCm)
        {
            SendCommand(new RoboMoveForwardCommand(distanceCm));
        }

        public void MoveBackward(int distanceCm)
        {
            SendCommand(new RoboMoveBackwardCommand(distanceCm));
        }

        public void TunrRight(int angleDegree)
        {
            SendCommand(new RoboTurnRightCommand(angleDegree));
        }

        public void TurnLeft(int angleDegree)
        {
            SendCommand(new RoboTurnLeftCommand(angleDegree));
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
