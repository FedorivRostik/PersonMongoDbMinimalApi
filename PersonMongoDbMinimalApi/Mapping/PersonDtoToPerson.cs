
using PersonMongoDbMinimalApi.Contracts.DTO;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Mapping;
public static class PersonDtoToPerson
{
    public static Person ToPerson(this PersonDto dto)
    {
        return new Person 
        {
            Id = dto.Id,
            Age = dto.Age,
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            Email = dto.Email,
            Telephone = dto.Telephone
        };
    }
    public static IEnumerable<Person> ToPeople(this List<PersonDto> dtos)
    {
        var people= dtos.Select(p => new Person
        {
            Id = p.Id,
            Age = p.Age,
            FirstName = p.FirstName,
            SecondName = p.SecondName,
            Email = p.Email,
            Telephone = p.Telephone
        });
        return people;
    }
}
