using System;
using System.Collections.Generic;
using System.Text;



namespace Task5_TheNumberInTheRecord.BL
{
    class NumberParser: INumberParser
    {
        #region variables
        private readonly long maxValue;
        private readonly long minValue;
        private readonly int ten = 10;
        private readonly int twenty = 20;
        private readonly int hundred = 100;
        private readonly int thousand = 1000;
        #endregion

        public NumberParser(long maxValue, long minValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public string Parse(long inner)
        {
            if (inner < minValue || inner > maxValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            int maxDigit = NumberDigit(inner);
            string result = string.Empty; 
            int currentDigit = maxDigit;
            if (inner < 0)
            {
                result = "minus";
                inner =  Math.Abs(inner);
            }
            for (int i = 0; i < maxDigit; i++)
            {
                long num = inner / (long)(Math.Pow(thousand, currentDigit -1));
                string order = string.Empty;
                if (currentDigit > ((int)OverHundred.Hundred))
                {
                    order = ((OverHundred)currentDigit).ToString();
                }
                result = string.Format("{0} {1} {2}", result, HundredConverter(num), order);
                inner = inner - num * (long)(Math.Pow(thousand, currentDigit - 1));
                currentDigit--;
            }
            result = result.Trim();
            result = result.ToLower();

            return result;
        }

        private int NumberDigit(long inner)
        {
            int result = 1;
            do
            {
                inner /= thousand;
                if (inner > 0)
                {
                    result++;
                }
            } while (inner != 0);

            return result;
        }

        private string HundredConverter(long inner)
        {
            int maxProcessValue = 999;
            if (inner < 0 || inner > maxProcessValue)
            {
                throw new ArgumentOutOfRangeException();
            }
            string result = string.Empty;
            if (inner == 0)
            {
                result = Units.Zero.ToString();
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
                        result = string.Format("{0}{1}{2}", result, flagВash,(Units)inner);
                }
                result = result.Trim();
                result = result.ToLower();
            }

            return result;
        }
    }
}
