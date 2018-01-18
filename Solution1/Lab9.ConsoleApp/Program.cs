using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        #region Multithreading examples part 1

        // http://www.c-sharpcorner.com/article/introduction-to-multithreading-in-C-Sharp/
        // https://www.codeproject.com/Articles/1083/Multithreaded-Programming-Using-C

        public static void Example1()
        {
            var example1 = new MultitreadingExample1();
        }

        public static void Example2()
        {
            var example1 = new MultitreadingExample2();
        }

        public static void Example3()
        {
            var example1 = new MultitreadingExample3();
        }

        #endregion Multithreading examples part 1

        #region Multithreading examples part 2

        public static void Example4()
        {
            var multiThreadingExample4 = new MultiThreadingExample4();

            multiThreadingExample4.ThreadExampleTryCath();
        }

        public static void Example5()
        {
            var multiThreadingExample4 = new MultiThreadingExample4();

            multiThreadingExample4.ThreadExampleWaitForThreadToFinish();
        }

        public static void Example6()
        {
            var multiThreadingExample4 = new MultiThreadingExample4();

            multiThreadingExample4.ThreadExampleExecutionInBackground();
        }

        public static void Example7()
        {
            var multiThreadingExample4 = new MultiThreadingExample4();

            multiThreadingExample4.ThreadExampleExecutionWithPriority();
        }

        #endregion Multithreading examples part 2
    }
}
