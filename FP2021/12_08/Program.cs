using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _12_08
{
    // Algoritm de sortare. 
    class Program
    {
        static Random rnd = new Random();
        static int MAX = 100; 
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            
            int[] v = GenerateRandomArray(8);

            PrintArray(v, "Inainte de sortare");

            //Array.Sort(v);
            sw.Start();
            //SelectionSort(v);
            //BubbleSort(v);
            //BubbleSort2(v);
            InsertionSort(v);
            sw.Stop();

            Console.WriteLine($"Sortarea a durat {sw.ElapsedMilliseconds} milisecunde");


            PrintArray(v, "Dupa sortare");




        }
//        for i = 2:n,
//              for (k = i; k > 1 and a[k] < a[k - 1]; k--)
//                  swap a[k, k - 1]
//              → invariant: a[1..i] is sorted
//         end
        private static void InsertionSort(int[] v)
        {
            int i, k;
            for (i = 1; i < v.Length; i++)
            {
                for (k = i; k > 0 && v[k] < v[k - 1]; k--)
                {
                    Swap(v, k, k - 1);
                }
            }
        }

        private static void BubbleSort2(int[] v)
        {
            int i;
            bool sortat;


            do
            {
                sortat = true;
                for (i = 0; i < v.Length - 1; i++)
                {
                    if (v[i] > v[i + 1])
                    {
                        Swap(v, i, i + 1);
                        sortat = false;
                    }
                }
            } while (!sortat);


        }


        //        for i = 1:n,
        //          swapped = false
        //          for j = n:i+1,
        //              if a[j] < a[j - 1],
        //                  swap a[j, j - 1]
        //                  swapped = true
        //          → invariant: a[1..i] in final position
        //          break if not swapped
        //        end
        private static void BubbleSort(int[] v)
        {
            int i, j;
            bool swapped;
            for (i = 0; i < v.Length; i++)
            {
                swapped = false;
                for (j = v.Length - 1; j >= i + 1; j--)
                {
                    if (v[j] < v[j - 1])
                    {
                        Swap(v, j, j - 1);
                        swapped = true;
                    }
                }
                    
                if (!swapped)
                {
                    break;
                }
            }
        }


        //        for i = 1:n,
        //              k = i
        //              for j = i+1:n
        //                  if a[j] < a[k]
        //                      k = j
        //              → invariant: a[k] smallest of a[i..n]
        //
        //              swap a[i, k]
        //
        //              → invariant: a[1..i] in final position
        //        end
        private static void SelectionSort(int[] v)
        {
            Console.Write("SelectionSort - sorting ...");
            int i, j, k;
            for (i = 0; i < v.Length; i++)
            {
                k = i;
                for (j = i + 1; j < v.Length; j++)
                {
                    if (v[j] < v[k])
                    {
                        k = j;
                    }
                }
                Swap(v, i, k);
            }
            Console.WriteLine(" Done.");
        }

        private static void Swap(int[] v, int i, int j)
        {
            int aux;
            aux = v[i];
            v[i] = v[j];
            v[j] = aux;
        }

        private static void PrintArray(int[] v, string message)
        {
            Console.WriteLine(message);
            foreach (int item in v)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static int[] GenerateRandomArray(int n)
        {
            int[] v = new int[n];
            
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = rnd.Next(MAX);
            }
            return v;
        }
    }
}
