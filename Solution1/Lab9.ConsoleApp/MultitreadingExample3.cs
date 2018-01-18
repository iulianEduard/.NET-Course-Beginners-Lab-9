using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab9.ConsoleApp
{
    public class MultitreadingExample3
    {
        private string _threadOutput = "";
        private bool _stopThreads;

        AutoResetEvent _blockThread1 = new AutoResetEvent(false);
        AutoResetEvent _blockThread2 = new AutoResetEvent(true);

        public MultitreadingExample3()
        {
            // construct two threads for our demonstration;
            Thread thread1 = new Thread(new ThreadStart(DisplayThread_1));
            Thread thread2 = new Thread(new ThreadStart(DisplayThread_2));

            // start them
            thread1.Start();
            thread2.Start();
        }

        /// <summary>
        /// Thread 1, Displays that we are in thread 1
        /// </summary>
        private void DisplayThread_1()
        {
            while (_stopThreads == false)
            {
                // block thread 1  while the thread 2 is executing
                _blockThread1.WaitOne();

                // Set was called to free the block on thread 1, continue executing the code
                Console.WriteLine("Display Thread 1");

                _threadOutput = "Hello Thread 1";
                Thread.Sleep(1000);  // simulate a lot of processing

                // tell the user what thread we are in thread #1
                Console.WriteLine("Thread 1 Output --> {0}", _threadOutput);

                // finished executing the code in thread 1, so unblock thread 2
                _blockThread2.Set();
            }
        }

        /// <summary>
        /// Thread 2, Displays that we are in thread 2
        /// </summary>
        private void DisplayThread_2()
        {
            while (_stopThreads == false)
            {
                // block thread 2  while thread 1 is executing
                _blockThread2.WaitOne();

                // Set was called to free the block on thread 2, continue executing the code
                Console.WriteLine("Display Thread 2");

                _threadOutput = "Hello Thread 2";
                Thread.Sleep(1000);  // simulate a lot of processing

                // tell the user we are in thread #2
                Console.WriteLine("Thread 2 Output --> {0}", _threadOutput);

                // finished executing the code in thread 2, so unblock thread 1
                _blockThread1.Set();
            }
        }

    }
}
