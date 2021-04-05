using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;
using Xunit;
using Xunit.Abstractions;

namespace PoCMotorRegraPontoTests.SpecificationsTests
{
    public class NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeiaTests
    {
        private readonly ITestOutputHelper _output;

        public NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeiaTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [MemberData(nameof(MockRegistros.MockRegistrosTurnoDiurno), parameters: 500,
            MemberType = typeof(MockRegistros))]
        public void DeveValidarSpecificationNumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia(Registro registro)
        {
            // Arrange 
            var strategy = new NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia();

            // Act
            var resultado = strategy.IsSatisfyBy(registro, default);

            // Assert
            if (resultado.EhSucesso)
                Assert.True(Convert.ToDecimal(resultado.ValorCalculado) <= 9.5m);
            else
                Assert.True(Convert.ToDecimal(resultado.ValorCalculado) > 9.5m);

            _output.WriteLine($"{resultado.EhSucesso} - {resultado.ValorCalculado} - {resultado.Mensagem}");
        }
    }
}