using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StudentsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students.ToList());
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(string id)
        {
            var student = _context.Find<Student>(Guid.Parse(id));
            return Ok(student);
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return CreatedAtRoute("GetById", new { id = student.Id }, student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
