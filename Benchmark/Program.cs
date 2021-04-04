using System;
using System.Collections;
using System.Numerics;
using BenchmarkDotNet.Running;
using PoCMotorRegraPontoTests.Registros;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // var summary = BenchmarkRunner.Run(typeof(RegistroTests).Assembly);

            var a = 2;

            var r = (a ^ 1) == a + 1;

            Console.WriteLine(r);
        }
    }
}