using System;
using System.Collections.Generic;
using System.Text;
using Task5_TheNumberInTheRecord.Intermidiate;

namespace Task5_TheNumberInTheRecord.BL
{
    class MControler
    {
        public MControler(IUI visualizator)
        {
            _converter = new NumberParser();
            visualizator.SendNumberDesc += GetInnerNum;
            CompareEnvelopesDesc += visualizator.WaitForAnswer;
        }

        private void GetInnerNum(long inner)
        {
            string result = _converter.Parse(inner);
            if (_finishProcessing != null)  // использовать подсказки студии _finishProcessing?.Invoke(result);??????
            {
                _finishProcessing(result);
            }
        }

        public event FinishProcessing CompareEnvelopesDesc
        {
            add
            {
                _finishProcessing += value;
            }
            remove
            {
                _finishProcessing -= value;
            }
        }

        private FinishProcessing _finishProcessing;

        private INumberParser _converter;
    }
}
