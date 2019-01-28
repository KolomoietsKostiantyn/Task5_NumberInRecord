using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_TheNumberInTheRecord.Intermediate;

namespace Task5_TheNumberInTheRecord.UI
{
    class ConsoleUI : IVisualizator
    {
        private string _instruction;

        public ConsoleUI(long maxValue)
        {
            _instruction = string.Format("For the use of the program, transfer the integer"
                            + " number in range {0} and {1}"
                            + " and get its capital equivalent", maxValue*(-1), maxValue);
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

        public void SendAnswer(string txtNumber, long num)
        {
            Console.WriteLine(string.Format("{0} - {1}", num, txtNumber));
        }

        public void SendInfo(Message message)
        {
            switch (message)
            {
                case Message.Ininstruction:
                    Console.WriteLine(_instruction);
                    break;
                case Message.IncorectData:
                    Console.WriteLine("This text cannot be converted to number.");
                    break;
                default:
                    break;
            }
        }
    }
}
