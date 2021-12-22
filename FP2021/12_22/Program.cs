using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12_22
{
    /// <summary>
    /// Matrici
    /// </summary>
    class Matrix
    {
        static void Main(string[] args)
        {
            P1(args[0]);
        }

        private static void P1(string fileName)
        {
            int[,] matrix1, matrix2;

            StreamReader sr = new StreamReader(fileName);

            matrix1 = ReadMatrix(sr);
            PrintMatrix(matrix1);

            matrix2 = ReadMatrix(sr);
            PrintMatrix(matrix2);

            int[,] matrix3 = Multiply(matrix1, matrix2);
            PrintMatrix(matrix3);

            Spiral(matrix3);
        }

        private static void Spiral(int[,] matrix)
        {
            int count = 0;
            int i1 = 0;
            int i2 = matrix.GetLength(0) - 1;
            int j1 = 0;
            int j2 = matrix.GetLength(1) - 1;

            while (count < matrix.Length)
            {
                for (int j = j1; j <= j2; j++)
                {
                    Console.Write($"{matrix[i1, j]} ");
                    count++;
                }
                i1++;
                if (count == matrix.Length)
                {
                    break;
                }

                for (int i = i1; i <= i2; i++)
                {
                    Console.Write($"{matrix[i, j2]} ");
                    count++;
                }
                j2--;
                if (count == matrix.Length)
                {
                    break;
                }


                for (int j = j2; j >= j1; j--)
                {
                    Console.Write($"{matrix[i2, j]} ");
                    count++;
                }
                i2--;
                if (count == matrix.Length)
                {
                    break;
                }


                for (int i = i2; i >= i1; i--)
                {
                    Console.Write($"{matrix[i, j1]} ");
                    count++;
                }
                j1++;
                if (count == matrix.Length)
                {
                    break;
                }
            }
        }

        private static int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            int suma;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    suma = 0;

                    for (int k = 0; k < matrix2.GetLength(0); k++)
                    {
                        suma += matrix1[i, k] * matrix2[k, j];
                    }


                    matrix[i, j] = suma;
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j], 5}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int[,] ReadMatrix(StreamReader sr)
        {
            int[,] matrix;
            
            string line;
            line = sr.ReadLine();
            char[] sep = { ' ', '\n', '\t', ',', ';' };
            int linii, coloane;
            string[] tokens;

            tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            linii = int.Parse(tokens[0]);
            coloane = int.Parse(tokens[1]);

            matrix = new int[linii, coloane];

            for (int i = 0; i < linii; i++)
            {
                line = sr.ReadLine();
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
