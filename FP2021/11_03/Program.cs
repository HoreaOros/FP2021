using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stars1();
            // Stars2();
            // Stars3();

            Stars4();
            Stars5();

            // Palindrom();

            // Coins();

            SumaCifre();

        }

        private static void SumaCifre()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            int suma = SumaCifre(n);

            Console.WriteLine($"Suma cifrelor este {suma}");


            suma = SumaCifreR(n);
            Console.WriteLine($"Suma cifrelor este {suma}");
        }


        /// <summary>
        /// Calculeaza suma cifrelor lui n - recursiv
        /// </summary>
        /// <param name="n">Numarul pentru care calculam suma cifrelor</param>
        /// <returns></returns>
        private static int SumaCifreR(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else
            {
                return n % 10 + SumaCifreR(n / 10);
            }
        }

        private static int SumaCifre(int n)
        {
            int suma = 0;
            int cifra;
            while (n > 0)
            {
                cifra = n % 10;
                suma += cifra; // echivalent cu suma = suma + cifra;
                n /= 10; // echivalent cu n = n / 10;
            }
            return suma;
        }

        private static void Coins()
        {
            int stake;
            int goal;
            int times = 10000;
            int wins = 0, losses = 0;


            Random rnd = new Random();

            for (int i = 1; i <= times; i++)
            {
                stake = 30;
                goal = 100;

                while (!(stake == 0 || goal == stake))
                {
                    if (rnd.Next(2) == 0)
                    {
                        stake++;
                    }
                    else
                    {
                        stake--;
                    }
                }
                if (stake == 0)
                {
                    losses++;
                }
                else if (stake == goal)
                {
                    wins++;
                } 
            }

            Console.WriteLine($"Wins: {wins}, Losses: {losses}");
        }

        /// <summary>
        /// Verifica daca un numar citit de la tastatura este palindrom 
        /// (este egal cu rasturnatul/oglindit)
        /// </summary>
        /// <example>
        /// n = 12321 - este palindrom
        /// n = 123321 - este palindrom
        /// n = 122 - nu este palidrom
        /// </example>
        private static void Palindrom()
        {
            int n;

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            if (n.IsPalindrome())
            {
                Console.WriteLine("Numarul este palindrom");
            }
            else
            {
                Console.WriteLine("Numarul nu este palindrom");
            }

            //Console.WriteLine($"Numarul {n.IsPalidrom()?"":"nu"} este palindrom");
        }

        // TODO
        /// <summary>
        /// pt n = 4
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// </summary>
        private static void Stars5()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j <= 2 * (n - i); j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= 2 * n; j++)
                {
                    if (j <= i)
                    {
                        Console.Write("*");
                    }
                    else if (j >= 2 * n - i + 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        // TODO
        /// <summary>
        /// pt n = 4 se va afisa:
        /// *      *
        /// **    **
        /// ***  ***
        /// ********
        /// <summary>
        private static void Stars4()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            for(int i = 1; i<= n; i++)
            {
                for(int j = 1; j <= 2*n; j++)
                {
                    if(j<=i)
                    {
                        Console.Write("*");
                    }
                    else if(j>=2*n-i+1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// pt n = 4 se va afisa:
        /// ********
        /// ***  ***
        /// **    **
        /// *      *
        /// </summary>
        private static void Stars3()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                // afisez spatii;
                // pt i = n - 0 ==> 0
                // pt i = n - 1 ==> 2
                // pt i = n - 2 ==> 4

                for (int j = 1; j <= 2 * (n - i); j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

        }

        /// <summary>
        /// pt. n = 4
        /// ****
        /// ***
        /// **
        /// *
        /// </summary>
        private static void Stars2()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// pt. n = 5
        /// *
        /// **
        /// ***
        /// ****
        /// *****
        /// </summary>
        private static void Stars1()
        {
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
