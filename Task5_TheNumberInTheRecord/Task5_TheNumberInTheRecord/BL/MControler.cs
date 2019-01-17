using System;
using System.Collections.Generic;
using System.Text;
using Task5_TheNumberInTheRecord.Intermidiate;

namespace Task5_TheNumberInTheRecord.BL
{
    class MControler
    {
        #region Variables
        private IVisualizator _visualizator;
        private INumberParser _converter;
        private string[] _arr;
        #endregion

        public MControler(IVisualizator visualizator, string [] arr)
        {
            _arr = arr;
            _converter = new NumberParser(Constants.maxValue, Constants.minValue);
            _visualizator = visualizator;
        }


        public void Start()
        {
            ValidateInner(_arr);
            do
            {
                string StrNum = _visualizator.AskNumber();
                TryConvert(StrNum);
            } while (_visualizator.AskContinue());
        }

        private void TryConvert(string StrNum)
        {
            long num;
            if (ProcessNum(StrNum, out num))
            {
                string result = GetInnerNum(num);
                if (result != null)
                {
                    _visualizator.WaitForAnswer(ExecutionStatus.Ok, result, num);
                }
                else
                {
                    _visualizator.WaitForAnswer(ExecutionStatus.TooBigOrSmall);
                }
            }
            else
            {
                _visualizator.WaitForAnswer(ExecutionStatus.CantConvertToNum);
            }
        }

        
        private void ValidateInner(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                _visualizator.WaitForAnswer(ExecutionStatus.Ininstruction);
                return;
            }
            foreach (string item in arr)
            {
                TryConvert(item);
            }
        }

        private bool ProcessNum(string str, out long num)
        {
            bool result = false;
            if (long.TryParse(str, out num))
            {
                result = true;
            }
            return result;
        }

        private string GetInnerNum(long inner) 
        {
            string answer;
            try
            {
                answer = _converter.Parse(inner);
            }
            catch (ArgumentOutOfRangeException)
            {
                answer = null;
            }

            return answer;
        }
    }
}
