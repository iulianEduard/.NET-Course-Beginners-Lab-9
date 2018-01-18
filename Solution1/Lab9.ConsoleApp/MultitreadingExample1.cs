using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab9.ConsoleApp
{
    public class MultitreadingExample1
    {
        private string _threadOutput = "";
        private bool _stopThreads;

        public MultitreadingExample1()
        {
            // construct two threads for our demonstration;
            Thread thread1 = new Thread(new ThreadStart(DisplayThread1));
            Thread thread2 = new Thread(new ThreadStart(DisplayThread2));

            // start them
            thread1.Start();
            thread2.Start();
        }

        public void DisplayThread1()
        {
            while (_stopThreads == false)
            {
                Console.WriteLine("Display Thread 1");

                // Assign the shared memory to a message about thread #1
                _threadOutput = "Hello Thread1";

                Thread.Sleep(1000);  // simulate a lot of processing 

                // tell the user what thread we are in thread #1, and display shared memory
                Console.WriteLine("Thread 1 Output --> {0}", _threadOutput);

            }
        }

        public void DisplayThread2()
        {
            while (_stopThreads == false)
            {
                Console.WriteLine("Display Thread 2");

                // Assign the shared memory to a message about thread #2
                _threadOutput = "Hello Thread2";

                Thread.Sleep(1000);  // simulate a lot of processing

                // tell the user we are in thread #2
                Console.WriteLine("Thread 2 Output --> {0}", _threadOutput);

            }

        }
    }
}
