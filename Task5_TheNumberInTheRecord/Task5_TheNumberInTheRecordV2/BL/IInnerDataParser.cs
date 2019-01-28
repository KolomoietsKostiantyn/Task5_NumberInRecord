using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_TheNumberInTheRecord.BL
{
    public interface IInnerDataValidator
    {
        bool ValidateInputArray(string[] arr);
        bool ConvertStringToValidNumber(string number, out long result);

    }
}
