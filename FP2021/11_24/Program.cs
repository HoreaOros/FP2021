using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace _11_24
{
    // Tablouri - vectori/matrici
    class Program
    {
        static void Main(string[] args)
        {
            ArrayDemo();
        }

        private static void ArrayDemo()
        {
            // tablou = colectie liniara de elemente, toate de acelasi tip, care pot fi accesate printr-un index
            int[] arr;
            arr = InitArray(42);

            PrintArray(arr);

            /*int[] arr2 = {1, 2, 3, 4};
            PrintArray(arr2); */

            arr = InitRandomArray(42, 10);
            PrintArray(arr);

            arr = InitRandomArray(42, 10);
            PrintArray(arr);

            arr = InitRandomArray(42, 10);
            PrintArray(arr);

            arr = InitRandomArray(42, 10);
            PrintArray(arr);

            Console.WriteLine($"Sume elementelor din vector este: {SumaVector(arr)}");

            RotateLeft(arr);
            PrintArray(arr);

            ContorFrecvete(arr);

            SecventaMaxima(arr);

            int key = 5;
            int ret;
            ret = Cauta(arr, key);
            if (ret != -1)
            {
                Console.WriteLine($"Am gasit valoarea {key} pe pozitia {ret}");
            }
            else
            {
                Console.WriteLine($"Nu am gasit valoarea {key}");
            }


            Array.Sort(arr);
            PrintArray(arr);

            ret = CautaBinar(arr, key);
            if (ret != -1)
            {
                Console.WriteLine($"Am gasit valoarea {key} pe pozitia {ret}");
            }
            else
            {
                Console.WriteLine($"Nu am gasit valoarea {key}");
            }

            // TODO
            // adaptati algoritmul de cautare binara in asa fel incat sa faceti cautari aproximative
            // https://en.wikipedia.org/wiki/Binary_search_algorithm#Approximate_matches
            // rank, predecesor, succesor, nearest neighbour
        }

        private static int CautaBinar(int[] arr, int key)
        {
            int st, dr;
            st = 0;
            dr = arr.Length - 1;
            int mid;
            while (st <= dr)
            {
                mid = (st + dr) / 2; // st + (dr - st) / 2
                if (arr[mid] == key)
                    return mid;
                else if (key < arr[mid])
                    dr = mid - 1;
                else
                    st = mid + 1; 
            }
            return -1;
        }

        /// <summary>
        /// Cauta key in vectorul arr
        /// </summary>
        /// <param name="arr">vectorul</param>
        /// <param name="key">cheia pe care o cautam</param>
        /// <returns>prima pozitie pe care apare key in arr sau -1 daca key nu apare in arr</returns>
        private static int Cauta(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Functia determina cea mai lunga secventa din vector care incepe si se termina 
        /// cu acceasi cifra para si afiseaza lungimea acelei secventa si cifra 
        /// cu care incepe si se termina
        /// 
        /// Daca sunt mai multe astfel de secvente se vor afisa toate cifrele cu care incep si se
        /// termina acele secvente. 
        /// 
        /// E nevoie de o rezolvare eficienta/liniara. 
        /// </summary>
        /// <param name="arr"></param>
        private static void SecventaMaxima(int[] arr)
        {
            // TODO
            //throw new NotImplementedException();
        }

        private static void ContorFrecvete(int[] arr)
        {
            int[] freq = new int[10];
            for (int i = 0; i < arr.Length; i++)
            {
                freq[arr[i]]++;
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i} -> {freq[i]}");
            }
            Console.WriteLine($"Suma frecventelor este: {SumaVector(freq)}");
        }

        /// <summary>
        /// Roteste spre stanga cu o pozitie elementele vectorului
        /// </summary>
        /// <param name="arr"></param>
        private static void RotateLeft(int[] arr)
        {
            int aux;
            aux = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
            arr[arr.Length - 1] = aux;
        }

        private static int SumaVector(int[] arr)
        {
            int suma = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                suma += arr[i];
            }
            return suma;
        }

        private static int[] InitRandomArray(int v, int maxValue)
        {
            int[] arr = new int[v];
            Thread.Sleep(10);
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(maxValue); 
            }
            return arr;
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        private static int[] InitArray(int v)
        {
            return new int[v];
        }
    }
}
