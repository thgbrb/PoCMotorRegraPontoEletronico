using System.Linq;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;
using Xunit;

namespace PoCMotorRegraPontoTests
{
    public class Playground
    {
        [Fact]
        public void DeveReceberUmRegistroEValidarResultadoDeValidacao()
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
                .AdicionarBatida(new Batida(19, 00))
                .Build();

            // Act
            var resultados = Validador
                .Inicializar(registro)
                // .AdicionarValidador(Validadores.Estagiario)
                // .AdicionarValidador(Validadores.CLT)
                // .AdicionarValidador(Validadores.MenorAprendiz)
                .AdicionarValidador(Validadores.Jornada40HorasSemanais)
                .Executar();

            var resultado = resultados.ToList();

            // Assert
            Assert.True(resultado.Any());
        }
    }
}