namespace PocCMotorRegraPonto.Registros
{
    public class Regras
    {
        private byte[] _regras = new byte[255];

        public void InicializarRegras()
        {
            for (byte i = 0; i <= 255; i++)
            {
                _regras[i] = i;
            }
        }
    }
}