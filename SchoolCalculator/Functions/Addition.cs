using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalculator.Functions
{
    public class Addition : IOperator
    {
        public string Symbol => "+";

        public double Calculate(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}
