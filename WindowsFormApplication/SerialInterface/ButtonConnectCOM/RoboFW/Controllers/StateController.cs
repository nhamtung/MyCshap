using System.Diagnostics;
using System.Threading;

namespace Vn.Ntq.RoboFW.Controllers
{
    public enum RoboState
    {
        None,
        Initializing,
        Ready,
        Error,
        Shutingdown,
        Off
    }

    public delegate void ChangeStateEventHandler(RoboState state);

    public abstract class StateController
    {
        protected RoboState state = RoboState.None;
        private int retryCount = 0;
        private const int MAX_RETRY = 20;
        private Thread stateControllerThread;
        private ChangeStateEventHandler changeStateHandler;
        private object stateLocker = new object();

        private void StateMonitoringLoop()  //Thread
        {
            while (state != RoboState.Off)  //Main Loop: kiểm tra trạng thái của state
            {
                handleState();  //Kiểm tra trạng thái hoạt động
            }
        }
        public void RegisterChangeStateListener(ChangeStateEventHandler changeStateHandler)
        {
            this.changeStateHandler += changeStateHandler;
        }

        public void Start(ChangeStateEventHandler changeStateHandler)
        {
            if (state != RoboState.Off && state != RoboState.None)  //kiem tra trạng thái của state
            {
                return;   //nếu thỏa mãn điều kiện thì thoát khỏi hàm Start
            }
            this.changeStateHandler += OnStateChange;   //Hiển thị debug trang thái state
            RegisterChangeStateListener(changeStateHandler);  //đăng ký lắng nghe thay đổi data
            changeState(RoboState.Initializing);  //thay đổi trạng thái state thành Initializing
            stateControllerThread = new Thread(StateMonitoringLoop);  //tạo 1 luồng khác: StateMonitorLoop();
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
                    StopStateControllerThread();
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

        protected void changeState(RoboState newState)
        {
            lock (stateLocker)
            {
                if (this.state == newState)
                {
                    return;
                }
                if (state == RoboState.Shutingdown && (newState == RoboState.Error || newState == RoboState.Initializing)) // do not move from Shutingdown to Error or Initializing
                {
                    return;
                }
                if (newState == RoboState.Shutingdown && state != RoboState.Error && state != RoboState.Ready) // only move to Shutingdown from Error or Ready
                {
                    return;
                }
                this.state = newState;
            }
            changeStateHandler?.Invoke(newState);
        }

        abstract protected bool InitConnection();

        abstract protected bool CloseConnection();

        abstract protected bool Heartbeat();

        private void StopStateControllerThread()
        {
        }

        protected void Shutdown()
        {
            CloseConnection();
        }

        public void Stop()
        {
            if (state != RoboState.Ready)
            {
                return;
            }
            changeState(RoboState.Shutingdown);
        }
    }
}
