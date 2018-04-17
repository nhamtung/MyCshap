using Vn.Ntq.RoboFW.Commands;

namespace Vn.Ntq.RoboFW
{
    public class RoboMoveBackwardCommand : RoboMoveCommand
    {
        public RoboMoveBackwardCommand(int distance) : base(CommandId.MOVE_BACKWARD, distance)
        {
        }
    }
}