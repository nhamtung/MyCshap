using Vn.Ntq.RoboFW.Commands;

namespace Vn.Ntq.RoboFW
{
    public class RoboTurnLeftCommand : RoboMoveCommand
    {
        public RoboTurnLeftCommand(int distance) : base(CommandId.TURN_LEFT, distance)
        {
        }
    }
}