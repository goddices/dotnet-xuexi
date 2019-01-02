using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;

namespace Multithread
{

    class Item
    {
        public Item(int id, String txt)
        {
            Text = txt;
            Id = id;
            Count = 0;
        }
        public String Text { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return String.Format("Id={0},Count={1},Text={2}", Id, Count, Text);

        }
    }


    class ThreadOrTimer
    {
        private readonly string _name;
        private readonly Action<string> _callback;
        private Thread _thread;
        private Timer _timer;
        private bool _disposed = false;
        private bool _isLog = false;
        private long _cost = 0;
        private bool _isBackground = false;

        //只执行一次的初始化
        private readonly Action _init;

        public bool IsBackground
        {
            get
            {
                return _isBackground;
            }
            set
            {
                _isBackground = value;
            }
        }


        /// <summary>
        /// 是否需要打印日志
        /// </summary>
        public bool IsLog
        {
            set
            {
                _isLog = value;
            }
        }

        /// <summary>
        /// 线程名
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// 耗时
        /// </summary>
        public long Cost
        {
            get
            {
                return _cost;
            }
        }

        /// <summary>
        /// 创建线程实体
        /// </summary>
        /// <param name="name">对象名</param>
        /// <param name="interval">间隔时间</param>
        /// <param name="callback">执行回调</param>
        public ThreadOrTimer(string name, int interval, Action<string> callback, Action init)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = Guid.NewGuid().ToString();
            }
            _name = name;
            _callback = callback;
            _init = init;
            _thread = new Thread(new ThreadStart(() =>
            {
                while (!_disposed)
                {
                    this.Process();
                    Thread.Sleep(interval);
                }
            }));
            _thread.IsBackground = _isBackground;
        }

        /// <summary>
        /// 创建线程实体
        /// </summary>
        /// <param name="name">对象名</param>
        /// <param name="interval">间隔时间</param>
        /// <param name="initAct">间隔时间重新开始工作后的初始化函数</param>
        /// <param name="callback">执行回调</param>
        public ThreadOrTimer(string name, int interval, Action initAct, Action<string> callback, Action init)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = Guid.NewGuid().ToString();
            }
            _name = name;
            _callback = callback;
            _init = init;
            _thread = new Thread(new ThreadStart(() =>
            {
                while (!_disposed)
                {
                    this.Process();
                    Thread.Sleep(interval);
                    initAct();
                }
            }));
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            if (_init != null)
            {
                _init();
            }
            if (_thread != null)
            {
                _thread.Start();
            }
            //LogHelper.Info("   ThreadOrTimer:{0}开始执行", _name);
        }

        /// <summary>
        /// 停止执行
        /// </summary>
        public void Stop()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
            }
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
        }

        private void Process()
        {
            try
            {

                //运行时间计算
                Stopwatch watch = new Stopwatch();
                watch.Start();

                if (_callback != null)
                {
                    _callback(this._name);
                }

                watch.Stop();
                //if (_isLog) {
                //    LogHelper.Log(string.Format("      {0}执行完毕,耗时: {1}ms", _name, watch.ElapsedMilliseconds), "Threads");
                //}
                //LogHelper.Info(string.Format("      {0}执行完毕,耗时: {1}ms", _name, watch.ElapsedMilliseconds), "Threads");
                //赋值耗时
                _cost = watch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                ThreadAbortException te = ex as ThreadAbortException;
                if (te == null)
                {
                    ex.Source += "." + _name + "." + DateTime.Now.ToString();

                }
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            ConcurrentDictionary<int, Item> dictionary = new ConcurrentDictionary<int, Item>();
            dictionary.TryAdd(0, new Item(0, "Element[0]"));
            //dictionary.TryAdd(1, new Item(1, "Element[1]"));

            //计时器, 每3秒更新Count字段 ++
            //线程1, 休眠一秒后，更新(key=1)字段，再休眠一秒后，删除(key=1) 
            //线程2, 获取(key=1)，休眠两秒后，再调用该对象引用
            Console.WriteLine("dictionary set");

            ThreadOrTimer tmr = new ThreadOrTimer("sb", 1000, (x) =>
            {

                Task.Factory.StartNew(() =>
                {

                    var arr = dictionary.Values.ToArray();
                    foreach (var item in arr)
                    {

                        item.Count++;
                        Console.WriteLine(item);
                    }
                });

            }, null)
            { IsBackground = true };

            Thread thread1 = new Thread(() =>
            {
                Timer tmr1 = new Timer((x) =>
                {
                    var arr = dictionary.Values.ToArray();
                    foreach (var item in arr)
                    {
                        Console.WriteLine(item);
                    }
                }, null, 0, 1000);
                //Thread.Sleep(1000);
                //var arr = dictionary.Values.ToArray();
                ////dictionary[1].Text += " modified";
                //arr[0].Text += " modified ,to array";
                //Thread.Sleep(1000);
                //Item local;
                //Console.WriteLine("1 is removed, result={0}", dictionary.TryRemove(1, out local));
            });

            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(1000);
                Item obj1 = dictionary[1];
                Console.WriteLine("id={0},text={1}", obj1.Count, obj1.Text);
                //Thread.Sleep(2000);

                //Console.WriteLine("id={0},text={1}", obj1.Id, obj1.Text);
            });


            tmr.Start();
            
            //thread1.Start();
            //thread2.Start();
            // thread3.Start();
            Console.ReadLine();
        }


    }
}
