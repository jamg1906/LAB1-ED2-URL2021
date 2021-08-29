using System;
using System.Collections.Generic;
using System.Text;

namespace LAB1_DataStructures.Tree
{
    class BTreeNode<T>
    {
        //public int id { get; set; }
        public List<T> values { get; set;}
        
        //public List<int> children { get; set; }
        public List<BTreeNode<T>> children { get; set; }
        public BTreeNode<T> parent { get; set; }

        public int NumberOfValues = 0;
        public bool isLeaf = false;

        public BTreeNode(int degree) //método para inicializar un nodo.
        {
            if (values == null)
            {
                values = new List<T>(degree - 1); // si la lista no existe se crea con el número de valores máximos
                for (int i = 0; i < degree-1; i++)
                {
                    values.Add(default(T));
                }
                children = new List<BTreeNode<T>>(degree);
                for (int i = 0; i < degree; i++)
                {
                    children.Add(null); //No existe el nodo.
                }
            }
        }


    }
}
