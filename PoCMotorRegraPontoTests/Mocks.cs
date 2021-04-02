using System.Collections;
using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;

namespace PoCMotorRegraPontoTests
{
    public class MockRegistros : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new Registro(esquerda: new Batida(12, 01), direita: new Batida(12, 34))};
            yield return new object[] {new Registro(esquerda: new Batida(13, 01), direita: new Batida(14, 12))};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Lista de batidas recebidas na API
    // Lista de batidas obtidas em processos background
    public class MockBatidas : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new Batida(16, 20)};
            yield return new object[] {new Batida(8, 10)};
            yield return new object[] {new Batida(9, 30)};
            yield return new object[] {new Batida(9, 15)};
            yield return new object[] {new Batida(12, 30)};
            yield return new object[] {new Batida(14, 00)};
            yield return new object[] {new Batida(16, 00)};
            yield return new object[] {new Batida(19, 00)};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}