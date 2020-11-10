using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using School.Dto;
using School.Services;

namespace Web.Api.Controllers
{

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly ILogger<SchoolController> _logger;

        public SchoolController(ISchoolService schoolService, ILogger<SchoolController> logger)
        {
            _schoolService = schoolService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<SchoolDto[]>> Get()
        {
            var schools = await _schoolService.GetAll();
            return Ok(schools);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SchoolDto>> Get(int id)
        {
            var school = await _schoolService.Get(id);
            return Ok(school);
        }

        [HttpPost]
        public async Task<ActionResult<SchoolDto>> Post([FromBody] SchoolInputDto input)
        {
            var school = await _schoolService.Add(input);
            return CreatedAtAction(nameof(Get), new {id = school.SchoolId}, school);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SchoolDto>> Put(int id, [FromBody] SchoolInputDto update)
        {
            var dto = await _schoolService.Update(id, update);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _schoolService.Delete(id);
            return Ok();
        }
    }
}
}
