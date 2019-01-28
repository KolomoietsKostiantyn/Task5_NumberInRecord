using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_TheNumberInTheRecord.BL.Enums;

namespace Task5_TheNumberInTheRecord.BL
{
    public class NumberParser: INumberParser
    {
        private readonly long _maxValueMudul;
        private readonly int ten = 10;
        private readonly int twenty = 20;
        private readonly int hundred = 100;
        private readonly int thousand = 1000;

        public NumberParser(long maxValueMudul)
        {
            _maxValueMudul = maxValueMudul;
        }

        public int NumberDigitsOFThousands(long inner)
        {
            int result = 1;
            do
            {
                inner /= thousand;
                if (inner != 0)
                {
                    result++;
                }
            } while (inner != 0);

            return result;
        }

        public string HundredsConverter(long inner)
        {
            int maxProcessValue = 999;
            if (inner < 0 || inner > maxProcessValue)
            {
                return null;
            }
            string result = string.Empty;
            if (inner == 0)
            {
                result = Units.Zero.ToString().ToLower();
            }
            else
            {
                if (inner >= hundred)
                {
                    long hundreds = (inner / hundred);
                    result = string.Format("{0} {1}", (Units)hundreds, OverHundred.Hundred);
                }
                inner = inner - (inner / hundred) * hundred;
                string flagВash = " ";
                if (inner >= twenty)
                {
                    flagВash = "-";
                    long innerTens = (inner - (inner - (inner / ten) * 10)) / ten;
                    result = string.Format("{0} {1}", result, (Dozen2090)innerTens);
                    inner = inner - innerTens * ten;
                }
                if (inner >= ten && inner < twenty)
                {
                    result = string.Format("{0} {1}", result, (Dozen1019)inner);
                }
                if (inner > 0 && inner < ten)
                {
                    result = string.Format("{0}{1}{2}", result, flagВash, (Units)inner);
                }
                result = result.Trim();
                result = result.ToLower();
            }

            return result;
        }

        public string Parse(long inner)
        {
            if (Math.Abs(inner) > _maxValueMudul)
            {
                return null;
            }
            int maxDigit = NumberDigitsOFThousands(inner);
            string result = string.Empty;
            int currentDigit = maxDigit;
            if (inner < 0)
            {
                result = "minus";
                inner = Math.Abs(inner);
            }
            for (int i = 0; i < maxDigit; i++)
            {
                long num = inner / (long)(Math.Pow(thousand, currentDigit - 1));
                string order = string.Empty;
                if (currentDigit > ((int)OverHundred.Hundred))
                {
                    order = ((OverHundred)currentDigit).ToString();
                }
                result = string.Format("{0} {1} {2}", result, HundredsConverter(num), order);
                inner = inner - num * (long)(Math.Pow(thousand, currentDigit - 1));
                currentDigit--;
            }
            result = result.Trim();
            result = result.ToLower();

            return result;
        }




    }
}
