using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Win32Messaging
{
    public partial class FormMain : Form
    {

        #region win32函数声明
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, ref CustomParam lParam);

        private struct CustomParam
        {
            public String MessageText { get; set; }
            public DateTime DateTime { get; set; }
        }

        public const int WM_CUSTM_MSG = 0x5000;

        #endregion

        #region 自定义win32消息处理
        protected event EventHandler<MessageEventArgs> MessageRecvived;

        protected class MessageEventArgs : EventArgs
        {
            public DateTime MessageDateTime { get; set; }
            public String MessageText { get; set; }
        }

        private void ProductMessage(String message)
        {
            var parm = new CustomParam
            {
                DateTime = DateTime.Now,
                MessageText = message
            };
            if (this.InvokeRequired)
            {

                this.Invoke(new Action(() =>
                {
                    SendMessage(this.Handle, WM_CUSTM_MSG, 0, ref parm);
                }));
            }
            else
            {
                SendMessage(this.Handle, WM_CUSTM_MSG, 0, ref parm);
            }
        }



        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CUSTM_MSG:
                    if (MessageRecvived != null)
                    {
                        var parm = (CustomParam)m.GetLParam(typeof(CustomParam));
                        MessageRecvived.Invoke(this, new MessageEventArgs
                        {
                            MessageText = parm.MessageText,
                            MessageDateTime = parm.DateTime
                        });
                    }
                    //不应该堵塞该线程
                    //Thread.Sleep(1000);
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }

        }
        #endregion

        #region winform事件
        public FormMain()
        {
            InitializeComponent();
            MessageRecvived += CustomEvent_MessageReceived;
        }

        private void CustomEvent_MessageReceived(object sender, MessageEventArgs e)
        {
            Debug.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            AddItem(e.MessageText, e.MessageDateTime);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //System.Windows.Forms.WindowsFormsSynchronizationContext
            AddItem($"当前 SynchronizationContext 是: {SynchronizationContext.Current?.ToString()}", DateTime.Now);
        }
        private void SyncMethod_Click(object sender, EventArgs e)
        {
            //任何地方，都不能堵塞窗口的主线程
            //Thread.Sleep(1000);
            ProductMessage(String.Format("基于事件的同步方法:线程(Id={0})产生的消息", Thread.CurrentThread.ManagedThreadId));
        }

        private void TaskFactoryStartNew_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProductMessage(String.Format("Task.Factory.StartNew:线程(Id={0})产生的消息", Thread.CurrentThread.ManagedThreadId));
            });
        }


        private async void AfterAwaitMethod_Click(object sender, EventArgs e)
        {
            //await不会堵塞主线程
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });
            AddItem(String.Format("await之后:线程(Id={0})产生的消息", Thread.CurrentThread.ManagedThreadId), DateTime.Now);

        }

        #endregion

        #region 我的方法
        private void AddItem(String txt, DateTime dt)
        {
            listBox1.Items.Add(String.Format("[{1}] {0}", txt, dt.ToString("yyyy/MM/dd HH:mm:ss")));
        }

        #endregion

    }
}
