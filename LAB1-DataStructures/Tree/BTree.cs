using System;
using System.Collections.Generic;
using System.Text;

namespace LAB1_DataStructures.Tree
{
    public class BTree<T> : Interfaces.IBTree<T>
    {
        public int degree { get; set; }
        //public int root = -1;
        public int count;
        public Delegate Comparer;
        //int current_id = 1;
        private BTreeNode<T> Root { get; set; }

        //int SetID()
        //{
        //    current_id++;
        //    return current_id - 1;
        //}
        public void Delete(T value)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                //No hay raíz, se crea.
                BTreeNode<T> node = new BTreeNode<T>(degree)
                {
                    parent = null,
                    isLeaf = true,
                };
                node.values.Add(value);
                //root = current_id - 1;
            }
            else
            {
                //ya hay raíz, se busca sí ya existe el valor.

                //si no existe, se inserta

                //ir a hoja navegando de acuerdo a los valores.

                //si existe se ignora
            }
            throw new NotImplementedException();
        }

        public bool Exists(T value)
        {
            return Exists(value, Root);
        }

        bool Exists(T value, BTreeNode<T> Node)
        {
            int i = 0;
            while (i < (count - 1) && ((int)Comparer.DynamicInvoke(value, Node.values[i]) != -1))
            {
                i++;
            }
            if ((int)Comparer.DynamicInvoke(value, Node.values[i]) == 0)
            {
                return true;
            }
            if (Root.isLeaf)
            {
                return false;
            }
            return Exists(value, Node.children[i]);

        }
    }
}
