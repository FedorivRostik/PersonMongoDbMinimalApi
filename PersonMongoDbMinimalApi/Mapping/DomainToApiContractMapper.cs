using PersonMongoDbMinimalApi.Contracts.Responses;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Mapping;
public static class DomainToApiContractMapper
{
    public static PersonResponse ToPersonResponse(this Person person)
    {
        return new PersonResponse
        {
            Id=person.Id,
            FirstName=person.FirstName,
            SecondName=person.SecondName,
            Email=person.Email,
            Telephone=person.Telephone,
            Age=person.Age
        };
    }
    public static GetPeopleResponse ToPeopleResponse(this IEnumerable<Person> people)
    {
        return new GetPeopleResponse
        {
            People = people.Select(p => new PersonResponse
            {
                Id = p.Id,
                Age = p.Age,
                FirstName = p.FirstName,
                SecondName = p.SecondName,
                Email = p.Email,
                Telephone = p.Telephone
            })
        };
    }
}
