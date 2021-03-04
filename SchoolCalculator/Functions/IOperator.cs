using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalculator.Functions
{
    public interface IOperator:ICommand
    {
        double Calculate(double num1, double num2);
    }
}
