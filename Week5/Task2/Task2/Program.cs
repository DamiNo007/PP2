using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    // Class Mark
    public class Mark
    {   
        public int points;
        //Empty constructor for serialization
        public Mark() { }
        //Constructor with one parameter
        public Mark(int points)
        {
            this.points = points;
        }

        //A Method to get letter by points
        public string GetLetter()
        {
            if (points == 100)
                return "A+";

            else if (points >= 95 && points <100)
                return "A";

            else if (points >= 90 && points < 95)
                return "A-";

            else if (points >= 85 && points <= 90)
                return "B+";

            else if (points >= 80 && points <= 85)
                return "B";
            else if (points >= 75 && points <= 80)
                return "C+";

            else if (points >= 70 && points <= 75)
                return "C";

            else if (points >= 65 && points <= 70)
                return "D+";

            else if (points >= 60 && points <= 65)
                return "D";

            else
            {
                return "F";
            }
        }

        //Overriding GetLetter() Method to string and returning it
        public override string ToString()
        {
            return  "Mark: " + GetLetter().ToString();
        }
    }

    class Program
    {
        // Creating two lists one to be serialized and another one to take the deserialized values
        public static List<Mark> marks = new List<Mark>();
        public static List<Mark> deser_marks;

        //A Method to Deserialize the objects from the file
        static void Deserialize()
        {   //FileStream to Open the file from wich the List of objects will be deserialized
            FileStream fs = new FileStream("Storage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Serializer of type List<Mark> to deserialize
            XmlSerializer deser = new XmlSerializer(typeof(List<Mark>));
            //Deserialization process
            deser_marks = deser.Deserialize(fs) as List<Mark>;
            //Close FileStream
            fs.Close();
        }

        //A Method to Serialize the List of objects of the class Mark
        static void Serialize(List<Mark> marks)
        {   //FileStream to Open or Create the file to which the List of objects will be serialized
            FileStream fs = new FileStream("Storage.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Serializer of type List<Mark> to serialize
            XmlSerializer ser = new XmlSerializer(typeof(List<Mark>));
            //Serialization process
            ser.Serialize(fs, marks);
            //Close FileStream
            fs.Close();
        }

        

        static void Main(string[] args)
        {   
            //How many objects will be created 
            int n = int.Parse(Console.ReadLine());
            //Cycle for creating the objects and adding them to the list
            for (int i = 0; i <n; i++)
            {
                Mark mark = new Mark(int.Parse(Console.ReadLine()));
                Console.WriteLine(mark);
                marks.Add(mark);
            }

            //Output the elements of the list
            foreach(Mark mark in marks)
            {
                Console.WriteLine(mark);
            }

            //Call the Serialize Method
            Serialize(marks);
            //Call the Deserialize Method
            Deserialize();

            //Output the elements of the deserialized list
            foreach(Mark mark in deser_marks)
            {
                Console.WriteLine(mark);
            }


            Console.ReadKey();

        }
    }
}
