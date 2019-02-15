﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FarManager1
{
    //Creating a class FarManager
    class FarManger
    {

        public int cursor; // the "cursor" variable 
        public int size; // Variable "size" gets size of the FileSystemInfo  
        public bool show_hidden_files; // if "show_hidden_files" is true => show hidden files

        //Creating a constructor FarManager
        public FarManger()
        {
            cursor = 0;
            show_hidden_files = true;
        }

        // A Method for Deleting files and directories
        public void DELETE(FileSystemInfo fs)
        {
            //If the cursor points on the file
            if (fs.GetType() == typeof(FileInfo))
            {
                File.Delete(fs.FullName);
            }

            //If the cursor points on the directory
            else
            {
                Directory.Delete(fs.FullName, true); //Deletes the directory with all files and directories inside it

            }
        }

        // A Method for Renaming the files and directories
        public void RENAME(FileSystemInfo fs)
        {
            string ext = Path.GetExtension(fs.FullName); // gets the file's extension of the given path
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Enter new name:");
            string new_name = Console.ReadLine(); // entering new name of the file

            // if user changes the name of the directory
            if (fs.GetType() == typeof(DirectoryInfo))
            {
                // Moving the contents of the Directory from the directory with one name to the same directory
                // but with another name
                Directory.Move(fs.FullName, Path.GetDirectoryName(fs.FullName) + "/" + new_name);
            }

            // if user changer the name of the folder
            else
            {
                //Copying the file contents from the file with one name to a file with another name
                File.Copy(fs.FullName, Path.GetDirectoryName(fs.FullName) + "/" + new_name + ext);
                //Deleting the initial file's path
                File.Delete(fs.FullName); // delete initial file
            }
            cursor = 0;// refresh the cursor
        }


        // A Method for Opening files
        public void OPEN(FileSystemInfo fs)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            // Use StreamReader to Read the contents of the file and output them 
            using (StreamReader sr = File.OpenText(fs.FullName)) // read the txt file
            {
                string s = null; // creating a string which will each line of the text from the file

                //creating a cycle to run through all lines
                do
                {
                    s = sr.ReadLine(); // Reading text from the file line by line
                    Console.WriteLine(s); // outputing line by line
                } while (s != null); // while it is not null
            }
            Console.ReadKey();
        }

        // A Method for Coloring the files in one color and directories in another one
        // also changes the color of the current directory to which the cursor points out
        public void Color(FileSystemInfo fi, int index)
        {
            // If our index equals cursor then it is our current directory and it should be colored somehow to be highlighted

            if (index == cursor)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Directories in one color
            else if (fi.GetType() == typeof(DirectoryInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Files in another one
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }

        // A Method which changes our cursor's value as we move up
        public void UP()
        {
            cursor--;
            // if cursor goes upper than the first element it should go up to the last element in a row
            if (cursor < 0)
                cursor = size - 1;
        }

        // A Method which changes our cursor's value as we move down
        public void DOWN()
        {
            // if cursor goes lower than the last element it should go up to the first element in a row
            cursor++;
            if (cursor == size)
                cursor = 0;
        }


        // A Method to show the contents
        public void SHOW(string path)
        {   // DirectoryInfo gets all info about the directories from the given path
            DirectoryInfo directory = new DirectoryInfo(path);
            //"FileSystemInfo" array stores all directories and files that are in the main directory
            FileSystemInfo[] fi = directory.GetFileSystemInfos();
            //Size of the "FileSystemInfo" array
            size = fi.Length;
            //index of the elements in the array
            int index = 0;
            foreach (FileSystemInfo fs in fi)
            {
                // When not to how hidden files the size must be changed as the number of elements changes
                if (!show_hidden_files && fs.Name.StartsWith("."))
                {
                    size--;
                    continue;
                }

                Color(fs, index);

                Console.WriteLine(index + 1 + "." + fs.Name);
                index++;
            }

        }



        // A Method to Start
        public void BEGIN(string path)
        {
            // Creating a directory path
            DirectoryInfo directory = new DirectoryInfo(path);
            //Creating an array "FileSystemInfo"
            FileSystemInfo[] fi = directory.GetFileSystemInfos();
            // ConsoleKey to Read from buttons
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            //Creating an empty FileSystemInfo to user later
            FileSystemInfo fs = null;

            // A cycle to always show the contents and update them
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.WriteLine(path);
                //Calling a show function
                SHOW(path);

                //If user press UpArrow we call UP() function
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    UP();
                }

                //if DownArrow we call DOWN() function
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    DOWN();
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    cursor = 0;
                    show_hidden_files = false;
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    cursor = 0;
                    show_hidden_files = true;
                }

                //If user press Backspace we go to parrent(previous) directory 
                if (key.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    directory = directory.Parent; // Updating the directory
                    fi = directory.GetFileSystemInfos(); //Updating the "FileSystemInfo" array with new directory
                    path = directory.FullName; // Updating the path 
                }

                //If user press Enter we enter the directory, or if it is a file he presses Enter on we open the contents of the file
                if (key.Key == ConsoleKey.Enter)
                {
                    //Creating a variable "k" for indexing the elements of the array
                    int k = 0;

                    for (int i = 0; i < fi.Length; i++)
                    {
                        //if cursor equals "k" we are on the current directory
                        if (cursor == k)
                        {
                            fs = fi[i];
                            cursor = 0;
                            // if it is a folder we are on => we open it
                            if (fs.GetType() == typeof(DirectoryInfo))
                            {
                                cursor = 0;
                                directory = new DirectoryInfo(fs.FullName); //Updating the directory
                                fi = directory.GetFileSystemInfos(); // Updating the "FileSystemInfo" array with new directory
                                path = fs.FullName; // Updating the path
                                break;
                            }

                            // If it is a file we are on we call the function OPEN() to open the file
                            else
                            {
                                OPEN(fs);
                            }
                        }

                        k++; // Incrementing the index
                    }

                }

                // If user press F1 call the function RENAME() to rename the current directory or file
                if (key.Key == ConsoleKey.F1)
                {
                    int k = 0;
                    foreach (FileSystemInfo f in fi)
                    {
                        if (cursor == k)
                            RENAME(f);

                        k++;
                    }
                }

                //If user press Delete call the function DELETE() to delete the current directory or file
                if (key.Key == ConsoleKey.Delete)
                {
                    int k = 0;
                    foreach (FileSystemInfo f in fi)
                    {
                        if (cursor == k)
                            DELETE(f);

                        k++;
                    }

                }
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            FarManger fm = new FarManger();
            //The main path
            string path = @"C:\";
            //Call function to Start
            fm.BEGIN(path);
        }
    }
}
