using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    enum TranslateLanguages
    {
        EN,
        RU,
    }

    static class Translator
    {
        static string[,] wordsUnits = new string[2, 9]
        {
            { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
            { "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" }
        };
        static string[,] wordsTens = new string[2, 9]
        {
            { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" },
            { "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" }
        };
        static string[,] wordsHundreds = new string[2, 9]
        {
            { "one hundred", "two hundred", "three hundred", "four hundred", "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred" },
            { "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" }
        };
        static string[,] wordsSpecial = new string[2, 9]
        {
            { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" },
            { "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" }
        };

        static public string ToWords(int num, TranslateLanguages lang)
        {
            string words = "";

            int hundreds = num / 100;
            int tens = (num - hundreds * 100) / 10;
            int units = (num - hundreds * 100) - (tens * 10);

            if (hundreds != 0)
            {
                words += wordsHundreds[(int) lang, hundreds - 1] + " ";
            }
            if (tens != 0)
            {
                if (tens == 1 && units != 0)
                {
                    words += wordsSpecial[(int) lang, units - 1];
                    units = 0;
                }
                else
                {
                    words += wordsTens[(int) lang, tens - 1] + " ";
                }
            }
            if (units != 0)
            {
                words += wordsUnits[(int) lang, units - 1];
            }

            return words;
        }
    }
}
