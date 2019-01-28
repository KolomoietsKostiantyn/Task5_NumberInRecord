using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_TheNumberInTheRecord.BL
{
    interface INumberParser
    {
        int NumberDigitsOFThousands(long inner);
        string HundredsConverter(long inner);
        string Parse(long inner);
    }
}
