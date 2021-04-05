namespace PocCMotorRegraPonto.Registros
{
    /// <summary>
    /// Cria um objeto com as informações de uma batida.
    /// </summary>
    public struct Batida
    {
        /// <summary>
        ///  Hora.
        /// </summary>
        public short Hora;

        /// <summary>
        /// Minuto.
        /// </summary>
        public short Minuto;

        /// <summary>
        ///  Calcula a hora decimal.
        /// </summary>
        public decimal Horario;

        /// <summary>
        /// Marca batida como inicializad.a
        /// </summary>
        public bool IsInicializada;

        /// <summary>
        /// Cria um objeto batida e calcula o seu valor decimal, que é utilizada nos cálculos.
        /// </summary>
        /// <param name="hora">Hora.</param>
        /// <param name="minuto">Minuto.</param>
        public Batida(short hora, short minuto)
        {
            Hora = hora;
            Minuto = minuto;
            Horario = hora + (minuto / 60m);
            IsInicializada = true;
        }
    }
}