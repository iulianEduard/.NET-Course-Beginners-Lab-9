using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab9.ConsoleApp
{
    public class MultitreadingExample2
    {
        private string _threadOutput = "";
        private bool _stopThreads;

        public MultitreadingExample2()
        {
            // construct two threads for our demonstration;
            Thread thread1 = new Thread(new ThreadStart(DisplayThread1));
            Thread thread2 = new Thread(new ThreadStart(DisplayThread2));

            // start them
            thread1.Start();
            thread2.Start();
        }

        /// <summary>
        /// Thread 1, Displays that we are in thread 1 (locked)
        /// </summary>
        public void DisplayThread1()
        {
            while (_stopThreads == false)
            {
                // lock on the current instance of the class for thread #1
                lock (this)
                {
                    Console.WriteLine("Display Thread 1");

                    _threadOutput = "Hello Thread1";

                    // simulate a lot of processing
                    Thread.Sleep(1000);

                    // tell the user what thread we are in thread #1
                    Console.WriteLine("Thread 1 Output --> {0}", _threadOutput);
                } // lock released  for thread #1 here
            }
        }

        /// <summary>
        /// Thread 1, Displays that we are in thread 1 (locked)
        /// </summary>
        public void DisplayThread2()
        {
            while (_stopThreads == false)
            {
                // lock on the current instance of the class for thread #2
                lock (this)
                {
                    Console.WriteLine("Display Thread 2");
                    _threadOutput = "Hello Thread2";

                    // simulate a lot of processing
                    Thread.Sleep(1000);

                    // tell the user what thread we are in thread #1
                    Console.WriteLine("Thread 2 Output --> {0}", _threadOutput);
                }  // lock released  for thread #2 here
            }

        }
    }
}
