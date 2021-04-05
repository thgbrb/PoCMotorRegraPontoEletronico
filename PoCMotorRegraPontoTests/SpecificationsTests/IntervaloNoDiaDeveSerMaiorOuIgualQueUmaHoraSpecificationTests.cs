using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;
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
            var strategy = new IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification();

            // Act
            var resultado = strategy.IsSatisfyBy(registro, default);

            // Assert
            if (resultado.EhSucesso)
                Assert.True(Convert.ToDecimal(resultado.ValorCalculado) >= 1m);
            else
                Assert.True(Convert.ToDecimal(resultado.ValorCalculado) < 1m);

            _output.WriteLine($"{resultado.EhSucesso} - {resultado.ValorCalculado} - {resultado.Mensagem}");
        }
    }
}