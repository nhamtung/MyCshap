using Vn.Ntq.RoboFW.Commands;

namespace Vn.Ntq.RoboFW
{
    public class RoboTurnRightCommand : RoboMoveCommand
    {
        public RoboTurnRightCommand(int distance) : base(CommandId.TURN_RIGHT, distance)
        {
        }
    }
}