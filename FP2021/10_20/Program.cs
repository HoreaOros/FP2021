using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cin.Cin;

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
                //Triunghi();

                Ordonare3();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Se dau 3 numere. Trebuie afisate in ordine crescatoare.
        /// </summary>
        private static void Ordonare3()
        {
            int a, b, c;
            Console.WriteLine("Introduceti 3 numere intregi pe o singura linie a ecranului separate printr-un spatiu");

            string linie = Console.ReadLine();
            char[] seps = {' '};
            string[] tokens = linie.Split(seps, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length < 3)
            {
                Console.WriteLine("Nu s-au introdus 3 numere");
                return;
            }


            a = int.Parse(tokens[0]);
            b = int.Parse(tokens[1]);
            c = int.Parse(tokens[2]);

            int min, max, med;


            // min = Math.Min(a, Math.Min(b, c));
            // max = Math.Max(a, Math.Max(b, c));
            min = a;
            if (b < min)
            {
                min = b;
            }
            if (c < min)
            {
                min = c;
            }


            max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }

            med = a + b + c - min - max;

            Console.WriteLine($"{min}, {med}, {max}");

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
            a = NextInt();
            b = NextInt();
            c = NextInt();



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
