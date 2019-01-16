using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_TheNumberInTheRecord.Intermidiate
{
    interface IVisualizator
    {
        void WaitForAnswer(ExecutionStatus result, string answer);
        event SendNumber SendNumberDesc;
        void Start();
    }
}
