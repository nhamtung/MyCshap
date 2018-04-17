using System;
using Vn.Ntq.RoboFW.RoboCommunicator.Messages;
using Vn.Ntq.RoboFW.Sensors;

namespace Vn.Ntq.RoboFW.Devices
{
    public class IndoorGpsSensor : DeviceSensor
    {
        public delegate void OnPositionReceived(PositionValue value);

        private OnPositionReceived positionHandler;
        private DateTime lastUpdate = DateTime.Now;
        private readonly TimeSpan TIMEOUT = TimeSpan.FromSeconds(2);

        public PositionValue Position { get; private set; }

        public IndoorGpsSensor(IMessageTransporter messageTransporter) : base(messageTransporter)
        {
            base.StartListener(0xB1);
        }

        public override void OnReceive(RoboMessage message)
        {
            this.lastUpdate = DateTime.Now;

            this.Position = (PositionValue)message;

            positionHandler?.Invoke(Position);
        }

        public void RegisterDistanceChangeHandler(OnPositionReceived positionHandler)
        {
            this.positionHandler += positionHandler;
        }

        internal void EnsureConnection()
        {
            if (this.lastUpdate -  DateTime.Now < TIMEOUT)
            {
                messageTransporter.Reconnect();
            }
        }
    }
}
