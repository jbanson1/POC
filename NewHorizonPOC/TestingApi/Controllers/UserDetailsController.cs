using Microsoft.AspNetCore.Mvc;

namespace TestingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly DocumentCreation documentCreation = new DocumentCreation();

        private readonly EmailMessenger emailMessenger = new EmailMessenger();

        private readonly ILogger<UserDetailsController> _logger;

        public UserDetailsController (ILogger<UserDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetUserDetails")]
        public IEnumerable<UserDetails> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new UserDetails())
            .ToArray();
        }

        [HttpPost(Name = "PostUserDetails")]
        public void PostNewStudent()
        {
            emailMessenger.Send();
        }

        [HttpPut(Name = "PutUserDetails")]
        public IEnumerable<UserDetails> Put()
        {
            return Enumerable.Range(1, 5).Select(index => new UserDetails())
            .ToArray();
        }

        [HttpDelete(Name = "DeleteUserDetails")]
        public IEnumerable<UserDetails> Delete()
        {
            return Enumerable.Range(1, 5).Select(index => new UserDetails())
            .ToArray();
        }
    }
}