using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTraining
{
    internal class StudentRepository : IStudentRepository
    {
        public Student GetStudent(int id)
        {
            // Make a DB call to get a student by ID
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            // Make a DB call to get all students by ID
            throw new NotImplementedException();
        }
    }
}
