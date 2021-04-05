using BenchmarkDotNet.Running;
using PoCMotorRegraPontoTests.Registros;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(RegistroTests).Assembly);
        }
    }
}