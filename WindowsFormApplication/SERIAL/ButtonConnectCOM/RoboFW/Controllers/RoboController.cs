using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.Devices;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Sensors;
using static Vn.Ntq.RoboFW.Sensors.DistanceSensor;

namespace Vn.Ntq.RoboFW.Controllers
{
    public class RoboController : StateController
    {
        private List<IMessageTransporter> messageTransporter = new List<IMessageTransporter>();

        private static RoboController instance = null;

        private List<DistanceSensor> distanceSensors = new List<DistanceSensor>();

        private WheelController wheelController;

        public IndoorGpsSensor positionSensor { get; private set; }

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

            PositonConnect(portNames);  //kiểm tra địa chỉ kết nối (xác nhận mã từ arduino)

            return messageTransporter.Count > 0? "" : null;
        }

        private void PositonConnect(List<string> portNames)
        {
            for (int i = portNames.Count - 1; i >= 0; i--)
            {
                string portName = portNames.ElementAt(i);
                try
                {
                    Debug.WriteLine("Connecting to " + portName);

                    IMessageTransporter transporter = IndoorGpsReceiver.getInstance(portName);

                    IndoorGpsSensor sensor = new IndoorGpsSensor(transporter);

                    int count = 3;
                    while (count-- > 0 && sensor.Position == null)
                    {
                        Thread.Sleep(1000);
                    }
                    if (sensor.Position != null)
                    {
                        this.positionSensor = sensor;
                        messageTransporter.Add(transporter);
                    } else
                    {
                        transporter.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed when connecting to " + portName);
                    Debug.WriteLine(e.Message);
                }
            }
        }//*/

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
                        CreateController((HandshakeResponse)response, sender);
                        messageTransporter.Add(sender);
                        Debug.WriteLine("Connected to " + portName);
                        portNames.RemoveAt(i);
                    } else
                    {
                        sender.Dispose();
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed when connecting to " + portName);
                    Debug.WriteLine(e.Message);
                }
            }
        }//*/

        private void CreateController(HandshakeResponse response, IMessageTransporter transporter)
        {
            DistanceSensor ds = null;
            foreach (var device in response.Devices)
            {
                switch (device.Type)
                {
                    case DeviceType.DistanceSensor:
                        if (ds == null)
                        {
                            ds = new DistanceSensor(transporter);
                            distanceSensors.Add(ds);
                        }
                        ds.AddSensor(device.Id);
                        break;
                    case DeviceType.WheelController:
                        wheelController = new WheelController(transporter);
                        break;
                }
            }
        }//*/

        protected override bool Heartbeat()
        {
            positionSensor?.EnsureConnection();
            return true;
        }//*/

        protected override bool InitConnection()
        {
            try
            {
                this.PortName = AutoConnect();  //kiểm tra kết nối cổng COM
                return PortName != null;
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
        }//*/

        protected override bool CloseConnection()
        {
            foreach (var trans in messageTransporter)
            {
                trans.Dispose();
            }
            MessageTransporter.closeAll();
            distanceSensors?.Clear();
            messageTransporter.Clear();
            return true;
        }//*/
        
        public String GetConnectionStatus()
        {
            string result = "";
            foreach (var a in messageTransporter)
            {
                if (a is MessageTransporter)
                {
                    result += "\n Arduino: " + ((MessageTransporter)a).GetConnectionStatus();
                }
                if (a is IndoorGpsReceiver)
                {
                    result += "\n IndoorGPS: " + ((AbstractMessageTransporter)a).GetConnectionStatus();
                }
            }

            return result;
        }//*/
    }

}
