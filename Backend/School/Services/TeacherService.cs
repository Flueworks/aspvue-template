using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.EntityFrameworkCore;
using School.Dto;
using School.Entity;

namespace School.Services
{
    public interface ITeacherService
    {
        Task<TeacherDto> Add(TeacherInputDto teacherInput);

        Task<TeacherDto> Update(int teacherId, TeacherInputDto teacherInput);

        Task<IReadOnlyCollection<TeacherDto>> GetAll();

        Task<TeacherDto> Get(int teacherId);

        Task Delete(int teacherId);
    }

    public class TeacherService : ITeacherService
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly TeacherDtoFactory _dtoFactory;

        public TeacherService(ISchoolDbContext dbContext, TeacherDtoFactory dtoFactory)
        {
            _dbContext = dbContext;
            _dtoFactory = dtoFactory;
        }

        public async Task<TeacherDto> Add(TeacherInputDto teacherInput)
        {
            var teacher = new Teacher()
            {
                FamilyName = teacherInput.FamilyName,
                GivenName = teacherInput.GivenName,
                DateOfBirth = teacherInput.DateOfBirth,
                Address = teacherInput.Address,
            };

            _dbContext.Teachers.Add(teacher);

            await _dbContext.SaveChangesAsync();

            return _dtoFactory.CreateDto(teacher);
        }

        public async Task<TeacherDto> Update(int teacherId, TeacherInputDto teacherInput)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(x => x.TeacherId == teacherId);
            if (teacher == null) throw new NotFoundException();

            teacher.DateOfBirth = teacherInput.DateOfBirth;
            teacher.FamilyName = teacher.FamilyName;
            teacher.GivenName = teacher.GivenName;
            teacher.Address = teacherInput.Address;

            // save changes
            await _dbContext.SaveChangesAsync();

            return _dtoFactory.CreateDto(teacher);
        }

        public async Task<IReadOnlyCollection<TeacherDto>> GetAll()
        {
            var teachers = await _dbContext.Teachers.ToListAsync();
            return teachers.ConvertAll(t => _dtoFactory.CreateDto(t));
        }

        public async Task<TeacherDto> Get(int teacherId)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);
            if (teacher == null) throw new NotFoundException();

            return _dtoFactory.CreateDto(teacher);
        }

        public async Task Delete(int teacherId)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(t => t.TeacherId == teacherId);
            if (teacher == null) throw new NotFoundException();

            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}