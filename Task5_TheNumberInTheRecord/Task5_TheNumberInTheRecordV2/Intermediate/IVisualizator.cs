using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_TheNumberInTheRecord.Intermediate
{
    interface IVisualizator
    {
        void SendAnswer(string txtNumber, long num);
        void SendInfo(Message message);
        string AskNumber();
        bool AskContinue();
    }
}
