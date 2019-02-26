using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    //Creating the Class Complex
    public class Complex
    {
        public int real;
        public int imaginary;

        //Creating an empty constructor for serialization
        public Complex() { }
        //Creating a constructor with two parameters
        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
    }



    class Program
    {   public static Complex n1;
        public static int real_part;
        public static int imaginary_part;
        public static string re;
        public static string imag;

        //A Method which separates the real part and imaginary part
        public static void Get_Real_Imaginary_parts(string complex)
        {
            int i = 0;
            while (complex[i] != '+')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    re += complex[i];
                }
                i++;
            }

            real_part = int.Parse(re);

            while (complex[i] != 'i')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    imag += complex[i];
                }
                i++;
            }

            imaginary_part = int.Parse(imag);
        }

        //A Method to Serialize an object
        static void Serialize(Complex number)
        {   
            //Creating a FileStream to Open or Create file to which an object will be uploaded
            FileStream fs = new FileStream("Storage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Creating a Serializer of type Complex
            XmlSerializer ser = new XmlSerializer(typeof(Complex));
            //Upload an object to the file using Serialization
            ser.Serialize(fs, number);
            //Close FileStream
            fs.Close();
        }

        // A Method to Deserialize an object
        static void Deserialize()
        {
            //Creating a FileStream to Open the file from which an object will be uploaded
            FileStream fs = new FileStream("Storage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Creating Deserializer of type Complex
            XmlSerializer deser = new XmlSerializer(typeof(Complex));
            //Deserializing an object using Deserialization
            n1 = deser.Deserialize(fs) as Complex;
            //Close FileStream
            fs.Close();
        }

        static void Main(string[] args)
        {
            string complex_number = Console.ReadLine();
            //Call Method Get_Real_Imaginary_parts
            Get_Real_Imaginary_parts(complex_number);
            //Creating an object called number
            Complex number = new Complex(real_part, imaginary_part);
            //Calling Serialize Method
            Serialize(number);
            //Calling Deserialize Method
            Deserialize();
            //Checking wheather the deserialization works or not by outputting the deserialized object2 
            Console.WriteLine(n1.real+"+"+n1.imaginary+'i');
            Console.ReadKey();
            
        }
    }
}
