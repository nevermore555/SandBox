using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SandBox.Entities;
using SandBox.Repositories;

namespace SandBox.Controllers
{
    public class StudentsController : Controller
    {
        static StudentRepository studentRepository = new StudentRepository();

        [HttpGet]
        public List<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public IActionResult Get(int id)
        {
            Student item = studentRepository.Get(id);
            if (item == null)
            {
                return NoContent();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student item)
        { 
            if (item == null)
            {
                return BadRequest();
            }

            studentRepository.Add(item);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Student item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            studentRepository.Update(item);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Student item = studentRepository.Get(id);
            if (item == null)
            {
                return NoContent();
            }

            studentRepository.Remove(id);
            return Ok();
        }
    }
}
