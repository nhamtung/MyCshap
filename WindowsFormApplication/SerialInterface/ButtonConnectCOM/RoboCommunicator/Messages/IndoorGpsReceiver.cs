using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    enum RECV
    {
        HDR,
        DGRAM
    };
    
    public class IndoorGpsReceiver : AbstractMessageTransporter
    {
        private const int POSITION_DATAGRAM_ID = 0x0001;
        private const int BEACONS_POSITIONS_DATAGRAM_ID = 0x0002;
        private static Dictionary<String, IndoorGpsReceiver> instances = new Dictionary<string, IndoorGpsReceiver>();

        RECV recvState = RECV.HDR;

        public IndoorGpsReceiver(string portName)
        {
            Init(portName, messageCreator);
        }

        public static IndoorGpsReceiver getInstance(string portName)
        {
            lock (instances)
            {
                IndoorGpsReceiver ret;
                if (instances.ContainsKey(portName))
                {
                    ret = instances[portName];
                }
                else
                {
                    ret = new IndoorGpsReceiver(portName);
                    instances[portName] = ret;
                }
                ret.InitIfNeeded(portName, null);
                return ret;
            }
        }
        
        private static int CalcCrcModbus(byte[] buf, int len)
        {
            int crc = 0xFFFF;
            int pos;
            for (pos = 0; pos < len; pos++)
            {
                crc ^= (int)buf[pos]; // XOR byte into least sig. byte of crc
                int i;
                for (i = 8; i != 0; i--) // Loop over each bit
                {
                    if ((crc & 0x0001) != 0) // If the LSB is set
                    {
                        crc >>= 1; // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else  // Else LSB is not set
                        crc >>= 1; // Just shift right
                }
            }
            return crc;
        }

        int dataId = 0;
        protected override void ProcessOneByteData(byte receivedChar)
        {
            buffer[nBytesInBlockReceived] = receivedChar;
            bool goodByte = false;
            if (recvState == RECV.HDR)
            {
                switch (nBytesInBlockReceived)
                {
                    case 0:
                        goodByte = (receivedChar == 0xFF);
                        break;
                    case 1:
                        goodByte = (receivedChar == 0x47);
                        break;
                    case 2:
                        goodByte = true;
                        break;
                    case 3:
                        dataId = (((int)receivedChar) << 8) + buffer[2];
                        goodByte = (dataId == POSITION_DATAGRAM_ID) ||
                                    (dataId == BEACONS_POSITIONS_DATAGRAM_ID);
                        break;
                    case 4:
                        switch (dataId)
                        {
                            case POSITION_DATAGRAM_ID:
                                goodByte = (receivedChar == 0x10);
                                break;
                            case BEACONS_POSITIONS_DATAGRAM_ID:
                                goodByte = true;
                                break;
                        }
                        if (goodByte)
                            recvState = RECV.DGRAM;
                        break;


                }
                if (goodByte)
                {
                    // correct header byte
                    NextBufferIndex();
                }
                else
                {
                    // ...or incorrect
                    recvState = RECV.HDR;
                    nBytesInBlockReceived = 0;
                }
            }
            else
            {
                NextBufferIndex();
                if (nBytesInBlockReceived >= 7 + buffer[4])
                {
                    // parse dgram
                    int blockCrc =
                        CalcCrcModbus(buffer, nBytesInBlockReceived);

                    if (blockCrc == 0)
                    {
                        switch (dataId)
                        {
                            case POSITION_DATAGRAM_ID:
                                // add to positionBuffer
                                OnReceive(new PositionValue(buffer));
                                break;
                            case BEACONS_POSITIONS_DATAGRAM_ID:
                                Debug.WriteLine("BEACONS LOC");
                                break;
                        }
                    }
                    // and repeat
                    recvState = RECV.HDR;
                    nBytesInBlockReceived = 0;
                }
            }
        }

        
    }
}
