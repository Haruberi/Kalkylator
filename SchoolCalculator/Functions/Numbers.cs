using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalculator.Functions
{
    public class Numbers:IOperands
    {
        //ctor: construktor
        public Numbers(string number)
        {
            Symbol=number;
        }
        public string Symbol { get; }
    }
}
