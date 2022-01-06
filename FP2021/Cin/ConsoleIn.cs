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
            string token = NextToken();
            int value;

            try
            {
                value = int.Parse(token);
            }
            catch (FormatException e)
            {
                throw new FormatException($"Valoarea {token} nu poate fi transformata in int!", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(
                    $"Valoarea {token} este mai mare decat {int.MaxValue} sau mai mica decat {int.MinValue}!", e);
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
            string token = NextToken();
            double value;

            try
            {
                value = double.Parse(token.Replace(',', '.'));
            }
            catch (FormatException e)
            {
                throw new FormatException($"Valoarea {token} nu poate fi transformata in double!", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(
                    $"Valoarea {token} este mai mare decat {double.MaxValue} sau mai mica decat {double.MinValue}!", e);
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
            string token = NextToken();
            long value;

            try
            {
                value = long.Parse(token);
            }
            catch (FormatException e)
            {
                throw new FormatException($"Valoarea {token} nu poate fi transformata in long!", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException(
                    $"Valoarea {token} este mai mare decat {long.MaxValue} sau mai mica decat {long.MinValue}!", e);
            }

            return value;
        }
        
        /// <summary>
        /// Citeste primele n cuvinte date in consola.
        /// </summary>
        /// <param name="count">numarul de cuvinte care va fi citit.</param>
        /// <returns>string-ul format prin concatenarea tuturor cuvintelor citite.</returns>
        public static string FirstWords(int count)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= count; ++i)
            {
                sb.Append($"{NextToken()} ");
            }
            return sb.ToString();
        }
    }
}
