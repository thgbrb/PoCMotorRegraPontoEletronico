using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    ///<inheritdoc/>
    public class NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia : Specification<Registro>
    {
        private const string ERRO = "A jornada de trabalho diária deve ser menor ou igual a 9,5 horas.";

        ///<inheritdoc/>
        protected override Func<Registro, Registro, Resultado> ExpressionDefinition() =>
            (current, next) =>
            {
                var valor =
                    current.Batidas[^1].Horario - current.Batidas[0].Horario;

                var ehSucesso = valor <= 9.5m;

                var resultado = new Resultado(
                    valorCalculado: valor.ToString(),
                    mensagem: ehSucesso ? string.Empty : ERRO,
                    ehSucesso: ehSucesso,
                    current: current,
                    next: next);

                return resultado;
            };
    }
}