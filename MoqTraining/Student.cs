using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTraining
{
    /// <summary>
    /// A class to denote students in a system.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GradeAverage { get; set; }
    }
}
