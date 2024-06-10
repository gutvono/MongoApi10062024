using Microsoft.AspNetCore.Mvc;
using MongoApi10062024.Models;
using MongoApi10062024.Service;

namespace MongoApi10062024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _service.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _service.Get(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            var result = _service.Post(customer);
            if (result == null) return BadRequest();
            return CreatedAtRoute("GetCustomer", new { id = result.Id }, result);
        }
    }
}
