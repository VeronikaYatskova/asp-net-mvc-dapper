using DapperMvc.Data;
using DapperMvc.Models;
using DapperMvc.Services.Abstracts;

namespace DapperMvc.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudents() => _studentRepository.GetStudents();

        public Student? GetStudentById(Guid id) => _studentRepository.Get(id);

        public void CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            _studentRepository.Create(student);
        }

        public void UpdateStudent(Student student) => _studentRepository.Update(student);

        public void DeleteStudent(Guid id) => _studentRepository.Delete(id);
    }
}
