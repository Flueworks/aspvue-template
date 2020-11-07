using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Dto;
using School.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService service, ILogger<TeacherController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> Get()
        {
            var teachers = await _service.GetAll();

            return Ok(teachers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeacherDto>> Get(int id)
        {
            var teacher = await _service.Get(id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeacherDto>> Add(TeacherInputDto input)
        {
            var dto = await _service.Add(input);
            return CreatedAtAction(nameof(Get), new { id = dto.TeacherId }, dto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeacherDto>> Update(int id, [FromBody] TeacherInputDto update)
        {
            var dto = await _service.Update(id, update);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
