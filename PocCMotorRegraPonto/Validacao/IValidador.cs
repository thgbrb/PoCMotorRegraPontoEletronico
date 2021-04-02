using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao
{
    public interface IValidador
    {
        Resultado Executar(Registro registro);
    }
}