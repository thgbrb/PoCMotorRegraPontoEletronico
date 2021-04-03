using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao
{
    public interface IValidadorStrategy
    {
        Resultado Executar(Registro registro);
    }
}