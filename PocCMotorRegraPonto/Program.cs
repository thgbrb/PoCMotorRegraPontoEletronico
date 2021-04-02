using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;

namespace PocCMotorRegraPonto
{
    class Program
    {
        static void Main(string[] args)
        {
            var valor = 255u;

            var resultado = BitOperations.PopCount(valor);

            Console.WriteLine(resultado);
            Console.WriteLine(resultado % 2);
            Console.WriteLine(Convert.ToString(valor, 2));
        }
    }
}