using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    ///<inheritdoc/>
    public class IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification : Specification<Registro>
    {
        // Mensagem de erro é uma constante é faz sentido somente dentro da própria specification
        private const string ERRO = "O tempo de intervalo deve ser maior ou igual que 1 hora.";

        ///<inheritdoc/>
        protected override Func<Registro, Registro, Resultado> ExpressionDefinition() =>
            (current, next) =>
            {
                // Registros validos
                // E SE SE SE S
                // 0 12 34 56 7

                if (!current.Batidas[4].IsInicializada || !current.Batidas[3].IsInicializada)
                    throw new ArgumentException(
                        "Uma ou mais batidas do intervalo não foram adicionadas. Adicionar no objeto de erro");

                // Aplica regra nos pares de marcação
                var valor = current.Batidas[4].Horario - current.Batidas[3].Horario;

                // Define regra para indicar sucesso
                var ehSucesso = valor >= 1;

                // Cria um objeto com as informações do processamento da regra
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