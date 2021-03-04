using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCalculator.Command_Pattern
{
    //Command
    public interface IPatternClass
    {
        //Undo - Ta bort översta kommando i stacken
       void Undo();
        //Redo - Returnera det kommando som togs bort i stacken
       void Redo();

        bool operationPerformedCorrectly { get; set; }
        
        //Execute
        void equal_click(object sender, EventArgs e);

    }
}
