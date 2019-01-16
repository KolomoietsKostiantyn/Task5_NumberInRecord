using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_TheNumberInTheRecord.UI
{
    class InnerValidator : IInnerValidator
    {
        public bool Convertor(string[] arr, out long[] newArr)
        {
            bool result = true;
            newArr = null;
            if (arr == null || arr.Length == 0)
            {
                result = false;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                newArr = new long[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!long.TryParse(arr[i],out newArr[i]))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
