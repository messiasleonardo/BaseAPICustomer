using BaseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly APIConfig _config;

        //Get all customer inside the DataBase
        [HttpGet]
        public List<Customer> Get()
        {
            return new List<Customer>();
        }

        [HttpGet("Id")]
        public Customer Get(int id)
        {
            return new Customer();
        }

        [HttpPost]
        public bool Post(Customer customer)
        {
            return true;
        }

        [HttpDelete("Id")]
        public bool Delete(int id)
        {
            return true;
        }

        [HttpPut]
        public bool Update(Customer customer)
        {
            return true;
        }

        
    }
}
