using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vn.Ntq.RoboFW.Commons;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.RoboCommunicator
{
    public abstract class AbstractMessageTransporter : IMessageTransporter, ISerialReceiver
    {
        private const int RESPONSE_TIMEOUT_MILLI = 3000;

        protected ConcurrentQueue<RoboMessage> messageQueue;

        protected MultiMapBuffer<RoboMessage> responseBuffer;

        protected ISerialIO serialIO;

        protected int nBytesInBlockReceived = 0;  //đếm số byte trong khung truyền data

        protected byte[] buffer = new byte[10000];

        protected ConcurrentDictionary<byte, ManualResetEvent> lockers;

        protected ConcurrentDictionary<byte, ReceivedMessageEventHandler> messageListeners;

        protected IMessageCreator messageCreator;
        private string portName;

        protected void InitIfNeeded(String portName, IMessageCreator messageCreator)
        {
            if (serialIO == null)
            {
                Init(portName, messageCreator);
            }
        }

        protected void Init(String portName, IMessageCreator messageCreator)
        {
            this.portName = portName;
            this.serialIO = new ComPortIO(portName);
            this.messageCreator = messageCreator;
            serialIO.RegisterOnReceiveListener(this);  //đăng ký nhận data
            this.messageQueue = new ConcurrentQueue<RoboMessage>();
            this.responseBuffer = new MultiMapBuffer<RoboMessage>();
            lockers = new ConcurrentDictionary<byte, ManualResetEvent>();
            messageListeners = new ConcurrentDictionary<byte, ReceivedMessageEventHandler>(); 
        }

        void ISerialReceiver.OnReceiveData(byte[] data)
        {
            foreach (byte b in data)
            {
                ProcessOneByteData(b);
            }
        }

        protected abstract void ProcessOneByteData(byte data);

        protected int Send(RoboMessage message)  
        {
            if (serialIO == null)
            {
                throw new ConnectionException("Connection is closed");
            }

            byte[] encoded = messageCreator.EncodeMessage(message.GetData());  //gọi hàm EncodeMessage trong class ResponseFactory với tham biến data = [0x22, SensorOnFlag]  (Encode = [0x22, SensorOnFlag])

            serialIO.Send(encoded);  //Send Data (encoded = [0xFD, 0x22, SensorOnFlag, crc, crc >> 8, 0xFE];)

            return 0;
        }

        public void Dispose()
        {
            if (serialIO != null)
            {
                serialIO.Dispose();
                serialIO = null;
            }
        }

        public void RegisterListener(byte messageId, ReceivedMessageEventHandler listener)  //đăng kí nhận dữ liệu từ sensor
        {
            if (messageListeners.ContainsKey(messageId))  //nếu messageListeners có chứa key messageId = 0xA1
            {
                messageListeners[messageId] += new ReceivedMessageEventHandler(listener);  //thêm 1 event mới
            }
            else
            {
                messageListeners[messageId] = new ReceivedMessageEventHandler(listener);  //tạo 1 event mới
            }
        }

        public void OnReceive(RoboMessage message)
        {
            ManualResetEvent lockObj = GetLockObj(message.getId(), false);
            if (lockObj != null)
            {
                AddResponse(message);
                lockObj.Set();
            }
            if (messageListeners.ContainsKey(message.getId()))
            {
                messageListeners[message.getId()](message);
            }
        }

        private void AddResponse(RoboMessage message)
        {
            responseBuffer.Add(message);
        }

        public void SendASync(RoboMessage message)  //message: data = [0x22, SensorOnFlag]; 
        {
            Send(message);  
        }

        public RoboMessage SendSync(RoboMessage command, byte responseId)
        {
            int start = Environment.TickCount;
            try
            {
                Send(command);

                ManualResetEvent lockObj = GetLockObj(responseId, true);

                if (!lockObj.WaitOne(RESPONSE_TIMEOUT_MILLI))
                {
                    Debug.WriteLine("Timeout for command: " + command.ToString());
                    return null;
                }

                return GetResponse(responseId);
            }
            finally
            {
                Debug.WriteLine("Time for command: " + command.ToString() + " : " + (Environment.TickCount - start) + " ms");
            }
        }

        private ManualResetEvent GetLockObj(byte id, bool add)
        {
            lock (lockers)
            {
                ManualResetEvent returnObj = null;
                if (lockers.ContainsKey(id))
                {
                    returnObj = lockers[id];
                }
                if (add)
                {
                    if (returnObj == null)
                    {
                        returnObj = new ManualResetEvent(false);
                        lockers[id] = returnObj;
                    }
                }
                else
                {
                    lockers[id] = null;
                }
                return returnObj;
            }
        }

        private RoboMessage GetResponse(byte responseId)
        {
            return responseBuffer.RemoveByKey(responseId);
        }

        public String GetConnectionStatus()
        {
            if (serialIO != null)  //biến trạng thái kết nối cổng COM
            {
                return serialIO.GetConnectionStatus();  //gọi hàm GetConnectionStatus() trong ComPortIO + trả về trạng thái cổng COM và thoát khỏi hàm GetConnectionStatus
            }
            return "disconnected";
        }

        public void Reconnect()
        {
            Dispose();
            Init(portName, messageCreator);
        }

        protected void NextBufferIndex()
        {
            nBytesInBlockReceived = (nBytesInBlockReceived + 1) % buffer.Length;
        }
    }
}


