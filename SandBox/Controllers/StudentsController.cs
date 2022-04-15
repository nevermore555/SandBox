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
        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public IActionResult Get(int id)
        {
            Student item;
            try
            {
                item = studentRepository.Get(id);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student item)
        { 
            if (!studentRepository.Add(item))
            {
                return BadRequest("Name is null");
            }

            return Ok("Added");
        }

        [HttpPut]
        public IActionResult Update([FromBody] Student item)
        {
            if (!studentRepository.Update(item))
            {
                return BadRequest("Invalid ID or Name");
            }

            return Ok("Updated");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (!studentRepository.Remove(id))
            {
                return Ok("Invalid ID");
            }

            return Ok("Deleted");
        }
    }
}
