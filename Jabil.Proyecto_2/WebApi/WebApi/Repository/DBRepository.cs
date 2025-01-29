using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Modelos;
using WebApi.Repository.IRepository;

namespace WebApi.Repository
{
    public class DBRepository : IDBRepository
    {
        private readonly ApplicationDbContext _context;
        public DBRepository(ApplicationDbContext context)
        {
            _context = context;        
        }
        public async Task<bool> AddStudent(Student student)
        {
            _context.Add(student);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return _context.Database.ExecuteSql($"exec sp_delete_student {id}") > 0;
        }

        public async Task<Student> GetStudent(int id)
        {
           return await _context.Students.FirstAsync(s => s.IdStudent == id);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var studentParam = new SqlParameter("student", student);
            _context.Database.ExecuteSqlRaw("exec sp_update_student @student", studentParam);
            return await _context.Students.FirstOrDefaultAsync(s => s.IdStudent == student.IdStudent);
        }
    }
}
