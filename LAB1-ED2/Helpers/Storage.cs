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
        //Lab01.Models.Pelis Movie = new Lab01.Models.Pelis();
        //Lab01.Models.arbolB<Lab01.Models.Pelis> arbolito = new Lab01.Models.arbolB<Lab01.Models.Pelis>(1,default);
        public Lab01.Models.arbolB<Models.Movies> arbolito;
        public Lab01.Models.CompararCon<int> CC = new Lab01.Models.CompararCon<int>(Models.Movies.MovieComparison);
        //public static Lab01.Models.arbolB<Models.Movies> MoviesTree;


    }
}
