using System;

namespace Vn.Ntq.RoboFW.Commands
{
    internal class HandshakeCommand : RoboCommand
    {
        public HandshakeCommand() : base(new byte[] { CommandId.HANDSHAKE })  //0x10
        {
        }
    }
}