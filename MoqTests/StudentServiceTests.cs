using Moq;
using MoqTraining;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoqTests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockStudentRepository;
        private StudentService _studentService;

        [SetUp]
        public void Setup()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_mockStudentRepository.Object);
        }

        [Test]
        public void GetStudentGrade_ReturnsCorrectGrade()
        {
            // Arrange
            var student = new Student { Id = 1, FirstName = "Kieran", LastName = "Emery", GradeAverage = 92.0 };
            _mockStudentRepository.Setup(repo => repo.GetStudent(1)).Returns(student);

            // Act
            var grade = _studentService.GetStudentGrade(1);

            // Assert
            Assert.That(grade, Is.EqualTo(Grade.A));
        }

        [Test]
        public void ShouldThrowExceptionIfStudentIdNotExist()
        {
            // Arrange
            var student = new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                GradeAverage = 81.5
            };

            var mockStudentService = new Mock<IStudentRepository>();
            mockStudentService.Setup(p => p.GetStudent(1)).Returns(student);

            _studentService = new StudentService(mockStudentService.Object);

            // Act & Assert
            var grade = _studentService.GetStudentGrade(1);
            Assert.That(grade, Is.EqualTo(Grade.B));

            // If we pass in a value not defined to Moq, its result will be treated as null.
            Assert.Throws<ArgumentException>(() => _studentService.GetStudentGrade(123));
        }

        [Test]
        public async Task ShouldSortStudentsInAlphabeticalOrder()
        {
            // Arrange
            var students = new List<Student>
    {
        new Student { Id = 1, FirstName = "Kieran", LastName = "Emery" },
        new Student { Id = 2, FirstName = "Banjo", LastName = "Kazooie" },
        new Student { Id = 3, FirstName = "Mollie", LastName = "Spaniel" }
    };

            var mockStudentService = new Mock<IStudentRepository>();
            mockStudentService.Setup(p => p.GetStudentsAsync()).Returns(Task.FromResult(students));

            _studentService = new StudentService(mockStudentService.Object);

            // Act
            var result = await _studentService.GetStudentsInAlphabeticalOrderAsync();

            // Log the order of students for debugging
            Console.WriteLine("Actual Order of Students:");
            foreach (var student in result)
            {
                Console.WriteLine($"Id: {student.Id}, LastName: {student.LastName}");
            }

            // Assert
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].Id, Is.EqualTo(1)); // Kieran Emery
            Assert.That(result[1].Id, Is.EqualTo(2)); // Banjo Kazooie
            Assert.That(result[2].Id, Is.EqualTo(3)); // Mollie Spaniel
        }
    }
}
