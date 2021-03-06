﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class CalcBase
    {
        public float first_number;
        public float second_number;
        public float result;
        public string operation;
        public List<float> memory= new List<float>();
        public float memory_add;

        public void Calculate()
        {
            switch (operation)
            {
                case "+":
                    result = first_number + second_number;
                    break;
                case "-":
                    result = first_number - second_number;
                    break;
                case "x":
                    result = first_number * second_number;
                    break;
                case "/":
                    result = first_number / second_number;
                    break;
                case "x^2":
                    result = first_number * first_number;
                    break;
                case "sqrt":
                    result = first_number/first_number;
                    break;
                case "1/x":
                    result = 1 / first_number;
                    break;
                case "%":
                    result = first_number/100;
                    break;
                case "M+":
                    memory[memory.Count - 1] = memory[memory.Count - 1] + memory_add;
                    break;
            }
        }
    }
}
