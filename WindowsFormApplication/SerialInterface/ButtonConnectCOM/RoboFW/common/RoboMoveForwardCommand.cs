using Vn.Ntq.RoboFW.Commands;

namespace Vn.Ntq.RoboFW
{
    public class RoboMoveForwardCommand : RoboMoveCommand
    {
        public RoboMoveForwardCommand(int distance) : base( CommandId.MOVE_FORWARD, distance)
        {
        }
    }
}