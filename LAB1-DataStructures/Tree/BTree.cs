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
                node.values[0] = value;
                Root = node;
                Root.NumberOfValues++;
                count++;
                //root = current_id - 1;
            }
            else
            {
                //ya hay raíz, se busca sí ya existe el valor.
                if (!Exists(value))
                {
                    if (Root.NumberOfValues == degree-1)
                    {
                        BTreeNode<T> Temporal = new BTreeNode<T>(degree);
                        Temporal.isLeaf = false;
                        Temporal.parent = null;
                        Temporal.children[0] = Root;
                        Split(0, Root);
                        int i = 0;
                        if ((int)Comparer.DynamicInvoke(Temporal.values[0], value) == -1)
                        {
                            i++;
                        }
                        InsertInNode(value, Temporal.children[i]);
                        Root = Temporal;
                    }
                    else
                    {
                        InsertInNode(value, Root);
                    }
                    //No existe, se inserta
                    //int d = Root.values.Capacity;
                    //ir a hoja navegando de acuerdo a los valores.

                }
                else
                {
                    //si existe se ignora
                }

                //ir a hoja navegando de acuerdo a los valores.

            }
        }

        void InsertInNode(T value)
        {
            InsertInNode(value, Root);
        }

        void InsertInNode(T value, BTreeNode<T> Node)
        {
            //Aquí habría que ir a buscar un nodo que tenga espacio y que sea hoja para insertar el valor.
            int i = Node.NumberOfValues - 1;
            if (Node.isLeaf)
            {
                while (i >= 0 && ((int)Comparer.DynamicInvoke(Node.values[i], value) == 1))
                {
                    Node.values[i + 1] = Node.values[i];
                    i--;
                }
                Node.values[i + 1] = value;
                Node.NumberOfValues++;
            }
            else
            {
                while (i >= 0 && ((int)Comparer.DynamicInvoke(Node.values[i], value) == 1))
                {
                    i--;
                }
                if (Node.children[i + 1].NumberOfValues == degree-1) //2tpord
                {
                    //split
                    Split(i + 1, Node.children[i + 1]);
                    if (((int)Comparer.DynamicInvoke(Node.values[i + 1], value) == -1))
                    {
                        i++;
                    }
                }
                InsertInNode(value, Node.children[i + 1]);
            }
        }

        void Split(int i, BTreeNode<T> Node)
        {
            BTreeNode<T> Temp = new BTreeNode<T>(degree);
            Temp.isLeaf = Node.isLeaf;
            Temp.NumberOfValues = degree/2 - 1;
            for (int j = 0; j < degree/2 - 1; j++) //degpor/2
            {
                Temp.values[j] = Node.values[j + degree/2];//cambié por deg medios
            }
            if (!Node.isLeaf)
            {
                for (int j = 0; j < degree/2; j++)//degpor/2
                {
                    Temp.children[j] = Node.children[j + degree/2];//degpor/2
                }
            }
            Node.NumberOfValues = degree/2 - 1;
            //acá voy a probar
            for (int j = Node.NumberOfValues; j >= i + 1; j--)
            {
                Node.children[j + 1] = Node.children[j];
            }
            Node.children[i + 1] = Temp;
            for (int j = Node.NumberOfValues-1; j >= i; j--)
            {
                Node.values[j + 1] = Node.values[j];
            }
            Temp.values[i] = Node.values[degree/2 - 1];//degpor/2
            Temp.NumberOfValues++;
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
