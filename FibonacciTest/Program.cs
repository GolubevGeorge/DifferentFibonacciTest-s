using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace FibonacciTest
{
    class FibonacciRecursive
    {
        public int FibRecurs(int n)
        {
            return n > 1 ? FibRecurs(n - 1) + FibRecurs(n - 2) : n;
        }
    }

    class FibonacciMemoizationRecursive
    {
        int[] memF = new int[50];
        public int FibRecursMem(int n)
        {
            if (n <= 1) return n;
            if (memF[n] != 0) return memF[n];
            memF[n] = FibRecursMem(n - 2) + FibRecursMem(n - 1);
            return memF[n];
        }
    }

    class FibonacciIteration
    {
        public int FibIter(int n)
        {
            int prev = 0, cur = 1, next;

            if (n <= 1) return n;
            for (int i = 2; i <= n; ++i)
            {
                next = cur + prev;
                prev = cur;
                cur = next;
            }
            return cur;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 45;
            Console.WindowWidth = 60;

            var sw = new Stopwatch();
            var fibRec = new FibonacciRecursive();
            var fibRecMem = new FibonacciMemoizationRecursive();
            var fibIter = new FibonacciIteration();
            int number, iteration, result = 0;
            long memoryBefore, memoryAfter, memoryResult = 0, averageTicks = 0;

            memoryBefore = GC.GetTotalMemory(true);
            Console.WriteLine("Byte used now = {0}", memoryBefore);
            Console.WriteLine(new string('_', 45));

            Console.Write("\nEnter number: ");
            number = Int32.Parse(Console.ReadLine());

            Console.Write("Enter number of iteration: ");
            iteration = Int32.Parse(Console.ReadLine());
            long[] arrayTicks = new long[iteration];
            Console.WriteLine();

            #region Recursive method

            Console.WriteLine(new string('_', 45));
            Console.WriteLine("\nRecursive method");

            memoryAfter = GC.GetTotalMemory(true);
            Console.WriteLine("\nBytes of memory used before {0}", memoryAfter);

            for (int i = 0; i < iteration; i++)
            {
                sw.Start();
                result = fibRec.FibRecurs(number);
                sw.Stop();
                arrayTicks[i] = sw.Elapsed.Ticks;
                sw.Reset();
            }
            memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Bytes of memory used after {0}", memoryAfter);
            memoryResult = memoryAfter - memoryBefore;
            Console.WriteLine("Memroy used {0}", memoryResult);

            for (int i = 0; i < arrayTicks.Length; i++)
            {
                averageTicks += arrayTicks[i];
            }
            averageTicks /= iteration;
            Console.WriteLine("Average time is {0} ticks ", averageTicks);
            Console.WriteLine("Result for recursive method is: {0}.", result);
            sw.Reset();

            #endregion
            
            #region Memoization method

            Console.WriteLine(new string('_', 45));
            Console.WriteLine("\nRecursive with memoization method ");

            memoryBefore = GC.GetTotalMemory(true);
            Console.WriteLine("\nMemory before {0}", memoryBefore);

            for (int i = 0; i < iteration; i++)
            {
                sw.Start();
                result = fibRecMem.FibRecursMem(number);
                sw.Stop();
                arrayTicks[i] = sw.Elapsed.Ticks;
                sw.Reset();
            }
            memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Memory after {0}", memoryAfter);
            memoryResult = (memoryAfter - memoryBefore);
            Console.WriteLine("Memroy used {0}", memoryResult);

            for (int i = 0; i < arrayTicks.Length; i++)
            {
                averageTicks += arrayTicks[i];
            }
            averageTicks /= iteration;
            Console.WriteLine("Average time is {0} ticks ", averageTicks);
            Console.WriteLine("Result for recursive method is: {0}.", result);
            sw.Reset();

            #endregion
            
            #region Iterative method

            Console.WriteLine(new string('_', 45));
            Console.WriteLine("\nIterative method");

            memoryBefore = GC.GetTotalMemory(true);
            Console.WriteLine("\nMemory before {0}", memoryBefore);

            for (int i = 0; i < iteration; i++)
            {
                sw.Start();
                result = fibIter.FibIter(number);
                sw.Stop();
                arrayTicks[i] = sw.Elapsed.Ticks;
                sw.Reset();
            }
            memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Memory after {0}", memoryAfter);
            memoryResult = memoryAfter - memoryBefore;
            Console.WriteLine("Memroy used {0}", memoryResult);

            for (int i = 0; i < arrayTicks.Length; i++)
            {
                averageTicks += arrayTicks[i];
            }
            averageTicks /= iteration;
            Console.WriteLine("Average time is {0} ticks ", averageTicks);

            memoryResult = (memoryAfter - memoryBefore);
            Console.WriteLine("Result for recursive method is: {0}.", result);
            sw.Reset();
            Console.WriteLine(new string('_', 45));

            #endregion

            Console.ReadKey();
        }
    }
}
