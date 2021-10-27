using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cin;
using System.Diagnostics;

namespace _10_27
{
    // operare asupra cifrelor unui numar
    // verificarea unor proprietati ale unor numere
    // generarea de siruri de numere
    // maxime, minime
    // tablouri - (vectori, matrici),
    // sortare
    class Program
    {
        static void Main(string[] args)
        {
            // Cifre();
            // Primalitate();
            TreiNPlus1();
        }


        // TODO
        // se da un numar n si se cere lungimea secventei Collatz care incepe cu n si cel mai mare numar din secventa
        // se dau doua numere a si b; se cere sa se determine numarul din intervalul [a,b] pentru care obtinem cea mai
        // lunga secventa. 

        private static void TreiNPlus1()
        {
            int n;
            Console.WriteLine("Introduceti un numar pozitiv");
            n = ConsoleIn.NextInt();
            int nr;
            for (int i = 1; i <= n; i++)
            {
                nr = i;
                Console.Write($"{nr} -> ");
                while (nr != 1)
                {
                    if (nr % 2 == 0)
                    {
                        nr = nr / 2;
                    }
                    else
                    {
                        nr = 3 * nr + 1;
                    }
                    Console.Write($"{nr} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Verficam daca n este prim
        /// </summary>
        private static void Primalitate()
        {
            int n;
            n = ConsoleIn.NextInt();


            Stopwatch sw = new Stopwatch();


            sw.Start();
            if (Prim(n))
            {
                Console.WriteLine($"Numarul {n} este prim");
            }
            else
            {
                Console.WriteLine($"Numarul {n} nu este prim");
            }
            sw.Stop();
            Console.WriteLine($"Verificare primalitatii numarului {n} a durat {sw.ElapsedMilliseconds} milisecunde");


            sw.Reset();

            sw.Start();
            if (PrimRapid(n))
            {
                Console.WriteLine($"Numarul {n} este prim");
            }
            else
            {
                Console.WriteLine($"Numarul {n} nu este prim");
            }
            sw.Stop();
            Console.WriteLine($"Verificare primalitatii numarului {n} a durat {sw.ElapsedMilliseconds} milisecunde");



        }

        private static bool PrimRapid(int n)
        {
            if (n < 2)
                return false;
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }

            // n = a * b unde a >= 2 si b >= 2
            // pp ca a <= b
            // a * a <= a * b;
            // a * a <= n

            for (int d = 3; d * d <= n; d = d + 2)
            {
                if (n % d == 0)
                {
                    return false;
                }
            }


            return true;


        }

        private static bool Prim(int n)
        {
            if (n < 2)
                return false;
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }

            for (int d = 3; d <= n / 2; d = d + 2)
            {
                if (n % d == 0)
                {
                    return false;
                }
            }


            return true;


        }

        /// <summary>
        /// Se citeste un numar de la consola si se cere sa se determine complementul fata de 9 al numarului.
        /// </summary>
        /// <example>
        /// Daca n = 1258 ==> 8741
        /// </example>
        private static void Cifre()
        {
            int n;
            n = int.Parse(Console.ReadLine());

            int cifra;
            int p = 1;
            int rezultat = 0;

            // TODO: caz particular n = 0
            int copie_n = n;
            while (n != 0)
            {
                cifra = n % 10;
                n = n / 10;

                rezultat += (9 - cifra) * p;
                p = p * 10;
            }

            Console.WriteLine($"Complementul fata de 9 al numarului {copie_n} este {rezultat}");


        }
    }
}
