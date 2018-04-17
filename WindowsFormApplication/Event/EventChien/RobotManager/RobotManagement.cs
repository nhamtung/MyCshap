using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotManager
{
    public delegate void ChangeName(string name);

    public interface IRobotManagement
    {
        void Config(string name);
        event ChangeName OnChangeName;
    }

    public class RobotManagement : IRobotManagement
    {
        public RobotManagement()
        {
            RobotController = new RobotController();
        }

        private RobotController RobotController;

        public void Config(string name)
        {
            RobotController.Name = name;
        }

        public void RobotSendToUi()
        {
            RobotController.Name += "Chien";
            if (OnChangeName != null)
                OnChangeName(RobotController.Name);
        }

        public event ChangeName OnChangeName;
    }

    public class RobotController
    {
        public string Name { get; set; }
    }
}
