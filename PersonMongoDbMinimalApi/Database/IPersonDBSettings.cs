namespace PersonMongoDbMinimalApi.Database;
public interface IPersonDbSettings
{
    public string PersonCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
