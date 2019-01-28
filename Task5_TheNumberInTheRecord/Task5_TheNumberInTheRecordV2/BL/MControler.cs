using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5_TheNumberInTheRecord.Intermediate;

namespace Task5_TheNumberInTheRecord.BL
{
    class MControler
    {
        private IVisualizator _visualizator;
        private INumberParser _parser;
        private IInnerDataValidator _innerDataValidator;
        string[] _arr;

        public MControler(IVisualizator visualizator, INumberParser converter, IInnerDataValidator innerDataParser, string [] arr)
        {
            _visualizator = visualizator;
            _parser = converter;
            _innerDataValidator = innerDataParser;
            _arr = arr;
        }

        public void Start()
        {
            if (_innerDataValidator.ValidateInputArray(_arr))
            {
                foreach (string item in _arr)
                {
                    TryConvert(item);
                }
            }
            else
            {
                _visualizator.SendInfo(Message.Ininstruction);
            }
            do
            {
                string strNum = _visualizator.AskNumber();
                TryConvert(strNum);
            } while (_visualizator.AskContinue());
        }


        private void TryConvert(string strNum)
        {
            long num;
            if (_innerDataValidator.ConvertStringToValidNumber(strNum, out num))
            {
                string result = _parser.Parse(num);
                _visualizator.SendAnswer(result, num);
            }
            else
            {
                _visualizator.SendInfo(Message.IncorectData);
            }

        }



    }
}
