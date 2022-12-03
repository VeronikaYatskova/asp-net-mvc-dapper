using DapperMvc.Models;

namespace DapperMvc.Services.Abstracts
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudentById(Guid id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Guid id);
    }
}
