using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public class RoboResponse : RoboMessage
    {
        public RoboResponse(byte[] data) : base(data)
        {
        }
    }
}
