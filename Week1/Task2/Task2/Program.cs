using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Implement a class Student. Student has a name, id and a year of study. Provide a constructor
with two parameters and create methods to access name, id and increment the year of study.*/

namespace Task2
{
    class Student         // Создаем класс Student
    {
        public string name; // Создаем глобальные переменные этого класса, т.е. name, id и year
        public string id;
        public int year; // Переменная year не будет передаваться в конструктор, т.к. конструктор содержит только 2 параметра по условию, а именно name и id
        // Объект будет выводится 4 раза (т.к. бакалавр включает в себя 4 года обучения) и при каждом выводе год обучения будет увеличиваться на 1 
        // Поэтому по дефолту  переменной year присваивается значение = 0

        public Student(string name, string id) // Создаем конструктор класса c 2мя параметрами, в который будем закидывать объект
        {
            this.name = name; // Инициализируем переменные. Используем указатель this для того, чтобы дать компилятору понять что и куда нужно скопировать
            this.id = id;
        }

        // Method 1 to access the name of the object
        public string getName()
        {
            return name;
        }

        // Method 2 to access the id 
        public string getID()
        {
            return id;
        }

        // Method 3 to access the year and increment it by 1
        public int getYear()
        {
            year++;  // year++ делаем для того чтобы при каждом выводе объекта его год обучения увеличивался на 1
            return year;
        }

        // Method for accessing the full info of the student
        public string getInfo()
        {
            return ("Name: " + getName() + "\nID: " + getID() + "\nYear: " + getYear());
        }

    }


    class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); // Вводим данные
            string id = Console.ReadLine();
            Student st = new Student(name, id); // Создаем объект и закидываем его в конструктор с 2мя параметрами, расположенный в классе Student

            // Cоздаем цикл для того чтобы объект выводился 4 раза и при каждом выводе год обучения объекта увеличивался на 1
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine();
                Console.WriteLine(st.getInfo()); // Выводим полную информацию о студенте
                Console.WriteLine();
            }

            Console.ReadKey();

        }
    }
}
