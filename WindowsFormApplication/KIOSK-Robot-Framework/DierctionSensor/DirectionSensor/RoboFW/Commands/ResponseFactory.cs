using System;
using System.Collections.Generic;
using System.Diagnostics;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Commands
{
    public class ResponseFactory : IMessageCreator
    {
        public RoboMessage Create(byte[] data)
        {
            if (data == null || data.Length < 1)
            {
                return null;
            }
            switch (data[0] - 0x80)
            {
                case CommandId.GET_DIRECTION_DATA:
                    return new DirectionSensorData(data);
                case CommandId.HANDSHAKE:
                    return new HandshakeResponse(data);
            }
            return new RoboResponse(data); ;
        }

        public bool IsStartMessage(byte data)
        {
            return data == MessageSignal.START;
        }

        public bool IsEndMessage(byte data)
        {
            return data == MessageSignal.END;
        }

        public byte[] EncodeMessage(byte[] data)   //data = [0x22, SensorOnFlag]; 
        {
            return MessageEncoder.EncodeMessage(data);  //gọi hàm EncodeMessage trong class MessageEncoder
        }

        public byte[] DecodeCommandData(byte[] data)
        {
            return MessageEncoder.DecodeCommandData(data);
        }
    }
}