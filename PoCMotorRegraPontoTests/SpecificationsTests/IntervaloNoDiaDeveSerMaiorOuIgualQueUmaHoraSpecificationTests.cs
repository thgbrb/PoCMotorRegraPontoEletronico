using System;
using System.Linq;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;
using PocCMotorRegraPonto.Validacao;
using Xunit;
using Xunit.Abstractions;

namespace PoCMotorRegraPontoTests.SpecificationsTests
{
    public class IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecificationTests
    {
        private readonly ITestOutputHelper _output;

        public IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecificationTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(MockRegistros.MockRegistrosTurnoDiurno), parameters: 500,
            MemberType = typeof(MockRegistros))]
        public void DeveValidarSpecificationIntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification(Registro registro)
        {
            // Arrange 

            var validador = new Validador()
                .AdicionarSpecification(new IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification());

            // Processa resultado (materializa) ou yield return
            var resultado = validador.Validar(registro);

            // PoC: Processando resultado
            var r = resultado.First();

            // Assert
            if (r.EhSucesso)
                Assert.True(Convert.ToDecimal(r.Valor) >= 1m);
            else
                Assert.True(Convert.ToDecimal(r.Valor) < 1m);

            _output.WriteLine($"{r.EhSucesso} - {r.Valor} - {r.Mensagem}");
        }
    }
}