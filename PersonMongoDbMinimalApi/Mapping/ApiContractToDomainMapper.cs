using PersonMongoDbMinimalApi.Contracts.Requests;
using PersonMongoDbMinimalApi.Domain;

namespace PersonMongoDbMinimalApi.Mapping;
public static class ApiContractToDomainMapper
{
    public static Person ToPerson(this UpdatePersonRequest updatePersonRequest)
    {
        return new Person
        {
            Id = updatePersonRequest.Id,
            FirstName = updatePersonRequest.FirstName,
            SecondName = updatePersonRequest.SecondName,
            Age = updatePersonRequest.Age,
            Email = updatePersonRequest.Email,
            Telephone = updatePersonRequest.Telephone,
        };
    }

    public static Person ToPerson(this CreatePersonRequest updatePersonRequest)
    {

        return new Person
        {
            FirstName = updatePersonRequest.FirstName,
            SecondName = updatePersonRequest.SecondName,
            Age = updatePersonRequest.Age,
            Email = updatePersonRequest.Email,
            Telephone = updatePersonRequest.Telephone,
        };
    }
}
