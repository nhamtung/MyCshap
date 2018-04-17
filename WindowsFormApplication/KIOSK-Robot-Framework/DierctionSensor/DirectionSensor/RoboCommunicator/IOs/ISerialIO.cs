using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vn.Ntq.RoboFW.RoboCommunicator
{
    public interface ISerialIO : IDisposable
    {
        void Send(byte[] data);
        void RegisterOnReceiveListener(ISerialReceiver listerner);
        string GetConnectionStatus();
    }
    public interface ISerialReceiver
    {
        void OnReceiveData(byte[] data);
    }
}
