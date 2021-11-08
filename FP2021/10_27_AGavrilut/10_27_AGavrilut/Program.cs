using System;

namespace _10_27
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Introduceti un numar pozitiv");
            n = int.Parse(Console.ReadLine());
            LengthMaxCollatz(n);
           

            int lengthCollatz, a, b, maxI = 0, max = 0;
            Console.WriteLine("Introduceti capetele de interval:");
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
            {
                lengthCollatz = LengthCollatz(i);
                if (lengthCollatz > max)
                {
                    max = lengthCollatz;
                    maxI = i;
                }
            }
            Console.WriteLine($"Cea mai lunga secventa este pentru numarul {maxI}");

        }

        public static void LengthMaxCollatz(int n)
        {
            int nr = 0;
            int max = 1;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
                Console.Write($"{n} ");
                nr++;
                if (n > max)
                {
                    max = n;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Lungimea secventei este {nr}");
            Console.WriteLine($"Cel mai mare numar din secventa este {max}");
        }

        public static int LengthCollatz(int n)
        {
            int nr = 0;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = 3 * n + 1;
                }
                nr++;
            }
            return nr;
        }
    }
}
