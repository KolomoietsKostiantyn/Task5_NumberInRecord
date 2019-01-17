using System;
using System.Collections.Generic;
using System.Text;
using Task5_TheNumberInTheRecord.Intermidiate;

//может-ли юай парсить входные данные??

namespace Task5_TheNumberInTheRecord.UI
{
    class AplicationUI : IVisualizator
    {
        #region Variables
        private string _instruction;
        #endregion

        public AplicationUI()
        {
            _instruction = string.Format("For the use of the program, transfer the integer"
                            + " number in range {0} and {1}"
                            + " and get its capital equivalent",Constants.minValue, Constants.maxValue);
        }

        public bool AskContinue()
        {
            Console.WriteLine("Continue?");
            string ask = Console.ReadLine();
            ask = ask.ToLower();
            bool result = false;
            if (ask == "y" || ask == "yes")
            {
                result = true;
            }
            return result;
        }

        public string AskNumber()
        {
            Console.WriteLine("Enter number to convert to number.");
            return Console.ReadLine();
        }

        public void WaitForAnswer(ExecutionStatus result, string answer = null, long num = 0)
        {
            switch (result)
            {
                case ExecutionStatus.Ininstruction:
                    Console.WriteLine(_instruction);
                    break;
                case ExecutionStatus.Ok:
                    Console.WriteLine(string.Format("{0} - {1}", num, answer));
                    break;
                case ExecutionStatus.TooBigOrSmall:
                    Console.WriteLine("Number to big or small to be convert");
                    break;
                case ExecutionStatus.CantConvertToNum:
                    Console.WriteLine("This text cannot be converted to number.");
                    break;
                default:
                    break;
            }
        }
    }
}
