using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestInvoke
{
    public class Sensor
    {
        public event EventHandler<int> SensorValueChanged;
        private System.Timers.Timer timerUpdateValue;
        private int value;
        public Sensor()
        {
            value = 0;

            timerUpdateValue = new System.Timers.Timer();
            timerUpdateValue.AutoReset = true;
            timerUpdateValue.Interval = 1000;
            timerUpdateValue.Elapsed += TimerUpdateValue_Elapsed;
            timerUpdateValue.Enabled = true;
        }

        private void TimerUpdateValue_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SensorValueChanged?.Invoke(this, value++);
        }
    }
}
