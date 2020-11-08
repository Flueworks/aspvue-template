using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using School.Dto;
using School.Entity;

namespace School.Services
{
    public interface IStudentService
    {
        Task<StudentDto> Add(StudentInputDto studentInput);

        Task<StudentDto> Update(int studentId, StudentInputDto studentInput);

        Task<IReadOnlyCollection<StudentDto>> GetAll();

        Task<StudentDto> Get(int studentId);

        Task Delete(int studentId);

    }

    public class StudentService : IStudentService
    {
        private readonly ISchoolDbContext _dbContext;
        private readonly StudentDtoFactory _dtoFactory;

        public StudentService(ISchoolDbContext dbContext, StudentDtoFactory dtoFactory)
        {
            _dbContext = dbContext;
            _dtoFactory = dtoFactory;
        }

        public async Task<StudentDto> Add(StudentInputDto studentInput)
        {
            var student = new Student()
            {
                GivenName = studentInput.GivenName,
                FamilyName = studentInput.FamilyName,
                DateOfBirth = studentInput.DateOfBirth,
                Address = studentInput.Address,
            };

            await _dbContext.Students.AddAsync(student);

            await _dbContext.SaveChangesAsync();

            return _dtoFactory.CreateDto(student);
        }

        public async Task<StudentDto> Update(int studentId, StudentInputDto studentInput)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if(student == null) throw new NotFoundException();

            student.GivenName = studentInput.GivenName;
            student.FamilyName = studentInput.FamilyName;
            student.DateOfBirth = studentInput.DateOfBirth;
            student.Address = studentInput.Address;

            await _dbContext.SaveChangesAsync();

            return _dtoFactory.CreateDto(student);
        }

        public async Task<IReadOnlyCollection<StudentDto>> GetAll()
        {
            var students = await _dbContext.Students.ToListAsync();

            return students.ConvertAll(_dtoFactory.CreateDto);
        }

        public async Task<StudentDto> Get(int studentId)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if(student == null) throw new NotFoundException();
            return _dtoFactory.CreateDto(student);
        }

        public async Task Delete(int studentId)
        {
            var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == studentId);
            if(student == null) throw new NotFoundException();

            _dbContext.Students.Remove(student);

            await _dbContext.SaveChangesAsync();
        }
    }
}