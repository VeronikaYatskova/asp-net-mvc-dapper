using DapperMvc.Models;

namespace DapperMvc.Data
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student? Get(Guid id);
        void Create(Student strudent);
        void Update(Student user);
        void Delete(Guid id);
    }
}
