namespace Lab01.Models
{
    public class DataSingelton
    {
        private static DataSingelton _instance = null;
        public static DataSingelton Instance
        {
            get
            {
                if (_instance == null) _instance = new DataSingelton();
                return _instance;
            }
        }
        private static Comparador _Comparador = new Comparador();
        public arbolB<Pelis> Arbolb = new arbolB<Pelis>(5, _Comparador.CompararPortitle);
    }
}
