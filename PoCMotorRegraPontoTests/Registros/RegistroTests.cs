using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using PocCMotorRegraPonto.Registros;
using Xunit;
using Xunit.Abstractions;

namespace PoCMotorRegraPontoTests.Registros
{
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    [HardwareCounters(HardwareCounter.TotalCycles)]
    public class RegistroTests
    {
        private readonly ITestOutputHelper _output;

        public RegistroTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        [Benchmark]
        public void DeveRetornarUmRegistroValido()
        {
            // Arrange
            var registro = Registro
                .Criar()
                .AdicionarBatida(new Batida(16, 20))
                .AdicionarBatida(new Batida(8, 10))
                .AdicionarBatida(new Batida(9, 15))
                .AdicionarBatida(new Batida(9, 30))
                .AdicionarBatida(new Batida(12, 30))
                .AdicionarBatida(new Batida(14, 00))
                .AdicionarBatida(new Batida(16, 00))
                .AdicionarBatida(new Batida(19, 00));

            // Act
            registro.Build();

            // Assert
            Assert.True(registro.EhValido);
        }

        [Fact]
        [Benchmark]
        public void DeveRetornarUmaListaDeRegistrosValidos()
        {
            // Arrange

            var random = new Random();

            // Act
            for (int i = 0; i < 5000; i++)
            {
                var registro = Registro
                    .Criar()
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .AdicionarBatida(new Batida((short) random.Next(0, 23), (short) random.Next(0, 59)))
                    .Build();

                // Assert
                Assert.True(registro.EhValido);
            }
        }

        [Fact]
        public void DeveRetornarUmRegistroInvalido()
        {
            // Arrange
            var registro = Registro
                .Criar()
                .AdicionarBatida(new Batida(16, 20))
                .AdicionarBatida(new Batida(8, 10))
                .AdicionarBatida(new Batida(9, 15))
                .AdicionarBatida(new Batida(9, 30))
                .AdicionarBatida(new Batida(14, 00))
                .AdicionarBatida(new Batida(16, 00))
                .AdicionarBatida(new Batida(19, 00));

            // Act
            registro.Build();

            // Act
            Assert.False(registro.EhValido);
        }

        [Fact]
        public void DeveRetornarUmaExceptionQuandoAsBatidasForemAcessadasSemExecutarOMetodoBuildNoObjetoRegistro()
        {
            // Arrange
            var registro = Registro
                .Criar()
                .AdicionarBatida(new Batida(16, 20))
                .AdicionarBatida(new Batida(8, 10))
                .AdicionarBatida(new Batida(9, 15))
                .AdicionarBatida(new Batida(9, 30))
                .AdicionarBatida(new Batida(14, 00))
                .AdicionarBatida(new Batida(16, 00))
                .AdicionarBatida(new Batida(19, 00));

            // Act
            // nothing

            // Act
            Assert.Throws<InvalidOperationException>(() => registro.Batidas.ToList());
        }

        public void DeveCalcularAQuantidadeDeHorasTrabalhadasNoDia()
        {
        }

        public void DeveDescobrirAPrimeiraMarcacaoDoDia()
        {
        }

        public void DeveDescobrirAUltimaMarcacaoDoDia()
        {
        }

        public void DeveRetornarErroNumeroHorasDoDiaSuperiorANoveHorasEMeia()
        {
        }

        public void DeveRetornarSucessoNumeroDeHorasDoDiaInferiorANoveHorasEMeia()
        {
        }

        public void DeveDescobrirAJornadaDoTurno()
        {
            // 6 horas
            // 8,5 horas
            // outros
        }

        public void DeveCriarValidacaoParaUmTurnoDeOitoHorasEMeia()
        {
        }
    }
}