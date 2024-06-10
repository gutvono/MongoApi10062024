using MongoApi10062024.Models;
using MongoApi10062024.Utils;
using MongoDB.Driver;

namespace MongoApi10062024.Service
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        
        public AddressService(IProjMongoDBApiConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            var db = client.GetDatabase(config.DatabaseName);
            _address = db.GetCollection<Address>(config.AddressCollection);
        }

        public List<Address> Get() => _address.Find(address => true).ToList();
        public Address Get(string id) => _address.Find<Address>(address => address.Id == id).FirstOrDefault();
        public Address Post(Address address)
        {
            _address.InsertOne(address);
            return address;
        }
    }
}
