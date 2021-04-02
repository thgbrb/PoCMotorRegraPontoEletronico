namespace PocCMotorRegraPonto.Registros
{
    public struct Batida
    {
        public short Hora;
        public short Minuto;
        public decimal Horario;

        public Batida(short hora, short minuto)
        {
            Hora = hora;
            Minuto = minuto;
            Horario = hora + (minuto / 60m);
        }
    }
}