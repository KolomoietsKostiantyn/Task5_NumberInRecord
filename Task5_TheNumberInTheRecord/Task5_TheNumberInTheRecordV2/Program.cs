using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_TheNumberInTheRecord.BL;
using Task5_TheNumberInTheRecord.Intermediate;
using Task5_TheNumberInTheRecord.UI;

namespace Task5_TheNumberInTheRecordV2
{
    class Program
    {
        static void Main(string[] args)
        {
            long maxValue = 999999999999;
            IVisualizator visualizator = new ConsoleUI(maxValue);
            INumberParser numberParser = new NumberParser(maxValue);
            IInnerDataValidator innerDataValidator = new InnerDataParser(maxValue);

            MControler mControler = new MControler(visualizator, numberParser, innerDataValidator, args);

            mControler.Start();
        }
    }
}
