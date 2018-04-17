using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vn.Ntq.RoboFW.RoboCommunicator.Messages
{
    public interface IMessageCreator
    {
        RoboMessage Create(byte[] data);
        bool IsStartMessage(byte data);
        bool IsEndMessage(byte data);
        byte[] EncodeMessage(byte[] message);  //khai báo mảng EncodeMessage 
        byte[] DecodeCommandData(byte[] v);
    }
}
