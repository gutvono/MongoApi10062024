namespace MongoApi10062024.Utils
{
    public class ProjMongoDBApiConfig : IProjMongoDBApiConfig
    {
        public string CustomerCollection { get; set; }
        public string AddressCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
