using System;
using LAB1_DataStructures.Tree;

namespace LAB1_ConsoleApp
{
    class Program
    {
        public static Comparison<int> IntComparison = delegate (int x1, int x2)
        {
            if (x1 > x2) return 1;
            if (x2 > x1) return -1;
            return 0;
        };
        public static void Header()
        {
            Console.Clear();
            string textToEnter = "--PRÁCTICA DE LABORATORIO #1 - ESTRUCTURA DE DATOS 2--";
            string textToEnter2 = "----- Javier Andrés Morales González - 1210219 | Mario José Roldán Hernández - 1117517 -----";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter2.Length / 2)) + "}", textToEnter2));
            Console.WriteLine("\n");
            Console.ResetColor();
        }
        public static void TitleOption1()
        {
            string t = "--NÚMEROS AL AZAR--";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t) + "\n");
            Console.ResetColor();
        }
        public static void TitleOption2()
        {
            string t = "--INGRESO MANUAL DE NÚMEROS--";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t) + "\n");
            Console.ResetColor();
        }
        public static void TitleTraversal(int n)
        {
            switch (n)
            {
                case 1:
                    {
                        string t = "--PREORDER--";
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t) + "\n");
                        Console.ResetColor();
                    }
                    break;
                case 2:
                    {
                        string t = "--INORDER--";
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t) + "\n");
                        Console.ResetColor();
                    }
                    break;
                case 3:
                    {
                        string t = "--POSTORDER--";
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (t.Length / 2)) + "}", t) + "\n");
                        Console.ResetColor();
                    }
                    break;
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Seleccione una opción:\n" + "\n1. Ingresar números al azar." + "\n2. Ingresar números manualmente." + "\n3. Salir del programa." + Environment.NewLine);
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Header();
                    Menu();
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                //DECLARAR ARBOL B
                                LAB1_DataStructures.Tree.BTree<int> Tree = new LAB1_DataStructures.Tree.BTree<int>();
                                Tree.Comparer = IntComparison;
                                bool a = true;
                                while (a)
                                {
                                    try
                                    {
                                        Header();
                                        TitleOption1();
                                        Console.WriteLine("Ingrese el grado del árbol B (debe ser mayor a 2):");
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        if (m < 2)
                                        {
                                            throw new FormatException();
                                        }
                                        //SET GRADO DEL ARBOL
                                        Tree.degree = m;
                                        Header();
                                        TitleOption1();
                                        Console.WriteLine("Ingrese la cantidad de números al azar a ingresar (debe ser mayor a 0):");
                                        int i = Convert.ToInt32(Console.ReadLine());
                                        if (i < 1)
                                        {
                                            throw new FormatException();
                                        }
                                        Header();
                                        TitleOption1();
                                        Console.WriteLine("Ingrese el número mínimo generado al azar:");
                                        int min = Convert.ToInt32(Console.ReadLine());
                                        Header();
                                        TitleOption1();
                                        Console.WriteLine("Ingrese el número máximo generado al azar:");
                                        int max = Convert.ToInt32(Console.ReadLine());
                                        if (min > max || min == max)
                                        {
                                            throw new FormatException();
                                        }
                                        Header();
                                        TitleOption1();
                                        Random ElRandom1 = new Random();
                                        for (int j = 0; j < i; j++)
                                        {
                                            //INSERTAR ACA AL ARBOL B EL NÚMERO GENERADO AL AZAR.
                                            Tree.Insert(ElRandom1.Next(min, max));
                                        }
                                        Console.WriteLine("Se ha llenado satisfactoriamente el árbol. Presione cualquier tecla para ver los recorridos.");
                                        Console.ReadKey();
                                        Header();
                                        TitleOption1();
                                        a = false;
                                        TitleTraversal(1);
                                        //METER EN LISTA RECORRIDO EL PREORDER DEL ARBOL
                                        string result = "";
                                        int iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result);
                                        TitleTraversal(2);
                                        //METER EN LISTA RECORRIDO EL INORDER DEL ARBOL
                                        result = "";
                                        iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result);
                                        TitleTraversal(3);
                                        //METER EN LISTA RECORRIDO EL POSTORDER DEL ARBOL
                                        result = "";
                                        iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result + "\n");
                                        string f = "Finalizaron los recorridos. Presione una tecla para volver al menú principal.";
                                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (f.Length / 2)) + "}", f) + "\n");
                                        Console.ReadKey();
                                    }
                                    catch
                                    {
                                        Header();
                                        string e = "Ocurrió un error. Presione una tecla para volver al menú principal.";
                                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (e.Length / 2)) + "}", e) + "\n");
                                        Console.ReadKey();
                                        a = false;
                                    }
                                }
                            }
                            break;
                        case 2:
                            {
                                //DECLARAR ARBOL B
                                bool b = true;
                                while (b)
                                {
                                    try
                                    {
                                        Header();
                                        TitleOption2();
                                        Console.WriteLine("Ingrese el grado del árbol B (debe ser mayor a 2):");
                                        int m = Convert.ToInt32(Console.ReadLine());
                                        if (m < 2)
                                        {
                                            throw new FormatException();
                                        }
                                        //SET GRADO DE ARBOL CON EL VALOR INGRESAOD
                                        Header();
                                        TitleOption2();
                                        Console.WriteLine("Ingrese un número para insertarlo en el árbol: (Si desea parar ingrese otro caracter o presione enter)");
                                        //CREAR LISTA DE INTS ADDME
                                        bool stop = false;
                                        while (!stop)
                                        {
                                            try
                                            {
                                                int me = Convert.ToInt32(Console.ReadLine());
                                                //AÑADIR A ADDME EL INT
                                            }
                                            catch
                                            {
                                                stop = true;
                                                //if (AddMe.Count == 0)
                                                {
                                                    throw new FormatException();
                                                }
                                            }
                                        }
                                        Header();
                                        TitleOption2();
                                        /*foreach (int n in AddMe)
                                        {
                                            //INSERTAR N EN ARBOL B
                                        }*/
                                        Console.WriteLine("Se ha llenado satisfactoriamente el árbol. Presione cualquier tecla para ver los recorridos.");
                                        Console.ReadKey();
                                        Header();
                                        TitleOption2();
                                        b = false;
                                        TitleTraversal(1);
                                        //METER EN LISTA RECORRIDO EL PREORDER DEL ARBOL
                                        string result = "";
                                        int iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result);
                                        TitleTraversal(2);
                                        //METER EN LISTA RECORRIDO EL INORDER DEL ARBOL
                                        result = "";
                                        iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result);
                                        TitleTraversal(3);
                                        //METER EN LISTA RECORRIDO EL POSTORDER DEL ARBOL
                                        result = "";
                                        iterardor = 1;
                                        /*foreach (int number in Recorrido)
                                        {
                                            result += number.ToString() + ",";
                                            if ((iterardor % m) == 0)
                                            {
                                                result += Environment.NewLine;
                                            }
                                            iterardor++;
                                        }*/
                                        Console.WriteLine(result + "\n");
                                        string f = "Finalizaron los recorridos. Presione una tecla para volver al menú principal.";
                                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (f.Length / 2)) + "}", f) + "\n");
                                        Console.ReadKey();
                                    }
                                    catch
                                    {
                                        Header();
                                        string e = "Ocurrió un error. Presione una tecla para volver al menú principal.";
                                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (e.Length / 2)) + "}", e) + "\n");
                                        Console.ReadKey();
                                        b = false;
                                    }
                                }
                            }
                            break;
                        case 3:
                            {
                                exit = true;
                            }
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Ha ocurrido un error.");
                    Console.Clear();
                }
            }
        }
    }
}
