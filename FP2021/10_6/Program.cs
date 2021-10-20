using System;
using System.Text;

namespace _10_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World. Today is {DateTime.Now}");

            Console.WriteLine("Hello World. Today is {0}", DateTime.Now);

            Console.WriteLine("Hello World. Today is " + DateTime.Now);



            Console.WriteLine("Introduceti un numar:");
            
            int n = 0;
            // Ce este o variabila???
            // n este o variabila (nume pentru o locatie de memorie)
            // int este un tip de date (defineste valorile pe care le poate lua o variabila de acel tip si operatiile pe care le putem efectua cu variabila respectiva)

            Console.WriteLine($"Cea mai mare valoare care se poate stoca pe int este {int.MaxValue}");
            Console.WriteLine($"Cea mai mica valoare care se poate stoca pe int este {int.MinValue}");
            Console.WriteLine($"Numarul total de valori care se poate stoca pe int este {1L + int.MaxValue - int.MinValue}");

            // int se stocheaza pe 32 de biti
            // short se stocheaza pe 16 de biti
            // long  se stocheaza pe 64 de biti
            // byte se stocheaza pe 8 de biti
            // uint se stocheaza pe 32 de biti - (u = unsigned)
            // ushort se stocheaza pe 16 de biti
            // sbyte se stocheaza pe 8 de biti
            // ulong se stocheaza pe 64 de biti


            string line;
            line = Console.ReadLine();

            try
            {
                n = int.Parse(line);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            


            Console.WriteLine($"Numarul pe care l-ati introdus este: {n}");


        }
    }
}
