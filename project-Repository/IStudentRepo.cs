using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_Repository
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAll();
        Student GetById(int StudentId);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int StudentId);
    }
}
