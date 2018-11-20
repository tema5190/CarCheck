using DAL.Registration;
using Microsoft.AspNetCore.Mvc;
using Models.User;

namespace CarNumber.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationService registrationService;
        public RegistrationController(RegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        // GET api/values
        [HttpPost("create")]
        public ActionResult CreateNewUser([FromBody] RegistrationModel registrationModel)
        {
            var result = registrationService.CreateNewUser(registrationModel);
            if (result)
            {
                return Ok("Created");
            }

            return BadRequest("Error");
        }

        [HttpGet("user/{id}")]
        public User GetUserById(int id)
        {
            return registrationService.GetUserById(id);
        }
    }
}