using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace project_Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayOption();
            Console.ReadKey();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("1. Show All Student");
            Console.WriteLine("2. Insert Student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Delete student");
            var index = int.Parse(Console.ReadLine());
            show(index);
        }
        public static void show(int index)
        {
            StudentRepo studentRepo = new StudentRepo();
            if (index == 1)
            {
                var studentDB = studentRepo.GetAll();
                if (studentDB.Count() == 0)
                {
                    Console.WriteLine("===================");
                    Console.WriteLine("No Item found in the list!!!!");
                    Console.WriteLine("*********************");
                }
                else
                {
                    foreach (var item in studentRepo.GetAll())
                    {
                        Console.WriteLine($"Student Id :{item.StudentId},Name :{item.StudentName},Age :{item.Age}");
                    }
                    Console.WriteLine("*******************");
                    DisplayOption();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("===================");
                Console.Write("Name  :");
                string name = Console.ReadLine();
                Console.Write("Age  :");
                int Age = int.Parse(Console.ReadLine());
                int maxId = studentRepo.GetAll().Any() ? studentRepo.GetAll().Max(a => a.StudentId) : 0;
                Student student = new Student
                {
                    StudentId = maxId + 1,
                    StudentName = name,
                    Age = Age
                };
                studentRepo.Insert(student);
                Console.WriteLine("Data inserted successfully !!!");
                DisplayOption();
            }
            else if (index == 3)
            {
                Console.WriteLine("********************");
                Console.Write("Enter Student Id to update  :");
                int id = int.Parse(Console.ReadLine());
                var _student = studentRepo.GetById(id);
                if (_student == null)
                {
                    Console.WriteLine("*********************");
                    Console.WriteLine("Student Id is invalid !!");
                    Console.WriteLine("***********************");
                    return;
                }
                else
                {
                    Console.WriteLine($"Update info for Student Id :{id} ");
                    Console.WriteLine("***********************");

                    Console.Write("Name  :");
                    string name = Console.ReadLine();
                    Console.Write("Age  :");
                    int Age = int.Parse(Console.ReadLine());

                    Student student = new Student
                    {
                        StudentId = id,
                        StudentName = name,
                        Age = Age
                    };
                    studentRepo.Update(student);
                    Console.WriteLine("Data Updated successfully !!");
                    DisplayOption();
                }

            }
            else if (index == 4)
            {
                Console.WriteLine("==========================");
                Console.Write("Enter StudentId to delete :");

                int id = Convert.ToInt32(Console.ReadLine());
                var _student = studentRepo.GetById(id);

                if (_student == null)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("student id is invalid!!!");
                    Console.WriteLine("==========================");
                    return;
                }
                else
                {
                    studentRepo.Delete(id);
                    Console.WriteLine("Data deleted successfully!!!");
                    Console.WriteLine("==========================");
                    DisplayOption();
                }
            }
        }
    }
}
