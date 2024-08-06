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
                string millionsString = number.millions.ToString();
                words += Convert(millionsString);

                SplittedNumber displaced = new SplittedNumber(millionsString);

                if (displaced.units == 1 && displaced.tens != 1)
                {
                    words += " миллион ";
                }
                else if (displaced.units >= 2 && displaced.units <= 4 && displaced.tens != 1)
                {
                    words += " миллиона ";
                }
                else
                {
                    words += " миллионов ";
                }
            }

            if (number.thousands > 0)
            {
                string thousandsString = number.thousands.ToString();

                string[] splitted = Convert(thousandsString).Split();
                string lastWord = splitted[splitted.Length - 1];
                lastWord = lastWord.Replace("один", "одна").Replace("два", "две");
                splitted[splitted.Length-1] = lastWord;
                words += string.Join(" ", splitted);

                SplittedNumber displaced = new SplittedNumber(thousandsString);

                if (displaced.units == 1 && displaced.tens != 1)
                {
                    words += " тысяча ";
                }
                else if (displaced.units >= 2 && displaced.units <= 4 && displaced.tens != 1)
                {
                    words += " тысячи ";
                }
                else
                {
                    words += " тысяч ";
                }
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

            return words.Trim();
        }
    }
}
