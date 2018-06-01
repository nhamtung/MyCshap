using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DisplayState
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly SerialPort _serialPort = new SerialPort();
        private ConcurrentQueue<char> commandQueue;
        private String _stringCommand = "";

        char[] buffer = new char[1024];

        public MainWindow()
        {
            InitializeComponent();
            GetAvailablePorts();
            ButtonState(true);

            commandQueue = new ConcurrentQueue<char>();
        }
        private void GetAvailablePorts()
        {
            var ports = SerialPort.GetPortNames();
            foreach(var port in ports)
                comboBoxCOM.Items.Add(port);
        }
        private void ReadSerial()
        {
            Task.Run(() =>
            {
                var check = false;
                while (true)
                {
                    try
                    {
                        char command;
                        while (commandQueue.TryDequeue(out command))
                        {
                            //Debug.WriteLine("Array data: " + BitConverter.ToString(command));
                            if ((command == '{'))
                            {
                                check = true;
                                _stringCommand = "";
                            }
                            if (check)
                            {
                                _stringCommand += command;
                            }
                            if (command == '}')
                            {
                                DisplayReadSerial(_stringCommand);

                                CheckStateTv(_stringCommand[1]);
                                CheckStateHuman(_stringCommand[2]);
                                CheckFlagSmartDevice(_stringCommand[3]);
                                CheckFlagEnableSmartMode(_stringCommand[4]);
                                check = false;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            });
        }

        private void CheckStateTv(char data)
        {
            if (data == '1')
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    stateTV.Visibility = Visibility.Hidden;
                }));
            }
            else
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    stateTV.Visibility = Visibility.Visible;
                }));
            }
        }
        private void CheckStateHuman(char data)
        {
            if (data == '1')
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    stateHuman.Visibility = Visibility.Hidden;
                }));
            }
            else
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    stateHuman.Visibility = Visibility.Visible;
                }));
            }
        }
        private void CheckFlagSmartDevice(char data)
        {
            if (data == '1')
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    flagSmartDevice.Visibility = Visibility.Hidden;
                }));
            }
            else
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    flagSmartDevice.Visibility = Visibility.Visible;
                }));
            }
        }
        private void CheckFlagEnableSmartMode(char data)
        {
            if (data == '1')
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    flagEnableSmartMode.Visibility = Visibility.Hidden;
                }));
            }
            else
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    flagEnableSmartMode.Visibility = Visibility.Visible;
                }));
            }
        }

        private void DisplayReadSerial(string data)
        {
            Debug.WriteLine("String Command: " + data);
            Dispatcher.BeginInvoke((Action)(() => {
                try
                {
                    textBoxSend.Text = "";
                    textBoxSend.Text = data;
                }
                catch (TimeoutException)
                {
                    textBoxSend.Text = "Timeout!";
                }
            }));
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((comboBoxCOM.Text == "") || (comboBoxBaudrate.Text == ""))
                {
                    textBoxReceive.Text = "Please choose port setting!";
                }
                else
                {
                    _serialPort.PortName = comboBoxCOM.Text;
                    _serialPort.BaudRate = Convert.ToInt32(comboBoxBaudrate.Text);
                    _serialPort.Open();
                    ButtonState(false);
                    textBoxReceive.Text = "READY!";
                    ReadSerial();
                    _serialPort.DataReceived += SerialPort_DataReceived;
                }
            }
            catch (Exception ex)
            {
                textBoxReceive.Text = Convert.ToString(ex);
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int count = _serialPort.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < count; i++)
                {
                    commandQueue.Enqueue(buffer[i]);
                }
                //foreach (var data in buffer)
                //{
                //    Debug.Write(((int)data).ToString("X2"));
                //}
                //Debug.WriteLine("");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnDisConnect_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.Close();
            ButtonState(true);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            _serialPort.WriteLine(textBoxSend.Text);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxSend.Text = "";
            textBoxReceive.Text = "";
        }
        private void ButtonState(bool ready)
        {
            comboBoxCOM.IsEnabled = ready;
            comboBoxBaudrate.IsEnabled = ready;
            btnConnect.IsEnabled = ready;

            btnDisConnect.IsEnabled = !ready;
            textBoxSend.IsEnabled = !ready;
            textBoxReceive.IsEnabled = !ready;
            btnSend.IsEnabled = !ready;
            btnClear.IsEnabled = !ready;
        }
    }
}
