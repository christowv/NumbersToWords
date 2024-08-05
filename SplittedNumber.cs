using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    struct SplittedNumber
    {
        public uint millions;
        public uint thousands;
        public uint hundreds;
        public uint tens;
        public uint units;

        public SplittedNumber(string num)
        {
            while (num.Length < 9)
                num = "0" + num;

            millions = Convert.ToUInt32(num.Substring(0, 3));
            thousands = Convert.ToUInt32(num.Substring(3, 3));
            hundreds = Convert.ToUInt32(num.Substring(6, 1));
            tens = Convert.ToUInt32(num.Substring(7, 1));
            units = Convert.ToUInt32(num.Substring(8, 1));
        }

        public bool IsNull()
        {
            return (millions + thousands + hundreds + tens + units) == 0;
        }
    }
}
