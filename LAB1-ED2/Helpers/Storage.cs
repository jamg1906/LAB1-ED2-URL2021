using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB1_DataStructures;

namespace LAB1_ED2.Helpers
{
    public class Storage
    {
        private static Storage _instance = null;

        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }
        //AQUÍ SE DEBERÍA DECLARAR EL ÁRBOL B

        public Lab01.Models.arbolB<Models.Movies> arbolito;

    }
}
