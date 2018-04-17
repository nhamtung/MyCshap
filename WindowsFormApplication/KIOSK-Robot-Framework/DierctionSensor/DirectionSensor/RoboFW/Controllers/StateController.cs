using System.Diagnostics;
using System.Threading;

namespace Vn.Ntq.RoboFW.Controllers
{
    public enum RoboState //Khai báo kiểu biến RoboState
    {
        None,
        Initializing,
        Ready,
        Error,
        Shutingdown,
        Off
    }

    public delegate void ChangeStateEventHandler(RoboState state);  //Khai báo 1 Event delegate ChangeStateEventHandle với tham biến state

    public abstract class StateController
    {
        protected RoboState state = RoboState.None;   //khời tạo biển state = None (kiểu RoboState)
        private int retryCount = 0;
        private const int MAX_RETRY = 20;
        private Thread stateControllerThread;
        private ChangeStateEventHandler changeStateHandler;  //Khai báo Event ChangeStateHandler
        private object stateLocker = new object();

        private void StateMonitoringLoop()  //Thread
        {
            while (state != RoboState.Off)  //vòng lặp: Nếu trạng thái khác Off
            {
                handleState();  
            }
        }
        public void RegisterChangeStateListener(ChangeStateEventHandler changeStateHandler)  //changeStatehandler là OnStateChange
        {
            this.changeStateHandler += changeStateHandler;  //thêm hàm OnStateChange vào Event changeStateHandler
        }

        public void Start(ChangeStateEventHandler changeStateHandler)  //changeStatehandler là OnStateChange trong MainForm
        {
            if (state != RoboState.Off && state != RoboState.None)  //kiem tra trạng thái của state
            {
                return;   //nếu thỏa mãn điều kiện thì thoát khỏi hàm Start
            }
            this.changeStateHandler += OnStateChange; //thêm hàm OnStateChange vào Event(sự kiện) changeStateHandler
            RegisterChangeStateListener(changeStateHandler);  //gọi hàm RegisterChangeStateListener với tham biến changeStateHandler
            changeState(RoboState.Initializing);  //gọi hàm changeState với tham biển là trạng thái Initializing
            stateControllerThread = new Thread(StateMonitoringLoop);  //tạo 1 Thread(luồng) khác: StateMonitorLoop();
            stateControllerThread.Start();  //Bắt đầu thread: StateMonitoringLoop
        }

        private void OnStateChange(RoboState state)
        {
            Debug.WriteLine(state);   //hiển thị debug trạng thái của state
        }

        private void handleState()   //Kiểm tra trạng thái hoạt động
        {
            switch (state)
            {
                case RoboState.Initializing:
                    if (InitConnection())  //gọi hàm InitConnection (kiểm tra có cổng COM nào kết nổi không)
                    {
                        changeState(RoboState.Ready);  //Thay đổi trang thái state thành Ready
                    }
                    else
                    {
                        changeState(RoboState.Error);
                    }
                    break;
                case RoboState.Error:
                    if (retryCount++ > MAX_RETRY)
                    {
                        changeState(RoboState.Shutingdown);
                    }
                    else
                    {
                        changeState(RoboState.Initializing);  //thay đổi trạng thái state thành Initializing
                        Thread.Sleep(2000);
                    }
                    break;
                case RoboState.Shutingdown:
                    Shutdown();
                    changeState(RoboState.Off);
                    break;
                case RoboState.Off:
                    changeStateHandler = null;
                    break;
                case RoboState.Ready:
                    if (!Heartbeat())
                    {
                        changeState(RoboState.Error);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                    break;
            }
        }

        protected void changeState(RoboState newState)  //Thay đổi trạng thái hoạt động
        {
            lock (stateLocker)
            {
                if (this.state == newState)   //kiểm tra trạng thái của state có giống tham biến đưa vào không
                {
                    return;   //thoát khỏi hàm changeState
                }
                if (state == RoboState.Shutingdown && (newState == RoboState.Error || newState == RoboState.Initializing)) //nếu trạng thái đang là ShutingDoưn và tham chiếu là Error hoặc Initializing
                {
                    return;
                }
                if (newState == RoboState.Shutingdown && state != RoboState.Error && state != RoboState.Ready) // only move to Shutingdown from Error or Ready
                {
                    return;
                }
                this.state = newState;  //đổi trạng thái hoạt động
            }
            changeStateHandler?.Invoke(newState);  //Nếu Event changeStateHandler khác null thì thực thiện sự kiện với tham biến là newState (Invoke là lệnh để gọi thread khác thực hiện)
        }

        abstract protected bool InitConnection();

        abstract protected bool CloseConnection();

        abstract protected bool Heartbeat();

        protected void Shutdown()
        {
            CloseConnection();
        }

        public void Stop()
        {
            if (state != RoboState.Ready)  // nếu trạng thái hiện tại khác Ready thì thoát khỏi hàm Stop
            {
                return;
            }
            changeState(RoboState.Shutingdown);  //gọi hàm changeState với tham biến trạng thái là ShutingDown
        }
    }
}
