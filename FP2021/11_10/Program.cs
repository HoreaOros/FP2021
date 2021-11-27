using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _11_10
{
    class Program
    {
        static void Main(string[] args)
        {
            DateDiff1();
            DateDiff2();
        }

        private static void DateDiff2()
        {
            // ziua 1
            int z1 = 10, l1 = 11, a1 = 2000;
            // ziua 2
            int z2 = 10, l2 = 11, a2 = 2021;

            int contor = 0;
            while ( !(z1 == z2 && l1 == l2 && a1 == a2) )
            {
                contor++;
                if (z2 > 1)
                {
                    z2--;
                }
                else
                {
                   switch(l2)
                   {
                        case 1:
                            z2 = 31;
                            l2 = 12;
                            a2--;
                            break;
                        case 2:
                        case 4:
                        case 6:
                        case 8:
                        case 9:
                        case 11:
                            z2 = 31;
                            l2--;
                            break;
                        case 5:
                        case 7:
                        case 10:
                        case 12:
                            z2 = 30;
                            l2--;
                            break;
                        case 3:
                            z2 = 28;
                            if (EsteAnBisect(a2))
                                z2++;
                            l2--;
                            break;
                    }
                }
            }

            Console.WriteLine($"Numarul de zile dintre cele doua date este: {contor}");
        }

        private static bool EsteAnBisect(int a)
        {
            return (a % 4 == 0 && a % 100 != 0) || (a % 400 == 0);
        }

        private static void DateDiff1()
        {
            DateTime dt = DateTime.Now;
            CultureInfo[] cultures = new CultureInfo[] {CultureInfo.InvariantCulture,
                                                  new CultureInfo("en-us"),
                                                  new CultureInfo("fr-fr"),
                                                  new CultureInfo("de-DE"),
                                                  new CultureInfo("es-ES"),
                                                  new CultureInfo("ja-JP")};
            foreach (var culture in cultures)
            {
                Console.WriteLine(dt.ToString(culture));
            }
            Console.WriteLine(dt.ToString("d MMMM yyyy, HH:mm:ss"));


            DateTime dt2 = new DateTime(2000, 11, 10);


            Console.WriteLine($"Numarul de zile dintre {dt.ToShortDateString()} si {dt2.ToShortDateString()} este {dt.Subtract(dt2).Days}");

        }
    }
}
