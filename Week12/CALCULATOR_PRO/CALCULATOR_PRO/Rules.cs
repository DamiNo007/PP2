using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CALCULATOR_PRO
{
    class Rules
    {
        public static bool IsDigit(string text)
        {
           String[] input = new String[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return input.Contains(text);
        }

        public static bool IsNonZeroDigit(string text)
        {
            String[] input = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            return input.Contains(text);
        }

        public static bool IsOperation(string text)
        {
            String[] input = new String[] { "+", "-", "*", "/","x^2","sqrt","1/x","%","<-","C","+/-"};
            return input.Contains(text);
        }

        public static bool IsEqual(string text)
        {
                return text == "="; 
        }
    }
}
