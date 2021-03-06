using System;
using System.Diagnostics;

namespace Performance
{
    internal class Program
    {
        private const int ArraySize = 100000;
        public static void Main(string[] args)
        {
            var rnd = new Random();
            
            var privateMemoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;
            var classes = new C[ArraySize];
            
            for (var i = 0; i < ArraySize; i++)
                classes[i] = new C(rnd.Next());
            
            var privateMemoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;
            var classDelta = privateMemoryAfter - privateMemoryBefore;
            Console.WriteLine("Memory Delta after classes initialization : {0}", classDelta);

            privateMemoryBefore = Process.GetCurrentProcess().PrivateMemorySize64;
            var structs = new S[ArraySize];
            
            for (var i = 0; i < ArraySize; i++)
                structs[i] = new S(rnd.Next());
            
            privateMemoryAfter = Process.GetCurrentProcess().PrivateMemorySize64;
            var structDelta = privateMemoryAfter - privateMemoryBefore;
            Console.WriteLine("Memory Delta after structs initialization : {0}", structDelta);
            Console.WriteLine("Memory Delta between class and struct deltas : {0}", classDelta - structDelta);

            var sw = new Stopwatch();
            sw.Start();
            Array.Sort(classes);
            sw.Stop();
            Console.WriteLine("Sorting classes array took {0}ms", sw.ElapsedMilliseconds);
            
            sw.Restart();
            Array.Sort(structs); 
            sw.Stop();
            Console.WriteLine("Sorting structs array took {0}ms", sw.ElapsedMilliseconds);
        }
    }
}