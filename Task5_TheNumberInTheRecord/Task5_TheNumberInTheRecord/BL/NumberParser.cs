using System;
using System.Collections.Generic;
using System.Text;



namespace Task5_TheNumberInTheRecord.BL
{
    class NumberParser: INumberParser
    {

        public NumberParser()
        {

        }

        public string Parse(long inner)
        {
            long maxValue = 999999999999999;
            long minValue = maxValue * (-1);
            if (inner < minValue || inner > maxValue)
            {
                throw new ArgumentOutOfRangeException();//нужно ли писать текст ексепшина?
            }

            int maxDigit = NumberDigit(inner);
            string result = "";
            int digit = 1000;
            int currentDigit = maxDigit;
            if (inner < 0)
            {
                result = "minus";
                inner *= (-1);
            }
            for (int i = 0; i < maxDigit; i++)
            {
                long num = inner / (long)(Math.Pow(digit, currentDigit -1));
                string order = "";
                if (currentDigit > ((int)OverHundred.Hundred))
                {
                    order = string.Format("{0}", ((OverHundred)currentDigit).ToString());
                }

                result = string.Format("{0} {1} {2}", result, HundredConverter(num), order);

                inner = inner - num * (long)(Math.Pow(digit, currentDigit - 1));
                currentDigit--;
            }

            result = result.Trim();
            result = result.ToLower();
            return result;
        }

        private int NumberDigit(long inner)
        {
            int result = 1;
            int thousand = 1000;
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
            int maxValue = 999;
            if (inner < 0 || inner > maxValue)
            {
                throw new ArgumentOutOfRangeException();//нужно ли писать текст ексепшина?
            }

            string result = "";
            if (inner == 0)
            {
                result = Units.Zero.ToString();
            }
            else
            {
                int hundred = 100;
                if (inner >= hundred)
                {
                    long hundreds = (inner / hundred);
                    result = string.Format("{0} {1}", (Units)hundreds, OverHundred.Hundred);
                }
                inner = inner - (inner / hundred) * hundred;
                int twenty = 20;
                int ten = 10;
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
