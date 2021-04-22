using System;
using System.Threading;
using System.Threading.Tasks;

namespace threads
{
    class Program
    {
        static void Main(string[] args)
        {




            //var w1 = new HelloWriter("kurt");
            //var w2 = new HelloWriter("Flemming");
            //Task.Run(() => w1.SayHello(1000,200));
            //var k= Task.Run(() => w2.SayHello(1000,500));
            //Console.WriteLine("Hello");
            //Task.WaitAll(k);

        }
    }

    public class HelloWriter
    {
        private readonly string Name;

        public HelloWriter(string name)
        {
            Name = name;
        }

        public  void SayHello(int number,int sleep)
        {
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Hello from " +Name +" #"+ i);
                Thread.Sleep(sleep);
            }
        }
    }
}
