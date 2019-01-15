using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_TheNumberInTheRecord.Intermidiate
{
    interface IUI
    {
        void WaitForAnswer(string answer);
        event SendNumber SendNumberDesc;
        void Start();
    }
}
