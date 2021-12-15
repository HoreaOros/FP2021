using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] w = { 3, 6, 2, 1, 5, 7, 2, 4, 1, 9 };
            int C = 10;
            NF(w, C);
            FF(w, C);
            BF(w, C);
            WF(w, C);


            Console.WriteLine("Sort values in descending order");

            NFD(w, C);
            FFD(w, C);
            BFD(w, C);
            WFD(w, C);


        }

        private static void WFD(int[] w, int c)
        {
            Array.Sort(w, (x, y) => y - x);
            WF(w, c);
        }

        private static void BFD(int[] w, int c)
        {
            Array.Sort(w, (x, y) => y - x);
            BF(w, c);
        }

        private static void FFD(int[] w, int c)
        {
            Array.Sort(w, (x, y) => y - x);
            FF(w, c);
        }

        private static void NFD(int[] w, int c)
        {
            Array.Sort(w, (x, y) => y - x);
            NF(w, c);
        }

        private static void WF(int[] w, int C)
        {
            Console.WriteLine("*** Worst Fit ***");
            int k = 0;
            int[] containers = new int[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                int j = 0;
                int maxim = 0, imax = -1;
                while (j <= k)
                {
                    if (w[i] + containers[j] <= C && C - (w[i] + containers[j]) > maxim)
                    {
                        maxim = C - (w[i] + containers[j]);
                        imax = j;
                    }
                    j++;
                }
                if (imax != -1)
                {
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {imax + 1}");
                    containers[imax] += w[i];
                }
                else
                {
                    k++;
                    containers[k] = w[i];
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {k + 1}");
                }
            }
            Console.WriteLine($"Numarul de containere folosite este {k + 1}\n");
        }

        private static void BF(int[] w, int C)
        {
            Console.WriteLine("*** Best Fit ***");
            int k = 0;
            int[] containers = new int[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                int j = 0;
                int minim = C, imin = -1;
                while (j <= k)
                {
                    if (w[i] + containers[j] <= C && C - (w[i] + containers[j]) < minim)
                    {
                        minim = C - (w[i] + containers[j]);
                        imin = j;
                    }
                    j++;
                }
                if (imin != -1)
                {
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {imin + 1}");
                    containers[imin] += w[i];
                }
                else
                {
                    k++;
                    containers[k] = w[i];
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {k + 1}");
                }
            }
            Console.WriteLine($"Numarul de containere folosite este {k + 1}\n");
        }

        private static void FF(int[] w, int C)
        {
            Console.WriteLine("*** First Fit ***");
            int k = 0;
            int[] containers = new int[w.Length];
            for (int i = 0; i < w.Length; i++)
            {
                int j = 0;
                while (j <= k && containers[j] + w[i] > C)
                {
                    j++;
                }
                if (j <= k)
                {
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {j + 1}");
                    containers[j] += w[i];
                }
                else
                {
                    k++;
                    containers[k] = w[i];
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {k + 1}");
                }
            }
            Console.WriteLine($"Numarul de containere folosite este {k + 1}\n");
        }

        private static void NF(int[] w, int C)
        {
            Console.WriteLine("*** Next Fit ***");
            int k = 1;
            int current_capacity = 0;
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] + current_capacity <= C)
                {
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {k}");
                    current_capacity += w[i];
                }
                else
                {
                    k++;
                    current_capacity = w[i];
                    Console.WriteLine($"Obiectul {i + 1} care are greutatea {w[i]} il pun in containerul {k}");
                }
            }
            Console.WriteLine($"Numarul de containere folosite este {k}\n");
        }
    }
}
