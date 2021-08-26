using System;
using System.Collections.Generic;
using System.Text;

namespace LAB1_DataStructures.Tree
{
    class BTreeNode<T>
    {
        public int id { get; set; }
        public List<T> values { get; set;}
        public List<int> children { get; set; }
        public int parent { get; set; }

        public BTreeNode(int degree) //método para inicializar un nodo.
        {
            if (values == null)
            {
                values = new List<T>(degree - 1); // si la lista no existe se crea con el número de valores máximos
                children = new List<int>(degree);
                for (int i = 0; i < degree; i++)
                {
                    children.Add(-1); // -1 como identificador de un nodo que no existe.
                }
            }
        }


    }
}
