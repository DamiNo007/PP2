using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR_PRO
{
    enum CalcState
    {
        Zero,
        AccumulateDigit,
        Operation,
        Result
    };

    public delegate void ChangeTextDelegate(string text);
    class Calculator
    {
        public ChangeTextDelegate textDeleg;
        public CalcState state;
        public string temp_num;
        public string res_num;
        public string operation;

        public Calculator(ChangeTextDelegate textDeleg)
        {
            this.textDeleg = textDeleg;
            temp_num = "";
            res_num = "";
            operation = "";
        }

        public void Process(string input)
        {
            switch (state)
            {
                case CalcState.Zero:
                    Zero(input, false);
                    break;
                case CalcState.AccumulateDigit:
                    AccumulateDigit(input, false);
                    break;
                case CalcState.Operation:
                    Operation(input, false);
                    break;
                case CalcState.Result:
                    Result(input, false);
                    break;
            }
        }

        public void Zero(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Zero;
            }

            else
            {
                if (Rules.IsNonZeroDigit(msg))
                    AccumulateDigit(msg, true); 
            }
        }

        public void AccumulateDigit(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.AccumulateDigit;
                temp_num += msg;
                textDeleg.Invoke(temp_num);
            }

            else
            {
                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
                if (Rules.IsEqual(msg))
                    Result(msg, true);
            }
        }

        public void Calculate()
        {
            if (operation == "+")
                res_num = (float.Parse(res_num) + float.Parse(temp_num)).ToString();
            if(operation == "-")
                res_num = (float.Parse(res_num) - float.Parse(temp_num)).ToString();
            if (operation == "*")
                res_num = (float.Parse(res_num) * float.Parse(temp_num)).ToString();
            if(operation == "/")
                res_num = (float.Parse(res_num) / float.Parse(temp_num)).ToString();              

        }

        public void Operation (string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Operation;

                if (msg == "x^2")
                {
                    res_num = temp_num;
                    res_num = (float.Parse(res_num)*float.Parse(res_num)).ToString();
                    textDeleg.Invoke(res_num);
                    temp_num = res_num;
                }

                else if(msg == "sqrt")
                {
                    res_num = temp_num;
                    res_num = (Math.Sqrt(float.Parse(res_num))).ToString();
                    textDeleg.Invoke(res_num);
                    temp_num = res_num;
                }

                else if(msg == "1/x")
                {
                    res_num = temp_num;
                    res_num = (1 / float.Parse(res_num)).ToString();
                    textDeleg.Invoke(res_num);
                    temp_num = res_num;
                }

                else if(msg == "%")
                {
                    res_num = temp_num;
                    res_num = (float.Parse(res_num) * 0.01).ToString();
                    textDeleg.Invoke(res_num);
                    temp_num = res_num;
                }

                else if (msg == "<-")
                {
                    if (temp_num.Length == 1)
                        temp_num = "0";
                    else
                        temp_num = temp_num.Remove(temp_num.Length - 1, 1);

                    textDeleg.Invoke(temp_num);
                    if(temp_num=="0")
                        temp_num = "";
                }

                else if (msg == "C")
                {
                    res_num = "";
                    temp_num = "";
                    operation = "";
                    textDeleg.Invoke("0");
                }

                else if(msg == "+/-")
                {
                    temp_num=(float.Parse(temp_num)*(-1)).ToString();
                    textDeleg.Invoke(temp_num);
                }



                else
                {
                    textDeleg.Invoke(temp_num + msg);

                    if (operation.Length > 0)
                    {
                        Calculate();
                        textDeleg.Invoke(res_num+msg);
                    }

                    else
                    {
                        res_num = temp_num;
                                
                    }

                    temp_num = "";
                    operation = msg;   
                }
            }
                    

            else
            {

                if (Rules.IsDigit(msg))
                    AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg))
                    Operation(msg, true);
            }
        }

        public void Result(string msg, bool input)
        {
            if (input)
            {
                Calculate();
                textDeleg.Invoke(res_num);
            }

        }
    }
}
