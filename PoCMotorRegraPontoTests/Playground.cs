using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PoCMotorRegraPontoTests
{
    public class Playground
    {
        public void DeveReceberUmRegistroEValidarResultadoDeValidacao()
        {
            // Obtem um registro, que é composto por uma lista de batidas.
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

            // Cria validador e Executa validação

            var resultado = Validador
                .Inicializar(registro)
                .AdicionarValidador(Validadores.Estagiario)
                .AdicionarValidador(Validadores.CLT)
                .AdicionarValidador(Validadores.MenorAprendiz)
                .AdicionarValidador(Validadores.Jornada40HorasSemanais)
                .Executar();

            // Trata o resultado
        }
    }
}