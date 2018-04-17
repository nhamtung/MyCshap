using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Response
{
    public class ThermalSensorData : RoboResponse
    {
        public int[] Human { get; private set; }

        public ThermalSensorData(byte[] responseBytes) : base(responseBytes)
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

            Human = new int[count];

            for (int i = 0; i < count; i++)
            {
                int pos = (i + 1) * 2;
                Human[i] = responseBytes[pos] + (responseBytes[pos + 1] << 8);
            }
        }
    }
}
