using System;
using System.Diagnostics;

namespace loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch(); 
            const long N = 40000000; 
            double[] A, B, C; 
            A = new double[N]; 
            B = new double[N]; 
            C = new double[N]; 
            Random rand = new Random();
            for (int i = 0; i < N; i++)
            {
                A[i] = rand.Next(); 
                B[i] = rand.Next(); 
                C[i] = rand.Next();
            } 
            Console.WriteLine("Starts sequential for now."); 
            stopwatch.Start();
            for (int i = 0; i < N; i++)
            {
                C[i] = A[i] * B[i];
            } 
            stopwatch.Stop(); Console.WriteLine("Sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds); 
            stopwatch.Reset(); Console.WriteLine("Finished");
        }
    }
}
