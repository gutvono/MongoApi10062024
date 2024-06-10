using MongoApi10062024.Models;
using MongoApi10062024.Utils;
using MongoDB.Driver;

namespace MongoApi10062024.Service
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IProjMongoDBApiConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            var db = client.GetDatabase(config.DatabaseName);
            _customer = db.GetCollection<Customer>(config.CustomerCollection);
        }

        public List<Customer> Get() => _customer.Find(customer => true).ToList();
        public Customer Get(string id) => _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();
        public Customer Post(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }
    }
}
