namespace AdvancedThreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            
        }
    }

    class ThreadUnsafe
    {
        static int _vali1 = 1, _vali2 = 1;

        static void Go()
        {
            if(_vali2 != 0) Console.WriteLine(_vali1 / _vali2);
            _vali2 = 0;
        }
    }

    class ThreadSafe
    {
        static readonly object _locker = new object();   
        static int _vali1 = 1, _vali2 = 1;

        
        static void Go()
        {
            lock (_locker)
            {
                if (_vali2 != 0) Console.WriteLine(_vali1 / _vali2);
                _vali2 = 0;
            }

            Monitor.Enter(_locker);
            try
            {
           
                if (_vali2 != 0) Console.WriteLine(_vali1 / _vali2);
                _vali2 = 0;
            }
            finally { Monitor.Exit(_locker); }
        }
    }

    //class Deadlock
    //{
    //    object locker1 = new object();
    //    object locker2 = new object();

    //    new Thread(() =>{
    //        lock (locker1)
    //        {
    //            Thread.Sleep(1000);
    //            lock (locker2) ;
    //        }
    //    }).Start(); 

    //    lock(locker2){
    //        Thread.Sleep(1000);
    //        lock(locker1);
    //}
}
