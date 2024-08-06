using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    enum ReplaceFormats
    {
        EN,
        RU,
        XXI,
    }

    static class Replacer
    {
        static public string Replace(string text, ReplaceFormats format)
        {
            IConverter myConverter = ConverterFactory.GetConverter(format);
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char myChar = text[i];

                if (!Char.IsDigit(myChar))
                {
                    result += myChar;
                }
                else
                {
                    string readNumber = "" + myChar;

                    while (true)
                    {
                        if (i + 1 < text.Length)
                        {
                            i++;
                            myChar = text[i];
                        }
                        else
                        {
                            break;
                        }

                        if (myChar == ' ')
                        {
                            continue; 
                        }

                        if (!char.IsDigit(myChar))
                        {
                            i--;
                            break;
                        }
                        else
                        {
                            readNumber += myChar;
                        }
                    }

                    result += myConverter.Convert(readNumber);
                }
            }

            return result;
        }
    }
}
