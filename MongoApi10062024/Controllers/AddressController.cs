using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApi10062024.Models;
using MongoApi10062024.Service;

namespace MongoApi10062024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<Address>> Get() => _addressService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id) => _addressService.Get(id);

        [HttpGet("{cep:length(8)}")]
        public ActionResult<AddressDTO> GetPostOffice(string cep) => PostOfficeService.GetAddress(cep).Result;

        [HttpPost]
        public ActionResult<Address> Post(Address address)
        {
            _addressService.Post(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id }, address);
        }
    }
}
