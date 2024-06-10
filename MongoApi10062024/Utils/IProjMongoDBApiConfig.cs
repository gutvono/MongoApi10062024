namespace MongoApi10062024.Utils
{
    public interface IProjMongoDBApiConfig
    {
        string CustomerCollection { get; set; }
        string AddressCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
