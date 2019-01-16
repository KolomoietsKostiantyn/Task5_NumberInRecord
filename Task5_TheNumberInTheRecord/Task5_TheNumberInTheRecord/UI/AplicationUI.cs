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
        private long[] _args;
        private string _instruction;
        private IInnerValidator Validator;
        private SendNumber _sendNumber;
        #endregion

        public AplicationUI(string[] args)
        {
            _instruction = string.Format("For the use of the program, transfer the"
                            + " number in range {0} and {1}"
                            + " and get its capital equivalent",Constants.minValue, Constants.maxValue);
            Validator = new InnerValidator();
            Validate(args);
        }

        private void Validate(string[] args)
        {
            bool result = Validator.Convertor(args,out _args);
            if (!result)
            {
                Console.WriteLine(_instruction);
            }
        }      

        public void Start()
        {
            SendingInnParams(_args);
            do
            {
                long enterNumber;
                string innString;
                bool continueFlag;
                do
                {
                    continueFlag = false;
                    Console.WriteLine("Enter number:");
                    innString = Console.ReadLine();
                    if (!long.TryParse(innString, out enterNumber))
                    {
                        Console.WriteLine("Wrong value, try again");
                        continueFlag = true;
                    }
                } while (continueFlag);
                if (_sendNumber != null)
                {
                    _sendNumber(enterNumber);
                }
                Console.WriteLine("Continue?");
            } while (ContinuationRequest(Console.ReadLine()));
        }

        private bool ContinuationRequest(string str)
        {
            bool result = false;
            str = str.ToLower();
            if (str == "y" || str == "yes")
            {
                result = true;
            }
            return result;
        }

        private void SendingInnParams(long[] _args)
        {
            if (_args != null)
            {
                for (int i = 0; i < _args.Length; i++)
                {
                    Console.WriteLine(_args[i]);
                    if (_sendNumber != null)
                    {
                        _sendNumber(_args[i]);
                    }
                }
            }
        }

        public void WaitForAnswer(ExecutionStatus result,string answer)
        {
            switch (result)
            {
                case ExecutionStatus.Ok:
                    Console.WriteLine(answer);
                    break;
                case ExecutionStatus.TooBigOrSmall:
                    Console.WriteLine(answer);
                    Console.WriteLine(_instruction);
                    break;
                default:
                    break;
            }     
        }

        public event SendNumber SendNumberDesc
        {
            add
            {
                _sendNumber += value;
            }
            remove
            {
                _sendNumber -= value;
            } 
        }

    }
}
