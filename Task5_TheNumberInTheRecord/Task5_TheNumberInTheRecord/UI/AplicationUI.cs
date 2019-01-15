using System;
using System.Collections.Generic;
using System.Text;
using Task5_TheNumberInTheRecord.Intermidiate;

//может-ли юай парсить входные данные??

namespace Task5_TheNumberInTheRecord.UI
{
    class AplicationUI : IUI
    {
        private long[] _args;
        private bool _isProcessed = false;
        private string _answer;
        private string instruction = "For the use of the program, transfer the"
                            + " number in range -999 999 999 999 999 and 999 999 999 999 999"
                            + " and get its capital equivalent";
        public AplicationUI(string[] args)
        {
            _args = ValidateInitialization(args);
        }


        private long[] ValidateInitialization(string[] args)
        {
            if (args == null)
            {
                throw new NullReferenceException();
            }
            long[] result = new long[args.Length];
            if (args.Length == 0)
            {
                Console.WriteLine(instruction);
                result = null;
            }
            else
            {


                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == null || !long.TryParse(args[i], out result[i]))
                    {
                        Console.WriteLine(instruction);
                        result = null;
                        break;
                    }
                }
            }
            return result;
        }

        public void Start()
        {
            if (_args != null)
            {
                ProprocessingMainParams(_args);
            }

            string answer;
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
                if (_isProcessed)
                {
                    _isProcessed = false;
                    string result = string.Format("{0} - {1}", enterNumber, _answer);
                    Console.WriteLine(result);
                }


                Console.WriteLine("Continue?");
                answer = Console.ReadLine();
            } while (ContinuationRequest(answer));
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


        private void ProprocessingMainParams(long[] _args)
        {
            foreach (long item in _args)
            {
                _sendNumber(item);
                if (_isProcessed)
                {
                    string result = string.Format("{0} - {1}", item, _answer);
                    Console.WriteLine(result);
                }
            }
        }

        public void WaitForAnswer(string answer)
        {
            _isProcessed = true;
            _answer = answer;
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

        private SendNumber _sendNumber;


    }
}
