using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords.Converters
{
    class EnglishConverter : IConverter
    {
        static string[] unitWords = new string[9] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] tenWords = new string[9] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] intervalWords = new string[9] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        public string Convert(string strNum)
        {
            SplittedNumber number = new SplittedNumber(strNum);
            string words = "";

            if (number.IsNull())
            {
                return "null";
            }

            if (number.millions > 0)
            {
                words += Convert(number.millions.ToString()) + " million ";
            }

            if (number.thousands > 0)
            {
                words += Convert(number.thousands.ToString()) + " thousand ";
            }

            if (number.hundreds > 0)
            {
                words += unitWords[number.hundreds - 1] + " hundred ";

                if (number.tens + number.units > 0)
                {
                    words += "and ";
                }
            }

            if (number.tens == 1 && number.units > 0)
            {
                words += intervalWords[number.units - 1] + " ";
            }
            else
            {
                if (number.tens > 0)
                {
                    words += tenWords[number.tens - 1] + " ";
                }
                if (number.units > 0)
                {
                    words += unitWords[number.units - 1] + " ";
                }
            }

            return words.Trim();
        }
    }
}
