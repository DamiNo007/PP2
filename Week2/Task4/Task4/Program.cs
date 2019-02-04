using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        public static string FolderName = @"C:\Users\User\PP2\Week2\Task4\FileToCopy";
        public static string fileName = "FileToCopy.txt";

        //A Method to Copy the file from one location to another
        public static void Copy(string source, string dest)
        {
            File.Copy(source, dest,true); //Copying the file from one directory to another
            Delete(source); // Call Delete function in order to delete the file from the source directory

        }

        //A Method to Delete the file from the source location when it's already copied to another location
        public static void Delete(string source)
        {
            File.Delete(source); //Deleting the file from the source directory
        }

        // Or instead those two methods we can use File.Move function in order to move file from one location to another

        /*public static void Move(string source, string dest)
        {
            File.Move(source, dest);
        }*/


        // Main Method    
        static void Main(string[] args)
        { 
            string path = Path.Combine(FolderName, "From"); 
            string path1 = Path.Combine(FolderName, "To"); 
            Directory.CreateDirectory(path); // Creating a directory 1 called "path"
            Directory.CreateDirectory(path1); // Creating a directory 2 called "path1"
            path = Path.Combine(path, fileName); //Creating the way to the file in directory 1
            path1 = Path.Combine(path1, fileName); // Creating the way to the file in directory 2

            FileInfo fi = new FileInfo(path); // Getting a file info in order to check whether the file exists or not

            //If the file does not exist the following condition holds
            if (!fi.Exists) 
            {
                //Creating a file and writing a text to it
                //using StreamWriter
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Hello World!");
                }
            }

            //If the file already exists the following condition holds
            else
            {
                Console.WriteLine("File already exists!");

            }


            Copy(path, path1); //Call the function Copy() which then will call the function Delete()

            //Move(path, path1);



            Console.ReadKey();           
        } 
    }
}
