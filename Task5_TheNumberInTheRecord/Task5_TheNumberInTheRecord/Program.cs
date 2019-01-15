using System;
using Task5_TheNumberInTheRecord.BL;
using Task5_TheNumberInTheRecord.Intermidiate;
using Task5_TheNumberInTheRecord.UI;

namespace Task5_TheNumberInTheRecord
{
    class Program
    {
        static void Main(string[] args)
        {

            IUI visualizator = new AplicationUI(args);
            MControler Controler = new MControler(visualizator);
            visualizator.Start();
        }
    }
}
