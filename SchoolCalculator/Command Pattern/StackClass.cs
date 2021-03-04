using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolCalculator.Functions;

namespace SchoolCalculator.Command_Pattern
{
    //Invoker
    public class StackClass
    {
        public void Add(ICommand icommand)
        {
            CommandStack.Push(icommand);
        }
        //ctrl+rr=byta överallt
        private Stack<ICommand> CommandStack = new Stack<ICommand>();
        private Stack<ICommand> _RedoCommand = new Stack<ICommand>();

        public void Redo(int level)
        {
            for(int i = 0; i <= level; i++)
            {
                Redo();
            }
        }

        public void Undo(int level)
        {
            for (int i = 0; i <= level; i++)
            {
                Undo();
            }
        }

        public void Redo()
        {
            {
                if (_RedoCommand.Count != 0)
                {
                    var command = _RedoCommand.Pop();
                    CommandStack.Push(command);
                }
            }
        }
        public void Undo()
        {
            if (CommandStack.Count != 0)
            {
                var command = CommandStack.Pop();
                _RedoCommand.Push(command);
            }
        }

        public string GetNumberPeek()
        {
            string result = GetNumber();

            for (int i = result.Length-1; i >= 0; i--)
            {
                CommandStack.Push(new Numbers(result[i].ToString()));
            }
            return result;
        }
        public string GetNumber()
        {
            string result = string.Empty;
            try
            {
                ICommand command;
                while ((command = CommandStack.Peek()) is IOperands)
                {
                    CommandStack.Pop();
                    result = result.Insert(0, (command as IOperands).Symbol);

                }
            }
            catch (InvalidOperationException)
            {
            }
            return result;
        }
        public string StackToString()
        {
            var stackList = CommandStack.ToList();
            string result = "";
            foreach (var item in stackList)
            {
                result = result.Insert(0, item.Symbol);
            }
            return result;
        }
        public double Equals()
        {
            var secondNum = GetNumber();
            var opt= CommandStack.Pop() as IOperator;
            var firstNum = GetNumber();
            return opt.Calculate(double.Parse(firstNum), double.Parse(secondNum));
            
        }

        public bool operationPerformedCorrectly 
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException(); 
        }
    }
}

