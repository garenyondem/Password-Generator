using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

/* 
 * Garen Yöndem 2016
 * http://garen.yondem.com
*/

namespace PasswordGenerator
{
    class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            try
            {
                short length = short.Parse(ReadLine());
                WriteLine(new string(GeneratePassword(length, true, true, false).ToArray()));
                ReadKey();
            }
            catch (Exception)
            {
                Main(null);
            }
        }

        static IEnumerable<char> GeneratePassword(short length, bool isCapsEnable, bool isSymbolsEnable, bool isNumberEnable)
        {
            string passwordSymbols = GetPasswordSymbols(ref isCapsEnable, ref isSymbolsEnable, ref isNumberEnable);
            for (int i = 0; i < length; i++)
            {
                yield return passwordSymbols[random.Next(passwordSymbols.Length)];
            }
        }

        static string GetPasswordSymbols(ref bool isCapsEnable, ref bool isSymbolsEnable, ref bool isNumberEnable)
        {
            string charsCaps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chars = "abcdefghijklmnopqrstuvwxyz";
            string nums = "0123456789";
            string symbols = @"€+'!@#_\&*|}^%/:?]([-,)${.>~;<=";
            string passwordSymbols = $"{chars + (isCapsEnable ? charsCaps : string.Empty) + (isSymbolsEnable ? symbols : string.Empty) + (isNumberEnable ? nums : string.Empty)  }";
            return Shuffle(ref passwordSymbols);
        }

        static string Shuffle(ref string password)
        {
            char[] array = password.ToCharArray();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
    }
}