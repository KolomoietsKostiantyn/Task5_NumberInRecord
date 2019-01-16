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
        #endregion

        public MControler(IVisualizator visualizator)
        {
            _converter = new NumberParser(Constants.maxValue, Constants.minValue);
            visualizator.SendNumberDesc += GetInnerNum;
            _visualizator = visualizator;
        }

        private void GetInnerNum(long inner)  // добавить ловлю исключений
        {
            ExecutionStatus result = ExecutionStatus.Ok;
            string answer;
            try
            {
                answer = _converter.Parse(inner);
            }
            catch (ArgumentOutOfRangeException)
            {
                result = ExecutionStatus.TooBigOrSmall;
                answer = "You pass too big or small value.";
            }

            if (_visualizator != null)
            {
                _visualizator.WaitForAnswer(result, answer);
            }
        }
    }
}
