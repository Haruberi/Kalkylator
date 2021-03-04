using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalculator.Command_Pattern
{
    //Receiver
    public class PatternClass : IPatternClass
    {
        public void equal_click(object sender, EventArgs e)
        {
        }

        public void Undo()
        {
        }
        public void Redo()
        {
        }

        public bool operationPerformedCorrectly
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}

        

