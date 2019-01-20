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

            IVisualizator visualizator = new AplicationUI();
            MControler Controler = new MControler(visualizator, args);
            Controler.Start();
        }
    }
}
