using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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
                C[i] = 0;
            } 


            Console.WriteLine("Starts sequential for now."); 
            stopwatch.Start();
            for (int i = 0; i < N; i++)
            {
                C[i] = A[i] * B[i];
            } 
            stopwatch.Stop(); Console.WriteLine("sequential loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds); 
            stopwatch.Reset(); Console.WriteLine("Finished");

            Console.WriteLine("Parallel.loop  for now:");
            stopwatch.Start();
            Parallel.For(0, N, i => C[i] = A[i] * B[i]);
            stopwatch.Stop(); Console.WriteLine("parallel loop time in milliseconds: {0}", 
                stopwatch.ElapsedMilliseconds);
            stopwatch.Reset(); Console.WriteLine("Finished");
           
            

            Console.WriteLine("Parallel.foreach  for now:");
            stopwatch.Start();
            Parallel.ForEach(C, (c, x,i)=>c=B[i]*A[i]) ;
            stopwatch.Stop(); 
            Console.WriteLine("parallel loop time in milliseconds: {0}",
                stopwatch.ElapsedMilliseconds);
            stopwatch.Reset(); 
            Console.WriteLine("Finished");


            List<three> kurt = new List<three>();
            for (int i = 0; i < N; i++)
            {
                kurt.Add(new three());
                kurt[i].Arr = A[i];
                kurt[i].Brr = B[i];
            }

            Console.WriteLine("NEW Parallel.foreach  for now:");
            stopwatch.Start();
            Parallel.ForEach(kurt, (t) => t.Crr = t.Arr * t.Brr);
            stopwatch.Stop(); Console.WriteLine("parallel loop time in milliseconds: {0}",
                stopwatch.ElapsedMilliseconds);
            stopwatch.Reset(); Console.WriteLine("Finished");

            //List<double[]> kurt = new List<double[]>();

            //kurt.Add(A);
            //kurt.Add(B);
            //kurt.Add(C);

            //Console.WriteLine("Starts para for now.");
            //stopwatch.Start();
            //Parallel.ForEach(kurt, kurt => kurt[2] = kurt[1] * kurt[0]);
            //stopwatch.Stop(); Console.WriteLine("para loop time in milliseconds: {0}", stopwatch.ElapsedMilliseconds);
            //stopwatch.Reset(); Console.WriteLine("Finished");

            //Console.WriteLine($"A:{kurt[0][1]}, B:{kurt[1][1]}, C:{kurt[2][1]}");

            //Console.WriteLine($"A:{kurt[0][5000]}, B:{kurt[1][5000]}, C:{kurt[2][5000]}");

            //Console.WriteLine($"A:{kurt[0][400000]}, B:{kurt[1][400000]}, C:{kurt[2][400000]}");
        }

        public class three
        {
           public double Arr;
           public double Brr;
           public double Crr;
        }
    }
}
