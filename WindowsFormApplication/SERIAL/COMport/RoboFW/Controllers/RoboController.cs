using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.RoboCommunicator;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;

namespace Vn.Ntq.RoboFW.Controllers
{
    public class RoboController : StateController
    {
        private List<IMessageTransporter> messageTransporter = new List<IMessageTransporter>(); 

        private static RoboController instance = null;

        public static RoboController getInstance()
        {
            if (instance == null)
            {
                instance = new RoboController();
            }
            return instance;
        }

        private RoboController() : base(){}

        public string PortName { get; private set; }

        private string AutoConnect()
        {
            var portNames = SerialPort.GetPortNames().ToList();  //kiểm tra anh sách cổng COM đang kết nối

            BoardConnect(portNames);  //Kiểm tra kết nối mạch (xác nhận mã từ arduino)
            
            return messageTransporter.Count > 0? "" : null;
        }

        private void BoardConnect(List<string> portNames)
        {
            RoboCommand command = new HandshakeCommand();
            
            for (int i = portNames.Count - 1; i >= 0; i--) 
            {
                string portName = portNames.ElementAt(i);
                try
                {
                    Debug.WriteLine("Connecting to " + portName);
                    IMessageTransporter sender = MessageTransporter.getInstance(portName, new Commands.ResponseFactory());

                    var response = sender.SendSync(command, command.getResponseId());


                    if (response != null && response.getId() == command.getResponseId())
                    {
                        messageTransporter.Add(sender);
                        Debug.WriteLine("Connected to " + portName);
                        portNames.RemoveAt(i);
                    } else
                    {
                        sender.Dispose();
                    }//*/
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed when connecting to " + portName);
                    Debug.WriteLine(e.Message);
                }
            }
        }//*/

        protected override bool InitConnection()
        {
            try
            {
                this.PortName = AutoConnect();  //kiểm tra kết nối cổng COM
                return PortName != null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }//*/
        
    }

}
