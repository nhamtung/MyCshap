using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Response
{
    public class DirectionSensorData : RoboResponse
    {
        public int[] Angle { get; private set; }

        public DirectionSensorData(byte[] responseBytes) : base(responseBytes)
        {
            if (responseBytes.Length < 2)
            {
                return;
            }

            int count = responseBytes[1];

            if (count == 0 || responseBytes.Length < 2 * (1 + count))
            {
                return;
            }

            Angle = new int[count];

            for (int i = 0; i < count; i++)
            {
                int pos = (i + 1) * 2;
                Angle[i] = responseBytes[pos] + (responseBytes[pos + 1] << 8);
            }
        }
    }
}
