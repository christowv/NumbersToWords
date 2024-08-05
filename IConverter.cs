using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    interface IConverter
    {
        string Convert(string strNum);
    }
}
