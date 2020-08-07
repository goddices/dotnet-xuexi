using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformFrx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // let's see the thread id
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("mToolStripButtonThreads_Click thread: " + id);

            // grab the sync context associated to this
            // thread (the UI thread), and save it in uiContext
            // note that this context is set by the UI thread
            // during Form creation (outside of your control)
            // also note, that not every thread has a sync context attached to it.
            SynchronizationContext uiContext = SynchronizationContext.Current;

            // create a thread and associate it to the run method
            Thread thread = new Thread(Run);

            // start the thread, and pass it the UI context,
            // so this thread will be able to update the UI
            // from within the thread
            thread.Start(uiContext);
        }

        private void Run(object state)
        {
            // lets see the thread id
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("Run thread: " + id);

            // grab the context from the state
            SynchronizationContext uiContext = state as SynchronizationContext;

            for (int i = 0; i < 1000; i++)
            {
                // normally you would do some code here
                // to grab items from the database. or some long
                // computation
                Thread.Sleep(10);

                // use the ui context to execute the UpdateUI method,
                // this insure that the UpdateUI method will run on the UI thread.

                uiContext.Post(UpdateUI, "line " + i.ToString());
            }
        }

        /// <summary>
        /// This method is executed on the main UI thread.
        /// </summary>
        private void UpdateUI(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Trace.WriteLine("UpdateUI thread:" + id);
            string text = state as string;
            listBox1.Items.Add(text);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                // normally you would do some code here
                // to grab items from the database. or some long
                // computation
                await Task.Delay(10);

                // use the ui context to execute the UpdateUI method,
                // this insure that the UpdateUI method will run on the UI thread.

                //uiContext.Post(UpdateUI, "line " + i.ToString());
                string id = "line " + i.ToString();
                Trace.WriteLine("UpdateUI thread:" + id);
                string text = id;
                listBox2.Items.Add(text);
            }
        }
    }
}
