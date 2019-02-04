using System;
using System.IO;

namespace Task3
{
    class Program
    {
        //A Method to print spaces when directories are recursively outputed
        static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("    "); //Printing the spaces as level increases
        }

        //A method to get directories and files
        static void GetDir(DirectoryInfo directory, int level)
        {
            // using FileInfo class and GetFiles command to get all files from the current directory 
            //and store them in array "files"
            FileInfo[] files = directory.GetFiles();
            //using DirectoryInfo class and GetDirectories command to get all directories inside the current directory
            //and store them in array "directories"
            DirectoryInfo[] directories = directory.GetDirectories();
                
                //Cycle to run through all files in "files"
                foreach (FileInfo file in files)
                {
                    //When the new circle of the cycle starts print an appropriate number of spaces
                    //to make a tree-like structure
                    PrintSpaces(level);
                    Console.WriteLine(file.Name);
                }

                //Cycle to run through all directories in "directories"
                foreach (DirectoryInfo d in directories)
                {
                    //When the new circle of the cycle starts print an appropriate number of spaces
                    //to make a tree-like structure
                    PrintSpaces(level);
                    Console.WriteLine(d.Name);
                    GetDir(d,level + 1);
                }
        }

        //Main Method
        static void Main(string[] args)
        {
            //Pointing a path to the folder which will be checked for directories and files
            string path = @"C:\Users\User\PP2\Week2";
            DirectoryInfo directory = new DirectoryInfo(path); 
            //Outputing the name of the main folder
            Console.WriteLine(directory.Name);
            GetDir(directory,1); //Call the GetDir() function to get all directories and files inside the folder "Week2"
            Console.ReadKey();
        }

    }

}