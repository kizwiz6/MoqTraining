using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTraining
{
    /// <summary>
    /// A repository containing all the students in a system.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Returns a student by an ID value.
        /// </summary>
        /// <param name="id">Numeric ID value of student to pull</param>
        /// <returns>If student with ID supplied exists in the repository, it return such a Student with Id. If no student in repository has such Id, it returns null.</returns>
        public Student GetStudent(int id);

        /// <summary>
        /// Asynchronously returns all the students in the repository
        /// </summary>
        /// <returns>A list of students in the repository</returns>
        public Task<List<Student>> GetStudentsAsync();
    }
}
