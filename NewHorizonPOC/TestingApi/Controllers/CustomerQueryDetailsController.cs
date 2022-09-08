using Microsoft.AspNetCore.Mvc;

namespace TestingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerQueryDetailsController : ControllerBase
    {
        private readonly DocumentCreation documentCreation = new DocumentCreation();

        private readonly CustomerQueryDetails CQD = new CustomerQueryDetails();

        private readonly ILogger<CustomerQueryDetailsController> _logger;

        public CustomerQueryDetailsController(ILogger<CustomerQueryDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomerQueryDetails")]
        public IEnumerable<CustomerQueryDetails> Get(CustomerQueryDetails)
        {
            return Enumerable.Range(1, 5).Select(index => new CustomerQueryDetails())
            .ToArray();
        }

        [HttpPost(Name = "PostCustomerQueryDetails")]
        public void PostNewStudent()
        {
            
        }

        [HttpPut(Name = "PutCustomerQueryDetails")]
        public IEnumerable<CustomerQueryDetails> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new CustomerQueryDetails())
            .ToArray();
        }

        [HttpDelete(Name = "DeleteCustomerQueryDetails")]
        public IEnumerable<CustomerQueryDetails> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new CustomerQueryDetails())
            .ToArray();
        }
    }
}