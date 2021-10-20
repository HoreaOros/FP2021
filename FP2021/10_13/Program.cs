using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_13
{
    class Program
    {
        static void Main(string[] args)
        {
            problema1();
        }

        /// <summary>
        /// Metoda calculeaza suma numerelor de la 1 la n
        /// </summary>
        /// <example>
        /// pentru n = 3 metoda calculeaza 1+2+3 care este egal cu si afiseaza rezultatul
        /// </example>
        private static void problema1()
        {
            int numar;
            
            
            // identificatori formati dintr-o singura litera nu sunt recomandati.
            int m, k, l, s, aux, lin, col;
            // obs. numele identificatorilor trebuie sa sugereze rolul lor.
            // in general numele indentificatorilor vor fi cuvinte sau combinatii de cuvinte 
            // luate din spatiul problemei. 
            // Exemple
            int suma, linie, coloana, contor, maximumCapacity, length;
            
            
            numar = int.Parse(Console.ReadLine()); /// ?? tratarea exceptiilor

            int i = 0;
            try
            {
                suma = 0;
                i = 1;
                while (i <= numar)
                {
                    checked
                    {
                        suma = suma + i;    
                    }
                    i = i + 1;
                }
                Console.WriteLine($"Suma numerelor de la 1 la {numar} este {suma}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"pentru i = {i} {e.Message}");
            }
        }
    }
}
