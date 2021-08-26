using System;
using LAB1_DataStructures.Tree;
using System.Collections.Generic;
using System.Text;

namespace LAB1_DataStructures.Interfaces
{
    interface IBTree<T>
    {
        void Insert(T value);
        void Delete(T value);

    }
}
