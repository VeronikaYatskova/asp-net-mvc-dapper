using Dapper;
using DapperMvc.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperMvc.Data
{
    public class StudentRepository : IStudentRepository
    {
        string connectionString = null;
        public StudentRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Student> GetStudents()
        {
            using IDbConnection db = new SqlConnection(connectionString);

            return db.Query<Student>("SELECT * FROM Student").ToList();
        }

        public Student? Get(Guid id)
        {
            using IDbConnection db = new SqlConnection(connectionString);

            return db.Query<Student>("SELECT * FROM Student WHERE Id=@id", new { id }).FirstOrDefault();
        }

        public void Create(Student student)
        {
            using IDbConnection db = new SqlConnection(connectionString);

            var sqlQuery = $"INSERT INTO Student (Id, Name, Age) VALUES (@Id, @Name, @Age)";

            db.Query<Student>(sqlQuery, student);
        }

        public void Update(Student student)
        {
            using IDbConnection db = new SqlConnection(connectionString);

            var sqlQuery = "UPDATE Student SET Name=@Name, Age=@Age WHERE Id=@Id";

            db.Execute(sqlQuery, student);
        }

        public void Delete(Guid id)
        {
            using IDbConnection db = new SqlConnection(connectionString);

            var sqlQuery = "DELETE FROM Student WHERE Id=@id";

            db.Execute(sqlQuery, new { id });
        }

    }
}
