using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Modelos;
using WebApi.Repository.IRepository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/jabil")]
    public class JabilController : ControllerBase
    {
        private readonly IDBRepository _repo;
        public JabilController(IDBRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return Ok(_repo.GetStudent(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            _repo.AddStudent(student);
            return Created("JabilController/", student.IdStudent);
        }

        [HttpPut]
        public IActionResult Edit(Student student)
        {
            _repo.UpdateStudent(student);
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repo.DeleteStudent(id);
            return NoContent();
        }
    }
}
