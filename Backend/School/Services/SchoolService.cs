using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;
using School.Dto;
using School.Entity;

namespace School.Services
{
    public interface ISchoolService
    {
        Task<IReadOnlyCollection<SchoolDto>> GetAll();
        Task<SchoolDto> Get(int id);
        Task<SchoolDto> Add(SchoolInputDto input);
        Task<SchoolDto> Update(int id, SchoolInputDto update);
        Task Delete(int id);
    }

    public class SchoolService : ISchoolService
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly SchoolDtoFactory _dtoFactory;

        public SchoolService(ISchoolDbContext dbContext, SchoolDtoFactory dtoFactory)
        {
            _dbContext = dbContext;
            _dtoFactory = dtoFactory;
        }

        public async Task<IReadOnlyCollection<SchoolDto>> GetAll()
        {
            var schools = await _dbContext.Schools.ToListAsync();
            return schools.ConvertAll(_dtoFactory.CreateDto);
        }

        public async Task<SchoolDto> Get(int id)
        {
            var school = await _dbContext.Schools.FirstOrDefaultAsync(x => x.SchoolId == id);
            if(school == null) throw new NotFoundException();
            return _dtoFactory.CreateDto(school);
        }

        public async Task<SchoolDto> Add(SchoolInputDto input)
        {
            var school = new Entity.School()
            {
                Name = input.Name,
                Address = input.Address,
            };
            await _dbContext.Schools.AddAsync(school);

            await _dbContext.SaveChangesAsync();
            return _dtoFactory.CreateDto(school);
        }

        public async Task<SchoolDto> Update(int id, SchoolInputDto update)
        {
            var school = await _dbContext.Schools.FirstOrDefaultAsync(x => x.SchoolId == id);
            if(school == null) throw new NotFoundException();

            school.Name = update.Name;
            school.Address = update.Address;

            await _dbContext.SaveChangesAsync();

            return _dtoFactory.CreateDto(school);
        }

        public async Task Delete(int id)
        {
            var school = await _dbContext.Schools.FirstOrDefaultAsync(x => x.SchoolId == id);
            if(school == null) throw new NotFoundException();

            _dbContext.Schools.Remove(school);

            await _dbContext.SaveChangesAsync();
        }
    }

    
}
