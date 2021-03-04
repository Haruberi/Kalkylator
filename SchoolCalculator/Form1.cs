using SchoolCalculator.Command_Pattern;
using SchoolCalculator.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolCalculator
{
    //Client
    public partial class Form1 : Form
    {
        double valueResult = 0;
        string operation = "";
        bool operationPerformedCorrectly = false;


        public Form1()
        {
            stackClass = new StackClass();
            //renderar hela gränssnittet
            InitializeComponent();
        }

        private StackClass stackClass;
        //Functions for buttons for numbers and ","
        private void button_click(object sender, EventArgs e)
        {
            if ((ResultBox.Text == "0") || (operationPerformedCorrectly))
                ResultBox.Clear();

            operationPerformedCorrectly = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!stackClass.GetNumberPeek().Contains("."))
                {
                    Numnum(button.Text);
                }
            }
            else
                Numnum(button.Text);

            PrintStack();
  }
        //Functions for buttons for "+" , "-" , "x" and "/"
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //if (valueResult != 0)
            //{
            //    equalButton.PerformClick();
            //    operation = button.Text;
            //    showOperationLabel.Text = valueResult + " " + operation;
            //    operationPerformedCorrectly = true;
            //}
            //else
            //{
            //    operation = button.Text;
            //    alueResult = double.Parse(ResultBox.Text);
            //    showOperationLabel.Text = valueResult + " " + operation;
            //    operationPerformedCorrectly = true;
            //}
            switch (button.Text)
            {
                case "+":
                    Addadd();
                    break;

                case "-":
                    Subsub();
                    break;

                case "x":
                    ResultBox.Text = (valueResult * double.Parse(ResultBox.Text)).ToString();
                    break;

                case "/":
                    ResultBox.Text = (valueResult / double.Parse(ResultBox.Text)).ToString();
                    break;

                default:
                    break;
            }
            PrintStack();

        }

        //Function for button "CE"
        private void clear_click(object sender, EventArgs e)
        {

            ResultBox.Text = "0";
        }

        //Function for button "C"
        private void c_click(object sender, EventArgs e)
        {
            ResultBox.Text = "0";
            valueResult = 0;
        }

        //Function for button "="
        public void equal_click(object sender, EventArgs e)
        {
            var result = stackClass.Equals();
            ResultBox.Text = result.ToString();

            operationPerformedCorrectly = true;
        }

        void undoButton_Click(object sender, EventArgs e)
        {
            {
                stackClass.Undo();
                PrintStack();
            }
        }


            void redoButton_Click(object sender, EventArgs e)
            {
                stackClass.Redo();
                PrintStack();
            }
        //+
        private void Addadd()
        {
            Addition addition = new Addition();
            stackClass.Add(addition);
        }
        //-
        private void Subsub()
        {
            Subtraction subtraction = new Subtraction();
            stackClass.Add(subtraction);
        }
        
        private void Numnum(string doub)
        {
            Numbers numbers = new Numbers(doub);
            stackClass.Add(numbers);
        }
        private void PrintStack()
        {
            ResultBox.Text = stackClass.StackToString();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 49)
            {
                Numnum("1");
            }
        }

        }


    
}