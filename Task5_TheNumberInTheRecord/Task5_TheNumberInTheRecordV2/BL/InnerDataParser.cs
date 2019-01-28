using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task5_TheNumberInTheRecord.BL
{
    public class InnerDataParser : IInnerDataValidator
    {
        private readonly long _maxValueMudul;
        public InnerDataParser(long maxValueMudul)
        {
            _maxValueMudul = maxValueMudul;
        }

        public bool ConvertStringToValidNumber(string number, out long result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(number))
            {
                return false;
            }

            bool res = false;
            if (long.TryParse(number,out result))
            {
                if (Math.Abs(result) <= _maxValueMudul)
                {
                    res = true;
                }
            }

            return res;
        }

        public bool ValidateInputArray(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return false;
            }
            bool result = true;
            foreach (string item in arr)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}