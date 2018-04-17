using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using Vn.Ntq.RoboFW.Commands;
using Vn.Ntq.RoboFW.Response;
using Vn.Ntq.RoboFW.RoboCommunicator;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Sensors;
using static Vn.Ntq.RoboFW.Sensors.ThermalSensor;

namespace Vn.Ntq.RoboFW.Controllers
{
    public class RoboController : StateController
    {
        private List<IMessageTransporter> messageTransporter = new List<IMessageTransporter>();
        private static RoboController instance = null;
        private List<ThermalSensor> ThermalSensors = new List<ThermalSensor>();
        
        public string PortName { get; private set; }
        
        public static RoboController getInstance()  //Khởi tạo 1 đối tượng trong class RoboController
        {
            if (instance == null)
            {
                instance = new RoboController();
            }
            return instance;
        }
        private RoboController() : base()  //(kế thừa class StateController) truy cập class StateController trong StateController
        {}
        private string AutoConnect()
        {
            var portNames = SerialPort.GetPortNames().ToList();  //kiểm tra anh sách cổng COM đang kết nối
            BoardConnect(portNames);  //Kiểm tra kết nối mạch (xác nhận mã từ arduino)
            return messageTransporter.Count > 0? "" : null;
        }
        private void BoardConnect(List<string> portNames)
        {
            RoboCommand command = new HandshakeCommand();  //khởi tạo đối tượng command trong class HandshakeCommand (data = 0x10)
            
            for (int i = portNames.Count - 1; i >= 0; i--)   //kiểm tra từng cổng COM
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
        }
        private void CreateController(HandshakeResponse response, IMessageTransporter transporter)
        {
            ThermalSensor ds = null;
            foreach (var device in response.Devices)
            {
                Debug.WriteLine(device.Type);
                switch (device.Type)
                {
                    case DeviceType.DirectionSensor:
                        if (ds == null)
                        {
                            ds = new ThermalSensor(transporter);
                            ThermalSensors.Add(ds);
                        }
                        ds.AddSensor(device.Id);
                        break;
                }
            }
        }
        protected override bool Heartbeat()
        {
            return true;
        }
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
        }
        protected override bool CloseConnection()
        {
            foreach (var trans in messageTransporter)
            {
                trans.Dispose();
            }
            ThermalSensors?.Clear();
            messageTransporter.Clear();
            return true;
        }
        public bool IsOff()
        {
            return state == RoboState.Off;
        }
        public Dictionary<byte, int> GetThermalSensorData()
        {
            return ThermalSensor.GetSensorData();
        }

        public ThermalSensor GetThermalSensor(int pos)
        {
            if (ThermalSensors.Count <= pos)
            {
                throw new ConnectionException("no sensor detected");
            }
            return ThermalSensors[pos];
        }
        public void SwitchThermalSensor(ICollection<byte> onSensorIds)  //
        {
            foreach (var dir in ThermalSensors)
            {
                dir.Switch(onSensorIds);  //gửi data và đăng ký nhận data
            }
        }
        public void RegisterThermalChangeHandler(OnThermalChanged onThermalChange)  //Hiển thị khoảng cách cảm biến lên Form
        {
            foreach (var dir in ThermalSensors)
            {
                dir.RegisterThermalChangeHandler(onThermalChange);
            }
        }
        public String GetConnectionStatus()  //Kiểm tra cổng COM đang kết nối là Arduino hay IndoorGPS
        {
            string result = "";
            foreach (var a in messageTransporter)
            {
                if (a is MessageTransporter)
                {
                    result += "\nArduino - " + ((MessageTransporter)a).GetConnectionStatus();  //gọi hàm GetConnectionStatus trong AbtractMessageTransporter (result = "Arduino + trạng thái cổng COM đang kết nối")
                }
            }

            return result;
        }

    }
}
