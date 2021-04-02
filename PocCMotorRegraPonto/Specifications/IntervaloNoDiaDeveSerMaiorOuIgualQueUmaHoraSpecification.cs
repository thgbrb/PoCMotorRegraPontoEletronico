using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    // Define uma regra que será aplicada para um par de marcação
    // O objetivo é que essa espeficação receba um par de marcações e aplique a regra.
    // Depois de validado a regra é devolvido um objeto que contém o resultado da validação.
    public class IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification : Specification<Registro>
    {
        // Mensagem de erro é uma constante é faz sentido somente dentro da própria specification
        private const string ERRO = "O tempo de intervalo deve ser maior ou igual que 1 hora.";

        // Define uma função que validará as regras para um par de marcação
        protected override Func<Registro, Resultado> ExpressionDefinition() =>
            marcacoes =>
            {
                // Registros validos
                // E SE SE SE S
                // 0 12 34 56 7

                if (!marcacoes.Batidas[4].IsInicializada || !marcacoes.Batidas[3].IsInicializada)
                    throw new ArgumentException("Uma ou mais batidas do intervalo não foram adicionadas. Adicionar no objeto de erro");
                
                // Aplica regra nos pares de marcação
                var valor = marcacoes.Batidas[4].Horario - marcacoes.Batidas[3].Horario;

                // Define regra para indicar sucesso
                var ehSucesso = valor >= 1;

                // Cria um objeto com as informações do processamento da regra
                var resultado = new Resultado(
                    valor: valor.ToString(),
                    mensagem: ehSucesso ? string.Empty : ERRO,
                    ehSucesso: ehSucesso);

                return resultado;
            };
    }
}