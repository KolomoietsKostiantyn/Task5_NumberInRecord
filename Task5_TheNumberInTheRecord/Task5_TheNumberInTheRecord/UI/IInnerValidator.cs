using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_TheNumberInTheRecord.UI
{
    interface IInnerValidator
    {
        bool Convertor(string [] arr, out long [] newArr);
    }
}
