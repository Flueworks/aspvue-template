namespace School.Dto
{
    public class SchoolDtoFactory
    {
        public SchoolDto CreateDto(Entity.School school)
        {
            return new SchoolDto()
            {
                Address = school.Address,
                Name = school.Name,
                SchoolId = school.SchoolId,
            };
        }
    }
}