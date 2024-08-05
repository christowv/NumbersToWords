using NumbersToWords.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    static class ConverterFactory
    {
        static public IConverter GetConverter(ReplaceFormats format)
        {
            switch (format)
            {
                case ReplaceFormats.EN:
                    return new EnglishConverter();
                case ReplaceFormats.RU:
                    return new RussianConverter();
                case ReplaceFormats.XXI:
                    return new RomanConverter();
                default: 
                    return new EnglishConverter();
            }
        }
    }
}
