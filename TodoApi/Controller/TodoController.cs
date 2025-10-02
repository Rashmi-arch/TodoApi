using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Repository;

namespace TodoApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoRepository _repo = new();

        [HttpGet]
        public IActionResult GetTodos() => Ok(_repo.GetAll());

        [HttpPost]
        public IActionResult Post([FromBody] string title) => Ok(_repo.Add(title));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => _repo.Delete(id) ? Ok() : NotFound();
    }
}
