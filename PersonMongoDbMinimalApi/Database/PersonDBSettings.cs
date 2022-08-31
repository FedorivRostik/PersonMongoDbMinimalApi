namespace PersonMongoDbMinimalApi.Database;
public class PersonDBSettings : IPersonDBSettings
{
    public string PersonCollectionName { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
