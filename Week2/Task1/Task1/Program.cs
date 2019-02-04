using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class Program
    {
        public static string s;

        // A Method to check whether the string is a polindorme or not
        public static bool Pol(string s)
        {
            for(int i =0; i<s.Length/2; i++)
            {
                //if any letter from the begining does not match to the corresponding letter from the end then it is not a polindrome 
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            //otherwise it is polindrome
            return true;
        }

        // A Method to read from the file
        public static void Read()
        {
            // Using the StreamReader command to read from the file called "input.txt"
            StreamReader sr = new StreamReader(@"C:\Users\User\PP2\Week2\Task1\input.txt");
            s = sr.ReadLine();
            sr.Close();
        }

        // A Method to Write to the file
        public static  void Write()
        {
            //Using the StreamWriter command to write to the file called "output.txt"
            StreamWriter sw = File.AppendText(@"C:\Users\User\PP2\Week2\Task1\output.txt");
            //If the string got from the "input.txt" file is polindrome write "yes" to the "output.txt" file
            if (Pol(s)) sw.WriteLine("yes");
            //Otherwise write "no" to the "output.txt" file
            else sw.WriteLine("no");
            sw.Close(); // sw.Close() to save the text entered to the "output.txt"
        }

        static void Main(string[] args)
        {
            Read(); //Call the Method Read() 
            Write(); //Call the Method Write() 

            Console.ReadKey();
            

        }
       
    }
}
