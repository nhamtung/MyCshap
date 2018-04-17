using System;
using System.Collections.Generic;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.RoboCommunicator
{
    public class MessageTransporter : AbstractMessageTransporter
    {
        const int RESPONSE_TIMEOUT_MILLI = 3000;

        private static Dictionary<String, MessageTransporter> instances = new Dictionary<string, MessageTransporter>();

        public MessageTransporter(string portName, IMessageCreator messageCreator)
        {
            Init(portName, messageCreator);
        }

        public static IMessageTransporter getInstance(string portName)
        {
            return getInstance(portName, new DefaultResponseFactory());
        }
        public static MessageTransporter getInstance(String portName, IMessageCreator messageCreator)
        {
            lock (instances)
            {
                MessageTransporter ret;
                if (instances.ContainsKey(portName))
                {
                    ret = instances[portName];
                }
                else
                {
                    ret = new MessageTransporter(portName, messageCreator);
                    instances[portName] = ret;
                }
                return ret;
            }
        }


        protected override void ProcessOneByteData(byte data)
        {
            if (messageCreator.IsStartMessage(data))
            {
                base.nBytesInBlockReceived = 0;
            }

            buffer[nBytesInBlockReceived] = data;
            NextBufferIndex();

            if (messageCreator.IsEndMessage(data) && nBytesInBlockReceived > 0)
            {
                byte[] newCommandBytes = new byte[nBytesInBlockReceived];

                Array.Copy(buffer, newCommandBytes, nBytesInBlockReceived);

                var command = messageCreator.Create(messageCreator.DecodeCommandData(newCommandBytes));

                base.nBytesInBlockReceived = 0;

                if (command != null)
                {
                    OnReceive(command);
                }
            }
        }


        public static void closeAll()
        {
            lock (instances)
            {
                instances.Clear();
            }
        }

        
    }
}


