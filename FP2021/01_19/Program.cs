using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_19
{
    class Program
    {
        static void Main(string[] args)
        {
            //BS();


            MergeSort();
        }

        /// <summary>
        /// Sortare prin interclasare
        /// </summary>
        private static void MergeSort()
        {
            int[] v = { 8, 9, 20, 1, 4, 4, 10, 16, 6, 6 };

            MyMergeSort(v);
            PrintArray(v);
        }

        private static void MyMergeSort(int[] v)
        {
            MyMergeSortHelper(v, 0, v.Length - 1);
        }

        private static void MyMergeSortHelper(int[] v, int p, int r)
        {
            int q;
            if (p < r)
            {
                q = (p + r) / 2;
                MyMergeSortHelper(v, p, q);
                MyMergeSortHelper(v, q + 1, r);
                MyMerge(v, p, q, r);
            }
        }

        private static void MyMerge(int[] v, int p, int q, int r)
        {
            // aloc memorie suplimentara
            int[] v1 = new int[q - p + 1];
            int[] v2 = new int[r - q];

            // copiez elementele 
            int i, j;
            for (i = p; i <= q; i++)
            {
                v1[i - p] = v[i];
            }
            for (i = q + 1; i <= r; i++)
            {
                v2[i - (q + 1)] = v[i];
            }

            // interclasare
            // v = {1, 4, 6, 8, 2, 3, 7, 10 }
            // v1 = {1, 4, 6, 8}
            // v2 = {2, 3, 7, 10}
            // v = {1, 2, 3, 4, 6, 7, 8, 10}

            i = 0; j = 0;
            int k = 0;
            while (i < v1.Length && j < v2.Length)
            {
                if (v1[i] < v2[j])
                {
                    v[p + k] = v1[i];
                    i++;
                    k++;
                }
                else
                {
                    v[p + k] = v2[j];
                    j++;
                    k++;
                }
            }
            while (i < v1.Length)
            {
                v[p + k] = v1[i];
                i++;
                k++;
            }
            while (j < v2.Length)
            {
                v[p + k] = v2[j];
                j++;
                k++;
            }

        }

        private static void PrintArray(int[] v)
        {
            foreach (var item in v)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static void BS()
        {
            int[] v = { 1, 4, 6, 8, 9, 10, 16, 20 };

            int key = 10;
            //int pos = LinearSearch(v, key);
            //if (pos == -1)
            //{
            //    Console.WriteLine($"Nu am gasit cheia {key} in vector");
            //}
            //else
            //{
            //    Console.WriteLine($"Cheia {key} este in vector pe pozitia {pos}");
            //}

            //int ret = Array.BinarySearch<int>(v, key);
            //if (ret >= 0)
            //{
            //    Console.WriteLine($"Cheia {key} este in vector pe pozitia {ret}");
            //}
            //else
            //{
            //    Console.WriteLine($"Nu am gasit cheia {key} in vector");
            //}

            int pos = MyBinarySearch(v, key);
            if (pos == -1)
            {
                Console.WriteLine($"Nu am gasit cheia {key} in vector");
            }
            else
            {
                Console.WriteLine($"Cheia {key} este in vector pe pozitia {pos}");
            }

            pos = MyBinarySearchAlt(v, key);
            pos = MyBinarySearchLeftmost(v, key);
            pos = MyBinarySearchRightmost(v, key);

            // TODO
            // rank
            int rank = MyBinarySearchLeftmost(v, key);
            Console.WriteLine($"rank = {rank}");

            // succesor
            int succesor = MyBinarySearchRightmost(v, key) + 1;
            Console.WriteLine($"succesor = {v[succesor]}");

            // predecesor
            int predecesor = MyBinarySearchLeftmost(v, key) - 1;
            Console.WriteLine($"predecesor = {v[predecesor]}");

            // cel mai apropiat vecin
            int diferenta = Math.Min(key - v[predecesor], v[succesor] - key);
            int vecin;
            if (diferenta == key - v[predecesor])
                vecin = v[predecesor];
            else
                vecin = v[succesor];
            Console.WriteLine($"Cel mai apropiat vecin este {vecin}");
        }

        //          function binary_search_rightmost(A, n, T):
        //      L := 0
        //      R := n
        //      while L<R:
        //          m := floor((L + R) / 2)
        //          if A[m] > T:
        //              R := m
        //          else:
        //              L := m + 1
        //      return R - 1
        private static int MyBinarySearchRightmost(int[] v, int key)
        {
            // TODO

            int left = 0;
            int right = v.Length;
            int mid;
            while (left < right)
            {
                mid = (int)Math.Floor((double)(left + right) / 2);
                if (v[mid] > key)
                    right = mid;
                else
                    left = mid + 1;

            }
            return right - 1;

        }

        //    function binary_search_leftmost(A, n, T):
        //      L := 0
        //      R := n
        //      while L<R:
        //          m := floor((L + R) / 2)
        //          if A[m] < T:
        //              L := m + 1
        //          else:
        //              R := m
        //      return L
        private static int MyBinarySearchLeftmost(int[] v, int key)
        {
            // TODO

            int left = 0;
            int right = v.Length;
            int mid;
            while (left < right)
            {
                mid = (int)Math.Floor((double)(left + right) / 2);
                if (v[mid] < key)
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }


        //    function binary_search_alternative(A, n, T) is
        //  L := 0
        //  R := n − 1
        //  while L != R do
        //      m := ceil((L + R) / 2)
        //      if A[m] > T then
        //          R := m − 1
        //      else:
        //          L := m
        //  if A[L] = T then
        //      return L
        //  return unsuccessful
        private static int MyBinarySearchAlt(int[] v, int key)
        {
            // TODO

            int left, right, mid;
            left = 0;
            right = v.Length - 1;
            while (left != right)
            {
                mid = (int)Math.Ceiling((double)(left + right) / 2);
                if (v[mid] > key)
                    right = mid - 1;
                else
                    left = mid;
                if (v[left] == key)
                    return left;
            }
            return -1;
        }

        /// <summary>
        /// Binary Search
        /// </summary>
        /// <param name="v">Vectorul in care se cauta</param>
        /// <param name="key">Cheia care se cauta</param>
        /// <returns>pozitia pe care se afla cheia sau -1 daca nu gasim cheia in vector</returns>
        private static int MyBinarySearch(int[] v, int key)
        {
            int left, right, mid;
            left = 0; right = v.Length - 1;
            while (left <= right)
            {
                //mid = (left + right) / 2;
                mid = left + (right - left) / 2;
                if (key < v[mid])
                {
                    right = mid - 1;
                }
                else if (key > v[mid])
                {
                    left = mid + 1;
                }
                else
                    return mid;
            }

            return -1;
        }

        private static int LinearSearch(int[] v, int key)
        {
            int pos = -1;
            for (int i = 0; i < v.Length; i++)
            {
                if (key == v[i])
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }
    }
}
