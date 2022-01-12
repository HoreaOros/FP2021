using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_12
{
    class Program
    {
        static void Main(string[] args)
        {

            // Matrice patratica = matrice pentru care numarul de linii este egal cu numarul de coloane.

            //P1();



            P2();



        }

        /// <summary>
        /// Maximum size square sub-matrix with all 1s
        /// TODO: rezolvati aceasta problema mai eficient. 
        /// https://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/
        /// </summary>
        private static void P2()
        {
            // Rezolvare naiva. 
            int[,] matrix = ReadMatrix();
            int maxim = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int dim = Math.Min(matrix.GetLength(0) - i, matrix.GetLength(1) - j);
                    for (int k = 1; k <= dim; k++)
                    {
                        bool ok = true;
                        for (int lin = i; ok && lin < i + k; lin++)
                        {
                            for (int col = j; ok && col < j + k; col++)
                            {
                                if (matrix[lin, col] == 0)
                                {
                                    ok = false;
                                }
                            }
                        }
                        if (ok)
                            if (k > maxim)
                                maxim = k;
                    }
                }
            }
            Console.WriteLine(maxim);
        }

        private static void P1()
        {
            string line;
            line = Console.ReadLine();
            char[] sep = { ' ', '\n', '\t', ',', ';' };
            string[] tokens;

            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int n, z;
            n = int.Parse(tokens[0]);
            z = int.Parse(tokens[1]);
            int[,] matrix = ConsoleReadSquareMatrix(n);

            //PrintMatrix(matrix);

            switch (z)
            {
                case 1:
                    Console.WriteLine(Suma_Nord2(matrix));
                    break;
                case 2:
                    Console.WriteLine(Suma_Est(matrix));
                    break;
                case 3:
                    Console.WriteLine(Suma_Sud(matrix));
                    break;
                case 4:
                    Console.WriteLine(Suma_Vest(matrix));
                    break;
                default:
                    Console.WriteLine("Valorile posibile pentru <z> sunt 1, 2, 3, 4.");
                    break;
            }

        }

        private static int Suma_Nord2(int[,] matrix)
        {
            int suma = 0;
            int i;
            int j1, j2;

            j1 = 1;
            j2 = matrix.GetLength(0) - 2;
            for (i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = j1; j <= j2; j++)
                {
                    suma += matrix[i, j];
                }
                j1++;
                j2--;
            }
            return suma;
        }

        private static int Suma_Vest(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (SDP(i, j, matrix.GetLength(0)) && DDS(i, j, matrix.GetLength(0)))
                    {
                        suma += matrix[i, j];
                    }
                }
            }
            return suma;
        }

        private static int Suma_Sud(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (SDP(i, j, matrix.GetLength(0)) && SDS(i, j, matrix.GetLength(0)))
                    {
                        suma += matrix[i, j];
                    }
                }
            }
            return suma;
        }

        private static bool SDS(int i, int j, int n)
        {
            return i + j > n - 1;
        }

        private static bool SDP(int i, int j, int n)
        {
            return i > j;
        }

        private static int Suma_Est(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (DDP(i, j, matrix.GetLength(0)) && SDS(i, j, matrix.GetLength(0)))
                    {
                        suma += matrix[i, j];
                    }
                }
            }
            return suma;
        }

        /// <summary>
        /// Functia calculeaza suma elementelor matricii de deasupra diagonalei principale si deasupra diagonalei secundare
        /// </summary>
        /// <param name="matrix">Matricea</param>
        /// <returns>Suma</returns>
        private static int Suma_Nord(int[,] matrix)
        {
            int suma = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (DDP(i, j, matrix.GetLength(0)) && DDS(i, j, matrix.GetLength(0)))
                    {
                        suma += matrix[i, j];
                    }
                }

            }
            return suma;
        }

        /// <summary>
        /// Functia determina daca elementelul de pe pozitia (i, j) este deasupra diagonalei secundare
        /// a unei matrice patratice
        /// </summary>
        /// <param name="i">Indicele de linie</param>
        /// <param name="j">Indicele de coloana</param>
        /// <param name="n">Dimensiunea matricii</param>
        /// <returns>True sau False</returns>
        private static bool DDS(int i, int j, int n)
        {
            // pe diagonala secundara i + j == n - 1
            // deasupra diagonalei secundara i + j < n - 1
            // sub diagonalei secundara i + j == n - 1
            return i + j < n - 1;
        }

        /// <summary>
        /// Functia determina daca elementelul de pe pozitia (i, j) este deasupra diagonalei principale
        /// a unei matrice patratice
        /// </summary>
        /// <param name="i">Indicele de linie</param>
        /// <param name="j">Indicele de coloana</param>
        /// <param name="n">Dimensiunea matricii</param>
        /// <returns>True sau False</returns>
        private static bool DDP(int i, int j, int n)
        {
            // pe diagonala princiala i == j
            // deasupra diagonalei principale i < j
            // sub diagonala principala i > j
            return i < j;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int[,] ConsoleReadSquareMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            string line;
            
            char[] sep = { ' ', '\n', '\t', ',', ';' };
            
            string[] tokens;



            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line = Console.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(tokens[j]);
                }
            }

            return matrix;
        }


        private static int[,] ReadMatrix()
        {
            int[,] matrix;

            string line;
            line = Console.ReadLine();
            char[] sep = { ' ', '\n', '\t', ',', ';' };
            int linii, coloane;
            string[] tokens;

            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            linii = int.Parse(tokens[0]);
            coloane = int.Parse(tokens[1]);

            matrix = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                line = Console.ReadLine();
                tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < coloane; j++)
                {
                    matrix[i, j] = int.Parse(tokens[j]);
                }
            }

            return matrix;
        }
    }
}
