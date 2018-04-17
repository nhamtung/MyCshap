using System;
using System.Diagnostics;
using System.IO.Ports;
using Vn.Ntq.RoboFW.Commons;
using Vn.Ntq.RoboFW.RoboCommunicator.IOs;

namespace Vn.Ntq.RoboFW.RoboCommunicator
{
    public class ComPortIO : ISerialIO, IDisposable
    {
        private SerialPort serialPort;
        byte[] buffer;
        private ISerialReceiver listerner;

        public string PortName { get; private set; }

        public ComPortIO(string portName)
        {
            this.PortName = portName;
            CreatePort();
        }

        void CreatePort()
        {
            serialPort = new SerialPort(PortName, 9600, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.None;
            this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.DataReceivedHandler);
            buffer = new byte[this.serialPort.ReadBufferSize];
            serialPort.Open();
        }

        public void Send(byte[] data)  //data = [0xFD, 0x22, SensorOnFlag, crc, crc >> 8, 0xFE];
        {
            if (serialPort == null) CreatePort();
            try
            {
                serialPort.Write(data, 0, data.Length);  //send serial: system
                Debug.WriteLine(PortName + " sent: " + Utils.ByteArrayToHexString(data));
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(PortName + " send eror: " + e.Message);
                Close();
                throw new ConnectionException(PortName);
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            int bytesRead = this.serialPort.Read(buffer, 0, buffer.Length);

            byte[] receivedBytes = new byte[bytesRead];

            Array.Copy(buffer, 0, receivedBytes, 0, receivedBytes.Length);
            Debug.WriteLine(PortName + " recv: " + Utils.ByteArrayToHexString(receivedBytes));
            if (listerner != null)
            {
                listerner.OnReceiveData(receivedBytes);
            }
        }

        public void RegisterOnReceiveListener(ISerialReceiver listerner)
        {
            this.listerner = listerner;
        }

        public void Dispose()
        {
            Close();
        }

        private void Close()
        {
            if (serialPort != null)
            {
                serialPort.DataReceived -= DataReceivedHandler;
                serialPort.Close();
            }
            serialPort = null;
            buffer = null;
        }

        public string GetConnectionStatus()  //trả về tên cổng COM và trạng thái Connected hay Disconnected
        {
            return PortName + ": " + (serialPort != null? " connected" : " disconnected");
        }


    }
}
