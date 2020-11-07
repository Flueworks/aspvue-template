using Microsoft.Extensions.DependencyInjection;
using School.Dto;
using School.Services;

namespace School.Extensions
{
    public static class SchoolServiceCollectionExtensions
    {
        public static IServiceCollection AddSchoolServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<TeacherDtoFactory>();
            services.AddScoped<StudentDtoFactory>();
            return services;
        }
    }
}