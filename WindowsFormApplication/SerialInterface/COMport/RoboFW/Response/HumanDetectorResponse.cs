using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Response
{
    public class HumanDetectorResponse : RoboResponse
    {

        public HumanDetectorResponse(byte[] data) : base(data)
        {

        }

    }
}
