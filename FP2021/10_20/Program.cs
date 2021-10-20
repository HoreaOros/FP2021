﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_20
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // suma Gauss
                // Gauss();
                // GaussV2();

                Triunghi();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Se dau 2 numere naturale pozitive. Se cere sa se determine daca 
        /// cele 3 numere pot fi lungimile laturilor unui triunghi.
        /// Suma lungimilor oricaror 2 laturi trebuie sa fie mai mare decat lungimea celei
        /// de-a 3-a laturi.
        /// </summary>
        private static void Triunghi()
        {
            int a, b, c;
            Console.WriteLine("Introduceti 3 numere naturale pozitive. Cate unul pe o singura linie. ");
            a = Cin.Cin.NextInt();
            b = Cin.Cin.NextInt();
            c = Cin.Cin.NextInt();



            //Varianta 1

            if (a + b > c)
            {
                if (a + c > b)
                {
                    if (b + c > a)
                    {
                        Console.WriteLine($"{a}, {b}, {c} pot fi lungimile laturilor unui triunghi");
                    }
                    else
                    {
                        Console.WriteLine($"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi");
                    }
                }
                else
                {
                    Console.WriteLine($"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi");
                }
            }
            else
            {
                Console.WriteLine($"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi");
            }



            // Varianta 2

            bool ok = false;
            if (a + b > c)
            {
                if (a + c > b)
                {
                    if (b + c > a)
                    {
                        ok = true;
                    }
                }
            }
            if (ok)
            {
                Console.WriteLine($"{a}, {b}, {c} pot fi lungimile laturilor unui triunghi");
            }
            else
            {
                Console.WriteLine($"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi");
            }


            // Varianta 3
            if (a + b > c && a + c > b && b + c > a) 
            {
                Console.WriteLine($"{a}, {b}, {c} pot fi lungimile laturilor unui triunghi");
            }
            else
            {
                Console.WriteLine($"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi");
            }

            // Varianta 4
            Console.WriteLine($@"{(
                a + b > c && a + c > b && b + c > a ? 
                    $"{a}, {b}, {c} pot fi lungimile laturilor unui triunghi" : 
                    $"{a}, {b}, {c} nu pot fi lungimile laturilor unui triunghi")}");


        }

        /// <summary>
        /// Calculeaza suma numerelor de 1 la n - in mod eficient.
        /// </summary>
        /// <example>
        /// pt n = 5, S = 1+2+3+4+5 = 15
        /// </example>
        private static void GaussV2()
        {
            // S = 1+ 2 + 3+... +n
            // S = n+(n-1)+.......+1
            // 2S = (n+1)+(n+1)+..(n+1) = n(n+1);
            // S = n(n+1)/2;
            int suma = 0;
            int n = 0;

            Console.WriteLine(1 / n);

            Console.WriteLine("Introduceti un numar natural");
            n = int.Parse(Console.ReadLine());


            //Console.WriteLine($"Suma numerelor de la 1 la {n} este {n * (n + 1) / 2}");

            // SAU - o varianta mai buna:
            if (n % 2 == 0)
            {
                suma = n / 2 * (n + 1);
            }
            else
            {
                suma = (n + 1) / 2 * n;
            }

            Console.WriteLine($"Suma numerelor de la 1 la {n} este {suma}");
        }

        /// <summary>
        /// Calculeaza suma numerelor de 1 la n.
        /// </summary>
        /// <example>
        /// pt n = 5, S = 1+2+3+4+5 = 15
        /// </example>
        private static void Gauss()
        {

            int suma = 0;
            int n = 0;

            Console.WriteLine("Introduceti un numar natural");
            n = int.Parse(Console.ReadLine());


            try
            {
                for (int i = 1; i <= n; i++)
                {
                    checked
                    {
                        suma = suma + i;
                    }
                }
                Console.WriteLine($"Suma numerelor de la 1 la {n} este {suma}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
