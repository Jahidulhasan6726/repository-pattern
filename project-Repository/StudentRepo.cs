using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Repository
{
    public class StudentRepo : IStudentRepo
    {
        public void Delete(int StudentId)
        {
            Student student = StudentDb.StudentList.FirstOrDefault(a=>a.StudentId==StudentId);
           StudentDb.StudentList.Remove(student);
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentDb.StudentList;
        }

        public Student GetById(int StudentId)
        {
            Student student = StudentDb.StudentList.FirstOrDefault(a=>a.StudentId==StudentId);
            return student;
        }

        public void Insert(Student student)
        {
            StudentDb.StudentList.Add(student);
        }

        public void Update(Student student)
        {
            Student _student = StudentDb.StudentList.FirstOrDefault(a=>a.StudentId==student.StudentId);
            if(student.StudentName != null)
            {
                _student.StudentName = student.StudentName;
            }
            if (student.Age != 0)
            {
                _student.Age = student.Age;
            }
        }
    }
}
