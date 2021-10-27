using System;
using System.Text;

namespace Cin
{
    public static class ConsoleIn
    {
        /// <summary>
        /// Citeste un grup de caractere din consola.
        /// </summary>
        /// <returns>string-ul citit.</returns>
        public static string NextToken()
        {
            StringBuilder tokenChars = new StringBuilder();
            bool tokenFinished = false;
            bool skipWhitespace = false;

            while (!tokenFinished)
            {
                int nextChar = Console.Read();

                if (nextChar == -1)
                {
                    //Finalul stream-ului.
                    tokenFinished = true;
                }
                else
                {
                    char ch = (char) nextChar;
                    if (char.IsWhiteSpace(ch))
                    {
                        //Am ajuns la un caracter 'whitespace' (' ', '\r', '\n', '\t')
                        //sarim peste el daca este primul sau ne oprim din citit daca nu este
                        if (skipWhitespace)
                        {
                            tokenFinished = true;
                            if (ch == '\r' && Environment.NewLine == "\r\n")
                            {
                                Console.Read();
                            }
                        }
                    }
                    else
                    {
                        skipWhitespace = true;
                        tokenChars.Append(ch);
                    }
                }
            }

            return tokenChars.ToString();
        }

        /// <summary>
        /// Citeste urmatorul int dat ca si input in consola.
        /// </summary>
        /// <returns>valoarea int data sau 0 daca este intalnita o exceptie.</returns>
        /// <exception cref="FormatException">daca valoarea data nu este formata doar din cifre 0-9.</exception>
        /// <exception cref="OverflowException">daca valoarea data este mai mare de <see cref="int.MaxValue"/>.</exception>
        public static int NextInt()
        {
            int value;

            try
            {
                value =  int.Parse(NextToken());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valoarea data nu poate fi transformata in int!");
                value = 0;
                //throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Valoarea data este mai mare decat {int.MaxValue} sau mai mica decat {int.MinValue}!");
                value = 0;
                //throw;
            }

            return value;
        }

        /// <summary>
        /// Citeste urmatorul double dat ca si input in consola.
        /// </summary>
        /// <returns>valoarea double data sau 0 daca este intalnita o exceptie.</returns>
        /// <exception cref="FormatException">daca valoarea data nu este alcatuita doar din cifre 0-9 si caracterele . si ,</exception>
        /// <exception cref="OverflowException">daca valoarea data este mai mare de <see cref="Double.MaxValue"/></exception>
        public static double NextDouble()
        {
            double value;

            try
            {
                value = double.Parse(NextToken().Replace(',', '.'));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valoarea data nu poate fi transformata in double!");
                value = 0;
                //throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Valoarea data este mai mare decat {double.MaxValue} sau mai mica decat {double.MinValue}!");
                value = 0;
                //throw;
            }

            return value;
        }
        
        /// <summary>
        /// Citeste urmatorul long dat ca si input in consola.
        /// </summary>
        /// <returns>valoarea long data sau 0 daca este intalnita o exceptie.</returns>
        /// <exception cref="FormatException">daca valoarea data nu este alcatuita doar din cifre 0-9</exception>
        /// <exception cref="OverflowException">daca valoarea data este mai mare decat <see cref="long.MaxValue"/> sau mai mica decat <see cref="long.MinValue"/>.</exception>
        public static long NextLong()
        {
            long value;

            try
            {
                value = long.Parse(NextToken());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valoarea data nu poate fi transformata in long!");
                value = 0;
                //throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Valoarea data este mai mare decat {long.MaxValue} sau mai mica decat {long.MinValue}!");
                value = 0;
                //throw;
            }

            return value;
        }
    }
}