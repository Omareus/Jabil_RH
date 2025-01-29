using WebApi.Modelos;

namespace WebApi.Repository.IRepository
{
    public interface IDBRepository
    {
        public Task<Student> GetStudent(int id);
        public Task<bool> AddStudent(Student student);
        public Task<bool> DeleteStudent(int id);
        public Task<Student> UpdateStudent(Student student);
    }
}
