using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab9.ConsoleApp
{
    public class MultiThreadingExample4
    {
        public void ThreadExampleTryCath()
        {
            Console.WriteLine("Before start thread");

            ThreadWorker thr1 = new ThreadWorker();
            ThreadWorker thr2 = new ThreadWorker();

            Thread tid1 = new Thread(new ThreadStart(thr1.Job));
            Thread tid2 = new Thread(new ThreadStart(thr2.Job));

            tid1.Name = "Thread 1";
            tid2.Name = "Thread 2";

            try
            {
                tid1.Start();
                tid2.Start();
            }
            catch (ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            tid1.Abort();
            tid2.Abort();

            try
            {
                tid1.Start();
                tid2.Start();
            }
            catch (ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            Console.WriteLine("End of Method");
        }

        public void ThreadExampleWaitForThreadToFinish()
        {
            Console.WriteLine("Before start thread");

            ThreadWorker thr1 = new ThreadWorker();
            ThreadWorker thr2 = new ThreadWorker();

            Thread tid1 = new Thread(new ThreadStart(thr1.Job));
            Thread tid2 = new Thread(new ThreadStart(thr2.Job));

            tid1.Name = "Thread 1";
            tid2.Name = "Thread 2";

            try
            {
                tid1.Start();
                tid2.Start();
            }
            catch (ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            tid1.Join();
            tid2.Join(new TimeSpan(0, 0, 1));

            Console.WriteLine("End of Method");
        }

        public void ThreadExampleExecutionInBackground()
        {
            Console.WriteLine("Before start thread");

            ThreadWorker thr1 = new ThreadWorker();
            ThreadWorker thr2 = new ThreadWorker();

            Thread tid1 = new Thread(new ThreadStart(thr1.Job));
            Thread tid2 = new Thread(new ThreadStart(thr2.Job));

            tid1.Name = "Thread 1";
            tid2.Name = "Thread 2";

            tid1.IsBackground = true;
            tid2.IsBackground = true;

            try
            {
                tid1.Start();
                tid2.Start();
            }
            catch (ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            Thread.Sleep(10);

            Console.WriteLine("End of Method");
        }

        public void ThreadExampleExecutionWithPriority()
        {
            Console.WriteLine("Before start thread");

            ThreadWorker thr1 = new ThreadWorker();
            ThreadWorker thr2 = new ThreadWorker();

            Thread tid1 = new Thread(new ThreadStart(thr1.Job));
            Thread tid2 = new Thread(new ThreadStart(thr2.Job));

            tid1.Name = "Thread 1";
            tid2.Name = "Thread 2";

            tid1.Priority = ThreadPriority.Highest;
            tid2.Priority = ThreadPriority.Lowest;

            try
            {
                tid1.Start();
                tid2.Start();
            }
            catch (ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            tid1.Join();
            tid2.Join();

            Console.WriteLine("End of Program");
        }
    }

    public class ThreadWorker
    {
        public void Job()
        {
            for(int i = 1; i <= 100; i++)
            {
                Thread thr = Thread.CurrentThread;

                Console.WriteLine(thr.Name + "=" + i);

                Thread.Sleep(1);
            }
        }
    }

}
