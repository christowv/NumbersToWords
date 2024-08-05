using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords.Converters
{
    internal class RussianConverter : IConverter
    {
        static string[] unitWords = new string[9] { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        static string[] tenWords = new string[9] { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        static string[] hundredWords = new string[9] { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        static string[] intervalWords = new string[9] { "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };

        public string Convert(string strNum)
        {
            SplittedNumber number = new SplittedNumber(strNum);
            string words = "";

            if (number.IsNull())
            {
                return "ноль";
            }

            if (number.millions > 0)
            {
                words += Convert(number.millions.ToString()) + "миллионов ";
            }

            if (number.thousands > 0)
            {
                words += Convert(number.thousands.ToString()) + "тысяч ";
            }

            if (number.hundreds > 0)
            {
                words += hundredWords[number.hundreds - 1] + " ";
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

            return words;
        }
    }
}
