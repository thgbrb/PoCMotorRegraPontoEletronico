using System;
using System.Collections.Generic;
using System.Linq;
using PocCMotorRegraPonto.Registros;

namespace PoCMotorRegraPontoTests
{
    // Simula batidas recebidas em uma API ||
    // Simula batidas recebidas de processos background
    public class MockRegistros
    {
        const int QUANTIDADE_REGISTROS = 5000;

        public static IEnumerable<object[]> MockRegistrosTurnoDiurno(int numRegistros)
        {
            var registros = new List<object[]>();
            var random = new Random();

            for (int i = 0; i < QUANTIDADE_REGISTROS; i++)
            {
                var registro = Registro
                    .Criar()
                    .AdicionarBatida(new Batida((short) random.Next(6, 9), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(10, 10), (short) random.Next(0, 30)))
                    .AdicionarBatida(new Batida((short) random.Next(10, 10), (short) random.Next(31, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(11, 13), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(13, 14), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(15, 15), (short) random.Next(0, 30)))
                    .AdicionarBatida(new Batida((short) random.Next(15, 15), (short) random.Next(31, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(16, 19), (short) random.Next(0, 59)))
                    .Build();

                registros.Add(new object[] {registro});
            }

            return registros.Take(numRegistros);
        }
    }
}