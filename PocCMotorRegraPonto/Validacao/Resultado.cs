using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao
{
    /// <summary>
    /// Registra o resultado da validação de um registro.
    /// </summary>
    public class Resultado
    {
        // Memória do resultado calculado das horas (ex.: horainicial - horafinal, tempo intervalo).
        public string ValorCalculado { get; set; }

        // Mensagem do resultado da validação.
        public string Mensagem { get; set; }

        // Marca objeto com sucesso.
        public bool EhSucesso { get; set; }

        // Objeto atual para aplicar validação.
        public Registro Current { get; set; }

        // Objeto do próximo registro para validações onde é necessário usar o registo atual e próximo juntos (ex.: jornada noturna).
        public Registro Next { get; set; }

        /// <summary>
        /// Cria objeto com o resultado de uma validação
        /// </summary>
        /// <param name="valorCalculado">Memória do resultado calculado das horas (ex.: horainicial - horafinal, tempo intervalo).</param>
        /// <param name="mensagem">Mensagem do resultado da validação.</param>
        /// <param name="ehSucesso">Marca objeto com sucesso.</param>
        /// <param name="current">Objeto atual para aplicar validação.</param>
        /// <param name="next">Objeto do próximo registro para validações onde é necessário usar o registo atual e próximo juntos (ex.: jornada noturna).</param>
        public Resultado(string valorCalculado, string mensagem, bool ehSucesso, Registro current,
            Registro next = default)
        {
            ValorCalculado = valorCalculado;
            Mensagem = mensagem;
            EhSucesso = ehSucesso;
            Current = current;
            Next = next;
        }
    }
}