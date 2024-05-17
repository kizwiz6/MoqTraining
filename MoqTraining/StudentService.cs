using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTraining
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Grade GetStudentGrade(int id)
        {
            var student = _studentRepository.GetStudent(id);

            if (student == null)
            {
                throw new ArgumentException("Could not find student with that ID.", nameof(id));
            }

            if (student.GradeAverage >= 90)
            {
                return Grade.A;
            }
            else if (student.GradeAverage >= 80)
            {
                return Grade.B;
            }
            else if (student.GradeAverage >= 70)
            {
                return Grade.C;
            }
            else if (student.GradeAverage >= 60)
            {
                return Grade.D;
            }
            else
            {
                return Grade.F;
            }
        }

        /// <summary>
        /// Asynchronously resturns a list of students in order by their last name.
        /// </summary>
        /// <returns>A list of students organised by their last name, ascending.</returns>
        public async Task<List<Student>> GetStudentsInAlphabeticalOrderAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();

            return students.OrderBy(s => s.LastName).ToList();
        }

    }
}
