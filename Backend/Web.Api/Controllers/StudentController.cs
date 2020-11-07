using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Dto;
using School.Entity;
using School.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<Student[]>> Get()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _studentService.Get(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] StudentInputDto input)
        {
            var student = await _studentService.Add(input);
            return CreatedAtAction(nameof(Get), new {id = student.StudentId}, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put(int id, [FromBody] StudentInputDto update)
        {
            var dto = await _studentService.Update(id, update);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _studentService.Delete(id);
            return Ok();
        }
    }
}
