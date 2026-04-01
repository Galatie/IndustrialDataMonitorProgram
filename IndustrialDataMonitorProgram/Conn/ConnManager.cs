using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace IndustrialDataMonitorProgram.Conn
{
    internal class ConnManager
    {
        private IConnect _iconn;
        private Timer _timeOutTimer;
        private int _retryCount;
        private const int MaxRetryCount = 3;
        private const int TimeoutMs = 1000;

        private byte[] _currentCmd;
        private Action<byte[]> _onSuccess;
        private Action _onFail;

        public ConnManager(IConnect iconn)
        {
            _iconn = iconn;
        }

        //发送指令并启动计时
        public void SendCommand(byte[] cmd, Action<byte[]> onSuccess,Action onFail)
        {
            _currentCmd = cmd;
            _onSuccess = onSuccess;
            _onFail = onFail;
            _retryCount = 0;
            SendAndStarTimer();
        }

        private void SendAndStarTimer()
        {
            _iconn.Send(_currentCmd);
            _timeOutTimer = new Timer(TimeOutCallBack, null, -1, -1);
            _timeOutTimer.Change(TimeoutMs, -1);
        }

        //接收数据调用订阅委托
        public void OnResponseReceived(byte[] response)
        {
            CompleteAndClose();
            _onSuccess?.Invoke(response);
        }

        //接收超时处理
        private void TimeOutCallBack(object state)
        {
            _retryCount++;
            if (_retryCount < MaxRetryCount)
            {
                SendAndStarTimer();
            }
            else
            {
                _timeOutTimer.Change(-1, -1);
                _onFail?.Invoke();
                CompleteAndClose();
            }
        }

        //关闭计时器，重置订阅
        public void CompleteAndClose()
        {
            if (_timeOutTimer != null)
                _timeOutTimer.Dispose();
            _onSuccess = null;
            _onFail = null;
        }
    }
}
