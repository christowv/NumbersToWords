using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords.Converters
{
    internal class RomanConverter : IConverter
    {
        static string[] unitWords = new string[9] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        static string[] tenWords = new string[9] { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        static string[] hundredWords = new string[9] { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        static string[] intervalWords = new string[9] { "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX" };

        public string Convert(string strNum)
        {
            SplittedNumber number = new SplittedNumber(strNum);
            string words = "";

            if (number.IsNull())
            {
                return "N";
            }

            for (int i = 0; i < number.thousands + (number.thousands * (number.millions * 100)); i++)
            {
                words += "M";
            }
            if (number.hundreds > 0)
            {
                words += hundredWords[number.hundreds - 1];
            }
            if (number.tens == 1 && number.units > 0)
            {
                words += intervalWords[number.units - 1];
            }
            else
            {
                if (number.tens > 0)
                {
                    words += tenWords[number.tens - 1];
                }
                if (number.units > 0)
                {
                    words += unitWords[number.units - 1];
                }
            }

            return words;
        }
    }
}
