namespace PersonMongoDbMinimalApi.Database;
public class PersonDbSettings : IPersonDbSettings
{
    public string PersonCollectionName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
